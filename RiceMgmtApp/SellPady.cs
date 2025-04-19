using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Configuration;
using System.Text;

namespace RiceMgmtApp
{
    public partial class SellPady : UserControl
    {
        private readonly string connectionString;
        private int farmerID;
        private int selectedStockID = -1;
        private decimal availableQuantity = 0;

        // UI Controls
        private Panel panelMain;
        private Panel panelStock;
        private Panel panelSale;
        private Panel panelInvoice;

        private DataGridView dgvStock;
        private Label lblTitle;
        private Label lblStockTitle;
        private Label lblSelectedStock;
        private Label lblBuyerType;
        private Label lblBuyer;
        private Label lblPrice;
        private Label lblQuantity;
        private Label lblTotalAmount;
        private Label lblPaymentStatus;

        private ComboBox cmbBuyerType;
        private ComboBox cmbBuyer;
        private ComboBox cmbPaymentStatus;

        private TextBox txtSalePrice;
        private TextBox txtQuantity;
        private TextBox txtTotalAmount;

        private Button btnProcessSale;
        private Button btnClear;
        private Button btnRefresh;
        private RichTextBox rtbInvoicePreview;
        private Button btnSaveInvoice;
        private Button btnPrintInvoice;

        public SellPady(int farmerID)
        {
            InitializeComponent();

            // Get connection string from configuration if available, otherwise use default
            try
            {
                this.connectionString = ConfigurationManager.ConnectionStrings["RiceMgmtApp.Properties.Settings.RiceProductionDB2ConnectionString"].ConnectionString;
            }
            catch
            {
                this.connectionString = "Server=DESKTOP-O6K3I3U\\SQLEXPRESS;Database=RiceProductionDB2;Integrated Security=True;";
            }

            this.farmerID = farmerID;

            // Initialize the UI components
            InitializeUIComponents();

            // Subscribe to load event
            this.Load += SellPady_Load;
        }

        private void InitializeUIComponents()
        {
            // Main panel
            panelMain = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White
            };

            // Title label
            lblTitle = new Label
            {
                Text = "Sell Paddy",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                Location = new Point(10, 10),
                AutoSize = true
            };

            // Stock panel
            panelStock = new Panel
            {
                Location = new Point(10, 50),
                Size = new Size(800, 200),
                BorderStyle = BorderStyle.FixedSingle
            };

            lblStockTitle = new Label
            {
                Text = "Your Available Stock",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(10, 10),
                AutoSize = true
            };

            dgvStock = new DataGridView
            {
                Location = new Point(10, 40),
                Size = new Size(780, 150),
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                ReadOnly = true,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false,
                BackgroundColor = Color.White
            };

            // Sale panel
            panelSale = new Panel
            {
                Location = new Point(10, 260),
                Size = new Size(800, 220),
                BorderStyle = BorderStyle.FixedSingle
            };

            lblSelectedStock = new Label
            {
                Text = "No stock selected",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.Navy,
                Location = new Point(10, 10),
                AutoSize = true
            };

            // Buyer Type
            lblBuyerType = new Label
            {
                Text = "Buyer Type:",
                Location = new Point(10, 40),
                AutoSize = true
            };

