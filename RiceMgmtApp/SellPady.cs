using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace RiceMgmtApp
{
    public partial class SellPady : UserControl
    {
        private readonly string connectionString = "Server=DESKTOP-O6K3I3U\\SQLEXPRESS;Database=RiceProductionDB2;Integrated Security=True;";
        private readonly int currentFarmerId;
        private int selectedSaleId = -1;

        public SellPady(int farmerID)
        {
            InitializeComponent();
            this.currentFarmerId = farmerID;
            this.Load += SellPady_Load;
        }

        #region Event Handlers

        private void CmbBuyerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string selectedBuyerType = cmbBuyerType.SelectedItem?.ToString();
                if (string.IsNullOrEmpty(selectedBuyerType)) return;

                LoadBuyerComboFiltered(selectedBuyerType);

               
                if (lblSelectedStock.Tag is Tuple<int, string> stockInfo)
                {
                    string cropType = stockInfo.Item2;
                    FetchPriceForCropType(cropType, selectedBuyerType);
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error changing buyer type: {ex.Message}");
            }
        }

        private void btnViewStock_Click(object sender, EventArgs e)
        {
            ShowFarmerStock();
        }


   

        private void dataGridViewSales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.RowIndex < dataGridViewSales.Rows.Count)
                {
                    var saleIdCell = dataGridViewSales.Rows[e.RowIndex].Cells["SaleID"];
                    if (saleIdCell?.Value != null && int.TryParse(saleIdCell.Value.ToString(), out int saleId))
                    {
                        selectedSaleId = saleId;
                    }
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error selecting row: {ex.Message}");
            }
        }

       

        private void SellPady_Resize(object sender, EventArgs e)
        {
            float scaleFactor = Math.Min(this.Width / 900f, this.Height / 650f);
            scaleFactor = Math.Max(0.8f, Math.Min(1.5f, scaleFactor));
            AdjustControlFonts(this.Controls, scaleFactor);
            this.PerformLayout();
        }

        private void CalculateTotalAmount(object sender, EventArgs e)
        {
            try
            {
                if (decimal.TryParse(txtQuantity.Text, out decimal quantity) &&
                    decimal.TryParse(txtSalePrice.Text, out decimal price))
                {
                    decimal total = quantity * price;
                    txtTotalAmount.Text = total.ToString("N2");
                }
                else
                {
                    txtTotalAmount.Text = "0.00";
                }
            }
            catch
            {
                txtTotalAmount.Text = "0.00";
            }
        }

        #endregion

        #region Initialization Methods

        private void InitializeComponents()
        {
            StyleSalesGrid();
            SetupComboBoxes();
            AttachEventHandlers();
        }

        private void SetupComboBoxes()
        {
           
            cmbBuyerType.Items.Clear();
            cmbBuyerType.Items.AddRange(new[] { "Government", "Private" });

            cmbPaymentStatus.Items.Clear();
            cmbPaymentStatus.Items.AddRange(new[] { "Pending", "Completed" });
        }

        private void AttachEventHandlers()
        {
            cmbBuyerType.SelectedIndexChanged += CmbBuyerType_SelectedIndexChanged;
            btnViewStock.Click += btnViewStock_Click;
            btnGenerateInvoice.Click += btnGenerateInvoice_Click;
            btnSaveInvoice.Click += btnSaveInvoice_Click;
            btnPrintInvoice.Click += btnPrintInvoice_Click;
            txtQuantity.TextChanged += CalculateTotalAmount;
            txtSalePrice.TextChanged += CalculateTotalAmount;
            dataGridViewSales.CellClick += dataGridViewSales_CellClick;
        }

        private void LoadInitialData()
        {
            LoadBuyerCombo();
            LoadFarmerSalesData();
        }

        #endregion

        #region Data Loading Methods

        private void LoadBuyerComboFiltered(string buyerType)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    int roleId = buyerType == "Government" ? 3 : 4;
                    string query = "SELECT UserID, FullName FROM Users WHERE RoleID = @RoleID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@RoleID", roleId);
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        object currentValue = cmbBuyer.SelectedValue;

                        cmbBuyer.DataSource = dt;
                        cmbBuyer.DisplayMember = "FullName";
                        cmbBuyer.ValueMember = "UserID";

                        
                        if (currentValue != null && dt.Rows.Count > 0)
                        {
                            foreach (DataRow row in dt.Rows)
                            {
                                if (row["UserID"].ToString() == currentValue.ToString())
                                {
                                    cmbBuyer.SelectedValue = currentValue;
                                    return;
                                }
                            }
                        }

                        if (dt.Rows.Count > 0)
                        {
                            cmbBuyer.SelectedIndex = 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error loading buyers: {ex.Message}");
            }
        }

        private void LoadBuyerCombo()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT UserID, FullName FROM Users WHERE RoleID IN (3, 4)";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    cmbBuyer.DataSource = dt;
                    cmbBuyer.DisplayMember = "FullName";
                    cmbBuyer.ValueMember = "UserID";
                    cmbBuyer.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error loading buyer list: {ex.Message}");
            }
        }

        private void LoadFarmerSalesData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"
                        SELECT s.SaleID, s.BuyerID, b.FullName AS BuyerName, s.BuyerType, 
                               s.CropType, s.SalePrice, s.Quantity, 
                               (s.SalePrice * s.Quantity) AS TotalAmount, 
                               s.PaymentStatus, s.SaleDate, s.StockID
                        FROM Sales s
                        LEFT JOIN Users b ON s.BuyerID = b.UserID
                        WHERE s.FarmerID = @FarmerID
                        ORDER BY s.SaleDate DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FarmerID", currentFarmerId);
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dataGridViewSales.DataSource = dt;
                        ConfigureDataGridColumns();
                    }
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error loading sales data: {ex.Message}");
            }
        }

        #endregion

        #region Stock Management

        private void ShowFarmerStock()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT StockID, CropType, Quantity, LastUpdated FROM Stock WHERE FarmerID = @FarmerID AND Quantity > 0";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FarmerID", currentFarmerId);
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            ShowStockSelectionDialog(dt);
                        }
                        else
                        {
                            ShowWarningMessage("You don't have any available stock to sell.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error loading stock data: {ex.Message}");
            }
        }

        private void ShowStockSelectionDialog(DataTable stockData)
        {
            using (Form stockForm = new Form())
            {
                stockForm.Text = "My Available Stock";
                stockForm.Size = new Size(600, 400);
                stockForm.StartPosition = FormStartPosition.CenterParent;
                stockForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                stockForm.MaximizeBox = false;
                stockForm.MinimizeBox = false;

                DataGridView dgvStock = new DataGridView
                {
                    Dock = DockStyle.Fill,
                    DataSource = stockData,
                    AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                    SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                    ReadOnly = true,
                    AllowUserToAddRows = false,
                    MultiSelect = false
                };

                Button btnSelect = new Button
                {
                    Text = "Select Stock",
                    Dock = DockStyle.Bottom,
                    Height = 40
                };

                btnSelect.Click += (s, ev) =>
                {
                    if (dgvStock.SelectedRows.Count > 0)
                    {
                        DataGridViewRow row = dgvStock.SelectedRows[0];
                        HandleStockSelection(row);
                        stockForm.Close();
                    }
                    else
                    {
                        ShowWarningMessage("Please select a stock item.");
                    }
                };

                stockForm.Controls.Add(dgvStock);
                stockForm.Controls.Add(btnSelect);
                stockForm.ShowDialog();
            }
        }

        private void HandleStockSelection(DataGridViewRow row)
        {
            decimal availableQuantity = Convert.ToDecimal(row.Cells["Quantity"].Value);
            string cropType = row.Cells["CropType"].Value.ToString();
            int stockId = Convert.ToInt32(row.Cells["StockID"].Value);

            txtQuantity.Text = availableQuantity.ToString();
            lblSelectedStock.Text = $"Selected: {cropType} - {availableQuantity} kg";
            lblSelectedStock.Visible = true;
            lblSelectedStock.Tag = new Tuple<int, string>(stockId, cropType);

            // Update price if buyer type is selected
            if (cmbBuyerType.SelectedItem != null)
            {
                FetchPriceForCropType(cropType, cmbBuyerType.SelectedItem.ToString());
            }
        }

        #endregion

        #region Price Management

        private void FetchPriceForCropType(string cropType, string buyerType)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string priceColumn = buyerType == "Government" ? "GovernmentPrice" : "AvgPrice";
                    string query = $"SELECT TOP 1 {priceColumn} FROM PriceMonitoring WHERE CropType = @CropType ORDER BY CreatedAt DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CropType", cropType);
                        object result = cmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            decimal price = Convert.ToDecimal(result);
                            txtSalePrice.Text = price.ToString();
                            txtSalePrice.ReadOnly = buyerType == "Government";
                        }
                        else
                        {
                            string message = buyerType == "Government"
                                ? $"No government price found for {cropType}. Please contact the administrator."
                                : $"No price data found for {cropType}.";
                            ShowWarningMessage(message);
                            txtSalePrice.ReadOnly = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error fetching price information: {ex.Message}");
            }
        }

        #endregion

        #region Sale Processing

        private void ProcessSale()
        {
            if (!ValidateInputs()) return;

            if (!(lblSelectedStock.Tag is Tuple<int, string> stockInfo))
            {
                ShowWarningMessage("Please select stock before processing the sale.");
                return;
            }

            int stockId = stockInfo.Item1;
            string cropType = stockInfo.Item2;
            decimal saleQuantity = decimal.Parse(txtQuantity.Text);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlTransaction transaction = null;
                try
                {
                    conn.Open();
                    transaction = conn.BeginTransaction();

                    if (!ValidateStockAvailability(conn, transaction, stockId, saleQuantity))
                    {
                        transaction.Rollback();
                        return;
                    }

                    int newSaleId = InsertSaleRecord(conn, transaction, stockId, cropType, saleQuantity);
                    UpdateStockQuantity(conn, transaction, stockId, saleQuantity);
                  

                    transaction.Commit();

                    ShowSuccessMessage("Sale processed successfully!");
                    PostSaleProcessing(newSaleId);
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();
                    ShowErrorMessage($"Error processing sale: {ex.Message}");
                }
            }
        }

        private bool ValidateStockAvailability(SqlConnection conn, SqlTransaction transaction, int stockId, decimal requiredQuantity)
        {
            string checkStockQuery = "SELECT Quantity FROM Stock WHERE StockID = @StockID";
            using (SqlCommand checkCmd = new SqlCommand(checkStockQuery, conn, transaction))
            {
                checkCmd.Parameters.AddWithValue("@StockID", stockId);
                object result = checkCmd.ExecuteScalar();

                if (result == null || result == DBNull.Value)
                {
                    ShowErrorMessage("Stock not found.");
                    return false;
                }

                decimal availableQuantity = Convert.ToDecimal(result);
                if (availableQuantity < requiredQuantity)
                {
                    ShowErrorMessage($"Insufficient stock. Available: {availableQuantity} kg");
                    return false;
                }
            }
            return true;
        }

        private int InsertSaleRecord(SqlConnection conn, SqlTransaction transaction, int stockId, string cropType, decimal saleQuantity)
        {
            string insertSaleQuery = @"
                INSERT INTO Sales (FarmerID, BuyerID, BuyerType, SalePrice, Quantity, 
                          PaymentStatus, SaleDate, CropType, StockID)
                VALUES (@FarmerID, @BuyerID, @BuyerType, @SalePrice, @Quantity, @PaymentStatus, 
                        @SaleDate, @CropType, @StockID);
                SELECT SCOPE_IDENTITY();";

            using (SqlCommand insertCmd = new SqlCommand(insertSaleQuery, conn, transaction))
            {
                insertCmd.Parameters.AddWithValue("@FarmerID", currentFarmerId);
                insertCmd.Parameters.AddWithValue("@BuyerID", cmbBuyer.SelectedValue ?? DBNull.Value);
                insertCmd.Parameters.AddWithValue("@BuyerType", cmbBuyerType.Text);
                insertCmd.Parameters.AddWithValue("@SalePrice", decimal.Parse(txtSalePrice.Text));
                insertCmd.Parameters.AddWithValue("@Quantity", saleQuantity);
                insertCmd.Parameters.AddWithValue("@PaymentStatus", cmbPaymentStatus.Text);
                insertCmd.Parameters.AddWithValue("@SaleDate", DateTime.Now);
                insertCmd.Parameters.AddWithValue("@CropType", cropType);
                insertCmd.Parameters.AddWithValue("@StockID", stockId);

                object result = insertCmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    return Convert.ToInt32(result);
                }
                else
                {
                    throw new Exception("Failed to get new sale ID");
                }
            }
        }

        private void UpdateStockQuantity(SqlConnection conn, SqlTransaction transaction, int stockId, decimal saleQuantity)
        {
            string updateStockQuery = "UPDATE Stock SET Quantity = Quantity - @SaleQuantity, LastUpdated = GETDATE() WHERE StockID = @StockID";
            using (SqlCommand updateCmd = new SqlCommand(updateStockQuery, conn, transaction))
            {
                updateCmd.Parameters.AddWithValue("@SaleQuantity", saleQuantity);
                updateCmd.Parameters.AddWithValue("@StockID", stockId);
                int rowsAffected = updateCmd.ExecuteNonQuery();
                if (rowsAffected == 0)
                {
                    throw new Exception("Stock update failed");
                }
            }
        }

      

        private void PostSaleProcessing(int newSaleId)
        {
            selectedSaleId = newSaleId;
            pnlInvoice.Visible = true;
            GenerateInvoicePreview(newSaleId);
            LoadFarmerSalesData();
            ClearInputs();
        }

        #endregion

        #region Validation

        private bool ValidateInputs()
        {
            if (cmbBuyer.SelectedIndex == -1)
            {
                ShowWarningMessage("Please select a buyer.");
                return false;
            }

            if (cmbBuyerType.SelectedIndex == -1)
            {
                ShowWarningMessage("Please select a buyer type.");
                return false;
            }

            if (cmbPaymentStatus.SelectedIndex == -1)
            {
                ShowWarningMessage("Please select payment status.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSalePrice.Text))
            {
                ShowWarningMessage("Please enter sale price.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtQuantity.Text))
            {
                ShowWarningMessage("Please enter quantity.");
                return false;
            }

            if (!decimal.TryParse(txtSalePrice.Text, out decimal price) || price <= 0)
            {
                ShowWarningMessage("Sale Price must be a valid positive number.");
                return false;
            }

            if (!decimal.TryParse(txtQuantity.Text, out decimal quantity) || quantity <= 0)
            {
                ShowWarningMessage("Quantity must be a valid positive number.");
                return false;
            }

            return true;
        }

        #endregion

        #region Invoice Management

        private void GenerateInvoicePreview(int saleId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"
                        SELECT s.SaleID, s.SaleDate, s.SalePrice, s.Quantity, s.PaymentStatus, s.BuyerType, s.CropType,
                               f.FullName AS FarmerName, f.Email AS FarmerEmail, f.ContactNumber AS FarmerContactNumber, 
                               b.FullName AS BuyerName, b.Email AS BuyerEmail, b.ContactNumber AS BuyerContactNumber
                        FROM Sales s
                        INNER JOIN Users f ON s.FarmerID = f.UserID
                        LEFT JOIN Users b ON s.BuyerID = b.UserID
                        WHERE s.SaleID = @SaleID AND s.FarmerID = @FarmerID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@SaleID", saleId);
                        cmd.Parameters.AddWithValue("@FarmerID", currentFarmerId);
                        conn.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                rtbInvoicePreview.Text = BuildInvoiceText(reader);
                            }
                            else
                            {
                                ShowErrorMessage("Invoice data not found or you don't have permission to view this sale.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error generating invoice: {ex.Message}");
            }
        }

        private string BuildInvoiceText(SqlDataReader reader)
        {
            StringBuilder sb = new StringBuilder();
            decimal salePrice = Convert.ToDecimal(reader["SalePrice"]);
            decimal quantity = Convert.ToDecimal(reader["Quantity"]);
            decimal totalAmount = salePrice * quantity;

            // Format using Sri Lankan culture
            var lkrCulture = new System.Globalization.CultureInfo("en-LK");

            sb.AppendLine("RICE PRODUCTION SYSTEM");
            sb.AppendLine("SALES INVOICE");
            sb.AppendLine("=============================================");
            sb.AppendLine($"Invoice #: INV-{reader["SaleID"]:D5}");
            sb.AppendLine($"Date: {Convert.ToDateTime(reader["SaleDate"]):yyyy-MM-dd HH:mm}");
            sb.AppendLine("=============================================");

            sb.AppendLine("\nSELLER INFORMATION:");
            sb.AppendLine($"Name: {reader["FarmerName"]}");
            if (reader["FarmerContactNumber"] != DBNull.Value)
                sb.AppendLine($"Contact: {reader["FarmerContactNumber"]}");
            if (reader["FarmerEmail"] != DBNull.Value)
                sb.AppendLine($"Email: {reader["FarmerEmail"]}");

            sb.AppendLine("\nBUYER INFORMATION:");
            sb.AppendLine($"Type: {reader["BuyerType"]}");
            sb.AppendLine($"Name: {reader["BuyerName"]}");
            if (reader["BuyerContactNumber"] != DBNull.Value)
                sb.AppendLine($"Contact: {reader["BuyerContactNumber"]}");
            if (reader["BuyerEmail"] != DBNull.Value)
                sb.AppendLine($"Email: {reader["BuyerEmail"]}");

            sb.AppendLine("\n=============================================");
            sb.AppendLine("TRANSACTION DETAILS:");
            sb.AppendLine("=============================================");

            string cropType = reader["CropType"] != DBNull.Value ? reader["CropType"].ToString() : "Rice";
            sb.AppendLine($"Product: {cropType}");
            sb.AppendLine($"Price per kg: {salePrice.ToString("C", lkrCulture)}");
            sb.AppendLine($"Quantity: {quantity:N2} kg");
            sb.AppendLine($"Total Amount: {totalAmount.ToString("C", lkrCulture)}");
            sb.AppendLine($"Payment Status: {reader["PaymentStatus"]}");
            sb.AppendLine("=============================================");
            sb.AppendLine("\nThank you for your business!");
            sb.AppendLine("This is a computer-generated invoice and doesn't require a signature.");

            return sb.ToString();
        }

        private void SaveInvoice()
        {
            if (selectedSaleId == -1 || string.IsNullOrWhiteSpace(rtbInvoicePreview.Text))
            {
                ShowWarningMessage("Please generate an invoice first.");
                return;
            }

            using (SaveFileDialog saveDialog = new SaveFileDialog
            {
                Filter = "PDF Files (*.pdf)|*.pdf|Text Files (*.txt)|*.txt|All Files (*.*)|*.*",
                DefaultExt = "pdf",
                FileName = $"Invoice_{selectedSaleId}_{DateTime.Now:yyyyMMdd}"
            })
            {
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string fileExtension = Path.GetExtension(saveDialog.FileName)?.ToLower();

                        if (fileExtension == ".pdf")
                        {
                            SaveAsPDF(saveDialog.FileName);
                        }
                        else
                        {
                            File.WriteAllText(saveDialog.FileName, rtbInvoicePreview.Text);
                        }

                        ShowSuccessMessage("Invoice saved successfully!");
                    }
                    catch (UnauthorizedAccessException)
                    {
                        ShowErrorMessage("Access denied. Please check file permissions or choose a different location.");
                    }
                    catch (DirectoryNotFoundException)
                    {
                        ShowErrorMessage("Directory not found. Please choose a valid location.");
                    }
                    catch (IOException ioEx)
                    {
                        ShowErrorMessage($"File I/O error: {ioEx.Message}");
                    }
                    catch (Exception ex)
                    {
                        ShowErrorMessage($"An unexpected error occurred: {ex.Message}");
                    }
                }
            }
        }

        private void SaveAsPDF(string filePath)
        {
            try
            {
                using (FileStream stream = new FileStream(filePath, FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A4, 25, 25, 30, 30);
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();

                    // Create a font for better formatting
                    BaseFont baseFont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, 10);

                    // Split the text into lines and add each as a paragraph
                    string[] lines = rtbInvoicePreview.Text.Split(new[] { '\r', '\n' }, StringSplitOptions.None);
                    foreach (string line in lines)
                    {
                        pdfDoc.Add(new Paragraph(line, font));
                    }

                    pdfDoc.Close();
                    writer.Close();
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error saving PDF: {ex.Message}");
            }
        }

        private void PrintInvoice()
        {
            if (selectedSaleId == -1 || string.IsNullOrEmpty(rtbInvoicePreview.Text))
            {
                ShowWarningMessage("Please generate an invoice first.");
                return;
            }

            using (PrintDialog printDialog = new PrintDialog())
            {
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    
                    ShowInfoMessage("Printing functionality would be implemented here with PrintDocument class.");
                }
            }
        }

        #endregion

        #region UI Styling and Configuration

        private void StyleSalesGrid()

        {

            try

            {

                dataGridViewSales.EnableHeadersVisualStyles = false;

                dataGridViewSales.ColumnHeadersDefaultCellStyle.BackColor = Color.ForestGreen;

                dataGridViewSales.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

                dataGridViewSales.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 8, FontStyle.Bold);

                dataGridViewSales.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dataGridViewSales.DefaultCellStyle.BackColor = Color.White;

                dataGridViewSales.DefaultCellStyle.ForeColor = Color.Black;

                dataGridViewSales.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 8);

                dataGridViewSales.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dataGridViewSales.DefaultCellStyle.SelectionBackColor = Color.LightGreen;

                dataGridViewSales.DefaultCellStyle.SelectionForeColor = Color.Black;

                dataGridViewSales.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;

                dataGridViewSales.RowTemplate.Height = 28;

                dataGridViewSales.GridColor = Color.LightGray;

                dataGridViewSales.BorderStyle = BorderStyle.Fixed3D;

                dataGridViewSales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                dataGridViewSales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                dataGridViewSales.MultiSelect = false;

                dataGridViewSales.AllowUserToAddRows = false;

                dataGridViewSales.ReadOnly = true;

                dataGridViewSales.CellClick += dataGridViewSales_CellClick;

            }

            catch (Exception ex)

            {

                MessageBox.Show($"Error styling sales grid: {ex.Message}");

            }

        }
        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void ClearInputs()
        {
            // Clear all input fields
            txtQuantity.Text = string.Empty;
            txtSalePrice.Text = string.Empty;
            txtTotalAmount.Text = "0.00";
            cmbBuyer.SelectedIndex = -1;
            cmbBuyerType.SelectedIndex = -1;
            cmbPaymentStatus.SelectedIndex = -1;
            lblSelectedStock.Text = string.Empty;
            lblSelectedStock.Visible = false;
            lblSelectedStock.Tag = null;
        }
        private void ShowWarningMessage(string message)
        {
            MessageBox.Show(message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void AdjustControlFonts(Control.ControlCollection controls, float scaleFactor)
        {
            foreach (Control control in controls)
            {
                control.Font = new System.Drawing.Font(control.Font.FontFamily, control.Font.Size * scaleFactor, control.Font.Style);
                if (control.HasChildren)
                {
                    AdjustControlFonts(control.Controls, scaleFactor);
                }
            }
        }
        private void ConfigureDataGridColumns()
        {
            try
            {
               
                
                if (dataGridViewSales.Columns.Contains("BuyerName"))
                    dataGridViewSales.Columns["BuyerName"].HeaderText = "Buyer";
                if (dataGridViewSales.Columns.Contains("BuyerType"))
                    dataGridViewSales.Columns["BuyerType"].HeaderText = "Buyer Type";
                if (dataGridViewSales.Columns.Contains("CropType"))
                    dataGridViewSales.Columns["CropType"].HeaderText = "Rice Type";
                if (dataGridViewSales.Columns.Contains("SalePrice"))
                    dataGridViewSales.Columns["SalePrice"].HeaderText = "Price/kg";
                if (dataGridViewSales.Columns.Contains("Quantity"))
                    dataGridViewSales.Columns["Quantity"].HeaderText = "Quantity (kg)";
                if (dataGridViewSales.Columns.Contains("TotalAmount"))
                    dataGridViewSales.Columns["TotalAmount"].HeaderText = "Total Amount";
                if (dataGridViewSales.Columns.Contains("PaymentStatus"))
                    dataGridViewSales.Columns["PaymentStatus"].HeaderText = "Payment Status";
                if (dataGridViewSales.Columns.Contains("SaleDate"))
                    dataGridViewSales.Columns["SaleDate"].HeaderText = "Sale Date";

                if (dataGridViewSales.Columns.Contains("BuyerID"))
                    dataGridViewSales.Columns["BuyerID"].Visible = false;
                if (dataGridViewSales.Columns.Contains("StockID"))
                    dataGridViewSales.Columns["StockID"].Visible = false;
                if (dataGridViewSales.Columns.Contains("SaleID"))
                    dataGridViewSales.Columns["SaleID"].Visible = false;



            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error configuring data grid columns: {ex.Message}");
            }
        }
        private void ShowSuccessMessage(string message)
        {
            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void ShowInfoMessage(string message)
        {
            MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SellPady_Load(object sender, EventArgs e)
        {
            try
            {
                InitializeComponents();
                LoadInitialData();
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error during form initialization: {ex.Message}");
            }
        }

        private void btnCreateSale_Click(object sender, EventArgs e)
        {
            ProcessSale();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadFarmerSalesData();
        }

        private void btnGenerateInvoice_Click(object sender, EventArgs e)
        {
            if (dataGridViewSales.SelectedRows.Count > 0)
            {
                int saleId = Convert.ToInt32(dataGridViewSales.SelectedRows[0].Cells["SaleID"].Value);
                selectedSaleId = saleId;
                GenerateInvoicePreview(saleId);
                pnlInvoice.Visible = true;
            }
            else
            {
                ShowWarningMessage("Please select a sale to generate an invoice.");
            }
        }

        private void btnSaveInvoice_Click(object sender, EventArgs e)
        {
            SaveInvoice();
        }

        private void btnPrintInvoice_Click(object sender, EventArgs e)
        {
            PrintInvoice();
        }
    }
    #endregion
}
   