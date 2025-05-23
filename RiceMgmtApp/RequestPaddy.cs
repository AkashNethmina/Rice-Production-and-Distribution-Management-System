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

namespace RiceMgmtApp
{
    public partial class RequestPaddy : UserControl
    {
        private readonly string connectionString = "Server=DESKTOP-O6K3I3U\\SQLEXPRESS;Database=RiceProductionDB2;Integrated Security=True;";
        private int currentUserID;
        private int currentUserRole;

        // Constants for roles
        private const int ROLE_ADMIN = 1;
        private const int ROLE_FARMER = 2;
        private const int ROLE_GOVERNMENT = 3;
        private const int ROLE_PRIVATE_BUYER = 4;

        // Constants for request status
        private const string STATUS_PENDING = "Pending";
        private const string STATUS_UNDER_REVIEW = "Under Review";
        private const string STATUS_APPROVED = "Approved";
        private const string STATUS_REJECTED = "Rejected";

        public RequestPaddy(int userID, int roleID)
        {
            InitializeComponent();
            currentUserID = userID;
            currentUserRole = roleID;
        }

        public RequestPaddy()
        {
            InitializeComponent();
            currentUserID = 0;
            currentUserRole = ROLE_PRIVATE_BUYER; // Default to private buyer role
        }

        private void RequestPaddy_Load(object sender, EventArgs e)
        {
            ConfigureControlsBasedOnRole();
            LoadData();

            // Only load farmers for buyer roles
            if (currentUserRole == ROLE_PRIVATE_BUYER || currentUserRole == ROLE_GOVERNMENT)
            {
                var cmbFarmers = this.Controls.Find("cmbFarmers", true).FirstOrDefault() as ComboBox;
                if (cmbFarmers != null)
                {
                    LoadFarmers(cmbFarmers);
                }
            }
        }

        private void ConfigureControlsBasedOnRole()
        {
            // Get references to controls (with null checks)
            var cmbFarmers = this.Controls.Find("cmbFarmers", true).FirstOrDefault() as ComboBox;
            var cmbStock = this.Controls.Find("cmbStock", true).FirstOrDefault() as ComboBox;
            var txtRequestQty = this.Controls.Find("txtRequestQty", true).FirstOrDefault() as TextBox;
            var txtRequestPrice = this.Controls.Find("txtRequestPrice", true).FirstOrDefault() as TextBox;
            var btnSubmitRequest = this.Controls.Find("btnSubmitRequest", true).FirstOrDefault() as Button;
            var lblAvailableQtyValue = this.Controls.Find("lblAvailableQtyValue", true).FirstOrDefault() as Label;
            var lblFarmer = this.Controls.Find("lblFarmer", true).FirstOrDefault() as Label;
            var lblAvailableQty = this.Controls.Find("lblAvailableQty", true).FirstOrDefault() as Label;
            var btnApprove = this.Controls.Find("btnApprove", true).FirstOrDefault() as Button;
            var btnReject = this.Controls.Find("btnReject", true).FirstOrDefault() as Button;
            var btnReview = this.Controls.Find("btnReview", true).FirstOrDefault() as Button;

            // Configure based on user role
            switch (currentUserRole)
            {
                case ROLE_PRIVATE_BUYER:
                case ROLE_GOVERNMENT:
                    // Show request submission controls for buyers
                    SetControlVisibility(cmbFarmers, true);
                    SetControlVisibility(cmbStock, true);
                    SetControlVisibility(txtRequestQty, true);
                    SetControlVisibility(txtRequestPrice, true);
                    SetControlVisibility(btnSubmitRequest, true);
                    SetControlVisibility(lblAvailableQtyValue, true);

                    // Hide farmer approval controls
                    SetControlVisibility(btnApprove, false);
                    SetControlVisibility(btnReject, false);
                    SetControlVisibility(btnReview, false);
                    break;

                case ROLE_FARMER:
                    // Hide request submission controls for farmers
                    SetControlVisibility(cmbFarmers, false);
                    SetControlVisibility(cmbStock, false);
                    SetControlVisibility(txtRequestQty, false);
                    SetControlVisibility(txtRequestPrice, false);
                    SetControlVisibility(btnSubmitRequest, false);
                    SetControlVisibility(lblAvailableQtyValue, false);
                    SetControlVisibility(lblFarmer, false);
                    SetControlVisibility(lblAvailableQty, false);


                    // Show farmer approval controls
                    SetControlVisibility(btnApprove, true);
                    SetControlVisibility(btnReject, true);
                    SetControlVisibility(btnReview, true);

                    // Initially disable until a request is selected
                    SetControlEnabled(btnApprove, false);
                    SetControlEnabled(btnReject, false);
                    SetControlEnabled(btnReview, false);
                    break;

                case ROLE_ADMIN:
                    // Show all controls for admin but disable action buttons
                    SetControlVisibility(cmbFarmers, true);
                    SetControlVisibility(cmbStock, true);
                    SetControlVisibility(txtRequestQty, true);
                    SetControlVisibility(txtRequestPrice, true);
                    SetControlVisibility(btnSubmitRequest, true);
                    SetControlVisibility(lblAvailableQtyValue, true);
                    SetControlVisibility(btnApprove, true);
                    SetControlVisibility(btnReject, true);
                    SetControlVisibility(btnReview, true);

                    // Disable action buttons for admin (view-only)
                    SetControlEnabled(btnSubmitRequest, false);
                    SetControlEnabled(btnApprove, false);
                    SetControlEnabled(btnReject, false);
                    SetControlEnabled(btnReview, false);
                    break;

                default:
                    // Hide all controls for invalid roles
                    HideAllControls();
                    break;
            }
        }