            cmbBuyerType = new ComboBox
            {
                Location = new Point(120, 40),
                Size = new Size(200, 25),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbBuyerType.Items.AddRange(new object[] { "Government", "Private" });

            // Buyer
            lblBuyer = new Label
            {
                Text = "Buyer:",
                Location = new Point(10, 70),
                AutoSize = true
            };

            cmbBuyer = new ComboBox
            {
                Location = new Point(120, 70),
                Size = new Size(200, 25),
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            // Price
            lblPrice = new Label
            {
                Text = "Price per kg:",
                Location = new Point(10, 100),
                AutoSize = true
            };

            txtSalePrice = new TextBox
            {
                Location = new Point(120, 100),
                Size = new Size(150, 25),
                TextAlign = HorizontalAlignment.Right
            };

            // Quantity
            lblQuantity = new Label
            {
                Text = "Quantity (kg):",
                Location = new Point(10, 130),
                AutoSize = true
            };

            txtQuantity = new TextBox
            {
                Location = new Point(120, 130),
                Size = new Size(150, 25),
                TextAlign = HorizontalAlignment.Right
            };

            // Total Amount
            lblTotalAmount = new Label
            {
                Text = "Total Amount:",
                Location = new Point(350, 100),
                AutoSize = true
            };

            txtTotalAmount = new TextBox
            {
                Location = new Point(450, 100),
                Size = new Size(150, 25),
                ReadOnly = true,
                TextAlign = HorizontalAlignment.Right
            };

            // Payment Status
            lblPaymentStatus = new Label
            {
                Text = "Payment Status:",
                Location = new Point(350, 130),
                AutoSize = true
            };

            cmbPaymentStatus = new ComboBox
            {
                Location = new Point(450, 130),
                Size = new Size(150, 25),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbPaymentStatus.Items.AddRange(new object[] { "Pending", "Completed", "Failed" });
            cmbPaymentStatus.SelectedIndex = 0;

            // Buttons
            btnProcessSale = new Button
            {
                Text = "Process Sale",
                Location = new Point(450, 170),
                Size = new Size(150, 30),
                BackColor = Color.Navy,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };

            btnClear = new Button
            {
                Text = "Clear",
                Location = new Point(350, 170),
                Size = new Size(80, 30)
            };

            btnRefresh = new Button
            {
                Text = "Refresh",
                Location = new Point(250, 170),
                Size = new Size(80, 30)
            };

            // Invoice panel
            panelInvoice = new Panel
            {
                Location = new Point(10, 490),
                Size = new Size(800, 300),
                BorderStyle = BorderStyle.FixedSingle,
                Visible = false
            };

            rtbInvoicePreview = new RichTextBox
            {
                Location = new Point(10, 10),
                Size = new Size(780, 240),
                ReadOnly = true,
                BorderStyle = BorderStyle.None
            };

            btnSaveInvoice = new Button
            {
                Text = "Save Invoice",
                Location = new Point(580, 260),
                Size = new Size(100, 30)
            };

            btnPrintInvoice = new Button
            {
                Text = "Print Invoice",
                Location = new Point(690, 260),
                Size = new Size(100, 30)
            };

            // Add controls to panels
            panelStock.Controls.Add(lblStockTitle);
            panelStock.Controls.Add(dgvStock);

            panelSale.Controls.Add(lblSelectedStock);
            panelSale.Controls.Add(lblBuyerType);
            panelSale.Controls.Add(cmbBuyerType);
            panelSale.Controls.Add(lblBuyer);
            panelSale.Controls.Add(cmbBuyer);
            panelSale.Controls.Add(lblPrice);
            panelSale.Controls.Add(txtSalePrice);
            panelSale.Controls.Add(lblQuantity);
            panelSale.Controls.Add(txtQuantity);
            panelSale.Controls.Add(lblTotalAmount);
            panelSale.Controls.Add(txtTotalAmount);
            panelSale.Controls.Add(lblPaymentStatus);
            panelSale.Controls.Add(cmbPaymentStatus);
            panelSale.Controls.Add(btnProcessSale);
            panelSale.Controls.Add(btnClear);
            panelSale.Controls.Add(btnRefresh);

            panelInvoice.Controls.Add(rtbInvoicePreview);
            panelInvoice.Controls.Add(btnSaveInvoice);
            panelInvoice.Controls.Add(btnPrintInvoice);

            // Add panels to main panel
            panelMain.Controls.Add(lblTitle);
            panelMain.Controls.Add(panelStock);
            panelMain.Controls.Add(panelSale);
            panelMain.Controls.Add(panelInvoice);

            // Add main panel to UserControl
            this.Controls.Add(panelMain);

            // Set up events
            dgvStock.CellClick += DgvStock_CellClick;
            cmbBuyerType.SelectedIndexChanged += CmbBuyerType_SelectedIndexChanged;
            txtQuantity.TextChanged += CalculateTotalAmount;
            txtSalePrice.TextChanged += CalculateTotalAmount;
            btnProcessSale.Click += BtnProcessSale_Click;
            btnClear.Click += BtnClear_Click;
            btnRefresh.Click += BtnRefresh_Click;
            btnSaveInvoice.Click += BtnSaveInvoice_Click;
            btnPrintInvoice.Click += BtnPrintInvoice_Click;
        }

        private void SellPady_Load(object sender, EventArgs e)
        {
            // Load farmer's stock
            LoadFarmerStock();

            // Reset UI
            ResetUI();
        }

        private void LoadFarmerStock()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"SELECT StockID, CropType, Quantity, LastUpdated 
                                    FROM Stock 
                                    WHERE FarmerID = @FarmerID 
                                    AND Quantity > 0";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@FarmerID", farmerID);

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvStock.DataSource = dt;

                    // Format the grid
                    if (dgvStock.Columns.Contains("StockID"))
                        dgvStock.Columns["StockID"].HeaderText = "Stock ID";
                    if (dgvStock.Columns.Contains("CropType"))
                        dgvStock.Columns["CropType"].HeaderText = "Crop Type";
                    if (dgvStock.Columns.Contains("Quantity"))
                        dgvStock.Columns["Quantity"].HeaderText = "Available Quantity (kg)";
                    if (dgvStock.Columns.Contains("LastUpdated"))
                        dgvStock.Columns["LastUpdated"].HeaderText = "Last Updated";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading stock data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvStock_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvStock.Rows[e.RowIndex];
                selectedStockID = Convert.ToInt32(row.Cells["StockID"].Value);
                string cropType = row.Cells["CropType"].Value.ToString();
                availableQuantity = Convert.ToDecimal(row.Cells["Quantity"].Value);

                lblSelectedStock.Text = $"Selected: {cropType} - {availableQuantity} kg available";
                txtQuantity.Text = availableQuantity.ToString();

                // Enable the sales panel inputs
                EnableSaleInputs(true);
            }
        }

