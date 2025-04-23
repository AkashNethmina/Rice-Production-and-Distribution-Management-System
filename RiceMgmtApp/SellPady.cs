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

        private void SellPady_Load(object sender, EventArgs e)
        {
            // Initialize UI elements
            LoadFarmerSalesData();
            LoadBuyerCombo();

            cmbBuyerType.Items.Clear();
            cmbBuyerType.Items.AddRange(new[] { "Government", "Private" });
            cmbBuyerType.SelectedIndexChanged += CmbBuyerType_SelectedIndexChanged;

            cmbPaymentStatus.Items.Clear();
            cmbPaymentStatus.Items.AddRange(new[] { "Pending", "Completed" });

            // Set the farmer information
            LoadFarmerInfo();

            // Add stock-related functionality
            btnViewStock.Click += BtnViewStock_Click;

            // Add invoice-related functionality
            btnGenerateInvoice.Click += btnGenerateInvoice_Click;
            btnSaveInvoice.Click += btnSaveInvoice_Click;
            btnPrintInvoice.Click += btnPrintInvoice_Click;

            // Add event handlers for calculating total when quantity or price changes
            txtQuantity.TextChanged += CalculateTotalAmount;
            txtSalePrice.TextChanged += CalculateTotalAmount;

            StyleSalesGrid();
        }

        private void LoadFarmerInfo()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT FullName FROM Users WHERE UserID = @FarmerID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@FarmerID", currentFarmerId);
                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        lblFarmerName.Text = result.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading farmer information: {ex.Message}");
            }
        }

        private void CmbBuyerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBuyerType.SelectedItem?.ToString() == "Government")
            {
                // Filter only government buyers
                LoadBuyerComboFiltered("Government");

                // If crop type is already selected, fetch price
                if (lblSelectedStock.Tag != null && lblSelectedStock.Tag is Tuple<int, string> stockInfo)
                {
                    string cropType = stockInfo.Item2;
                    FetchPriceForCropType(cropType, "Government");
                }
            }
            else if (cmbBuyerType.SelectedItem?.ToString() == "Private")
            {
                // Filter only private buyers
                LoadBuyerComboFiltered("Private");

                // If crop type is already selected, fetch price
                if (lblSelectedStock.Tag != null && lblSelectedStock.Tag is Tuple<int, string> stockInfo)
                {
                    string cropType = stockInfo.Item2;
                    FetchPriceForCropType(cropType, "Private");
                }
            }
        }

        private void LoadBuyerComboFiltered(string buyerType)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string roleFilter = buyerType == "Government" ? "RoleID = 3" : "RoleID = 4";
                string query = $"SELECT UserID, FullName FROM Users WHERE {roleFilter}";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                cmbBuyer.DataSource = dt;
                cmbBuyer.DisplayMember = "FullName";
                cmbBuyer.ValueMember = "UserID";
                cmbBuyer.SelectedIndex = -1;
            }
        }

        private void BtnViewStock_Click(object sender, EventArgs e)
        {
            ShowFarmerStock();
        }

        private void ShowFarmerStock()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT StockID, CropType, Quantity, LastUpdated FROM Stock WHERE FarmerID = @FarmerID AND Quantity > 0";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@FarmerID", currentFarmerId);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        // Show the stock in a separate form or dialog
                        using (Form stockForm = new Form())
                        {
                            stockForm.Text = "My Available Stock";
                            stockForm.Size = new Size(600, 400);
                            stockForm.StartPosition = FormStartPosition.CenterParent;

                            DataGridView dgvStock = new DataGridView
                            {
                                Dock = DockStyle.Fill,
                                DataSource = dt,
                                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                                ReadOnly = true
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
                                    decimal availableQuantity = Convert.ToDecimal(row.Cells["Quantity"].Value);
                                    string cropType = row.Cells["CropType"].Value.ToString();

                                    // Set the maximum available quantity
                                    txtQuantity.Text = availableQuantity.ToString();
                                    lblSelectedStock.Text = $"Selected: {cropType} - {availableQuantity} kg";
                                    lblSelectedStock.Visible = true;

                                    // Store selected stock ID and crop type for later reference
                                    lblSelectedStock.Tag = new Tuple<int, string>(
                                        Convert.ToInt32(row.Cells["StockID"].Value),
                                        cropType
                                    );

                                    // Fetch and set price based on crop type and buyer type
                                    if (cmbBuyerType.SelectedItem != null)
                                    {
                                        FetchPriceForCropType(cropType, cmbBuyerType.SelectedItem.ToString());
                                    }

                                    stockForm.Close();
                                }
                                else
                                {
                                    MessageBox.Show("Please select a stock item.");
                                }
                            };

                            stockForm.Controls.Add(dgvStock);
                            stockForm.Controls.Add(btnSelect);

                            stockForm.ShowDialog();
                        }
                    }
                    else
                    {
                        MessageBox.Show("You don't have any available stock to sell.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading stock data: {ex.Message}");
            }
        }

        private void FetchPriceForCropType(string cropType, string buyerType)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query;
                    conn.Open();

                    if (buyerType == "Government")
                    {
                        // For government buyers, fetch government price
                        query = "SELECT GovernmentPrice FROM PriceMonitoring WHERE CropType = @CropType ORDER BY CreatedAt DESC";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@CropType", cropType);
                            object result = cmd.ExecuteScalar();
                            if (result != null && result != DBNull.Value)
                            {
                                decimal govPrice = Convert.ToDecimal(result);
                                txtSalePrice.Text = govPrice.ToString();
                                txtSalePrice.ReadOnly = true; // Lock the price for government sales
                            }
                            else
                            {
                                MessageBox.Show($"No government price found for {cropType}. Please contact the administrator.");
                                txtSalePrice.ReadOnly = false;
                            }
                        }
                    }
                    else if (buyerType == "Private")
                    {
                        // For private buyers, fetch average price as starting point but allow editing
                        query = "SELECT AvgPrice FROM PriceMonitoring WHERE CropType = @CropType ORDER BY CreatedAt DESC";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@CropType", cropType);
                            object result = cmd.ExecuteScalar();
                            if (result != null && result != DBNull.Value)
                            {
                                decimal avgPrice = Convert.ToDecimal(result);
                                txtSalePrice.Text = avgPrice.ToString();
                            }
                            else
                            {
                                MessageBox.Show($"No price data found for {cropType}.");
                            }
                            txtSalePrice.ReadOnly = false; // Allow price negotiation for private sales
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching price information: {ex.Message}");
            }
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

        private void StyleSalesGrid()
        {
            dataGridViewSales.EnableHeadersVisualStyles = false;
            dataGridViewSales.ColumnHeadersDefaultCellStyle.BackColor = Color.ForestGreen;
            dataGridViewSales.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewSales.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
            dataGridViewSales.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridViewSales.DefaultCellStyle.BackColor = Color.White;
            dataGridViewSales.DefaultCellStyle.ForeColor = Color.Black;
            dataGridViewSales.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10);
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
        }

        private void LoadFarmerSalesData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Join with Users table to display buyer names, limit to current farmer
                string query = @"SELECT s.SaleID, s.BuyerID, b.FullName AS BuyerName, s.BuyerType, 
                           s.CropType, s.SalePrice, s.Quantity, 
                           (s.SalePrice * s.Quantity) AS TotalAmount, 
                           s.PaymentStatus, s.SaleDate,
                           s.StockID
                           FROM Sales s
                           LEFT JOIN Users b ON s.BuyerID = b.UserID
                           WHERE s.FarmerID = @FarmerID
                           ORDER BY s.SaleDate DESC";


                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@FarmerID", currentFarmerId);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridViewSales.DataSource = dt;

                // Rename and reorder columns for better display
                if (dataGridViewSales.Columns.Contains("SaleID"))
                    dataGridViewSales.Columns["SaleID"].HeaderText = "Sale ID";
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

                // Hide IDs as they're not needed in the view
                if (dataGridViewSales.Columns.Contains("BuyerID"))
                    dataGridViewSales.Columns["BuyerID"].Visible = false;
                if (dataGridViewSales.Columns.Contains("StockID"))
                    dataGridViewSales.Columns["StockID"].Visible = false;
            }
        }

        private void LoadBuyerCombo()
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

        private void ProcessSale()
        {
            if (!ValidateInputs()) return;

            // Check if stock is selected
            if (lblSelectedStock.Tag == null)
            {
                MessageBox.Show("Please select stock before processing the sale.");
                return;
            }

            // Extract stock ID and crop type from the tag
            var stockInfo = (Tuple<int, string>)lblSelectedStock.Tag;
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

                    // 1. Check if there's enough stock
                    string checkStockQuery = "SELECT Quantity FROM Stock WHERE StockID = @StockID";
                    using (SqlCommand checkCmd = new SqlCommand(checkStockQuery, conn, transaction))
                    {
                        checkCmd.Parameters.AddWithValue("@StockID", stockId);
                        decimal availableQuantity = Convert.ToDecimal(checkCmd.ExecuteScalar());

                        if (availableQuantity < saleQuantity)
                        {
                            MessageBox.Show($"Insufficient stock. Available: {availableQuantity} kg");
                            return;
                        }
                    }

                    // 2. Insert the sale
                    string insertSaleQuery = @"INSERT INTO Sales (FarmerID, BuyerID, BuyerType, SalePrice, Quantity, PaymentStatus, SaleDate, CropType, StockID)
                                      VALUES (@FarmerID, @BuyerID, @BuyerType, @SalePrice, @Quantity, @PaymentStatus, @SaleDate, @CropType, @StockID);
                                      SELECT SCOPE_IDENTITY();";

                    int newSaleId;
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

                        newSaleId = Convert.ToInt32(insertCmd.ExecuteScalar());
                    }

                    // 3. Update the stock quantity
                    string updateStockQuery = "UPDATE Stock SET Quantity = Quantity - @SaleQuantity, LastUpdated = GETDATE() WHERE StockID = @StockID";
                    using (SqlCommand updateCmd = new SqlCommand(updateStockQuery, conn, transaction))
                    {
                        updateCmd.Parameters.AddWithValue("@SaleQuantity", saleQuantity);
                        updateCmd.Parameters.AddWithValue("@StockID", stockId);
                        updateCmd.ExecuteNonQuery();
                    }

                    // 4. Create invoice record
                    string invoicePath = $"Invoice_{newSaleId}_{DateTime.Now:yyyyMMdd}.pdf";
                    string insertInvoiceQuery = "INSERT INTO Invoices (SaleID, InvoicePath, CreatedAt) VALUES (@SaleID, @InvoicePath, GETDATE())";
                    using (SqlCommand invoiceCmd = new SqlCommand(insertInvoiceQuery, conn, transaction))
                    {
                        invoiceCmd.Parameters.AddWithValue("@SaleID", newSaleId);
                        invoiceCmd.Parameters.AddWithValue("@InvoicePath", invoicePath);
                        invoiceCmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    MessageBox.Show("Sale processed successfully!");

                    // Set the selected sale ID for invoice generation
                    selectedSaleId = newSaleId;

                    // Show the invoice panel and generate invoice preview
                    pnlInvoice.Visible = true;
                    GenerateInvoicePreview(newSaleId);
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();
                    MessageBox.Show($"Error processing sale: {ex.Message}");
                }
            }

            LoadFarmerSalesData();
            ClearInputs();
        }

        private bool ValidateInputs()
        {
            if (cmbBuyer.SelectedIndex == -1 ||
                cmbBuyerType.SelectedIndex == -1 || cmbPaymentStatus.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txtSalePrice.Text) || string.IsNullOrWhiteSpace(txtQuantity.Text))
            {
                MessageBox.Show("Please fill all required fields.");
                return false;
            }

            if (!decimal.TryParse(txtSalePrice.Text, out _) || !decimal.TryParse(txtQuantity.Text, out _))
            {
                MessageBox.Show("Sale Price and Quantity must be valid numbers.");
                return false;
            }

            return true;
        }

        private void ClearInputs()
        {
            cmbBuyer.SelectedIndex = -1;
            cmbBuyerType.SelectedIndex = -1;
            cmbPaymentStatus.SelectedIndex = -1;
            txtSalePrice.Clear();
            txtQuantity.Clear();
            txtTotalAmount.Clear();
            lblSelectedStock.Visible = false;
            lblSelectedStock.Tag = null;
            pnlInvoice.Visible = false;
            rtbInvoicePreview.Clear();
        }

       

        private void GenerateInvoicePreview(int saleId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"SELECT s.SaleID, s.SaleDate, s.SalePrice, s.Quantity, s.PaymentStatus, s.BuyerType, s.CropType,
                            f.FullName AS FarmerName, f.Email AS FarmerEmail, f.ContactNumber AS FarmerContactNumber, 
                            b.FullName AS BuyerName, b.Email AS BuyerEmail, b.ContactNumber AS BuyerContactNumber
                            FROM Sales s
                            INNER JOIN Users f ON s.FarmerID = f.UserID
                            LEFT JOIN Users b ON s.BuyerID = b.UserID
                            WHERE s.SaleID = @SaleID AND s.FarmerID = @FarmerID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@SaleID", saleId);
                    cmd.Parameters.AddWithValue("@FarmerID", currentFarmerId);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        StringBuilder sb = new StringBuilder();
                        decimal totalAmount = Convert.ToDecimal(reader["SalePrice"]) * Convert.ToDecimal(reader["Quantity"]);

                        sb.AppendLine("RICE PRODUCTION SYSTEM");
                        sb.AppendLine("SALES INVOICE");
                        sb.AppendLine("=============================================");
                        sb.AppendLine($"Invoice #: INV-{saleId:D5}");
                        sb.AppendLine($"Date: {Convert.ToDateTime(reader["SaleDate"]):yyyy-MM-dd HH:mm}");
                        sb.AppendLine("=============================================");
                        sb.AppendLine("\nSELLER INFORMATION:");
                        sb.AppendLine($"Name: {reader["FarmerName"]}");
                        if (reader["FarmerContactNumber"] != DBNull.Value) sb.AppendLine($"Contact: {reader["FarmerContactNumber"]}");
                        if (reader["FarmerEmail"] != DBNull.Value) sb.AppendLine($"Email: {reader["FarmerEmail"]}");

                        sb.AppendLine("\nBUYER INFORMATION:");
                        sb.AppendLine($"Type: {reader["BuyerType"]}");
                        sb.AppendLine($"Name: {reader["BuyerName"]}");
                        if (reader["BuyerContactNumber"] != DBNull.Value) sb.AppendLine($"Contact: {reader["BuyerContactNumber"]}");
                        if (reader["BuyerEmail"] != DBNull.Value) sb.AppendLine($"Email: {reader["BuyerEmail"]}");

                        sb.AppendLine("\n=============================================");
                        sb.AppendLine("TRANSACTION DETAILS:");
                        sb.AppendLine("=============================================");

                        string cropType = reader["CropType"] != DBNull.Value ? reader["CropType"].ToString() : "Rice";
                        sb.AppendLine($"Product: {cropType}");
                        sb.AppendLine($"Price per kg: {Convert.ToDecimal(reader["SalePrice"]):C}");
                        sb.AppendLine($"Quantity: {Convert.ToDecimal(reader["Quantity"]):N2} kg");
                        sb.AppendLine($"Total Amount: {totalAmount:C}");
                        sb.AppendLine($"Payment Status: {reader["PaymentStatus"]}");
                        sb.AppendLine("=============================================");
                        sb.AppendLine("\nThank you for your business!");
                        sb.AppendLine("This is a computer-generated invoice and doesn't require a signature.");
                        rtbInvoicePreview.Text = sb.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Invoice data not found or you don't have permission to view this sale.");
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating invoice: {ex.Message}");
            }
        }

        private void dataGridViewSales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridViewSales.Rows[e.RowIndex].Cells["SaleID"].Value != null)
            {
                selectedSaleId = Convert.ToInt32(dataGridViewSales.Rows[e.RowIndex].Cells["SaleID"].Value);
            }
        }


        private void SellPady_Resize(object sender, EventArgs e)
        {
            // Adjust font sizes based on container size if needed
            float scaleFactor = Math.Min(this.Width / 900f, this.Height / 650f);
            if (scaleFactor < 0.8f) scaleFactor = 0.8f;
            if (scaleFactor > 1.5f) scaleFactor = 1.5f;

            // Optionally adjust font sizes based on scale factor
            AdjustControlFonts(this.Controls, scaleFactor);

            // Force layout recalculation
            this.PerformLayout();
        }

        private void AdjustControlFonts(Control.ControlCollection controls, float scaleFactor)
        {
            foreach (Control control in controls)
            {
                // Skip certain controls if needed
                if (control is DataGridView) continue;

                // Adjust font size
                control.Font = new System.Drawing.Font(control.Font.FontFamily,
                                                       control.Font.Size * scaleFactor,
                                                       control.Font.Style);

                // Recursively adjust child controls
                if (control.Controls.Count > 0)
                {
                    AdjustControlFonts(control.Controls, scaleFactor);
                }
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
                MessageBox.Show("Please select a sale to generate an invoice.");
            }
        }

        private void btnSaveInvoice_Click(object sender, EventArgs e)
        {
            if (selectedSaleId == -1 || string.IsNullOrEmpty(rtbInvoicePreview.Text))
            {
                MessageBox.Show("Please generate an invoice first.");
                return;
            }

            SaveFileDialog saveDialog = new SaveFileDialog
            {
                Filter = "PDF Files (*.pdf)|*.pdf|Text Files (*.txt)|*.txt|All Files (*.*)|*.*",
                DefaultExt = "pdf",
                FileName = $"Invoice_{selectedSaleId}_{DateTime.Now:yyyyMMdd}"
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string fileExtension = Path.GetExtension(saveDialog.FileName).ToLower();

                    if (fileExtension == ".pdf")
                    {
                        // Create a PDF using iTextSharp
                        using (FileStream fs = new FileStream(saveDialog.FileName, FileMode.Create, FileAccess.Write, FileShare.None))
                        {
                            Document doc = new Document(PageSize.A4);
                            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                            doc.Open();
                            doc.Add(new Paragraph(rtbInvoicePreview.Text));
                            doc.Close();
                            writer.Close();
                        }
                    }
                    else
                    {
                        // Save as plain text
                        File.WriteAllText(saveDialog.FileName, rtbInvoicePreview.Text);
                    }

                    // Update invoice path in DB
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        string query = "UPDATE Invoices SET InvoicePath = @Path WHERE SaleID = @SaleID";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@Path", saveDialog.FileName);
                            cmd.Parameters.AddWithValue("@SaleID", selectedSaleId);
                            conn.Open();
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Invoice saved successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving invoice: {ex.Message}");
                }
            }
        }

        private void btnPrintInvoice_Click(object sender, EventArgs e)
        {
            if (selectedSaleId == -1 || string.IsNullOrEmpty(rtbInvoicePreview.Text))
            {
                MessageBox.Show("Please generate an invoice first.");
                return;
            }

            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Printing functionality would be implemented here.");
                // In a real application, you would implement printing here
                // This would typically use a PrintDocument object
            }
        }

       
    }
}