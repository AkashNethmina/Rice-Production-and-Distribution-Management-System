using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Configuration;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace RiceMgmtApp
{
    public partial class BuyPaddy : UserControl
    {
        private readonly string connectionString = "Server=DESKTOP-O6K3I3U\\SQLEXPRESS;Database=RiceProductionDB2;Integrated Security=True;";
        private readonly int currentBuyerId;
        private int selectedStockId = -1;
        private int selectedFarmerId = -1;
        private int selectedSaleId = -1;

        public BuyPaddy(int buyerID)
        {
            // Initialize the UI components
            InitializeComponent();
            this.currentBuyerId = buyerID;
            this.Load += BuyPaddy_Load;
        }

        private void BuyPaddy_Load(object sender, EventArgs e)
        {
            // Initialize UI elements
            LoadBuyerInfo();
            LoadFarmersData();

            // Initialize payment status combo box
            cmbPaymentStatus.Items.Clear();
            cmbPaymentStatus.Items.AddRange(new[] { "Pending", "Completed" });
            cmbPaymentStatus.SelectedIndex = 0;

            // Add stock-related functionality
            btnViewStock.Click += btnViewStock_Click;

            // Add purchase-related functionality
            btnCreatePurchase.Click += btnCreatePurchase_Click;
            btnClear.Click += btnClear_Click;
            btnRefresh.Click += btnRefresh_Click;

            // Add purchase history functionality
            dataGridViewPurchases.CellClick += dataGridViewPurchases_CellClick;

            // Add invoice-related functionality
            btnGenerateInvoice.Click += btnGenerateInvoice_Click;
            btnSaveInvoice.Click += btnSaveInvoice_Click;
            btnPrintInvoice.Click += btnPrintInvoice_Click;

            // Add event handlers for calculating total when quantity or price changes
            txtQuantity.TextChanged += CalculateTotalAmount;
            txtPurchasePrice.TextChanged += CalculateTotalAmount;

            // Style data grid views
            StylePurchaseGrid();

            // Load purchase history
            LoadBuyerPurchasesData();

            // Hide invoice panel initially
            pnlInvoice.Visible = false;

            // FIX: Add the missing event handler for farmer selection
            dataGridViewFarmers.CellClick += dataGridViewFarmers_CellClick;
        }

        private void LoadBuyerInfo()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT FullName FROM Users WHERE UserID = @BuyerID AND RoleID = 4";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@BuyerID", currentBuyerId);
                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        lblBuyerName.Text = result.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Error: You do not have private buyer privileges.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading buyer information: {ex.Message}");
            }
        }

        private void LoadFarmersData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"SELECT u.UserID, u.FullName, 
                                    (SELECT COUNT(*) FROM Stock s WHERE s.FarmerID = u.UserID AND s.Quantity > 0) AS StocksAvailable,
                                    (SELECT SUM(s.Quantity) FROM Stock s WHERE s.FarmerID = u.UserID AND s.Quantity > 0) AS TotalQuantity
                                    FROM Users u
                                    WHERE u.RoleID = 2 -- Farmer role
                                    AND u.Status = 'Active'
                                    AND EXISTS (SELECT 1 FROM Stock s WHERE s.FarmerID = u.UserID AND s.Quantity > 0)
                                    ORDER BY u.FullName";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridViewFarmers.DataSource = dt;

                    // Rename columns for better display
                    if (dataGridViewFarmers.Columns.Contains("UserID"))
                        dataGridViewFarmers.Columns["UserID"].HeaderText = "Farmer ID";
                    if (dataGridViewFarmers.Columns.Contains("FullName"))
                        dataGridViewFarmers.Columns["FullName"].HeaderText = "Farmer Name";
                    if (dataGridViewFarmers.Columns.Contains("StocksAvailable"))
                        dataGridViewFarmers.Columns["StocksAvailable"].HeaderText = "Stock Types";
                    if (dataGridViewFarmers.Columns.Contains("TotalQuantity"))
                        dataGridViewFarmers.Columns["TotalQuantity"].HeaderText = "Total Quantity (kg)";

                    // Style the farmers grid
                    StyleFarmersGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading farmers data: {ex.Message}");
            }
        }

        private void StyleFarmersGrid()
        {
            dataGridViewFarmers.EnableHeadersVisualStyles = false;
            dataGridViewFarmers.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue;
            dataGridViewFarmers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewFarmers.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
            dataGridViewFarmers.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridViewFarmers.DefaultCellStyle.BackColor = Color.White;
            dataGridViewFarmers.DefaultCellStyle.ForeColor = Color.Black;
            dataGridViewFarmers.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10);
            dataGridViewFarmers.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewFarmers.DefaultCellStyle.SelectionBackColor = Color.LightSteelBlue;
            dataGridViewFarmers.DefaultCellStyle.SelectionForeColor = Color.Black;

            dataGridViewFarmers.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dataGridViewFarmers.RowTemplate.Height = 28;
            dataGridViewFarmers.GridColor = Color.LightGray;
            dataGridViewFarmers.BorderStyle = BorderStyle.Fixed3D;
            dataGridViewFarmers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridViewFarmers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewFarmers.MultiSelect = false;
            dataGridViewFarmers.AllowUserToAddRows = false;
            dataGridViewFarmers.ReadOnly = true;
        }

        private void StylePurchaseGrid()
        {
            dataGridViewPurchases.EnableHeadersVisualStyles = false;
            dataGridViewPurchases.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue;
            dataGridViewPurchases.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewPurchases.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
            dataGridViewPurchases.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridViewPurchases.DefaultCellStyle.BackColor = Color.White;
            dataGridViewPurchases.DefaultCellStyle.ForeColor = Color.Black;
            dataGridViewPurchases.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10);
            dataGridViewPurchases.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewPurchases.DefaultCellStyle.SelectionBackColor = Color.LightSteelBlue;
            dataGridViewPurchases.DefaultCellStyle.SelectionForeColor = Color.Black;

            dataGridViewPurchases.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dataGridViewPurchases.RowTemplate.Height = 28;
            dataGridViewPurchases.GridColor = Color.LightGray;
            dataGridViewPurchases.BorderStyle = BorderStyle.Fixed3D;
            dataGridViewPurchases.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridViewPurchases.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewPurchases.MultiSelect = false;
            dataGridViewPurchases.AllowUserToAddRows = false;
            dataGridViewPurchases.ReadOnly = true;
        }

        private void LoadBuyerPurchasesData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Join with Users table to display farmer names, limit to current buyer
                string query = @"SELECT s.SaleID, s.FarmerID, f.FullName AS FarmerName, s.BuyerType, 
                           s.CropType, s.SalePrice, s.Quantity, 
                           (s.SalePrice * s.Quantity) AS TotalAmount, 
                           s.PaymentStatus, s.SaleDate
                           FROM Sales s
                           LEFT JOIN Users f ON s.FarmerID = f.UserID
                           WHERE s.BuyerID = @BuyerID AND s.BuyerType = 'Private'
                           ORDER BY s.SaleDate DESC";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@BuyerID", currentBuyerId);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridViewPurchases.DataSource = dt;

                // Rename and reorder columns for better display
                if (dataGridViewPurchases.Columns.Contains("SaleID"))
                    dataGridViewPurchases.Columns["SaleID"].HeaderText = "Purchase ID";
                if (dataGridViewPurchases.Columns.Contains("FarmerName"))
                    dataGridViewPurchases.Columns["FarmerName"].HeaderText = "Farmer";
                if (dataGridViewPurchases.Columns.Contains("BuyerType"))
                    dataGridViewPurchases.Columns["BuyerType"].HeaderText = "Buyer Type";
                if (dataGridViewPurchases.Columns.Contains("CropType"))
                    dataGridViewPurchases.Columns["CropType"].HeaderText = "Rice Type";
                if (dataGridViewPurchases.Columns.Contains("SalePrice"))
                    dataGridViewPurchases.Columns["SalePrice"].HeaderText = "Price/kg";
                if (dataGridViewPurchases.Columns.Contains("Quantity"))
                    dataGridViewPurchases.Columns["Quantity"].HeaderText = "Quantity (kg)";
                if (dataGridViewPurchases.Columns.Contains("TotalAmount"))
                    dataGridViewPurchases.Columns["TotalAmount"].HeaderText = "Total Amount";
                if (dataGridViewPurchases.Columns.Contains("PaymentStatus"))
                    dataGridViewPurchases.Columns["PaymentStatus"].HeaderText = "Payment Status";
                if (dataGridViewPurchases.Columns.Contains("SaleDate"))
                    dataGridViewPurchases.Columns["SaleDate"].HeaderText = "Purchase Date";

                // Hide IDs as they're not needed in the view
                if (dataGridViewPurchases.Columns.Contains("FarmerID"))
                    dataGridViewPurchases.Columns["FarmerID"].Visible = false;
            }
        }

        private void dataGridViewFarmers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridViewFarmers.Rows[e.RowIndex].Cells["UserID"].Value != null)
            {
                selectedFarmerId = Convert.ToInt32(dataGridViewFarmers.Rows[e.RowIndex].Cells["UserID"].Value);
                string farmerName = dataGridViewFarmers.Rows[e.RowIndex].Cells["FullName"].Value.ToString();
                lblSelectedFarmer.Text = $"Selected Farmer: {farmerName}";
                lblSelectedFarmer.Visible = true;

                // Clear any previous stock selection
                lblSelectedStock.Visible = false;
                lblSelectedStock.Tag = null;
            }
        }

        private void ShowFarmerStock(int farmerId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT StockID, CropType, Quantity, LastUpdated FROM Stock WHERE FarmerID = @FarmerID AND Quantity > 0";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@FarmerID", farmerId);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        // Show the stock in a separate form or dialog
                        using (Form stockForm = new Form())
                        {
                            stockForm.Text = "Available Stock";
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
                                    selectedStockId = Convert.ToInt32(row.Cells["StockID"].Value);
                                    decimal availableQuantity = Convert.ToDecimal(row.Cells["Quantity"].Value);
                                    string cropType = row.Cells["CropType"].Value.ToString();

                                    // Set the maximum available quantity
                                    txtQuantity.Text = availableQuantity.ToString();
                                    lblSelectedStock.Text = $"Selected: {cropType} - {availableQuantity} kg";
                                    lblSelectedStock.Visible = true;

                                    // Store selected stock ID and crop type for later reference
                                    lblSelectedStock.Tag = new Tuple<int, string>(selectedStockId, cropType);

                                    // Fetch and set suggested price based on crop type
                                    FetchPriceForCropType(cropType);

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
                        MessageBox.Show("This farmer does not have any available stock to sell.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading stock data: {ex.Message}");
            }
        }

        private void FetchPriceForCropType(string cropType)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT AvgPrice FROM PriceMonitoring WHERE CropType = @CropType ORDER BY CreatedAt DESC";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CropType", cropType);
                        conn.Open();
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            decimal avgPrice = Convert.ToDecimal(result);
                            txtPurchasePrice.Text = avgPrice.ToString();
                        }
                        else
                        {
                            MessageBox.Show($"No price data found for {cropType}. Please enter a price manually.");
                            txtPurchasePrice.Text = string.Empty;
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
                    decimal.TryParse(txtPurchasePrice.Text, out decimal price))
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

        private void ProcessPurchase()
        {
            if (!ValidateInputs()) return;

            // Check if stock is selected
            if (lblSelectedStock.Tag == null)
            {
                MessageBox.Show("Please select stock before processing the purchase.");
                return;
            }

            // Extract stock ID and crop type from the tag
            var stockInfo = (Tuple<int, string>)lblSelectedStock.Tag;
            int stockId = stockInfo.Item1;
            string cropType = stockInfo.Item2;
            decimal purchaseQuantity = decimal.Parse(txtQuantity.Text);

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

                        if (availableQuantity < purchaseQuantity)
                        {
                            MessageBox.Show($"Insufficient stock. Available: {availableQuantity} kg");
                            return;
                        }
                    }

                    // 2. Get the farmer ID for this stock
                    string getFarmerQuery = "SELECT FarmerID FROM Stock WHERE StockID = @StockID";
                    int farmerId;
                    using (SqlCommand getFarmerCmd = new SqlCommand(getFarmerQuery, conn, transaction))
                    {
                        getFarmerCmd.Parameters.AddWithValue("@StockID", stockId);
                        farmerId = Convert.ToInt32(getFarmerCmd.ExecuteScalar());
                    }

                    // 3. Insert the sale (which is a purchase from the buyer's perspective)
                    string insertSaleQuery = @"INSERT INTO Sales (FarmerID, BuyerID, BuyerType, SalePrice, Quantity, PaymentStatus, SaleDate, CropType, StockID)
                                      VALUES (@FarmerID, @BuyerID, 'Private', @SalePrice, @Quantity, @PaymentStatus, @SaleDate, @CropType, @StockID);
                                      SELECT SCOPE_IDENTITY();";

                    int newSaleId;
                    using (SqlCommand insertCmd = new SqlCommand(insertSaleQuery, conn, transaction))
                    {
                        insertCmd.Parameters.AddWithValue("@FarmerID", farmerId);
                        insertCmd.Parameters.AddWithValue("@BuyerID", currentBuyerId);
                        insertCmd.Parameters.AddWithValue("@SalePrice", decimal.Parse(txtPurchasePrice.Text));
                        insertCmd.Parameters.AddWithValue("@Quantity", purchaseQuantity);
                        insertCmd.Parameters.AddWithValue("@PaymentStatus", cmbPaymentStatus.Text);
                        insertCmd.Parameters.AddWithValue("@SaleDate", DateTime.Now);
                        insertCmd.Parameters.AddWithValue("@CropType", cropType);
                        insertCmd.Parameters.AddWithValue("@StockID", stockId);

                        newSaleId = Convert.ToInt32(insertCmd.ExecuteScalar());
                    }

                    // 4. Update the stock quantity
                    string updateStockQuery = "UPDATE Stock SET Quantity = Quantity - @SaleQuantity, LastUpdated = GETDATE() WHERE StockID = @StockID";
                    using (SqlCommand updateCmd = new SqlCommand(updateStockQuery, conn, transaction))
                    {
                        updateCmd.Parameters.AddWithValue("@SaleQuantity", purchaseQuantity);
                        updateCmd.Parameters.AddWithValue("@StockID", stockId);
                        updateCmd.ExecuteNonQuery();
                    }

                    // 5. Create invoice record
                    string invoicePath = $"Invoice_{newSaleId}_{DateTime.Now:yyyyMMdd}.pdf";
                    string insertInvoiceQuery = "INSERT INTO Invoices (SaleID, InvoicePath, CreatedAt) VALUES (@SaleID, @InvoicePath, GETDATE())";
                    using (SqlCommand invoiceCmd = new SqlCommand(insertInvoiceQuery, conn, transaction))
                    {
                        invoiceCmd.Parameters.AddWithValue("@SaleID", newSaleId);
                        invoiceCmd.Parameters.AddWithValue("@InvoicePath", invoicePath);
                        invoiceCmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    MessageBox.Show("Purchase processed successfully!");

                    // Set the selected sale ID for invoice generation
                    selectedSaleId = newSaleId;

                    // Show the invoice panel and generate invoice preview
                    pnlInvoice.Visible = true;
                    GenerateInvoicePreview(newSaleId);
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();
                    MessageBox.Show($"Error processing purchase: {ex.Message}");
                }
            }

            // Refresh data
            LoadBuyerPurchasesData();
            LoadFarmersData();
            ClearInputs();
        }

        private bool ValidateInputs()
        {
            if (selectedFarmerId <= 0)
            {
                MessageBox.Show("Please select a farmer.");
                return false;
            }

            if (lblSelectedStock.Tag == null)
            {
                MessageBox.Show("Please select stock to purchase.");
                return false;
            }

            if (cmbPaymentStatus.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txtPurchasePrice.Text) ||
                string.IsNullOrWhiteSpace(txtQuantity.Text))
            {
                MessageBox.Show("Please fill all required fields.");
                return false;
            }

            if (!decimal.TryParse(txtPurchasePrice.Text, out _) || !decimal.TryParse(txtQuantity.Text, out _))
            {
                MessageBox.Show("Purchase Price and Quantity must be valid numbers.");
                return false;
            }

            return true;
        }

        private void ClearInputs()
        {
            txtPurchasePrice.Clear();
            txtQuantity.Clear();
            txtTotalAmount.Clear();
            lblSelectedStock.Visible = false;
            lblSelectedStock.Tag = null;
            cmbPaymentStatus.SelectedIndex = 0;
            pnlInvoice.Visible = false;
            rtbInvoicePreview.Clear();
        }

        private void dataGridViewPurchases_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridViewPurchases.Rows[e.RowIndex].Cells["SaleID"].Value != null)
            {
                selectedSaleId = Convert.ToInt32(dataGridViewPurchases.Rows[e.RowIndex].Cells["SaleID"].Value);
            }
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
                            WHERE s.SaleID = @SaleID AND s.BuyerID = @BuyerID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@SaleID", saleId);
                    cmd.Parameters.AddWithValue("@BuyerID", currentBuyerId);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        StringBuilder sb = new StringBuilder();
                        decimal totalAmount = Convert.ToDecimal(reader["SalePrice"]) * Convert.ToDecimal(reader["Quantity"]);

                        sb.AppendLine("RICE PRODUCTION SYSTEM");
                        sb.AppendLine("PURCHASE INVOICE");
                        sb.AppendLine("=============================================");
                        sb.AppendLine($"Invoice #: INV-{saleId:D5}");
                        sb.AppendLine($"Date: {Convert.ToDateTime(reader["SaleDate"]):yyyy-MM-dd HH:mm}");
                        sb.AppendLine("=============================================");
                        sb.AppendLine("\nBUYER INFORMATION:");
                        sb.AppendLine($"Name: {reader["BuyerName"]}");
                        if (reader["BuyerContactNumber"] != DBNull.Value) sb.AppendLine($"Contact: {reader["BuyerContactNumber"]}");
                        if (reader["BuyerEmail"] != DBNull.Value) sb.AppendLine($"Email: {reader["BuyerEmail"]}");

                        sb.AppendLine("\nSELLER INFORMATION:");
                        sb.AppendLine($"Name: {reader["FarmerName"]}");
                        if (reader["FarmerContactNumber"] != DBNull.Value) sb.AppendLine($"Contact: {reader["FarmerContactNumber"]}");
                        if (reader["FarmerEmail"] != DBNull.Value) sb.AppendLine($"Email: {reader["FarmerEmail"]}");

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
                        MessageBox.Show("Invoice data not found or you don't have permission to view this purchase.");
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating invoice: {ex.Message}");
            }
        }

       
        
       
        private void btnCreateSale_Click(object sender, EventArgs e)
        {
            ProcessPurchase();
        }

      

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadFarmersData();
            LoadBuyerPurchasesData();
            MessageBox.Show("Data refreshed successfully.");
        }

        private void btnViewStock_Click(object sender, EventArgs e)
        {
            if (selectedFarmerId <= 0)
            {
                MessageBox.Show("Please select a farmer first.");
                return;
            }

            ShowFarmerStock(selectedFarmerId);
        }

        private void btnCreatePurchase_Click(object sender, EventArgs e)
        {
            ProcessPurchase();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
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

        private void btnGenerateInvoice_Click(object sender, EventArgs e)
        {
            if (dataGridViewPurchases.SelectedRows.Count > 0)
            {
                int saleId = Convert.ToInt32(dataGridViewPurchases.SelectedRows[0].Cells["SaleID"].Value);
                selectedSaleId = saleId;
                GenerateInvoicePreview(saleId);
                pnlInvoice.Visible = true;
            }
            else
            {
                MessageBox.Show("Please select a purchase to generate an invoice.");
            }
        }

        private void btnSaveInvoice_Click_1(object sender, EventArgs e)
        {

        }
    }
}