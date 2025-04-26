using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;

namespace RiceMgmtApp
{
    public partial class RequestPaddy : UserControl
    {
        private readonly string connectionString = "Server=DESKTOP-O6K3I3U\\SQLEXPRESS;Database=RiceProductionDB2;Integrated Security=True;";
        private int currentUserID;
        private int currentUserRole;

        public RequestPaddy(int userID, int roleID)
        {
            InitializeComponent();
            currentUserID = userID;
            currentUserRole = roleID;
        }

        private void RequestPaddy_Load(object sender, EventArgs e)
        {
            SetupUI();
            LoadData();
        }

        private void SetupUI()
        {
            // Main layout panel
            TableLayoutPanel mainLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 2,
                Padding = new Padding(20),
            };
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 300));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            this.Controls.Add(mainLayout);

            // Request form panel
            Panel requestFormPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BorderStyle = BorderStyle.FixedSingle,
            };
            mainLayout.Controls.Add(requestFormPanel, 0, 0);

            // Requests data grid panel
            Panel requestsGridPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BorderStyle = BorderStyle.FixedSingle,
            };
            mainLayout.Controls.Add(requestsGridPanel, 0, 1);

            // Request Form Elements
            Label headerLabel = new Label
            {
                Text = "Create Paddy Request",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(20, 20)
            };
            requestFormPanel.Controls.Add(headerLabel);

            // Only set up the create request form for Private Buyers (role 4)
            if (currentUserRole == 4) // Private Buyer
            {
                SetupCreateRequestForm(requestFormPanel);
            }
            else if (currentUserRole == 2) // Farmer
            {
                SetupFarmerRequestView(requestFormPanel);
            }

            // Setup DataGridView for all users to see their requests
            SetupRequestsDataGrid(requestsGridPanel);
        }

        private void SetupCreateRequestForm(Panel panel)
        {
            int yPos = 70;
            int xPos = 20;
            int labelWidth = 130;
            int controlWidth = 200;
            int height = 26;
            int spacing = 35;

            // Farmer dropdown
            Label lblFarmer = new Label
            {
                Text = "Select Farmer:",
                Location = new Point(xPos, yPos),
                Size = new Size(labelWidth, height),
                TextAlign = ContentAlignment.MiddleRight
            };
            panel.Controls.Add(lblFarmer);

            ComboBox cmbFarmers = new ComboBox
            {
                Name = "cmbFarmers",
                Location = new Point(xPos + labelWidth + 10, yPos),
                Size = new Size(controlWidth, height),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            panel.Controls.Add(cmbFarmers);
            LoadFarmers(cmbFarmers);

            // Stock dropdown - will be populated based on selected farmer
            yPos += spacing;
            Label lblStock = new Label
            {
                Text = "Select Stock:",
                Location = new Point(xPos, yPos),
                Size = new Size(labelWidth, height),
                TextAlign = ContentAlignment.MiddleRight
            };
            panel.Controls.Add(lblStock);

            ComboBox cmbStock = new ComboBox
            {
                Name = "cmbStock",
                Location = new Point(xPos + labelWidth + 10, yPos),
                Size = new Size(controlWidth, height),
                DropDownStyle = ComboBoxStyle.DropDownList,
                Enabled = false
            };
            panel.Controls.Add(cmbStock);

            // Available quantity label
            yPos += spacing;
            Label lblAvailableQty = new Label
            {
                Text = "Available Quantity:",
                Location = new Point(xPos, yPos),
                Size = new Size(labelWidth, height),
                TextAlign = ContentAlignment.MiddleRight
            };
            panel.Controls.Add(lblAvailableQty);

            Label lblAvailableQtyValue = new Label
            {
                Name = "lblAvailableQtyValue",
                Text = "0.00",
                Location = new Point(xPos + labelWidth + 10, yPos),
                Size = new Size(controlWidth, height),
                BorderStyle = BorderStyle.FixedSingle,
                TextAlign = ContentAlignment.MiddleLeft
            };
            panel.Controls.Add(lblAvailableQtyValue);

            // Request quantity
            yPos += spacing;
            Label lblRequestQty = new Label
            {
                Text = "Request Quantity:",
                Location = new Point(xPos, yPos),
                Size = new Size(labelWidth, height),
                TextAlign = ContentAlignment.MiddleRight
            };
            panel.Controls.Add(lblRequestQty);

            TextBox txtRequestQty = new TextBox
            {
                Name = "txtRequestQty",
                Location = new Point(xPos + labelWidth + 10, yPos),
                Size = new Size(controlWidth, height),
                TextAlign = HorizontalAlignment.Right
            };
            panel.Controls.Add(txtRequestQty);

            // Request price
            yPos += spacing;
            Label lblRequestPrice = new Label
            {
                Text = "Offer Price per Unit:",
                Location = new Point(xPos, yPos),
                Size = new Size(labelWidth, height),
                TextAlign = ContentAlignment.MiddleRight
            };
            panel.Controls.Add(lblRequestPrice);

            TextBox txtRequestPrice = new TextBox
            {
                Name = "txtRequestPrice",
                Location = new Point(xPos + labelWidth + 10, yPos),
                Size = new Size(controlWidth, height),
                TextAlign = HorizontalAlignment.Right
            };
            panel.Controls.Add(txtRequestPrice);

            // Submit button
            yPos += spacing;
            Button btnSubmitRequest = new Button
            {
                Text = "Submit Request",
                Location = new Point(xPos + labelWidth + 10, yPos),
                Size = new Size(controlWidth, height + 10),
                BackColor = Color.ForestGreen,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            btnSubmitRequest.Click += BtnSubmitRequest_Click;
            panel.Controls.Add(btnSubmitRequest);

            // Add event handlers
            cmbFarmers.SelectedIndexChanged += (s, e) =>
            {
                if (cmbFarmers.SelectedItem != null)
                {
                    var selectedFarmer = (FarmerItem)cmbFarmers.SelectedItem;
                    LoadFarmerStock(cmbStock, selectedFarmer.FarmerID);
                    cmbStock.Enabled = true;
                }
                else
                {
                    cmbStock.DataSource = null;
                    cmbStock.Enabled = false;
                    lblAvailableQtyValue.Text = "0.00";
                }
            };

            cmbStock.SelectedIndexChanged += (s, e) =>
            {
                if (cmbStock.SelectedItem != null)
                {
                    var selectedStock = (StockItem)cmbStock.SelectedItem;
                    lblAvailableQtyValue.Text = selectedStock.Quantity.ToString("0.00");
                }
                else
                {
                    lblAvailableQtyValue.Text = "0.00";
                }
            };

            txtRequestQty.KeyPress += (s, e) =>
            {
                // Allow only digits, decimal point, and control characters
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                {
                    e.Handled = true;
                }

                // Allow only one decimal point
                if (e.KeyChar == '.' && ((TextBox)s).Text.Contains('.'))
                {
                    e.Handled = true;
                }
            };

            txtRequestPrice.KeyPress += (s, e) =>
            {
                // Allow only digits, decimal point, and control characters
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                {
                    e.Handled = true;
                }

                // Allow only one decimal point
                if (e.KeyChar == '.' && ((TextBox)s).Text.Contains('.'))
                {
                    e.Handled = true;
                }
            };
        }

        private void SetupFarmerRequestView(Panel panel)
        {
            int yPos = 70;
            int xPos = 20;
            int labelWidth = 130;
            int controlWidth = 200;
            int height = 26;
            int spacing = 35;

            // Farmers see pending requests to them and can approve/reject
            Label lblMessage = new Label
            {
                Text = "Manage Incoming Paddy Requests",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(xPos, yPos)
            };
            panel.Controls.Add(lblMessage);

            // Add controls specific to farmers for managing requests
            yPos += spacing + 10;
            Label lblInstructions = new Label
            {
                Text = "Select a request below to approve or reject it.",
                Location = new Point(xPos, yPos),
                AutoSize = true
            };
            panel.Controls.Add(lblInstructions);

            // Add action buttons (will be enabled when a request is selected)
            yPos += spacing;
            Button btnApprove = new Button
            {
                Name = "btnApprove",
                Text = "Approve Selected Request",
                Location = new Point(xPos, yPos),
                Size = new Size(180, height + 10),
                Enabled = false,
                BackColor = Color.ForestGreen,
                ForeColor = Color.White
            };
            panel.Controls.Add(btnApprove);

            Button btnReject = new Button
            {
                Name = "btnReject",
                Text = "Reject Selected Request",
                Location = new Point(xPos + 200, yPos),
                Size = new Size(180, height + 10),
                Enabled = false,
                BackColor = Color.Firebrick,
                ForeColor = Color.White
            };
            panel.Controls.Add(btnReject);

            // Add event handlers
            btnApprove.Click += BtnApprove_Click;
            btnReject.Click += BtnReject_Click;
        }

        private void SetupRequestsDataGrid(Panel panel)
        {
            Label headerLabel = new Label
            {
                Text = currentUserRole == 4 ? "My Paddy Requests" : "Incoming Paddy Requests",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(20, 20)
            };
            panel.Controls.Add(headerLabel);

            DataGridView dgvRequests = new DataGridView
            {
                Name = "dgvRequests",
                Location = new Point(20, 60),
                Size = new Size(panel.Width - 40, panel.Height - 80),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToOrderColumns = true,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false
            };
            panel.Controls.Add(dgvRequests);

            // Add event handler for selection change
            dgvRequests.SelectionChanged += DgvRequests_SelectionChanged;
        }

        private void LoadData()
        {
            if (currentUserRole == 4) // Private Buyer
            {
                LoadPrivateBuyerRequests();
            }
            else if (currentUserRole == 2) // Farmer
            {
                LoadFarmerRequests();
            }
        }

        private void LoadFarmers(ComboBox comboBox)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT UserID, FullName FROM Users WHERE RoleID = 2 AND Status = 'Active'";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            List<FarmerItem> farmers = new List<FarmerItem>();

                            while (reader.Read())
                            {
                                farmers.Add(new FarmerItem
                                {
                                    FarmerID = reader.GetInt32(0),
                                    FarmerName = reader.GetString(1)
                                });
                            }

                            comboBox.DisplayMember = "FarmerName";
                            comboBox.ValueMember = "FarmerID";
                            comboBox.DataSource = farmers;
                            comboBox.SelectedIndex = -1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading farmers: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadFarmerStock(ComboBox comboBox, int farmerID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT StockID, CropType, Quantity FROM Stock WHERE FarmerID = @FarmerID AND Quantity > 0";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FarmerID", farmerID);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            List<StockItem> stocks = new List<StockItem>();

                            while (reader.Read())
                            {
                                stocks.Add(new StockItem
                                {
                                    StockID = reader.GetInt32(0),
                                    CropType = reader.GetString(1),
                                    Quantity = reader.GetDecimal(2)
                                });
                            }

                            comboBox.DisplayMember = "DisplayText";
                            comboBox.ValueMember = "StockID";
                            comboBox.DataSource = stocks;
                            comboBox.SelectedIndex = -1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading stock: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPrivateBuyerRequests()
        {
            try
            {
                DataGridView dgvRequests = this.Controls.Find("dgvRequests", true).FirstOrDefault() as DataGridView;
                if (dgvRequests == null) return;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT r.RequestPaddyID, u.FullName AS FarmerName, s.CropType, 
                               r.Quantity, r.RequestPrice, r.RequestStatus, r.RequestDate
                        FROM RequestPaddy r
                        INNER JOIN Users u ON r.FarmerID = u.UserID
                        INNER JOIN Stock s ON r.StockID = s.StockID
                        WHERE r.BuyerID = @BuyerID OR 
                              (r.BuyerID IS NULL AND r.BuyerType = 'Private' AND r.RequestStatus = 'Pending')
                        ORDER BY r.RequestDate DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@BuyerID", currentUserID);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dgvRequests.DataSource = dt;

                        // Format columns
                        if (dgvRequests.Columns.Contains("RequestPaddyID"))
                            dgvRequests.Columns["RequestPaddyID"].Visible = false;

                        if (dgvRequests.Columns.Contains("RequestPrice"))
                            dgvRequests.Columns["RequestPrice"].DefaultCellStyle.Format = "N2";

                        if (dgvRequests.Columns.Contains("Quantity"))
                            dgvRequests.Columns["Quantity"].DefaultCellStyle.Format = "N2";

                        if (dgvRequests.Columns.Contains("RequestDate"))
                            dgvRequests.Columns["RequestDate"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm";

                        // Set column headers
                        if (dgvRequests.Columns.Contains("FarmerName"))
                            dgvRequests.Columns["FarmerName"].HeaderText = "Farmer";

                        if (dgvRequests.Columns.Contains("CropType"))
                            dgvRequests.Columns["CropType"].HeaderText = "Crop Type";

                        if (dgvRequests.Columns.Contains("Quantity"))
                            dgvRequests.Columns["Quantity"].HeaderText = "Quantity (kg)";

                        if (dgvRequests.Columns.Contains("RequestPrice"))
                            dgvRequests.Columns["RequestPrice"].HeaderText = "Price per Unit";

                        if (dgvRequests.Columns.Contains("RequestStatus"))
                            dgvRequests.Columns["RequestStatus"].HeaderText = "Status";

                        if (dgvRequests.Columns.Contains("RequestDate"))
                            dgvRequests.Columns["RequestDate"].HeaderText = "Request Date";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading requests: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadFarmerRequests()
        {
            try
            {
                DataGridView dgvRequests = this.Controls.Find("dgvRequests", true).FirstOrDefault() as DataGridView;
                if (dgvRequests == null) return;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT
    r.RequestPaddyID, 
    u.FullName AS BuyerName, 
    s.CropType, 
    r.Quantity, 
    r.RequestPrice, 
    r.RequestStatus, 
    r.RequestDate
FROM RequestPaddy r
INNER JOIN Users u ON r.BuyerID = u.UserID
INNER JOIN Stock s ON r.StockID = s.StockID
WHERE r.FarmerID = @FarmerID
ORDER BY r.RequestDate DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FarmerID", currentUserID);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dgvRequests.DataSource = dt;

                        // Format columns
                        if (dgvRequests.Columns.Contains("RequestPaddyID"))
                            dgvRequests.Columns["RequestPaddyID"].Visible = false;

                        if (dgvRequests.Columns.Contains("RequestPrice"))
                            dgvRequests.Columns["RequestPrice"].DefaultCellStyle.Format = "N2";

                        if (dgvRequests.Columns.Contains("Quantity"))
                            dgvRequests.Columns["Quantity"].DefaultCellStyle.Format = "N2";

                        if (dgvRequests.Columns.Contains("RequestDate"))
                            dgvRequests.Columns["RequestDate"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm";

                        // Add color coding based on status
                        dgvRequests.CellFormatting += (s, e) => {
                            if (e.ColumnIndex == dgvRequests.Columns["RequestStatus"].Index)
                            {
                                string status = e.Value?.ToString();
                                if (status == "Pending")
                                    e.CellStyle.BackColor = Color.LightYellow;
                                else if (status == "Under Review")
                                    e.CellStyle.BackColor = Color.LightBlue;
                                else if (status == "Approved")
                                    e.CellStyle.BackColor = Color.LightGreen;
                                else if (status == "Rejected")
                                    e.CellStyle.BackColor = Color.LightPink;
                            }
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading requests: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSubmitRequest_Click(object sender, EventArgs e)
        {
            ComboBox cmbFarmers = this.Controls.Find("cmbFarmers", true).FirstOrDefault() as ComboBox;
            ComboBox cmbStock = this.Controls.Find("cmbStock", true).FirstOrDefault() as ComboBox;
            TextBox txtRequestQty = this.Controls.Find("txtRequestQty", true).FirstOrDefault() as TextBox;
            TextBox txtRequestPrice = this.Controls.Find("txtRequestPrice", true).FirstOrDefault() as TextBox;
            Label lblAvailableQtyValue = this.Controls.Find("lblAvailableQtyValue", true).FirstOrDefault() as Label;

            if (cmbFarmers?.SelectedItem == null)
            {
                MessageBox.Show("Please select a farmer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbStock?.SelectedItem == null)
            {
                MessageBox.Show("Please select a stock item.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtRequestQty?.Text))
            {
                MessageBox.Show("Please enter a request quantity.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtRequestPrice?.Text))
            {
                MessageBox.Show("Please enter a request price.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtRequestQty.Text, out decimal requestQty) || requestQty <= 0)
            {
                MessageBox.Show("Please enter a valid positive quantity.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtRequestPrice.Text, out decimal requestPrice) || requestPrice <= 0)
            {
                MessageBox.Show("Please enter a valid positive price.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(lblAvailableQtyValue?.Text, out decimal availableQty))
            {
                MessageBox.Show("Available quantity is invalid.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (requestQty > availableQty)
            {
                MessageBox.Show($"Requested quantity exceeds available stock ({availableQty}).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int farmerID = ((FarmerItem)cmbFarmers.SelectedItem).FarmerID;
            int stockID = ((StockItem)cmbStock.SelectedItem).StockID;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Validate user
                    string checkQuery = "SELECT COUNT(*) FROM Users WHERE UserID = @UserID";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@UserID", currentUserID);
                        int userExists = (int)checkCmd.ExecuteScalar();

                        if (userExists == 0)
                        {
                            MessageBox.Show("User does not exist in the system. Cannot submit request.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Insert request
                    string query = @"
                INSERT INTO RequestPaddy (FarmerID, StockID, BuyerID, BuyerType, RequestPrice, Quantity)
                VALUES (@FarmerID, @StockID, @BuyerID, 'Private', @RequestPrice, @Quantity)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FarmerID", farmerID);
                        cmd.Parameters.AddWithValue("@StockID", stockID);
                        cmd.Parameters.AddWithValue("@BuyerID", currentUserID); // <-- This was missing
                        cmd.Parameters.AddWithValue("@RequestPrice", requestPrice);
                        cmd.Parameters.AddWithValue("@Quantity", requestQty);

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Request submitted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Reset form
                            cmbFarmers.SelectedIndex = -1;
                            cmbStock.DataSource = null;
                            cmbStock.Enabled = false;
                            txtRequestQty.Clear();
                            txtRequestPrice.Clear();
                            lblAvailableQtyValue.Text = "0.00";

                            LoadPrivateBuyerRequests();
                        }
                        else
                        {
                            MessageBox.Show("Failed to submit request.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error submitting request: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void DgvRequests_SelectionChanged(object sender, EventArgs e)
        {
            if (currentUserRole == 2) // Farmer
            {
                DataGridView dgvRequests = sender as DataGridView;
                Button btnApprove = this.Controls.Find("btnApprove", true).FirstOrDefault() as Button;
                Button btnReject = this.Controls.Find("btnReject", true).FirstOrDefault() as Button;

                if (dgvRequests != null && dgvRequests.SelectedRows.Count > 0 && btnApprove != null && btnReject != null)
                {
                    DataGridViewRow row = dgvRequests.SelectedRows[0];
                    string status = row.Cells["RequestStatus"].Value.ToString();

                    // Enable buttons only for Pending status
                    btnApprove.Enabled = (status == "Pending");
                    btnReject.Enabled = (status == "Pending");
                }
                else if (btnApprove != null && btnReject != null)
                {
                    btnApprove.Enabled = false;
                    btnReject.Enabled = false;
                }
            }
        }

        private void BtnApprove_Click(object sender, EventArgs e)
        {
            DataGridView dgvRequests = this.Controls.Find("dgvRequests", true).FirstOrDefault() as DataGridView;
            if (dgvRequests == null || dgvRequests.SelectedRows.Count == 0) return;

            int requestID = Convert.ToInt32(dgvRequests.SelectedRows[0].Cells["RequestPaddyID"].Value);
            UpdateRequestStatus(requestID, "Approved");
        }

        private void BtnReject_Click(object sender, EventArgs e)
        {
            DataGridView dgvRequests = this.Controls.Find("dgvRequests", true).FirstOrDefault() as DataGridView;
            if (dgvRequests == null || dgvRequests.SelectedRows.Count == 0) return;

            int requestID = Convert.ToInt32(dgvRequests.SelectedRows[0].Cells["RequestPaddyID"].Value);
            UpdateRequestStatus(requestID, "Rejected");
        }

        private void UpdateRequestStatus(int requestID, string status)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE RequestPaddy SET RequestStatus = @Status WHERE RequestPaddyID = @RequestID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Status", status);
                        cmd.Parameters.AddWithValue("@RequestID", requestID);

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show($"Request {status.ToLower()} successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // If approved, update stock quantity
                            if (status == "Approved")
                            {
                                UpdateStockQuantity(requestID);
                            }

                            // Reload data grid
                            LoadFarmerRequests();
                        }
                        else
                        {
                            MessageBox.Show($"Failed to {status.ToLower()} request.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating request: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateStockQuantity(int requestID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // First, get the request details
                    string getRequestQuery = @"
                        SELECT StockID, Quantity 
                        FROM RequestPaddy 
                        WHERE RequestPaddyID = @RequestID";

                    int stockID = 0;
                    decimal requestQty = 0;

                    using (SqlCommand cmd = new SqlCommand(getRequestQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@RequestID", requestID);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                stockID = reader.GetInt32(0);
                                requestQty = reader.GetDecimal(1);
                            }
                        }
                    }
                    if (stockID > 0 && requestQty > 0)
                    {
                        string updateStockQuery = @"
                            UPDATE Stock 
                            SET Quantity = Quantity - @RequestQty,
                                LastUpdated = GETDATE()
                            WHERE StockID = @StockID AND Quantity >= @RequestQty";

                        using (SqlCommand cmd = new SqlCommand(updateStockQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@StockID", stockID);
                            cmd.Parameters.AddWithValue("@RequestQty", requestQty);

                            int result = cmd.ExecuteNonQuery();

                            if (result <= 0)
                            {
                                MessageBox.Show("Failed to update stock quantity. There may not be enough stock available.",
                                                "Stock Update Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating stock quantity: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Helper classes for ComboBox items
        private class FarmerItem
        {
            public int FarmerID { get; set; }
            public string FarmerName { get; set; }

            public override string ToString()
            {
                return FarmerName;
            }
        }

        private class StockItem
        {
            public int StockID { get; set; }
            public string CropType { get; set; }
            public decimal Quantity { get; set; }

            public string DisplayText => $"{CropType} - {Quantity:N2} kg";

            public override string ToString()
            {
                return DisplayText;
            }
        }

        // Constructor that handles the parameters
        public RequestPaddy()
        {
            InitializeComponent();

            // Default to private buyer role if no parameters provided
            currentUserID = 0;
            currentUserRole = 4;
        }

        // Method to set user details after control initialization
        public void SetUserDetails(int userID, int roleID)
        {
            currentUserID = userID;
            currentUserRole = roleID;

            // Reload data with new user details if control is already loaded
            if (this.IsHandleCreated)
            {
                LoadData();
            }
        }
    }
}