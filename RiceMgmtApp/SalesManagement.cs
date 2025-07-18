﻿using System;
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
          
            LoadSalesData();
            LoadFarmerCombo();
            LoadBuyerCombo();

            cmbBuyerType.Items.Clear();
            cmbBuyerType.Items.AddRange(new[] { "Government", "Private" });
            cmbBuyerType.SelectedIndexChanged += CmbBuyerType_SelectedIndexChanged;

            cmbPaymentStatus.Items.Clear();
            cmbPaymentStatus.Items.AddRange(new[] { "Pending", "Completed", "Failed" });

          
            btnViewStock.Click += BtnViewStock_Click;

       
            btnGenerateInvoice.Click += BtnGenerateInvoice_Click;
            btnSaveInvoice.Click += BtnSaveInvoice_Click;
            btnPrintInvoice.Click += BtnPrintInvoice_Click;

     
            txtQuantity.TextChanged += CalculateTotalAmount;
            txtSalePrice.TextChanged += CalculateTotalAmount;

            ClearInputs();
            StyleSalesGrid();
        }

        private void CmbBuyerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBuyerType.SelectedItem?.ToString() == "Government")
            {
               
                LoadBuyerComboFiltered("Government");

                
                if (lblSelectedStock.Tag != null && lblSelectedStock.Tag is Tuple<int, string> stockInfo)
                {
                    string cropType = stockInfo.Item2;
                    FetchPriceForCropType(cropType, "Government");
                }
            }
            else if (cmbBuyerType.SelectedItem?.ToString() == "Private")
            {
             
                LoadBuyerComboFiltered("Private");

               
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

                                   
                                    txtQuantity.Text = availableQuantity.ToString();
                                    lblSelectedStock.Text = $"Selected: {cropType} - {availableQuantity} kg";
                                    lblSelectedStock.Visible = true;

                              
                                    lblSelectedStock.Tag = new Tuple<int, string>(
                                        Convert.ToInt32(row.Cells["StockID"].Value),
                                        cropType
                                    );

                                   
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
                        MessageBox.Show("No stock available for this farmer.");
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
                        
                        query = "SELECT GovernmentPrice FROM PriceMonitoring WHERE CropType = @CropType ORDER BY CreatedAt DESC";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@CropType", cropType);
                            object result = cmd.ExecuteScalar();
                            if (result != null && result != DBNull.Value)
                            {
                                decimal govPrice = Convert.ToDecimal(result);
                                txtSalePrice.Text = govPrice.ToString();
                                txtSalePrice.ReadOnly = true; 
                            }
                            else
                            {
                                MessageBox.Show($"No government price found for {cropType}. Please set up price monitoring data.");
                                txtSalePrice.ReadOnly = false;
                            }
                        }
                    }
                    else if (buyerType == "Private")
                    {
                       
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
                                MessageBox.Show($"No price data found for {cropType}. Please set up price monitoring data.");
                            }
                            txtSalePrice.ReadOnly = false; 
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
            dataGridViewSales.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dataGridViewSales.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewSales.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
            dataGridViewSales.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridViewSales.DefaultCellStyle.BackColor = Color.White;
            dataGridViewSales.DefaultCellStyle.ForeColor = Color.Black;
            dataGridViewSales.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10);
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
               
                string query = @"SELECT s.SaleID, s.FarmerID, f.FullName AS FarmerName, 
       s.BuyerID, b.FullName AS BuyerName, s.BuyerType, 
       s.CropType, s.SalePrice, s.Quantity, 
       (s.SalePrice * s.Quantity) AS TotalAmount, 
       s.PaymentStatus, s.SaleDate,
       s.StockID  -- ✅ Added this line
       FROM Sales s
       INNER JOIN Users f ON s.FarmerID = f.UserID
       LEFT JOIN Users b ON s.BuyerID = b.UserID
       ORDER BY s.SaleDate DESC";


                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridViewSales.DataSource = dt;

              
                if (dataGridViewSales.Columns.Contains("SaleID"))
                    dataGridViewSales.Columns["SaleID"].HeaderText = "Sale ID";
                if (dataGridViewSales.Columns.Contains("FarmerName"))
                    dataGridViewSales.Columns["FarmerName"].HeaderText = "Farmer";
                if (dataGridViewSales.Columns.Contains("BuyerName"))
                    dataGridViewSales.Columns["BuyerName"].HeaderText = "Buyer";
                if (dataGridViewSales.Columns.Contains("BuyerType"))
                    dataGridViewSales.Columns["BuyerType"].HeaderText = "Buyer Type";
                if (dataGridViewSales.Columns.Contains("SalePrice"))
                if (dataGridViewSales.Columns.Contains("CropType"))
                    dataGridViewSales.Columns["CropType"].HeaderText = "Rice Type";
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
                if (dataGridViewSales.Columns.Contains("StockID"))
                    dataGridViewSales.Columns["StockID"].Visible = false;

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

         
            if (lblSelectedStock.Tag == null)
            {
                MessageBox.Show("Please select stock before processing the sale.");
                return;
            }

        
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

                 
                    string insertSaleQuery = @"INSERT INTO Sales (FarmerID, BuyerID, BuyerType, SalePrice, Quantity, PaymentStatus, SaleDate, CropType, StockID)
                                      VALUES (@FarmerID, @BuyerID, @BuyerType, @SalePrice, @Quantity, @PaymentStatus, @SaleDate, @CropType, @StockID);
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
                        insertCmd.Parameters.AddWithValue("@CropType", cropType);
                        insertCmd.Parameters.AddWithValue("@StockID", stockId);


                        newSaleId = Convert.ToInt32(insertCmd.ExecuteScalar());
                    }

                    string updateStockQuery = "UPDATE Stock SET Quantity = Quantity - @SaleQuantity, LastUpdated = GETDATE() WHERE StockID = @StockID";
                    using (SqlCommand updateCmd = new SqlCommand(updateStockQuery, conn, transaction))
                    {
                        updateCmd.Parameters.AddWithValue("@SaleQuantity", saleQuantity);
                        updateCmd.Parameters.AddWithValue("@StockID", stockId);
                        updateCmd.ExecuteNonQuery();
                    }

                   

                  
                    selectedSaleId = newSaleId;

                  
                    pnlInvoice.Visible = true;
                 // GenerateInvoicePreview(newSaleId);
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
                conn.Open();
                SqlTransaction transaction = null;

                try
                {
                    transaction = conn.BeginTransaction();

                    // Step 1: Get the current sale info including StockID
                    int stockId;
                    decimal oldQuantity = 0;
                    string cropType;

                    string getSaleInfoQuery = "SELECT Quantity, StockID, CropType FROM Sales WHERE SaleID = @SaleID";
                    using (SqlCommand getCmd = new SqlCommand(getSaleInfoQuery, conn, transaction))
                    {
                        getCmd.Parameters.AddWithValue("@SaleID", saleId);
                        using (SqlDataReader reader = getCmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                oldQuantity = reader.GetDecimal(0);
                                stockId = reader.GetInt32(1);
                                cropType = reader.GetString(2);
                            }
                            else
                            {
                                MessageBox.Show("Sale record not found.");
                                return;
                            }
                        }
                    }

                    // Step 2: Update sale
                    decimal newQuantity = decimal.Parse(txtQuantity.Text);
                    decimal quantityDiff = oldQuantity - newQuantity;

                    string updateQuery = @"UPDATE Sales 
                SET FarmerID = @FarmerID, BuyerID = @BuyerID, BuyerType = @BuyerType,
                    SalePrice = @SalePrice, Quantity = @Quantity, PaymentStatus = @PaymentStatus
                WHERE SaleID = @SaleID";

                    using (SqlCommand cmd = new SqlCommand(updateQuery, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@SaleID", saleId);
                        cmd.Parameters.AddWithValue("@FarmerID", cmbFarmer.SelectedValue);
                        cmd.Parameters.AddWithValue("@BuyerID", cmbBuyer.SelectedValue ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@BuyerType", cmbBuyerType.Text);
                        cmd.Parameters.AddWithValue("@SalePrice", decimal.Parse(txtSalePrice.Text));
                        cmd.Parameters.AddWithValue("@Quantity", newQuantity);
                        cmd.Parameters.AddWithValue("@PaymentStatus", cmbPaymentStatus.Text);
                        cmd.ExecuteNonQuery();
                    }

                    // Step 3: Adjust stock (add or subtract diff)
                    string updateStockQuery = "UPDATE Stock SET Quantity = Quantity + @QuantityDiff, LastUpdated = GETDATE() WHERE StockID = @StockID";
                    using (SqlCommand stockCmd = new SqlCommand(updateStockQuery, conn, transaction))
                    {
                        stockCmd.Parameters.AddWithValue("@QuantityDiff", quantityDiff); // Can be + or -
                        stockCmd.Parameters.AddWithValue("@StockID", stockId);
                        stockCmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    MessageBox.Show("Sale updated successfully!");
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();
                    MessageBox.Show($"Error updating sale: {ex.Message}");
                }
            }

            LoadSalesData();
            ClearInputs();
        }

        private void DeleteSale(int saleId)
        {
            var confirm = MessageBox.Show("Are you sure you want to delete this sale?", "Confirm", MessageBoxButtons.YesNo);
            if (confirm != DialogResult.Yes) return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction transaction = null;

                try
                {
                    transaction = conn.BeginTransaction();

                    // Step 1: Get sale quantity and StockID
                    decimal quantity = 0;
                    int stockId;

                    string getSaleQuery = "SELECT Quantity, StockID FROM Sales WHERE SaleID = @SaleID";
                    using (SqlCommand getCmd = new SqlCommand(getSaleQuery, conn, transaction))
                    {
                        getCmd.Parameters.AddWithValue("@SaleID", saleId);
                        using (SqlDataReader reader = getCmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                quantity = reader.GetDecimal(0);
                                stockId = reader.GetInt32(1);
                            }
                            else
                            {
                                MessageBox.Show("Sale record not found.");
                                return;
                            }
                        }
                    }

                
                   

               
                    string deleteQuery = "DELETE FROM Sales WHERE SaleID = @SaleID";
                    using (SqlCommand cmd = new SqlCommand(deleteQuery, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@SaleID", saleId);
                        cmd.ExecuteNonQuery();
                    }

               
                    string updateStockQuery = "UPDATE Stock SET Quantity = Quantity + @Quantity, LastUpdated = GETDATE() WHERE StockID = @StockID";
                    using (SqlCommand stockCmd = new SqlCommand(updateStockQuery, conn, transaction))
                    {
                        stockCmd.Parameters.AddWithValue("@Quantity", quantity);
                        stockCmd.Parameters.AddWithValue("@StockID", stockId);
                        stockCmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    MessageBox.Show("Sale deleted successfully!");
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();
                    MessageBox.Show($"Error deleting sale: {ex.Message}");
                }
            }

            LoadSalesData();
            ClearInputs();
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
            txtTotalAmount.Text = string.Empty; 
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
                    string query = @"
                SELECT s.SaleID, s.SaleDate, s.SalePrice, s.Quantity, s.PaymentStatus, s.BuyerType, s.CropType,
                       f.FullName AS FarmerName, f.Email AS FarmerEmail, f.ContactNumber AS FarmerContactNumber, 
                       b.FullName AS BuyerName, b.Email AS BuyerEmail, b.ContactNumber AS BuyerContactNumber
                FROM Sales s
                INNER JOIN Users f ON s.FarmerID = f.UserID
                LEFT JOIN Users b ON s.BuyerID = b.UserID
                WHERE s.SaleID = @SaleID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@SaleID", saleId);
                        conn.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                StringBuilder sb = new StringBuilder();
                                decimal salePrice = reader["SalePrice"] != DBNull.Value ? Convert.ToDecimal(reader["SalePrice"]) : 0;
                                decimal quantity = reader["Quantity"] != DBNull.Value ? Convert.ToDecimal(reader["Quantity"]) : 0;
                                decimal totalAmount = salePrice * quantity;

                                sb.AppendLine("RICE PRODUCTION SYSTEM");
                                sb.AppendLine("SALES INVOICE");
                                sb.AppendLine("=============================================");
                                sb.AppendLine($"Invoice #: INV-{saleId:D5}");
                                sb.AppendLine($"Date: {Convert.ToDateTime(reader["SaleDate"]):yyyy-MM-dd HH:mm}");
                                sb.AppendLine("=============================================");

                                sb.AppendLine("\nSELLER INFORMATION:");
                                sb.AppendLine($"Name: {reader["FarmerName"]}");
                                if (reader["FarmerContactNumber"] != DBNull.Value)
                                    sb.AppendLine($"Contact Number: {reader["FarmerContactNumber"]}");
                                if (reader["FarmerEmail"] != DBNull.Value)
                                    sb.AppendLine($"Email: {reader["FarmerEmail"]}");

                                sb.AppendLine("\nBUYER INFORMATION:");
                                sb.AppendLine($"Type: {reader["BuyerType"]}");
                                if (reader["BuyerName"] != DBNull.Value)
                                    sb.AppendLine($"Name: {reader["BuyerName"]}");
                                if (reader["BuyerContactNumber"] != DBNull.Value)
                                    sb.AppendLine($"Contact Number: {reader["BuyerContactNumber"]}");
                                if (reader["BuyerEmail"] != DBNull.Value)
                                    sb.AppendLine($"Email: {reader["BuyerEmail"]}");

                                sb.AppendLine("\n=============================================");
                                sb.AppendLine("TRANSACTION DETAILS:");
                                sb.AppendLine("=============================================");

                                string cropType = reader["CropType"] != DBNull.Value ? reader["CropType"].ToString() : "Rice";
                                sb.AppendLine($"Product: {cropType}");
                                sb.AppendLine($"Price per kg: Rs. {salePrice:N2}");
                                sb.AppendLine($"Quantity: {quantity:N2} kg");
                                sb.AppendLine($"Total Amount: Rs. {totalAmount:N2}");
                                sb.AppendLine($"Payment Status: {reader["PaymentStatus"]}");
                                sb.AppendLine("=============================================");
                                sb.AppendLine("\nThank you for your business!");
                                sb.AppendLine("This is a computer-generated invoice and doesn't require a signature.");

                                rtbInvoicePreview.Text = sb.ToString();
                            }
                            else
                            {
                                MessageBox.Show("No record found for the given Sale ID.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating invoice: {ex.Message}", "Invoice Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    txtTotalAmount.Text = row.Cells["TotalAmount"].Value.ToString();

                cmbPaymentStatus.Text = row.Cells["PaymentStatus"].Value?.ToString();

               
                btnViewStock.Enabled = false;
                lblSelectedStock.Visible = false;
            }
        }

    }
}