        private void EnableSaleInputs(bool enable)
        {
            cmbBuyerType.Enabled = enable;
            cmbBuyer.Enabled = enable;
            txtSalePrice.Enabled = enable;
            txtQuantity.Enabled = enable;
            cmbPaymentStatus.Enabled = enable;
            btnProcessSale.Enabled = enable;
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
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    int roleId = buyerType == "Government" ? 3 : 4; // 3 for Government, 4 for Private buyers
                    string query = "SELECT UserID, FullName FROM Users WHERE RoleID = @RoleID";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@RoleID", roleId);

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
                MessageBox.Show($"Error loading buyer data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            MessageBox.Show("No government price found. Please contact the administrator.");
                            txtSalePrice.ReadOnly = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching government price: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void BtnProcessSale_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            // Process the sale
            ProcessSale();
        }

        private bool ValidateInputs()
        {
            if (selectedStockID == -1)
            {
                MessageBox.Show("Please select a stock item first.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbBuyerType.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a buyer type.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbBuyer.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a buyer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSalePrice.Text) || !decimal.TryParse(txtSalePrice.Text, out _))
            {
                MessageBox.Show("Please enter a valid sale price.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtQuantity.Text) || !decimal.TryParse(txtQuantity.Text, out decimal qty))
            {
                MessageBox.Show("Please enter a valid quantity.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (qty <= 0)
            {
                MessageBox.Show("Quantity must be greater than zero.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (qty > availableQuantity)
            {
                MessageBox.Show($"Quantity exceeds available stock. Maximum available: {availableQuantity} kg",
                                "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void ProcessSale()
        {
            int buyerId = Convert.ToInt32(cmbBuyer.SelectedValue);
            string buyerType = cmbBuyerType.SelectedItem.ToString();
            decimal salePrice = decimal.Parse(txtSalePrice.Text);
            decimal quantity = decimal.Parse(txtQuantity.Text);
            string paymentStatus = cmbPaymentStatus.SelectedItem.ToString();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlTransaction transaction = null;

                try
                {
                    conn.Open();
                    transaction = conn.BeginTransaction();

                    // 1. Insert sale record
                    string insertSaleQuery = @"INSERT INTO Sales (FarmerID, BuyerID, BuyerType, SalePrice, Quantity, PaymentStatus, SaleDate)
                                              VALUES (@FarmerID, @BuyerID, @BuyerType, @SalePrice, @Quantity, @PaymentStatus, @SaleDate);
                                              SELECT SCOPE_IDENTITY();";

                    int newSaleId;
                    using (SqlCommand cmd = new SqlCommand(insertSaleQuery, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@FarmerID", farmerID);
                        cmd.Parameters.AddWithValue("@BuyerID", buyerId);
                        cmd.Parameters.AddWithValue("@BuyerType", buyerType);
                        cmd.Parameters.AddWithValue("@SalePrice", salePrice);
                        cmd.Parameters.AddWithValue("@Quantity", quantity);
                        cmd.Parameters.AddWithValue("@PaymentStatus", paymentStatus);
                        cmd.Parameters.AddWithValue("@SaleDate", DateTime.Now);

                        newSaleId = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    // 2. Update stock quantity
                    string updateStockQuery = "UPDATE Stock SET Quantity = Quantity - @SaleQuantity, LastUpdated = GETDATE() WHERE StockID = @StockID";
                    using (SqlCommand cmd = new SqlCommand(updateStockQuery, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@SaleQuantity", quantity);
                        cmd.Parameters.AddWithValue("@StockID", selectedStockID);
                        cmd.ExecuteNonQuery();
                    }

                    // 3. Create invoice record
                    string invoicePath = $"Invoice_{newSaleId}_{DateTime.Now:yyyyMMdd}.pdf";
                    string insertInvoiceQuery = "INSERT INTO Invoices (SaleID, InvoicePath, CreatedAt) VALUES (@SaleID, @InvoicePath, GETDATE())";
                    using (SqlCommand cmd = new SqlCommand(insertInvoiceQuery, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@SaleID", newSaleId);
                        cmd.Parameters.AddWithValue("@InvoicePath", invoicePath);
                        cmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    MessageBox.Show("Sale processed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Generate invoice preview
                    GenerateInvoicePreview(newSaleId);
                    panelInvoice.Visible = true;

                    // Refresh stock data
                    LoadFarmerStock();
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();
                    MessageBox.Show($"Error processing sale: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@SaleID", saleId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
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

                                sb.AppendLine("\nBUYER INFORMATION:");
                                sb.AppendLine($"Type: {reader["BuyerType"]}");
                                sb.AppendLine($"Name: {reader["BuyerName"]}");
                                if (reader["BuyerContactNumber"] != DBNull.Value) sb.AppendLine($"ContactNumber: {reader["BuyerContactNumber"]}");
                                if (reader["BuyerEmail"] != DBNull.Value) sb.AppendLine($"Email: {reader["BuyerEmail"]}");

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
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating invoice: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSaveInvoice_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(rtbInvoicePreview.Text))
            {
                MessageBox.Show("No invoice to save.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SaveFileDialog saveDialog = new SaveFileDialog
            {
                Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*",
                DefaultExt = "txt",
                FileName = $"Invoice_{DateTime.Now:yyyyMMdd}"
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.WriteAllText(saveDialog.FileName, rtbInvoicePreview.Text);
                    MessageBox.Show("Invoice saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving invoice: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnPrintInvoice_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(rtbInvoicePreview.Text))
            {
                MessageBox.Show("No invoice to print.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Printing functionality would be implemented here.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // In a real application, implement printing here using a PrintDocument object
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ResetUI();
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadFarmerStock();
            ResetUI();
        }

        private void ResetUI()
        {
            selectedStockID = -1;
            availableQuantity = 0;
            lblSelectedStock.Text = "No stock selected";

            cmbBuyerType.SelectedIndex = -1;
            cmbBuyer.DataSource = null;
            txtSalePrice.Clear();
            txtQuantity.Clear();
            txtTotalAmount.Clear();
            cmbPaymentStatus.SelectedIndex = 0;

            panelInvoice.Visible = false;
            rtbInvoicePreview.Clear();

            EnableSaleInputs(false);
        }

       
    }
}