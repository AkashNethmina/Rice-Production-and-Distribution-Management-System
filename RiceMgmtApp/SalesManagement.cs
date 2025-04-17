using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Text;

namespace RiceMgmtApp
{
    public partial class SalesManagement : UserControl
    {
        private readonly string connectionString = "Server=DESKTOP-O6K3I3U\\SQLEXPRESS;Database=RiceProductionDB2;Integrated Security=True;";
        private int selectedSaleId = -1;

        public SalesManagement()
        {
            InitializeComponent();
            this.Load += SalesManagement_Load;
        }

        private void SalesManagement_Load(object sender, EventArgs e)
        {
            // Initialize UI elements
            LoadSalesData();
            LoadFarmerCombo();
            LoadBuyerCombo();

            cmbBuyerType.Items.Clear();
            cmbBuyerType.Items.AddRange(new[] { "Government", "Private" });
            cmbBuyerType.SelectedIndexChanged += CmbBuyerType_SelectedIndexChanged;

            cmbPaymentStatus.Items.Clear();
            cmbPaymentStatus.Items.AddRange(new[] { "Pending", "Completed", "Failed" });

            // Add stock-related functionality
            btnViewStock.Click += BtnViewStock_Click;

            // Add invoice-related functionality
            btnGenerateInvoice.Click += BtnGenerateInvoice_Click;
            btnSaveInvoice.Click += BtnSaveInvoice_Click;
            btnPrintInvoice.Click += BtnPrintInvoice_Click;

            // Add event handler for calculating total when quantity or price changes
            txtQuantity.TextChanged += CalculateTotalAmount;
            txtSalePrice.TextChanged += CalculateTotalAmount;

            ClearInputs();
            StyleSalesGrid();
        }

