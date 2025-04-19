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
    public partial class DamageReporting : UserControl
    {
        private readonly string connectionString = "Server=DESKTOP-O6K3I3U\\SQLEXPRESS;Database=RiceProductionDB2;Integrated Security=True;";
        private int currentUserID;
        private int currentUserRole;

        public DamageReporting()
        {
            InitializeComponent();
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
        }

        private void InitializeUI()
        {
            // Initialize DataGridView for reports
            dgvDamageReports.AutoGenerateColumns = false;
            dgvDamageReports.Columns.Clear();

            dgvDamageReports.Columns.Add("ReportID", "Report ID");
            dgvDamageReports.Columns["ReportID"].DataPropertyName = "ReportID";
            dgvDamageReports.Columns["ReportID"].Width = 70;

            dgvDamageReports.Columns.Add("FarmerName", "Farmer");
            dgvDamageReports.Columns["FarmerName"].DataPropertyName = "FarmerName";
            dgvDamageReports.Columns["FarmerName"].Width = 120;

            dgvDamageReports.Columns.Add("ReportDetails", "Details");
            dgvDamageReports.Columns["ReportDetails"].DataPropertyName = "ReportDetails";
            dgvDamageReports.Columns["ReportDetails"].Width = 200;

            dgvDamageReports.Columns.Add("Status", "Status");
            dgvDamageReports.Columns["Status"].DataPropertyName = "Status";
            dgvDamageReports.Columns["Status"].Width = 100;

            dgvDamageReports.Columns.Add("CreatedAt", "Reported On");
            dgvDamageReports.Columns["CreatedAt"].DataPropertyName = "CreatedAt";
            dgvDamageReports.Columns["CreatedAt"].Width = 120;
            dgvDamageReports.Columns["CreatedAt"].DefaultCellStyle.Format = "dd-MMM-yyyy";

            // Initialize combo box for damage type
            cmbDamageType.Items.Clear();
            cmbDamageType.Items.Add("Flood");
            cmbDamageType.Items.Add("Drought");
            cmbDamageType.Items.Add("Pests");
            cmbDamageType.Items.Add("Disease");
            cmbDamageType.Items.Add("Storm");
            cmbDamageType.Items.Add("Other");
            cmbDamageType.SelectedIndex = 0;

            // Initialize status filter combobox
            cmbStatusFilter.Items.Clear();
            cmbStatusFilter.Items.Add("All");
            cmbStatusFilter.Items.Add("Pending");
            cmbStatusFilter.Items.Add("Under Review");
            cmbStatusFilter.Items.Add("Approved");
            cmbStatusFilter.Items.Add("Rejected");
            cmbStatusFilter.SelectedIndex = 0;
        }

        private void ConfigureUIBasedOnRole()
        {
            // Configure UI based on user role
            if (currentUserRole == 2) // Farmer
            {
                // Farmers can only create reports and view their own reports
                pnlReportCreation.Visible = true;
                pnlReviewActions.Visible = false;
                btnRefreshReports.Visible = true;
            }
            else if (currentUserRole == 3) // Government official
            {
                // Government officials can review reports but not create them
                pnlReportCreation.Visible = false;
                pnlReviewActions.Visible = true;
                btnRefreshReports.Visible = true;
            }
            else if (currentUserRole == 1) // Admin
            {
                // Admins can see everything
                pnlReportCreation.Visible = true;
                pnlReviewActions.Visible = true;
                btnRefreshReports.Visible = true;
            }
            else // Other roles
            {
                // Other roles can only view reports
                pnlReportCreation.Visible = false;
                pnlReviewActions.Visible = false;
                btnRefreshReports.Visible = true;
            }
        }

        private void LoadDamageReports()
        {
            try
            {
                string query = @"
                    SELECT dr.ReportID, u.FullName AS FarmerName, dr.ReportDetails, dr.Status, dr.CreatedAt 
                    FROM DamageReports dr
                    INNER JOIN Users u ON dr.FarmerID = u.UserID
                    WHERE 1=1 ";

                // Apply status filter if not "All"
                if (cmbStatusFilter.SelectedItem.ToString() != "All")
                {
                    query += " AND dr.Status = @Status";
                }

                // If the user is a farmer, only show their reports
                if (currentUserRole == 2)
                {
                    query += " AND dr.FarmerID = @UserID";
                }

                query += " ORDER BY dr.CreatedAt DESC";

                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (cmbStatusFilter.SelectedItem.ToString() != "All")
                    {
                        cmd.Parameters.AddWithValue("@Status", cmbStatusFilter.SelectedItem.ToString());
                    }

                    if (currentUserRole == 2)
                    {
                        cmd.Parameters.AddWithValue("@UserID", currentUserID);
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dgvDamageReports.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading damage reports: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSubmitReport_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDamageDetails.Text))
            {
                MessageBox.Show("Please enter damage details.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string details = $"Damage Type: {cmbDamageType.SelectedItem}, Details: {txtDamageDetails.Text}";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
                        INSERT INTO DamageReports (FarmerID, ReportDetails, Status, CreatedAt)
                        VALUES (@FarmerID, @ReportDetails, 'Pending', GETDATE())";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FarmerID", currentUserID);
                        cmd.Parameters.AddWithValue("@ReportDetails", details);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Damage report submitted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear inputs
                txtDamageDetails.Clear();
                cmbDamageType.SelectedIndex = 0;

                // Refresh reports
                LoadDamageReports();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error submitting damage report: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            // Enable or disable action buttons based on selection
            bool hasSelection = dgvDamageReports.SelectedRows.Count > 0;
            btnApprove.Enabled = hasSelection && (currentUserRole == 1 || currentUserRole == 3);
            btnReject.Enabled = hasSelection && (currentUserRole == 1 || currentUserRole == 3);
            btnReview.Enabled = hasSelection && (currentUserRole == 1 || currentUserRole == 3);

            if (hasSelection)
            {
                string status = dgvDamageReports.SelectedRows[0].Cells["Status"].Value.ToString();

                // Can only approve/reject if status is Pending or Under Review
                bool canAct = (status == "Pending" || status == "Under Review");
                btnApprove.Enabled = canAct && (currentUserRole == 1 || currentUserRole == 3);
                btnReject.Enabled = canAct && (currentUserRole == 1 || currentUserRole == 3);
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
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Report approved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDamageReports();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error approving report: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            if (dgvDamageReports.SelectedRows.Count == 0) return;

            int reportID = Convert.ToInt32(dgvDamageReports.SelectedRows[0].Cells["ReportID"].Value);

            string reason = Microsoft.VisualBasic.Interaction.InputBox("Please provide a reason for rejection:", "Reject Report", "");
            if (string.IsNullOrWhiteSpace(reason)) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
                        UPDATE DamageReports 
                        SET Status = 'Rejected', ResolvedAt = GETDATE(), ReportDetails = ReportDetails + ' | Rejection Reason: ' + @Reason
                        WHERE ReportID = @ReportID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ReportID", reportID);
                        cmd.Parameters.AddWithValue("@Reason", reason);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Report rejected successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDamageReports();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error rejecting report: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Report status changed to Under Review!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDamageReports();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating report status: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbDamageType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
