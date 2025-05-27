using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace RiceMgmtApp
{
    public partial class DamageReporting : UserControl
    {
        private readonly string connectionString = "Server=DESKTOP-O6K3I3U\\SQLEXPRESS;Database=RiceProductionDB2;Integrated Security=True;";
        private int currentUserID;
        private int currentUserRole;
        private const string MsgBoxTitle = "Damage Reporting";

        public DamageReporting()
        {
            InitializeComponent();
            this.Load += DamageReporting_Load;
            
        }

        public void SetUserContext(int userID, int roleID)
        {
            currentUserID = userID;
            currentUserRole = roleID;
            ConfigureUIBasedOnRole();
        }

        private void DamageReporting_Load(object sender, EventArgs e)
        {
            InitializeUI();
            LoadDamageReports();
            ConfigureUIBasedOnRole(); 
            dgvDamageReports.SelectionChanged += dgvDamageReports_SelectionChanged;
        }

        private void InitializeUI()
        {
            // Set up DataGridView
            dgvDamageReports.AutoGenerateColumns = false;
            dgvDamageReports.Columns.Clear();

            // Report ID column
            dgvDamageReports.Columns.Add("ReportID", "Report ID");
            dgvDamageReports.Columns["ReportID"].DataPropertyName = "ReportID";
            dgvDamageReports.Columns["ReportID"].Width = 70;

            // Farmer name column
            dgvDamageReports.Columns.Add("FarmerName", "Farmer");
            dgvDamageReports.Columns["FarmerName"].DataPropertyName = "FarmerName";
            dgvDamageReports.Columns["FarmerName"].Width = 120;

            // Report details column
            dgvDamageReports.Columns.Add("ReportDetails", "Details");
            dgvDamageReports.Columns["ReportDetails"].DataPropertyName = "ReportDetails";
            dgvDamageReports.Columns["ReportDetails"].Width = 200;

       
            DataGridViewTextBoxColumn statusCol = new DataGridViewTextBoxColumn
            {
                Name = "Status",
                HeaderText = "Status",
                DataPropertyName = "Status",
                Width = 100
            };
            dgvDamageReports.Columns.Add(statusCol);
            

            dgvDamageReports.Columns.Add("CreatedAt", "Reported On");
            dgvDamageReports.Columns["CreatedAt"].DataPropertyName = "CreatedAt";
            dgvDamageReports.Columns["CreatedAt"].Width = 120;
            dgvDamageReports.Columns["CreatedAt"].DefaultCellStyle.Format = "dd-MMM-yyyy";

            
            cmbStatusFilter.Items.Clear();
            cmbStatusFilter.Items.AddRange(new string[] { "All", "Pending", "Under Review", "Approved", "Rejected" });
            cmbStatusFilter.SelectedIndex = 0;
        }

        private void ConfigureUIBasedOnRole()
        {
          
            switch (currentUserRole)
            {
                case 1: // Admin
                    pnlReportCreation.Visible = false;
                    pnlReviewActions.Visible = true;
                    btnRefreshReports.Visible = true;
                    break;
                case 2: // Farmer
                    pnlReportCreation.Visible = true;
                    pnlReviewActions.Visible = false;
                    btnRefreshReports.Visible = true;
                    break;
                case 3: // Government
                    pnlReportCreation.Visible = false;
                    pnlReviewActions.Visible = true;
                    btnRefreshReports.Visible = true;
                    break;
                default:
                    pnlReportCreation.Visible = false;
                    pnlReviewActions.Visible = false;
                    btnRefreshReports.Visible = false;
                    break;
            }
            if (dgvDamageReports.Columns["FarmerName"] != null)
            {
                dgvDamageReports.Columns["FarmerName"].Visible = currentUserRole != 2;
            }
        }

        private void LoadDamageReports()
        {
            try
            {
                StringBuilder query = new StringBuilder(@"
                    SELECT dr.ReportID, u.FullName AS FarmerName, dr.ReportDetails, dr.Status, dr.CreatedAt 
                    FROM DamageReports dr
                    INNER JOIN Users u ON dr.FarmerID = u.UserID
                    WHERE 1=1");

                bool filterByStatus = cmbStatusFilter.SelectedItem != null && cmbStatusFilter.SelectedItem.ToString() != "All";
                if (filterByStatus)
                    query.Append(" AND dr.Status = @Status");

               
                if (currentUserRole == 2)
                    query.Append(" AND dr.FarmerID = @UserID");

                query.Append(" ORDER BY dr.CreatedAt DESC");

                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query.ToString(), conn))
                {
                    if (filterByStatus)
                        cmd.Parameters.AddWithValue("@Status", cmbStatusFilter.SelectedItem.ToString());

                    if (currentUserRole == 2)
                        cmd.Parameters.AddWithValue("@UserID", currentUserID);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvDamageReports.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading damage reports: " + ex.Message, MsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnSubmitReport_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDamageDetails.Text))
            {
                MessageBox.Show("Please enter damage details.", MsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (currentUserRole != 2) // Only Farmers 
            {
                MessageBox.Show("Only farmers are allowed to submit damage reports.", MsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                

                string details = $" Details: {txtDamageDetails.Text}";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                   
                    string checkQuery = "SELECT COUNT(*) FROM Users WHERE UserID = @UserID";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@UserID", currentUserID);
                        int userExists = (int)checkCmd.ExecuteScalar();

                        if (userExists == 0)
                        {
                            MessageBox.Show("User does not exist in the system. Cannot submit report.", MsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    
                    string insertQuery = @"
                        INSERT INTO DamageReports (FarmerID, ReportDetails, Status, CreatedAt)
                        VALUES (@FarmerID, @ReportDetails, 'Pending', GETDATE())";

                    using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                    {
                        insertCmd.Parameters.AddWithValue("@FarmerID", currentUserID);
                        insertCmd.Parameters.AddWithValue("@ReportDetails", details);
                        insertCmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Damage report submitted successfully!", MsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDamageDetails.Clear();
                LoadDamageReports();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error submitting damage report: " + ex.Message, MsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefreshReports_Click(object sender, EventArgs e)
        {
            LoadDamageReports();
        }

        private void cmbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDamageReports();
        }

        private void dgvDamageReports_SelectionChanged(object sender, EventArgs e)
        {
            bool hasSelection = dgvDamageReports.SelectedRows.Count > 0;

        
            btnApprove.Enabled = false;
            btnReject.Enabled = false;
            btnReview.Enabled = false;

            // Only Admin (1) and Gov Official (3) roles can take action
            if (hasSelection && (currentUserRole == 1 || currentUserRole == 3))
            {
                var selectedRow = dgvDamageReports.SelectedRows[0];

               
                if (dgvDamageReports.Columns.Contains("Status"))
                {
                    var statusCell = selectedRow.Cells["Status"];
                    if (statusCell != null && statusCell.Value != null)
                    {
                        string status = statusCell.Value.ToString();

                        
                        bool canAct = (status == "Pending" || status == "Under Review");

                        btnApprove.Enabled = canAct;
                        btnReject.Enabled = canAct;

                        btnReview.Enabled = (status == "Pending");
                    }
                }
            }
        }



        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (dgvDamageReports.SelectedRows.Count == 0) return;
            int reportID = Convert.ToInt32(dgvDamageReports.SelectedRows[0].Cells["ReportID"].Value);

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        UPDATE DamageReports 
                        SET Status = 'Approved', ResolvedAt = GETDATE() 
                        WHERE ReportID = @ReportID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ReportID", reportID);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected == 0)
                        {
                            MessageBox.Show("Report could not be approved. It may have been deleted or already processed.",
                                MsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }

                MessageBox.Show("Report approved successfully!", MsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDamageReports();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error approving report: " + ex.Message, MsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            if (dgvDamageReports.SelectedRows.Count == 0) return;
            int reportID = Convert.ToInt32(dgvDamageReports.SelectedRows[0].Cells["ReportID"].Value);

            DialogResult result = MessageBox.Show("Are you sure you want to reject this report?", "Reject Report", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                UPDATE DamageReports 
                SET Status = 'Rejected', ResolvedAt = GETDATE()
                WHERE ReportID = @ReportID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ReportID", reportID);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected == 0)
                        {
                            MessageBox.Show("Report could not be rejected. It may have been deleted or already processed.",
                                MsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }

                MessageBox.Show("Report rejected successfully!", MsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDamageReports();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error rejecting report: " + ex.Message, MsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnReview_Click(object sender, EventArgs e)
        {
            if (dgvDamageReports.SelectedRows.Count == 0) return;
            int reportID = Convert.ToInt32(dgvDamageReports.SelectedRows[0].Cells["ReportID"].Value);

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        UPDATE DamageReports 
                        SET Status = 'Under Review'
                        WHERE ReportID = @ReportID AND Status = 'Pending'";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ReportID", reportID);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected == 0)
                        {
                            MessageBox.Show("Report status could not be updated. It may have been deleted or is no longer pending.",
                                MsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }

                MessageBox.Show("Report status changed to Under Review!", MsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDamageReports();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating report status: " + ex.Message, MsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}