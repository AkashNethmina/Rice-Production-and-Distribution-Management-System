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
        private TableLayoutPanel mainTableLayout;
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
            // Main TableLayoutPanel for responsive layout
            mainTableLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                ColumnCount = 1,
                RowCount = 4,
                Padding = new Padding(10),
                AutoSize = true
            };

            // Set row styles
            mainTableLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));  // Title
            mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));  // Stock panel
            mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));  // Sale panel
            mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));  // Invoice panel

            // Title label
            lblTitle = new Label
            {
                Text = "Sell Paddy",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                Dock = DockStyle.Top,
                AutoSize = true,
                Margin = new Padding(0, 0, 0, 10)
            };

            // Stock panel
            panelStock = new Panel
            {
                Dock = DockStyle.Fill,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(0, 0, 0, 10)
            };

            // Create a TableLayoutPanel for the stock section
            TableLayoutPanel stockTableLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 2,
                Padding = new Padding(10)
            };

            stockTableLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            stockTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            lblStockTitle = new Label
            {
                Text = "Your Available Stock",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Dock = DockStyle.Top,
                AutoSize = true,
                Margin = new Padding(0, 0, 0, 10)
            };

            dgvStock = new DataGridView
            {
                Dock = DockStyle.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                ReadOnly = true,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false,
                BackgroundColor = Color.White
            };

            stockTableLayout.Controls.Add(lblStockTitle, 0, 0);
            stockTableLayout.Controls.Add(dgvStock, 0, 1);
            panelStock.Controls.Add(stockTableLayout);

            // Sale panel
            panelSale = new Panel
            {
                Dock = DockStyle.Fill,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(0, 0, 0, 10)
            };

            // Create a TableLayoutPanel for the sale section
            TableLayoutPanel saleTableLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 4,
                RowCount = 6,
                Padding = new Padding(10)
            };

            // Configure columns for responsiveness
            saleTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));  // Labels
            saleTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));  // Controls
            saleTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));  // Second set of labels
            saleTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));  // Second set of controls

            // Configure rows
            saleTableLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));  // Selected stock
            saleTableLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));  // Buyer type
            saleTableLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));  // Buyer
            saleTableLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));  // Price/Total Amount
            saleTableLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));  // Quantity/Payment Status
            saleTableLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));  // Buttons

            lblSelectedStock = new Label
            {
                Text = "No stock selected",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.Navy,
                Dock = DockStyle.Fill,
                AutoSize = true
            };

            // Set the selected stock label to span all columns
            saleTableLayout.Controls.Add(lblSelectedStock, 0, 0);
            saleTableLayout.SetColumnSpan(lblSelectedStock, 4);

            // Buyer Type
            lblBuyerType = new Label
            {
                Text = "Buyer Type:",
                Dock = DockStyle.Fill,
                AutoSize = true,
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top
            };

            cmbBuyerType = new ComboBox
            {
                Dock = DockStyle.Fill,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top
            };
            cmbBuyerType.Items.AddRange(new object[] { "Government", "Private" });

            // Buyer
            lblBuyer = new Label
            {
                Text = "Buyer:",
                Dock = DockStyle.Fill,
                AutoSize = true,
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top
            };

            cmbBuyer = new ComboBox
            {
                Dock = DockStyle.Fill,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top
            };

            // Price
            lblPrice = new Label
            {
                Text = "Price per kg:",
                Dock = DockStyle.Fill,
                AutoSize = true,
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top
            };

            txtSalePrice = new TextBox
            {
                Dock = DockStyle.Fill,
                TextAlign = HorizontalAlignment.Right,
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top
            };

            // Total Amount
            lblTotalAmount = new Label
            {
                Text = "Total Amount:",
                Dock = DockStyle.Fill,
                AutoSize = true,
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top
            };

            txtTotalAmount = new TextBox
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                TextAlign = HorizontalAlignment.Right,
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top
            };

            // Quantity
            lblQuantity = new Label
            {
                Text = "Quantity (kg):",
                Dock = DockStyle.Fill,
                AutoSize = true,
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top
            };

            txtQuantity = new TextBox
            {
                Dock = DockStyle.Fill,
                TextAlign = HorizontalAlignment.Right,
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top
            };

            // Payment Status
            lblPaymentStatus = new Label
            {
                Text = "Payment Status:",
                Dock = DockStyle.Fill,
                AutoSize = true,
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top
            };

            cmbPaymentStatus = new ComboBox
            {
                Dock = DockStyle.Fill,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top
            };
            cmbPaymentStatus.Items.AddRange(new object[] { "Pending", "Completed", "Failed" });
            cmbPaymentStatus.SelectedIndex = 0;

            // FlowLayoutPanel for buttons to ensure proper alignment
            FlowLayoutPanel buttonPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.RightToLeft,
                WrapContents = false,
                AutoSize = true
            };

            // Buttons
            btnProcessSale = new Button
            {
                Text = "Process Sale",
                BackColor = Color.Navy,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Size = new Size(150, 30),
                Margin = new Padding(5)
            };

            btnClear = new Button
            {
                Text = "Clear",
                Size = new Size(80, 30),
                Margin = new Padding(5)
            };

            btnRefresh = new Button
            {
                Text = "Refresh",
                Size = new Size(80, 30),
                Margin = new Padding(5)
            };

            buttonPanel.Controls.Add(btnProcessSale);
            buttonPanel.Controls.Add(btnClear);
            buttonPanel.Controls.Add(btnRefresh);

            // Add controls to saleTableLayout
            saleTableLayout.Controls.Add(lblBuyerType, 0, 1);
            saleTableLayout.Controls.Add(cmbBuyerType, 1, 1);
            saleTableLayout.Controls.Add(lblBuyer, 0, 2);
            saleTableLayout.Controls.Add(cmbBuyer, 1, 2);
            saleTableLayout.Controls.Add(lblPrice, 0, 3);
            saleTableLayout.Controls.Add(txtSalePrice, 1, 3);
            saleTableLayout.Controls.Add(lblQuantity, 0, 4);
            saleTableLayout.Controls.Add(txtQuantity, 1, 4);
            saleTableLayout.Controls.Add(lblTotalAmount, 2, 3);
            saleTableLayout.Controls.Add(txtTotalAmount, 3, 3);
            saleTableLayout.Controls.Add(lblPaymentStatus, 2, 4);
            saleTableLayout.Controls.Add(cmbPaymentStatus, 3, 4);
            saleTableLayout.Controls.Add(buttonPanel, 0, 5);
            saleTableLayout.SetColumnSpan(buttonPanel, 4);

            panelSale.Controls.Add(saleTableLayout);

            // Invoice panel
            panelInvoice = new Panel
            {
                Dock = DockStyle.Fill,
                BorderStyle = BorderStyle.FixedSingle,
                Visible = false
            };

            // Create a TableLayoutPanel for the invoice section
            TableLayoutPanel invoiceTableLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 2,
                Padding = new Padding(10)
            };

            invoiceTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 85F));
            invoiceTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));

            rtbInvoicePreview = new RichTextBox
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                BorderStyle = BorderStyle.None
            };

            FlowLayoutPanel invoiceButtonPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.RightToLeft,
                WrapContents = false,
                AutoSize = true
            };

            btnSaveInvoice = new Button
            {
                Text = "Save Invoice",
                Size = new Size(100, 30),
                Margin = new Padding(5)
            };

            btnPrintInvoice = new Button
            {
                Text = "Print Invoice",
                Size = new Size(100, 30),
                Margin = new Padding(5)
            };

            invoiceButtonPanel.Controls.Add(btnPrintInvoice);
            invoiceButtonPanel.Controls.Add(btnSaveInvoice);

            invoiceTableLayout.Controls.Add(rtbInvoicePreview, 0, 0);
            invoiceTableLayout.Controls.Add(invoiceButtonPanel, 0, 1);

            panelInvoice.Controls.Add(invoiceTableLayout);

            // Add panels to mainTableLayout
            mainTableLayout.Controls.Add(lblTitle, 0, 0);
            mainTableLayout.Controls.Add(panelStock, 0, 1);
            mainTableLayout.Controls.Add(panelSale, 0, 2);
            mainTableLayout.Controls.Add(panelInvoice, 0, 3);

            // Add mainTableLayout to UserControl
            this.Controls.Add(mainTableLayout);

            // Handle form resize events
            this.Resize += SellPady_Resize;

            // Set up other events
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

        private void SellPady_Resize(object sender, EventArgs e)
        {
            // Call the resize controls method to handle any specific resizing logic
            ResizeControls();
        }

        private void ResizeControls()
        {
            // Adjust column widths in the DataGridView to fit available space
            if (dgvStock != null && dgvStock.Columns.Count > 0)
            {
                // Ensure column widths are proportional to the grid width
                foreach (DataGridViewColumn col in dgvStock.Columns)
                {
                    // You can customize column width percentages here
                    // For example, make the first column narrower if it contains IDs
                    if (col.Index == 0)
                    {
                        col.Width = (int)(dgvStock.Width * 0.1); // 10% width for ID column
                    }
                    else
                    {
                        // Distribute remaining columns evenly
                        int remainingColumns = dgvStock.Columns.Count - 1;
                        if (remainingColumns > 0)
                        {
                            col.Width = (int)(dgvStock.Width * 0.9 / remainingColumns);
                        }
                    }
                }
            }

            // Adjust minimum sizes for text inputs if the form becomes very small
            int minTextBoxWidth = 100;
            if (txtSalePrice != null && txtSalePrice.Width < minTextBoxWidth)
            {
                txtSalePrice.MinimumSize = new Size(minTextBoxWidth, txtSalePrice.Height);
            }

            if (txtQuantity != null && txtQuantity.Width < minTextBoxWidth)
            {
                txtQuantity.MinimumSize = new Size(minTextBoxWidth, txtQuantity.Height);
            }

            if (txtTotalAmount != null && txtTotalAmount.Width < minTextBoxWidth)
            {
                txtTotalAmount.MinimumSize = new Size(minTextBoxWidth, txtTotalAmount.Height);
            }

            // Adjust font size based on form width for better readability
            if (this.Width < 600)
            {
                // Smaller font for small form size
                if (lblTitle != null)
                    lblTitle.Font = new Font("Segoe UI", 14, FontStyle.Bold);

                if (lblStockTitle != null)
                    lblStockTitle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            }
            else
            {
                // Default font for normal form size
                if (lblTitle != null)
                    lblTitle.Font = new Font("Segoe UI", 16, FontStyle.Bold);

                if (lblStockTitle != null)
                    lblStockTitle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            }

            // Ensure buttons maintain minimum usable sizes
            int minButtonWidth = 70;
            if (btnProcessSale != null && btnProcessSale.Width < 130)
            {
                btnProcessSale.MinimumSize = new Size(130, btnProcessSale.Height);
            }

            if (btnClear != null && btnClear.Width < minButtonWidth)
            {
                btnClear.MinimumSize = new Size(minButtonWidth, btnClear.Height);
            }

            if (btnRefresh != null && btnRefresh.Width < minButtonWidth)
            {
                btnRefresh.MinimumSize = new Size(minButtonWidth, btnRefresh.Height);
            }

            // Force layout update to apply changes
            this.PerformLayout();
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