        private void SetControlVisibility(Control control, bool visible)
        {
            if (control != null)
            {
                control.Visible = visible;

                // Also find and hide/show associated labels
                var controlName = control.Name;
                if (controlName.StartsWith("cmb") || controlName.StartsWith("txt") || controlName.StartsWith("btn"))
                {
                    var associatedLabel = this.Controls.Find("lbl" + controlName.Substring(3), true).FirstOrDefault() as Label;
                    if (associatedLabel != null)
                    {
                        associatedLabel.Visible = visible;
                    }
                }
            }
        }

        private void SetControlEnabled(Control control, bool enabled)
        {
            if (control != null)
            {
                control.Enabled = enabled;
            }
        }

        private void HideAllControls()
        {
            var allControls = new string[]
            {
                "cmbFarmers", "cmbStock", "txtRequestQty", "txtRequestPrice",
                "btnSubmitRequest", "lblAvailableQtyValue", "btnApprove",
                "btnReject", "btnReview"
            };

            foreach (var controlName in allControls)
            {
                var control = this.Controls.Find(controlName, true).FirstOrDefault();
                SetControlVisibility(control, false);
            }
        }

        private void LoadData()
        {
            switch (currentUserRole)
            {
                case ROLE_PRIVATE_BUYER:
                    LoadPrivateBuyerRequests();
                    break;
                case ROLE_GOVERNMENT:
                    LoadGovernmentBuyerRequests();
                    break;
                case ROLE_FARMER:
                    LoadFarmerRequests();
                    break;
                case ROLE_ADMIN:
                    LoadAllRequests();
                    break;
                default:
                    MessageBox.Show("Invalid user role.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        public void LoadFarmers(ComboBox comboBox)
        {
            if (comboBox == null) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT UserID, FullName 
                                   FROM Users 
                                   WHERE RoleID = @RoleID AND Status = 'Active'
                                   ORDER BY FullName";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@RoleID", ROLE_FARMER);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            List<FarmerItem> farmers = new List<FarmerItem>();

                            while (reader.Read())
                            {
                                farmers.Add(new FarmerItem
                                {
                                    FarmerID = reader.GetInt32(reader.GetOrdinal("UserID")),
                                    FarmerName = reader.GetString(reader.GetOrdinal("FullName"))
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

        public void LoadFarmerStock(ComboBox comboBox, int farmerID)
        {
            if (comboBox == null) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT StockID, CropType, Quantity 
                                   FROM Stock 
                                   WHERE FarmerID = @FarmerID AND Quantity > 0
                                   ORDER BY CropType";

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
                                    StockID = reader.GetInt32(reader.GetOrdinal("StockID")),
                                    CropType = reader.GetString(reader.GetOrdinal("CropType")),
                                    Quantity = reader.GetDecimal(reader.GetOrdinal("Quantity"))
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
                        SELECT r.RequestPaddyID, 
                               f.FullName AS FarmerName, 
                               s.CropType, 
                               r.Quantity, 
                               r.RequestPrice, 
                               r.RequestStatus, 
                               r.RequestDate,
                               s.Quantity as AvailableStock
                        FROM RequestPaddy r
                        INNER JOIN Users f ON r.FarmerID = f.UserID
                        INNER JOIN Stock s ON r.StockID = s.StockID
                        WHERE r.BuyerID = @BuyerID AND r.BuyerType = 'Private'
                        ORDER BY r.RequestDate DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@BuyerID", currentUserID);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dgvRequests.DataSource = dt;
                        FormatDataGridColumns(dgvRequests);
                        AddStatusColorCoding(dgvRequests);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading private buyer requests: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadGovernmentBuyerRequests()
        {
            try
            {
                DataGridView dgvRequests = this.Controls.Find("dgvRequests", true).FirstOrDefault() as DataGridView;
                if (dgvRequests == null) return;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT r.RequestPaddyID, 
                               f.FullName AS FarmerName, 
                               s.CropType, 
                               r.Quantity, 
                               r.RequestPrice, 
                               r.RequestStatus, 
                               r.RequestDate,
                               s.Quantity as AvailableStock
                        FROM RequestPaddy r
                        INNER JOIN Users f ON r.FarmerID = f.UserID
                        INNER JOIN Stock s ON r.StockID = s.StockID
                        WHERE r.BuyerID = @BuyerID AND r.BuyerType = 'Government'
                        ORDER BY r.RequestDate DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@BuyerID", currentUserID);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dgvRequests.DataSource = dt;
                        FormatDataGridColumns(dgvRequests);
                        AddStatusColorCoding(dgvRequests);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading government buyer requests: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private decimal GetGovernmentPrice(SqlConnection conn, string cropType)
        {
            string query = @"SELECT TOP 1 GovernmentPrice 
                    FROM PriceMonitoring 
                    WHERE CropType = @CropType 
                    ORDER BY CreatedAt DESC";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@CropType", cropType);
                object result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    return Convert.ToDecimal(result);
                }
            }

            return 0; 
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
                    string query = @"
                        SELECT r.RequestPaddyID, 
                               b.FullName AS BuyerName, 
                               s.CropType, 
                               r.Quantity, 
                               r.RequestPrice, 
                               r.RequestStatus, 
                               r.RequestDate,
                               r.BuyerType,
                               s.Quantity as AvailableStock
                        FROM RequestPaddy r
                        INNER JOIN Users b ON r.BuyerID = b.UserID
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
                        FormatDataGridColumns(dgvRequests);
                        AddStatusColorCoding(dgvRequests);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading farmer requests: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAllRequests()
        {
            try
            {
                DataGridView dgvRequests = this.Controls.Find("dgvRequests", true).FirstOrDefault() as DataGridView;
                if (dgvRequests == null) return;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT r.RequestPaddyID, 
                               f.FullName AS FarmerName,
                               b.FullName AS BuyerName, 
                               s.CropType, 
                               r.Quantity, 
                               r.RequestPrice, 
                               r.RequestStatus, 
                               r.RequestDate,
                               r.BuyerType,
                               s.Quantity as AvailableStock
                        FROM RequestPaddy r
                        INNER JOIN Users f ON r.FarmerID = f.UserID
                        INNER JOIN Users b ON r.BuyerID = b.UserID
                        INNER JOIN Stock s ON r.StockID = s.StockID
                        ORDER BY r.RequestDate DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dgvRequests.DataSource = dt;
                        FormatDataGridColumns(dgvRequests);
                        AddStatusColorCoding(dgvRequests);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading all requests: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatDataGridColumns(DataGridView dgv)
        {
            if (dgv == null) return;

            // Hide ID column
            if (dgv.Columns.Contains("RequestPaddyID"))
                dgv.Columns["RequestPaddyID"].Visible = false;

            // Format numeric columns
            if (dgv.Columns.Contains("RequestPrice"))
            {
                dgv.Columns["RequestPrice"].DefaultCellStyle.Format = "C2"; // Currency format
                dgv.Columns["RequestPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            if (dgv.Columns.Contains("Quantity"))
            {
                dgv.Columns["Quantity"].DefaultCellStyle.Format = "N2";
                dgv.Columns["Quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            if (dgv.Columns.Contains("AvailableStock"))
            {
                dgv.Columns["AvailableStock"].DefaultCellStyle.Format = "N2";
                dgv.Columns["AvailableStock"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            // Format date column
            if (dgv.Columns.Contains("RequestDate"))
                dgv.Columns["RequestDate"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm";

            // Set column headers
            if (dgv.Columns.Contains("FarmerName"))
                dgv.Columns["FarmerName"].HeaderText = "Farmer";

            if (dgv.Columns.Contains("BuyerName"))
                dgv.Columns["BuyerName"].HeaderText = "Buyer";

            if (dgv.Columns.Contains("CropType"))
                dgv.Columns["CropType"].HeaderText = "Crop Type";

            if (dgv.Columns.Contains("Quantity"))
                dgv.Columns["Quantity"].HeaderText = "Requested Qty (kg)";

            if (dgv.Columns.Contains("AvailableStock"))
                dgv.Columns["AvailableStock"].HeaderText = "Available Stock (kg)";

            if (dgv.Columns.Contains("RequestPrice"))
                dgv.Columns["RequestPrice"].HeaderText = "Price per kg";

            if (dgv.Columns.Contains("RequestStatus"))
                dgv.Columns["RequestStatus"].HeaderText = "Status";

            if (dgv.Columns.Contains("RequestDate"))
                dgv.Columns["RequestDate"].HeaderText = "Request Date";

            if (dgv.Columns.Contains("BuyerType"))
                dgv.Columns["BuyerType"].HeaderText = "Buyer Type";

            // Auto-resize columns
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void AddStatusColorCoding(DataGridView dgv)
        {
            if (dgv == null) return;

            dgv.CellFormatting += (s, e) =>
            {
                if (dgv.Columns.Contains("RequestStatus") && e.ColumnIndex == dgv.Columns["RequestStatus"].Index)
                {
                    string status = e.Value?.ToString();
                    switch (status)
                    {
                        case STATUS_PENDING:
                            e.CellStyle.BackColor = Color.LightYellow;
                            e.CellStyle.ForeColor = Color.DarkOrange;
                            break;
                        case STATUS_UNDER_REVIEW:
                            e.CellStyle.BackColor = Color.LightBlue;
                            e.CellStyle.ForeColor = Color.DarkBlue;
                            break;
                        case STATUS_APPROVED:
                            e.CellStyle.BackColor = Color.LightGreen;
                            e.CellStyle.ForeColor = Color.DarkGreen;
                            break;
                        case STATUS_REJECTED:
                            e.CellStyle.BackColor = Color.LightPink;
                            e.CellStyle.ForeColor = Color.DarkRed;
                            break;
                    }
                }
            };
        }

        public bool SubmitRequest(int farmerID, int stockID, decimal requestQty, decimal requestPrice, decimal availableQty)
        {
            // Input validation
            if (!ValidateRequestInput(requestQty, requestPrice, availableQty))
                return false;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Validate user exists and get buyer type
                    string buyerType = GetBuyerType(conn, currentUserID);
                    if (string.IsNullOrEmpty(buyerType))
                    {
                        MessageBox.Show("Invalid user or user role not supported for requests.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    // Check for duplicate pending request
                    if (HasPendingRequest(conn, farmerID, stockID, currentUserID))
                    {
                        MessageBox.Show("You already have a pending request for this stock item.",
                            "Duplicate Request", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                    // For government buyers, check and use government price
                    decimal finalPrice = requestPrice;
                    string cropType = "";

                    if (buyerType == "Government")
                    {
                        // Get crop type from stock
                        string getCropTypeQuery = "SELECT CropType FROM Stock WHERE StockID = @StockID";
                        using (SqlCommand cropCmd = new SqlCommand(getCropTypeQuery, conn))
                        {
                            cropCmd.Parameters.AddWithValue("@StockID", stockID);
                            object cropResult = cropCmd.ExecuteScalar();
                            if (cropResult != null)
                            {
                                cropType = cropResult.ToString();
                            }
                        }

                        if (!string.IsNullOrEmpty(cropType))
                        {
                            decimal governmentPrice = GetGovernmentPrice(conn, cropType);
                            if (governmentPrice > 0)
                            {
                                finalPrice = governmentPrice;

                                // Inform user about price adjustment if different from requested price
                                if (Math.Abs(requestPrice - governmentPrice) > 0.01m)
                                {
                                    DialogResult result = MessageBox.Show(
                                        $"Government price for {cropType} is {governmentPrice:C2}.\n" +
                                        $"Your requested price of {requestPrice:C2} will be adjusted to the government price.\n\n" +
                                        "Do you want to continue with the government price?",
                                        "Government Price Applied",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Information);

                                    if (result == DialogResult.No)
                                    {
                                        return false;
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show($"No government price found for {cropType}. Please contact administrator to set up pricing.",
                                    "Price Not Available", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Unable to determine crop type for the selected stock.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }

                    // Insert request with final price
                    string insertQuery = @"
                INSERT INTO RequestPaddy (FarmerID, StockID, BuyerID, BuyerType, RequestPrice, Quantity, RequestStatus, RequestDate)
                VALUES (@FarmerID, @StockID, @BuyerID, @BuyerType, @RequestPrice, @Quantity, @Status, GETDATE())";

                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@FarmerID", farmerID);
                        cmd.Parameters.AddWithValue("@StockID", stockID);
                        cmd.Parameters.AddWithValue("@BuyerID", currentUserID);
                        cmd.Parameters.AddWithValue("@BuyerType", buyerType);
                        cmd.Parameters.AddWithValue("@RequestPrice", finalPrice);
                        cmd.Parameters.AddWithValue("@Quantity", requestQty);
                        cmd.Parameters.AddWithValue("@Status", STATUS_PENDING);

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            string successMessage = (buyerType == "Government" && Math.Abs(finalPrice - requestPrice) > 0.01m)
                                ? $"Request submitted successfully with government price ({finalPrice:C2}) and is pending farmer approval."
                                : "Request submitted successfully and is pending farmer approval.";

                            MessageBox.Show(successMessage, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData(); // Refresh the data
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Failed to submit request. Please try again.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Database error submitting request: {sqlEx.Message}",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error submitting request: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        private void PopulateGovernmentPrice()
        {
            if (currentUserRole == ROLE_GOVERNMENT && cmbStock.SelectedItem != null)
            {
                try
                {
                    StockItem selectedStock = (StockItem)cmbStock.SelectedItem;

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        // Get crop type from selected stock
                        string getCropTypeQuery = "SELECT CropType FROM Stock WHERE StockID = @StockID";
                        string cropType = "";

                        using (SqlCommand cmd = new SqlCommand(getCropTypeQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@StockID", selectedStock.StockID);
                            object result = cmd.ExecuteScalar();
                            if (result != null)
                            {
                                cropType = result.ToString();
                            }
                        }

                        if (!string.IsNullOrEmpty(cropType))
                        {
                            decimal governmentPrice = GetGovernmentPrice(conn, cropType);
                            if (governmentPrice > 0)
                            {
                                txtRequestPrice.Text = governmentPrice.ToString("0.00");
                                txtRequestPrice.ReadOnly = true; // Make it read-only for government users
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle error silently or log it
                    Console.WriteLine($"Error populating government price: {ex.Message}");
                }
            }
            else if (currentUserRole == ROLE_PRIVATE_BUYER)
            {
                txtRequestPrice.ReadOnly = false; // Allow private buyers to set their own price
            }
        }


        private bool ValidateRequestInput(decimal requestQty, decimal requestPrice, decimal availableQty)
        {
            if (requestQty <= 0)
            {
                MessageBox.Show("Please enter a valid positive quantity.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (requestPrice <= 0)
            {
                MessageBox.Show("Please enter a valid positive price.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (requestQty > availableQty)
            {
                MessageBox.Show($"Requested quantity ({requestQty:N2} kg) exceeds available stock ({availableQty:N2} kg).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private string GetBuyerType(SqlConnection conn, int userID)
        {
            string query = "SELECT RoleID FROM Users WHERE UserID = @UserID AND Status = 'Active'";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@UserID", userID);
                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    int roleID = Convert.ToInt32(result);
                    return roleID == ROLE_GOVERNMENT ? "Government" :
                           roleID == ROLE_PRIVATE_BUYER ? "Private" : null;
                }
            }

            return null;
        }

        private bool HasPendingRequest(SqlConnection conn, int farmerID, int stockID, int buyerID)
        {
            string query = @"
                SELECT COUNT(*) 
                FROM RequestPaddy 
                WHERE FarmerID = @FarmerID 
                  AND StockID = @StockID 
                  AND BuyerID = @BuyerID 
                  AND RequestStatus = @Status";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@FarmerID", farmerID);
                cmd.Parameters.AddWithValue("@StockID", stockID);
                cmd.Parameters.AddWithValue("@BuyerID", buyerID);
                cmd.Parameters.AddWithValue("@Status", STATUS_PENDING);

                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        public void HandleRequestSelectionChanged(DataGridView dgvRequests, Button btnApprove, Button btnReject, Button btnReview = null)
        {
            if (dgvRequests == null || btnApprove == null || btnReject == null) return;

            bool enableApproveRejectButtons = false;
            bool enableReviewButton = false;

            if (currentUserRole == ROLE_FARMER && dgvRequests.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvRequests.SelectedRows[0];
                string status = row.Cells["RequestStatus"].Value?.ToString();

                // Enable approve/reject buttons for both Pending and Under Review statuses
                enableApproveRejectButtons = (status == STATUS_PENDING || status == STATUS_UNDER_REVIEW);

                // Enable review button only for Pending status
                enableReviewButton = (status == STATUS_PENDING);
            }

            btnApprove.Enabled = enableApproveRejectButtons;
            btnReject.Enabled = enableApproveRejectButtons;

            // Enable/disable review button
            if (btnReview != null)
                btnReview.Enabled = enableReviewButton;
        }

        public void SetRequestUnderReview(DataGridView dgvRequests)
        {
            if (dgvRequests?.SelectedRows.Count == 0) return;

            int requestID = Convert.ToInt32(dgvRequests.SelectedRows[0].Cells["RequestPaddyID"].Value);
            UpdateRequestStatus(requestID, STATUS_UNDER_REVIEW);
        }

        public void ApproveRequest(DataGridView dgvRequests)
        {
            if (dgvRequests?.SelectedRows.Count == 0) return;

            DialogResult result = MessageBox.Show("Are you sure you want to approve this request? This will reduce your stock quantity.",
                                                "Confirm Approval", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                int requestID = Convert.ToInt32(dgvRequests.SelectedRows[0].Cells["RequestPaddyID"].Value);
                UpdateRequestStatus(requestID, STATUS_APPROVED);
            }
        }

        public void RejectRequest(DataGridView dgvRequests)
        {
            if (dgvRequests?.SelectedRows.Count == 0) return;

            DialogResult result = MessageBox.Show("Are you sure you want to reject this request?",
                                                "Confirm Rejection", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                int requestID = Convert.ToInt32(dgvRequests.SelectedRows[0].Cells["RequestPaddyID"].Value);
                UpdateRequestStatus(requestID, STATUS_REJECTED);
            }
        }

        private void UpdateRequestStatus(int requestID, string status)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // Update request status
                            string updateQuery = "UPDATE RequestPaddy SET RequestStatus = @Status WHERE RequestPaddyID = @RequestID";

                            using (SqlCommand cmd = new SqlCommand(updateQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@Status", status);
                                cmd.Parameters.AddWithValue("@RequestID", requestID);

                                int result = cmd.ExecuteNonQuery();

                                if (result > 0)
                                {
                                    
                                    //if (status == STATUS_APPROVED)
                                    //{
                                    //    if (!UpdateStockQuantity(conn, transaction, requestID))
                                    //    {
                                    //        transaction.Rollback();
                                    //        MessageBox.Show("Failed to update stock quantity. Request approval cancelled.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    //        return;
                                    //    }
                                    //}

                                    transaction.Commit();
                                    MessageBox.Show($"Request {status.ToLower()} successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    LoadData(); // Refresh the data
                                }
                                else
                                {
                                    transaction.Rollback();
                                    MessageBox.Show($"Failed to {status.ToLower()} request.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating request: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private bool UpdateStockQuantity(SqlConnection conn, SqlTransaction transaction, int requestID)
        //{
        //    try
        //    {
        //        // Get the request details
        //        string getRequestQuery = @"
        //            SELECT s.StockID, r.Quantity, s.Quantity as CurrentStock
        //            FROM RequestPaddy r
        //            INNER JOIN Stock s ON r.StockID = s.StockID
        //            WHERE r.RequestPaddyID = @RequestID";

        //        int stockID = 0;
        //        decimal requestQty = 0;
        //        decimal currentStock = 0;

        //        using (SqlCommand cmd = new SqlCommand(getRequestQuery, conn, transaction))
        //        {
        //            cmd.Parameters.AddWithValue("@RequestID", requestID);

        //            using (SqlDataReader reader = cmd.ExecuteReader())
        //            {
        //                if (reader.Read())
        //                {
        //                    stockID = reader.GetInt32(reader.GetOrdinal("StockID"));
        //                    requestQty = reader.GetDecimal(reader.GetOrdinal("Quantity")); 
        //                    currentStock = reader.GetDecimal(reader.GetOrdinal("CurrentStock"));
        //                }   
        //            }
        //        }

        //        // Validate stock availability
        //        if (requestQty > currentStock)
        //        {
        //            MessageBox.Show($"Insufficient stock. Current stock: {currentStock:N2} kg, Requested: {requestQty:N2} kg",
        //                            "Insufficient Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            return false;
        //        }

        //        if (stockID > 0 && requestQty > 0)
        //        {
        //            // Update stock quantity
        //            string updateStockQuery = @"
        //                UPDATE Stock 
        //                SET Quantity = Quantity - @RequestQty,
        //                    LastUpdated = GETDATE()
        //                WHERE StockID = @StockID";

        //            using (SqlCommand cmd = new SqlCommand(updateStockQuery, conn, transaction))
        //            {
        //                cmd.Parameters.AddWithValue("@StockID", stockID);
        //                cmd.Parameters.AddWithValue("@RequestQty", requestQty);

        //                int result = cmd.ExecuteNonQuery();
        //                return result > 0;
        //            }
        //        }

        //        return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Error updating stock quantity: {ex.Message}", "Stock Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return false;
        //    }
        //}

        public void SetUserDetails(int userID, int roleID)
        {
            currentUserID = userID;
            currentUserRole = roleID;

            if (this.IsHandleCreated)
            {
                LoadData();
            }
        }

        public void RefreshData()
        {
            LoadData();
        }

        // Helper classes
        public class FarmerItem
        {
            public int FarmerID { get; set; }
            public string FarmerName { get; set; }

            public override string ToString()
            {
                return FarmerName;
            }
        }

        public class StockItem
        {
            public int StockID { get; set; }
            public string CropType { get; set; }
            public decimal Quantity { get; set; }

            public string DisplayText => $"{CropType} - {Quantity:N2} kg available";

            public override string ToString()
            {
                return DisplayText;
            }
        }

        private void cmbFarmers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFarmers.SelectedItem != null)
            {
                FarmerItem selectedFarmer = (FarmerItem)cmbFarmers.SelectedItem;
                LoadFarmerStock(cmbStock, selectedFarmer.FarmerID);
                cmbStock.Enabled = true;
                lblAvailableQtyValue.Text = "0.00";
            }
            else
            {
                cmbStock.Enabled = false;
                cmbStock.DataSource = null;
                lblAvailableQtyValue.Text = "0.00";
            }
        }

        private void cmbStock_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbStock.SelectedItem != null)
            {
                StockItem selectedStock = (StockItem)cmbStock.SelectedItem;
                lblAvailableQtyValue.Text = selectedStock.Quantity.ToString("N2");

                // Auto-populate government price for government users
                PopulateGovernmentPrice();
            }
            else
            {
                lblAvailableQtyValue.Text = "0.00";
                if (txtRequestPrice != null)
                {
                    txtRequestPrice.Clear();
                    txtRequestPrice.ReadOnly = false;
                }
            }
        }

        private void btnSubmitRequest_Click(object sender, EventArgs e)
        {
            if (cmbFarmers.SelectedItem == null)
            {
                MessageBox.Show("Please select a farmer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbStock.SelectedItem == null)
            {
                MessageBox.Show("Please select a stock item.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtRequestQty.Text) || string.IsNullOrWhiteSpace(txtRequestPrice.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtRequestQty.Text, out decimal requestQty) || !decimal.TryParse(txtRequestPrice.Text, out decimal requestPrice))
            {
                MessageBox.Show("Please enter valid numeric values for quantity and price.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FarmerItem selectedFarmer = (FarmerItem)cmbFarmers.SelectedItem;
            StockItem selectedStock = (StockItem)cmbStock.SelectedItem;

            if (SubmitRequest(selectedFarmer.FarmerID, selectedStock.StockID, requestQty, requestPrice, selectedStock.Quantity))
            {
                // Clear form after successful submission
                cmbFarmers.SelectedIndex = -1;
                cmbStock.DataSource = null;
                cmbStock.Enabled = false;
                txtRequestQty.Clear();
                txtRequestPrice.Clear();
                lblAvailableQtyValue.Text = "0.00";
            }
        }

        private void dgvRequests_SelectionChanged(object sender, EventArgs e)
        {
            HandleRequestSelectionChanged(dgvRequests, btnApprove, btnReject, btnReview);
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            ApproveRequest(dgvRequests);
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            RejectRequest(dgvRequests);
        }
        
        private void btnReview_Click(object sender, EventArgs e)
        {
            SetRequestUnderReview(dgvRequests);
        }

        private void txtRequestQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only numbers, decimal point, and control keys
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // Only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtRequestPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only numbers, decimal point, and control keys
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // Only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        
    }
}