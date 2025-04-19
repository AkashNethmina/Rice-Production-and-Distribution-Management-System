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
    public partial class BuyPaddy : UserControl
    {
        private readonly string connectionString;
        private int buyerID;
        private int selectedStockID = -1;
        private int selectedFarmerID = -1;
        private decimal availableQuantity = 0;
        private string cropType = string.Empty;
      //  private string qualityGrade = string.Empty;

        // UI Controls
        private Panel panelMain;
        private Panel panelFarmers;
        private Panel panelStock;
        private Panel panelPurchase;
        private Panel panelInvoice;

        private DataGridView dgvFarmers;
        private DataGridView dgvStock;
        private Label lblTitle;
        private Label lblFarmersTitle;
        private Label lblStockTitle;
        private Label lblSelectedFarmer;
        private Label lblSelectedStock;
        private Label lblPrice;
        private Label lblQuantity;
        private Label lblTotalAmount;
        private Label lblPaymentStatus;
        private ComboBox cmbPaymentStatus;
        private TextBox txtSalePrice;
        private TextBox txtQuantity;
        private TextBox txtTotalAmount;
        private Button btnPurchase;
        private Button btnClear;
        private Button btnRefresh;
        private Button btnBack;
        private RichTextBox rtbInvoicePreview;
        private Button btnSaveInvoice;
        private Button btnPrintInvoice;

        public BuyPaddy(int buyerID)
        {
            // Get connection string from configuration if available, otherwise use default
            try
            {
                this.connectionString = ConfigurationManager.ConnectionStrings["RiceMgmtApp.Properties.Settings.RiceProductionDB2ConnectionString"].ConnectionString;
            }
            catch
            {
                this.connectionString = "Server=DESKTOP-O6K3I3U\\SQLEXPRESS;Database=RiceProductionDB2;Integrated Security=True;";
            }

            this.buyerID = buyerID;

            // Initialize the UI components
            InitializeComponent();
            InitializeUIComponents();

            // Subscribe to load event
            this.Load += BuyPaddy_Load;
        }

        // Added the missing InitializeComponent method
        //private void InitializeComponent()
        //{
        //    this.SuspendLayout();
        //    this.AutoScaleDimensions = new SizeF(8F, 16F);
        //    this.AutoScaleMode = AutoScaleMode.Font;
        //    this.Name = "BuyPaddy";
        //    this.Size = new Size(850, 800);
        //    this.ResumeLayout(false);
        //}

        private void InitializeUIComponents()
        {
            // Main panel
            panelMain = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                AutoScroll = true
            };

            // Title label
            lblTitle = new Label
            {
                Text = "Purchase Paddy",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 100, 0),
                Location = new Point(10, 10),
                AutoSize = true
            };

            // Farmers Panel
            panelFarmers = new Panel
            {
                Location = new Point(10, 50),
                Size = new Size(800, 200),
                BorderStyle = BorderStyle.FixedSingle
            };

            lblFarmersTitle = new Label
            {
                Text = "Available Farmers",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(10, 10),
                AutoSize = true
            };

            dgvFarmers = new DataGridView
            {
                Location = new Point(10, 40),
                Size = new Size(780, 150),
                AllowUserToAddRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                ReadOnly = true,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White
            };

            // Stock panel
            panelStock = new Panel
            {
                Location = new Point(10, 260),
                Size = new Size(800, 200),
                BorderStyle = BorderStyle.FixedSingle
            };

            lblStockTitle = new Label
            {
                Text = "Farmer's Available Stock",
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

            // Purchase panel
            panelPurchase = new Panel
            {
                Location = new Point(10, 470),
                Size = new Size(800, 220),
                BorderStyle = BorderStyle.FixedSingle,
                Visible = false
            };

            lblSelectedFarmer = new Label
            {
                Text = "Selected Farmer: None",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.Navy,
                Location = new Point(10, 10),
                AutoSize = true
            };

            lblSelectedStock = new Label
            {
                Text = "Selected Stock: None",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.Navy,
                Location = new Point(10, 40),
                AutoSize = true
            };

            // Price
            lblPrice = new Label
            {
                Text = "Price per kg:",
                Location = new Point(10, 70),
                AutoSize = true
            };

            txtSalePrice = new TextBox
            {
                Location = new Point(120, 70),
                Size = new Size(150, 25),
                TextAlign = HorizontalAlignment.Right
            };

            // Quantity
            lblQuantity = new Label
            {
                Text = "Quantity (kg):",
                Location = new Point(10, 100),
                AutoSize = true
            };

            txtQuantity = new TextBox
            {
                Location = new Point(120, 100),
                Size = new Size(150, 25),
                TextAlign = HorizontalAlignment.Right
            };

            // Total Amount
            lblTotalAmount = new Label
            {
                Text = "Total Amount:",
                Location = new Point(350, 70),
                AutoSize = true
            };

            txtTotalAmount = new TextBox
            {
                Location = new Point(450, 70),
                Size = new Size(150, 25),
                ReadOnly = true,
                TextAlign = HorizontalAlignment.Right
            };

            // Payment Status
            lblPaymentStatus = new Label
            {
                Text = "Payment Status:",
                Location = new Point(350, 100),
                AutoSize = true
            };

            cmbPaymentStatus = new ComboBox
            {
                Location = new Point(450, 100),
                Size = new Size(150, 25),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbPaymentStatus.Items.AddRange(new object[] { "Pending", "Completed" });
            cmbPaymentStatus.SelectedIndex = 0;

            // Buttons
            btnPurchase = new Button
            {
                Text = "Process Purchase",
                Location = new Point(450, 140),
                Size = new Size(150, 30),
                BackColor = Color.FromArgb(0, 120, 0),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };

            btnClear = new Button
            {
                Text = "Clear",
                Location = new Point(350, 140),
                Size = new Size(80, 30)
            };

            btnRefresh = new Button
            {
                Text = "Refresh",
                Location = new Point(250, 140),
                Size = new Size(80, 30)
            };

            btnBack = new Button
            {
                Text = "Back",
                Location = new Point(700, 25),
                Size = new Size(80, 30),
                BackColor = Color.FromArgb(220, 220, 220)
            };

            // Invoice panel
            panelInvoice = new Panel
            {
                Location = new Point(10, 700), // Changed to avoid overlap with purchase panel
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
            panelFarmers.Controls.Add(lblFarmersTitle);
            panelFarmers.Controls.Add(dgvFarmers);

            panelStock.Controls.Add(lblStockTitle);
            panelStock.Controls.Add(dgvStock);

            panelPurchase.Controls.Add(lblSelectedFarmer);
            panelPurchase.Controls.Add(lblSelectedStock);
            panelPurchase.Controls.Add(lblPrice);
            panelPurchase.Controls.Add(txtSalePrice);
            panelPurchase.Controls.Add(lblQuantity);
            panelPurchase.Controls.Add(txtQuantity);
            panelPurchase.Controls.Add(lblTotalAmount);
            panelPurchase.Controls.Add(txtTotalAmount);
            panelPurchase.Controls.Add(lblPaymentStatus);
            panelPurchase.Controls.Add(cmbPaymentStatus);
            panelPurchase.Controls.Add(btnPurchase);
            panelPurchase.Controls.Add(btnClear);
            panelPurchase.Controls.Add(btnRefresh);

            panelInvoice.Controls.Add(rtbInvoicePreview);
            panelInvoice.Controls.Add(btnSaveInvoice);
            panelInvoice.Controls.Add(btnPrintInvoice);

            // Add panels to main panel
            panelMain.Controls.Add(lblTitle);
            panelMain.Controls.Add(panelFarmers);
            panelMain.Controls.Add(panelStock);
            panelMain.Controls.Add(panelPurchase);
            panelMain.Controls.Add(panelInvoice);
            panelMain.Controls.Add(btnBack);

            // Add main panel to UserControl
            this.Controls.Add(panelMain);

            // Set up events
            dgvFarmers.SelectionChanged += DgvFarmers_SelectionChanged;
            dgvStock.CellClick += DgvStock_CellClick;
            txtQuantity.TextChanged += CalculateTotalAmount;
            txtSalePrice.TextChanged += CalculateTotalAmount;
            btnPurchase.Click += BtnPurchase_Click;
            btnClear.Click += BtnClear_Click;
            btnRefresh.Click += BtnRefresh_Click;
            btnBack.Click += BtnBack_Click;
            btnSaveInvoice.Click += BtnSaveInvoice_Click;
            btnPrintInvoice.Click += BtnPrintInvoice_Click;
        }

        private void BuyPaddy_Load(object sender, EventArgs e)
        {
            // Load farmers data
            LoadFarmers();

            // Reset UI
            ResetUI();
        }

        private void LoadFarmers()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"
                        SELECT UserID, FullName, ContactNumber, Email
                        FROM Users
                        WHERE RoleID = 2 AND Status = 'Active'
                        ORDER BY FullName";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvFarmers.DataSource = dt;

                    // Format the grid
                    if (dgvFarmers.Columns.Contains("UserID"))
                        dgvFarmers.Columns["UserID"].Visible = false;
                    if (dgvFarmers.Columns.Contains("FullName"))
                        dgvFarmers.Columns["FullName"].HeaderText = "Farmer Name";
                    if (dgvFarmers.Columns.Contains("ContactNumber"))
                        dgvFarmers.Columns["ContactNumber"].HeaderText = "Contact Number";
                    if (dgvFarmers.Columns.Contains("Email"))
                        dgvFarmers.Columns["Email"].HeaderText = "Email";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading farmers data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvFarmers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvFarmers.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvFarmers.SelectedRows[0];
                selectedFarmerID = Convert.ToInt32(row.Cells["UserID"].Value);
                string farmerName = row.Cells["FullName"].Value.ToString();

                lblSelectedFarmer.Text = $"Selected Farmer: {farmerName}";

                // Load the farmer's stock
                LoadFarmerStock(selectedFarmerID);

                // Reset stock selection
                selectedStockID = -1;
                lblSelectedStock.Text = "Selected Stock: None";

                // Clear purchase fields
                ClearPurchaseFields();

                // Hide purchase panel until stock is selected
                panelPurchase.Visible = false;
                panelInvoice.Visible = false;
            }
        }

        private void LoadFarmerStock(int farmerID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Fixed query to include QualityGrade
                    string query = @"SELECT StockID, CropType, Quantity, LastUpdated 
                                    FROM Stock 
                                    WHERE FarmerID = @FarmerID 
                                    AND Quantity > 0";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@FarmerID", farmerID);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvStock.DataSource = dt;

                    // Format the grid
                    if (dgvStock.Columns.Contains("StockID"))
                        dgvStock.Columns["StockID"].Visible = false;
                    if (dgvStock.Columns.Contains("CropType"))
                        dgvStock.Columns["CropType"].HeaderText = "Crop Type";
                    if (dgvStock.Columns.Contains("Quantity"))
                        dgvStock.Columns["Quantity"].HeaderText = "Available Quantity (kg)";
                    //if (dgvStock.Columns.Contains("QualityGrade"))
                    //    dgvStock.Columns["QualityGrade"].HeaderText = "Quality Grade";
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
                availableQuantity = Convert.ToDecimal(row.Cells["Quantity"].Value);
                cropType = row.Cells["CropType"].Value.ToString();

                // Check if QualityGrade column exists and has a value
                //if (row.Cells["QualityGrade"].Value != null && row.Cells["QualityGrade"].Value != DBNull.Value)
                //{
                //    qualityGrade = row.Cells["QualityGrade"].Value.ToString();
                //}
                //else
                //{
                //    qualityGrade = "Unknown"; // Default if quality grade is not available
                //}

                lblSelectedStock.Text = $"Selected: {cropType} - {availableQuantity} kg available - Grade ";
                txtQuantity.Text = availableQuantity.ToString();

                // Calculate suggested price based on quality grade
                decimal suggestedPrice = 0;
                //switch (qualityGrade)
                //{
                //    case "A": suggestedPrice = 25.00m; break;
                //    case "B": suggestedPrice = 22.50m; break;
                //    case "C": suggestedPrice = 20.00m; break;
                //    default: suggestedPrice = 18.00m; break;
                //}

                txtSalePrice.Text = suggestedPrice.ToString("0.00");

                // Show purchase panel
                panelPurchase.Visible = true;
                panelInvoice.Visible = false;
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

        private void BtnPurchase_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            // Process the purchase
            ProcessPurchase();
        }

        private bool ValidateInputs()
        {
            if (selectedFarmerID == -1)
            {
                MessageBox.Show("Please select a farmer first.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (selectedStockID == -1)
            {
                MessageBox.Show("Please select a stock item first.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSalePrice.Text) || !decimal.TryParse(txtSalePrice.Text, out decimal price) || price <= 0)
            {
                MessageBox.Show("Please enter a valid purchase price.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtQuantity.Text) || !decimal.TryParse(txtQuantity.Text, out decimal qty) || qty <= 0)
            {
                MessageBox.Show("Please enter a valid quantity.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void ProcessPurchase()
        {
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

                    // 1. Insert purchase record
                    string insertSaleQuery = @"INSERT INTO Sales (FarmerID, BuyerID, BuyerType, SalePrice, Quantity, PaymentStatus, SaleDate)
                                              VALUES (@FarmerID, @BuyerID, 'Private', @SalePrice, @Quantity, @PaymentStatus, @SaleDate);
                                              SELECT SCOPE_IDENTITY();";

                    int newSaleId;
                    using (SqlCommand cmd = new SqlCommand(insertSaleQuery, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@FarmerID", selectedFarmerID);
                        cmd.Parameters.AddWithValue("@BuyerID", buyerID);
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
                    MessageBox.Show("Purchase processed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Generate invoice preview
                    GenerateInvoicePreview(newSaleId);
                    panelInvoice.Visible = true;

                    // Refresh stock data
                    LoadFarmerStock(selectedFarmerID);
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();
                    MessageBox.Show($"Error processing purchase: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                                sb.AppendLine("PURCHASE INVOICE");
                                sb.AppendLine("=============================================");
                                sb.AppendLine($"Invoice #: INV-{saleId:D5}");
                                sb.AppendLine($"Date: {Convert.ToDateTime(reader["SaleDate"]):yyyy-MM-dd HH:mm}");
                                sb.AppendLine("=============================================");
                                sb.AppendLine("\nSELLER INFORMATION:");
                                sb.AppendLine($"Name: {reader["FarmerName"]}");
                                if (reader["FarmerContactNumber"] != DBNull.Value) sb.AppendLine($"Contact Number: {reader["FarmerContactNumber"]}");
                                if (reader["FarmerEmail"] != DBNull.Value) sb.AppendLine($"Email: {reader["FarmerEmail"]}");

                                sb.AppendLine("\nBUYER INFORMATION:");
                                sb.AppendLine($"Type: {reader["BuyerType"]}");
                                sb.AppendLine($"Name: {reader["BuyerName"]}");
                                if (reader["BuyerContactNumber"] != DBNull.Value) sb.AppendLine($"Contact Number: {reader["BuyerContactNumber"]}");
                                if (reader["BuyerEmail"] != DBNull.Value) sb.AppendLine($"Email: {reader["BuyerEmail"]}");

                                sb.AppendLine("\n=============================================");
                                sb.AppendLine("TRANSACTION DETAILS:");
                                sb.AppendLine("=============================================");
                                sb.AppendLine($"Product: {cropType}");
                               // sb.AppendLine($"Quality Grade: {qualityGrade}");
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
                FileName = $"Purchase_Invoice_{DateTime.Now:yyyyMMdd}"
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
            ClearPurchaseFields();
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            if (selectedFarmerID != -1)
            {
                LoadFarmerStock(selectedFarmerID);
            }
            else
            {
                LoadFarmers();
            }

            ResetUI();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            // Navigate back to the dashboard or previous screen
            this.Parent.Controls.Remove(this);
        }
        private void ResetUI()
        {
            // Reset stock selection
            selectedStockID = -1;
            availableQuantity = 0;
            lblSelectedStock.Text = "Selected Stock: None";

            // Clear purchase fields
            ClearPurchaseFields();

            // Hide panels
            panelPurchase.Visible = false;
            panelInvoice.Visible = false;
        }

        private void ClearPurchaseFields()
        {
            txtSalePrice.Text = "0.00";
            txtQuantity.Text = "0.00";
            txtTotalAmount.Text = "0.00";
            cmbPaymentStatus.SelectedIndex = 0;
        }
    }
}