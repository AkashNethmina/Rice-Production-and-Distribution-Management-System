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

        public RequestPaddy()
        {
            InitializeComponent();
            currentUserID = 0;
            currentUserRole = 4; // Default to private buyer role
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

        public void LoadFarmers(ComboBox comboBox)
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

        public void LoadFarmerStock(ComboBox comboBox, int farmerID)
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

                        FormatDataGridColumns(dgvRequests);
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

                        FormatDataGridColumns(dgvRequests);
                        AddStatusColorCoding(dgvRequests);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading requests: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatDataGridColumns(DataGridView dgv)
        {
            if (dgv.Columns.Contains("RequestPaddyID"))
                dgv.Columns["RequestPaddyID"].Visible = false;

            if (dgv.Columns.Contains("RequestPrice"))
                dgv.Columns["RequestPrice"].DefaultCellStyle.Format = "N2";

            if (dgv.Columns.Contains("Quantity"))
                dgv.Columns["Quantity"].DefaultCellStyle.Format = "N2";

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
                dgv.Columns["Quantity"].HeaderText = "Quantity (kg)";

            if (dgv.Columns.Contains("RequestPrice"))
                dgv.Columns["RequestPrice"].HeaderText = "Price per Unit";

            if (dgv.Columns.Contains("RequestStatus"))
                dgv.Columns["RequestStatus"].HeaderText = "Status";

            if (dgv.Columns.Contains("RequestDate"))
                dgv.Columns["RequestDate"].HeaderText = "Request Date";
        }

        private void AddStatusColorCoding(DataGridView dgv)
        {
            dgv.CellFormatting += (s, e) =>
            {
                if (e.ColumnIndex == dgv.Columns["RequestStatus"].Index)
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

        public bool SubmitRequest(int farmerID, int stockID, decimal requestQty, decimal requestPrice, decimal availableQty)
        {
            // Validation
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
                MessageBox.Show($"Requested quantity exceeds available stock ({availableQty}).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Validate user exists
                    string checkQuery = "SELECT COUNT(*) FROM Users WHERE UserID = @UserID";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@UserID", currentUserID);
                        int userExists = (int)checkCmd.ExecuteScalar();

                        if (userExists == 0)
                        {
                            MessageBox.Show("User does not exist in the system. Cannot submit request.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
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
                        cmd.Parameters.AddWithValue("@BuyerID", currentUserID);
                        cmd.Parameters.AddWithValue("@RequestPrice", requestPrice);
                        cmd.Parameters.AddWithValue("@Quantity", requestQty);

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Request submitted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadPrivateBuyerRequests();
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Failed to submit request.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error submitting request: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public void HandleRequestSelectionChanged(DataGridView dgvRequests, Button btnApprove, Button btnReject)
        {
            if (currentUserRole == 2 && dgvRequests.SelectedRows.Count > 0) // Farmer
            {
                DataGridViewRow row = dgvRequests.SelectedRows[0];
                string status = row.Cells["RequestStatus"].Value.ToString();

                // Enable buttons only for Pending status
                btnApprove.Enabled = (status == "Pending");
                btnReject.Enabled = (status == "Pending");
            }
            else
            {
                btnApprove.Enabled = false;
                btnReject.Enabled = false;
            }
        }

        public void ApproveRequest(DataGridView dgvRequests)
        {
            if (dgvRequests.SelectedRows.Count == 0) return;

            int requestID = Convert.ToInt32(dgvRequests.SelectedRows[0].Cells["RequestPaddyID"].Value);
            UpdateRequestStatus(requestID, "Approved");
        }

        public void RejectRequest(DataGridView dgvRequests)
        {
            if (dgvRequests.SelectedRows.Count == 0) return;

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

                    // Get the request details
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

        public void SetUserDetails(int userID, int roleID)
        {
            currentUserID = userID;
            currentUserRole = roleID;

            if (this.IsHandleCreated)
            {
                LoadData();
            }
        }

        // Helper classes for ComboBox items
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

            public string DisplayText => $"{CropType} - {Quantity:N2} kg";

            public override string ToString()
            {
                return DisplayText;
            }
        }

        private void RequestPaddy_Load(object sender, EventArgs e)
        {
            LoadData();

        }
    }
}