        private void CmbBuyerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBuyerType.SelectedItem?.ToString() == "Government")
            {
                // For government buyers, fetch the current government price
                FetchGovernmentPrice();
                // Filter only government buyers
                LoadBuyerComboFiltered("Government");
            }
            else if (cmbBuyerType.SelectedItem?.ToString() == "Private")
            {
                // For private buyers, allow price negotiation
                txtSalePrice.ReadOnly = false;
                // Filter only private buyers
                LoadBuyerComboFiltered("Private");
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

        private void FetchGovernmentPrice()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT TOP 1 GovernmentPrice FROM PriceMonitoring ORDER BY CreatedAt DESC";
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            decimal govPrice = Convert.ToDecimal(result);
                            txtSalePrice.Text = govPrice.ToString();
                            txtSalePrice.ReadOnly = true; // Lock the price for government sales
                        }
                        else
                        {
                            MessageBox.Show("No government price found. Please set up price monitoring data.");
                            txtSalePrice.ReadOnly = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching government price: {ex.Message}");
            }
        }

        private void BtnViewStock_Click(object sender, EventArgs e)
        {
            if (cmbFarmer.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a farmer first to view their stock.");
                return;
            }

            int farmerId = (int)cmbFarmer.SelectedValue;
            ShowFarmerStock(farmerId);
        }

        private void ShowFarmerStock(int farmerId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT StockID, CropType, Quantity, LastUpdated FROM Stock WHERE FarmerID = @FarmerID";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@FarmerID", farmerId);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        // Show the stock in a separate form or dialog
                        using (Form stockForm = new Form())
                        {
                            stockForm.Text = $"Stock for {cmbFarmer.Text}";
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

                                    // Store selected stock ID for later reference
                                    lblSelectedStock.Tag = row.Cells["StockID"].Value;

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
                        MessageBox.Show("No stock available for this farmer.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading stock data: {ex.Message}");
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
                    lblTitle.Text = total.ToString("N2");
                }
                else
                {
                    lblTitle.Text = "0.00";
                }
            }
            catch
            {
                lblTitle.Text = "0.00";
            }
        }

        private void StyleSalesGrid()
        {
            dataGridViewSales.EnableHeadersVisualStyles = false;
            dataGridViewSales.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dataGridViewSales.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewSales.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridViewSales.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridViewSales.DefaultCellStyle.BackColor = Color.White;
            dataGridViewSales.DefaultCellStyle.ForeColor = Color.Black;
            dataGridViewSales.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGridViewSales.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewSales.DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue;
            dataGridViewSales.DefaultCellStyle.SelectionForeColor = Color.Black;

            dataGridViewSales.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dataGridViewSales.RowTemplate.Height = 28;
            dataGridViewSales.GridColor = Color.LightGray;
            dataGridViewSales.BorderStyle = BorderStyle.Fixed3D;
            dataGridViewSales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridViewSales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewSales.MultiSelect = false;
            dataGridViewSales.AllowUserToAddRows = false;
            dataGridViewSales.ReadOnly = true;
        }

        private void LoadSalesData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Join with Users table to display farmer and buyer names
                string query = @"SELECT s.SaleID, s.FarmerID, f.FullName AS FarmerName, 
                               s.BuyerID, b.FullName AS BuyerName, s.BuyerType, 
                               s.SalePrice, s.Quantity, (s.SalePrice * s.Quantity) AS TotalAmount, 
                               s.PaymentStatus, s.SaleDate 
                               FROM Sales s
                               INNER JOIN Users f ON s.FarmerID = f.UserID
                               LEFT JOIN Users b ON s.BuyerID = b.UserID
                               ORDER BY s.SaleDate DESC";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridViewSales.DataSource = dt;

                // Rename and reorder columns for better display
                if (dataGridViewSales.Columns.Contains("SaleID"))
                    dataGridViewSales.Columns["SaleID"].HeaderText = "Sale ID";
                if (dataGridViewSales.Columns.Contains("FarmerName"))
                    dataGridViewSales.Columns["FarmerName"].HeaderText = "Farmer";
                if (dataGridViewSales.Columns.Contains("BuyerName"))
                    dataGridViewSales.Columns["BuyerName"].HeaderText = "Buyer";
                if (dataGridViewSales.Columns.Contains("BuyerType"))
                    dataGridViewSales.Columns["BuyerType"].HeaderText = "Buyer Type";
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
                if (dataGridViewSales.Columns.Contains("FarmerID"))
                    dataGridViewSales.Columns["FarmerID"].Visible = false;
                if (dataGridViewSales.Columns.Contains("BuyerID"))
                    dataGridViewSales.Columns["BuyerID"].Visible = false;
            }
        }

        private void LoadFarmerCombo()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT UserID, FullName FROM Users WHERE RoleID = 2";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                cmbFarmer.DataSource = dt;
                cmbFarmer.DisplayMember = "FullName";
                cmbFarmer.ValueMember = "UserID";
                cmbFarmer.SelectedIndex = -1;
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

        private void AddSale()
        {
            if (!ValidateInputs()) return;

            // Check if stock is selected
            if (lblSelectedStock.Tag == null)
            {
                MessageBox.Show("Please select stock before processing the sale.");
                return;
            }

            int stockId = Convert.ToInt32(lblSelectedStock.Tag);
            decimal saleQuantity = decimal.Parse(txtQuantity.Text);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlTransaction transaction = null; // Declare the transaction here
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
                    string insertSaleQuery = @"INSERT INTO Sales (FarmerID, BuyerID, BuyerType, SalePrice, Quantity, PaymentStatus, SaleDate)
                                              VALUES (@FarmerID, @BuyerID, @BuyerType, @SalePrice, @Quantity, @PaymentStatus, @SaleDate);
                                              SELECT SCOPE_IDENTITY();";

                    int newSaleId;
                    using (SqlCommand insertCmd = new SqlCommand(insertSaleQuery, conn, transaction))
                    {
                        insertCmd.Parameters.AddWithValue("@FarmerID", cmbFarmer.SelectedValue);
                        insertCmd.Parameters.AddWithValue("@BuyerID", cmbBuyer.SelectedValue ?? DBNull.Value);
                        insertCmd.Parameters.AddWithValue("@BuyerType", cmbBuyerType.Text);
                        insertCmd.Parameters.AddWithValue("@SalePrice", decimal.Parse(txtSalePrice.Text));
                        insertCmd.Parameters.AddWithValue("@Quantity", saleQuantity);
                        insertCmd.Parameters.AddWithValue("@PaymentStatus", cmbPaymentStatus.Text);
                        insertCmd.Parameters.AddWithValue("@SaleDate", DateTime.Now);

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

            LoadSalesData();
            ClearInputs();
        }

        private void UpdateSale(int saleId)
        {
            if (!ValidateInputs()) return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"UPDATE Sales 
                                 SET FarmerID = @FarmerID, BuyerID = @BuyerID, BuyerType = @BuyerType,
                                     SalePrice = @SalePrice, Quantity = @Quantity, PaymentStatus = @PaymentStatus
                                 WHERE SaleID = @SaleID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SaleID", saleId);
                    cmd.Parameters.AddWithValue("@FarmerID", cmbFarmer.SelectedValue);
                    cmd.Parameters.AddWithValue("@BuyerID", cmbBuyer.SelectedValue ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BuyerType", cmbBuyerType.Text);
                    cmd.Parameters.AddWithValue("@SalePrice", decimal.Parse(txtSalePrice.Text));
                    cmd.Parameters.AddWithValue("@Quantity", decimal.Parse(txtQuantity.Text));
                    cmd.Parameters.AddWithValue("@PaymentStatus", cmbPaymentStatus.Text);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Sale updated successfully!");
                }
                LoadSalesData();
                ClearInputs();
            }
        }

        private void DeleteSale(int saleId)
        {
            var confirm = MessageBox.Show("Are you sure you want to delete this sale?", "Confirm", MessageBoxButtons.YesNo);
            if (confirm != DialogResult.Yes) return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Sales WHERE SaleID = @SaleID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SaleID", saleId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Sale deleted successfully!");
                }
                LoadSalesData();
                ClearInputs();
            }
        }

        private void SearchSales(string keyword)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT s.SaleID, s.FarmerID, f.FullName AS FarmerName, 
                               s.BuyerID, b.FullName AS BuyerName, s.BuyerType, 
                               s.SalePrice, s.Quantity, (s.SalePrice * s.Quantity) AS TotalAmount, 
                               s.PaymentStatus, s.SaleDate 
                               FROM Sales s
                               INNER JOIN Users f ON s.FarmerID = f.UserID
                               LEFT JOIN Users b ON s.BuyerID = b.UserID
                               WHERE CAST(s.SaleID AS NVARCHAR) LIKE @Keyword 
                               OR f.FullName LIKE @Keyword
                               OR b.FullName LIKE @Keyword
                               OR s.PaymentStatus LIKE @Keyword
                               OR s.BuyerType LIKE @Keyword
                               ORDER BY s.SaleDate DESC";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridViewSales.DataSource = dt;
            }
        }

        private bool ValidateInputs()
        {
            if (cmbFarmer.SelectedIndex == -1 || cmbBuyer.SelectedIndex == -1 ||
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
            cmbFarmer.SelectedIndex = -1;
            cmbBuyer.SelectedIndex = -1;
            cmbBuyerType.SelectedIndex = -1;
            cmbPaymentStatus.SelectedIndex = -1;
            txtSalePrice.Clear();
            txtQuantity.Clear();
            lblTitle.Text = string.Empty; // Fixed this line
            lblSelectedStock.Visible = false;
            lblSelectedStock.Tag = null;
            pnlInvoice.Visible = false;
            rtbInvoicePreview.Clear();
        }

        private void BtnGenerateInvoice_Click(object sender, EventArgs e)
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

        private void GenerateInvoicePreview(int saleId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"SELECT s.SaleID, s.SaleDate, s.SalePrice, s.Quantity, s.PaymentStatus, s.BuyerType,
                                    f.FullName AS FarmerName, f.Email AS FarmerEmail, f.ContactNumber AS FarmerContactNumber, 
                                    b.FullName AS BuyerName, b.Email AS BuyerEmail, b.ContactNumber AS BuyerContactNumber
                                    FROM Sales s
                                    INNER JOIN Users f ON s.FarmerID = f.UserID
                                    LEFT JOIN Users b ON s.BuyerID = b.UserID
                                    WHERE s.SaleID = @SaleID";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@SaleID", saleId);
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
                        if (reader["FarmerContactNumber"] != DBNull.Value) sb.AppendLine($"ContactNumber: {reader["FarmerContactNumber"]}");
                        if (reader["FarmerEmail"] != DBNull.Value) sb.AppendLine($"Email: {reader["FarmerEmail"]}");
                        //if (reader["FarmerAddress"] != DBNull.Value) sb.AppendLine($"Address: {reader["FarmerAddress"]}");

                        sb.AppendLine("\nBUYER INFORMATION:");
                        sb.AppendLine($"Type: {reader["BuyerType"]}");
                        sb.AppendLine($"Name: {reader["BuyerName"]}");
                        if (reader["BuyerContactNumber"] != DBNull.Value) sb.AppendLine($"ContactNumber: {reader["BuyerContactNumber"]}");
                        if (reader["BuyerEmail"] != DBNull.Value) sb.AppendLine($"Email: {reader["BuyerEmail"]}");
                       // if (reader["BuyerAddress"] != DBNull.Value) sb.AppendLine($"Address: {reader["BuyerAddress"]}");

                        sb.AppendLine("\n=============================================");
                        sb.AppendLine("TRANSACTION DETAILS:");
                        sb.AppendLine("=============================================");
                        sb.AppendLine($"Product: Rice");
                        sb.AppendLine($"Price per kg: {Convert.ToDecimal(reader["SalePrice"]):C}");
                        sb.AppendLine($"Quantity: {Convert.ToDecimal(reader["Quantity"]):N2} kg");
                        sb.AppendLine($"Total Amount: {totalAmount:C}");
                        sb.AppendLine($"Payment Status: {reader["PaymentStatus"]}");
                        sb.AppendLine("=============================================");
                        sb.AppendLine("\nThank you for your business!");
                        sb.AppendLine("This is a computer-generated invoice and doesn't require a signature.");

                        rtbInvoicePreview.Text = sb.ToString();
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating invoice: {ex.Message}");
            }
        }

        private void BtnSaveInvoice_Click(object sender, EventArgs e)
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
                    // For now, we'll save as text file
                    // In a real app, you'd use a PDF library to create a proper PDF
                    File.WriteAllText(saveDialog.FileName, rtbInvoicePreview.Text);

                    // Update the invoice path in the database
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

        private void BtnPrintInvoice_Click(object sender, EventArgs e)
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddSale();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewSales.SelectedRows.Count > 0)
            {
                int saleId = Convert.ToInt32(dataGridViewSales.SelectedRows[0].Cells["SaleID"].Value);
                UpdateSale(saleId);
            }
            else
            {
                MessageBox.Show("Please select a sale to update.");
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewSales.SelectedRows.Count > 0)
            {
                int saleId = Convert.ToInt32(dataGridViewSales.SelectedRows[0].Cells["SaleID"].Value);
                DeleteSale(saleId);
            }
            else
            {
                MessageBox.Show("Please select a sale to delete.");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchSales(txtSearch.Text);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
            txtSearch.Clear();
            LoadSalesData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadSalesData();
            txtSearch.Clear();
        }

        private void dataGridViewSales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridViewSales.Rows[e.RowIndex].Cells["SaleID"].Value != null)
            {
                DataGridViewRow row = dataGridViewSales.Rows[e.RowIndex];

                selectedSaleId = Convert.ToInt32(row.Cells["SaleID"].Value);

                cmbFarmer.SelectedValue = row.Cells["FarmerID"].Value;

                if (row.Cells["BuyerID"].Value != DBNull.Value)
                    cmbBuyer.SelectedValue = row.Cells["BuyerID"].Value;
                else
                    cmbBuyer.SelectedIndex = -1;

                cmbBuyerType.Text = row.Cells["BuyerType"].Value?.ToString();
                txtSalePrice.Text = row.Cells["SalePrice"].Value?.ToString();
                txtQuantity.Text = row.Cells["Quantity"].Value?.ToString();

                if (row.Cells["TotalAmount"].Value != null)
                    lblTitle.Text = row.Cells["TotalAmount"].Value.ToString();

                cmbPaymentStatus.Text = row.Cells["PaymentStatus"].Value?.ToString();

                // Disable stock selection for existing records
                btnViewStock.Enabled = false;
                lblSelectedStock.Visible = false;
            }
        }

        private void panelInput_Paint(object sender, PaintEventArgs e)
        {

        }

        // This method would be part of the Designer-generated code in a real project
        // It's included here for reference on what controls you'd need to add to your form

    }
}
