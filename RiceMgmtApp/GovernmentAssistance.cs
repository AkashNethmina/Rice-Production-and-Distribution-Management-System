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
    public partial class GovernmentAssistance : UserControl
    {
        private readonly string connectionString = "Server=DESKTOP-O6K3I3U\\SQLEXPRESS;Database=RiceProductionDB2;Integrated Security=True;";
        private int currentUserID;
        private int currentUserRole;

        public GovernmentAssistance()
        {
            InitializeComponent();
        }

        public void SetUserContext(int userID, int roleID)
        {
            currentUserID = userID;
            currentUserRole = roleID;
            ConfigureUIBasedOnRole();
        }

        

        private void InitializeUI()
        {
            // Initialize DataGridView for assistance requests
            dgvAssistanceRequests.AutoGenerateColumns = false;
            dgvAssistanceRequests.Columns.Clear();

            dgvAssistanceRequests.Columns.Add("RequestID", "Request ID");
            dgvAssistanceRequests.Columns["RequestID"].DataPropertyName = "RequestID";
            dgvAssistanceRequests.Columns["RequestID"].Width = 70;

            dgvAssistanceRequests.Columns.Add("FarmerName", "Farmer");
            dgvAssistanceRequests.Columns["FarmerName"].DataPropertyName = "FarmerName";
            dgvAssistanceRequests.Columns["FarmerName"].Width = 120;

            dgvAssistanceRequests.Columns.Add("AssistanceType", "Type");
            dgvAssistanceRequests.Columns["AssistanceType"].DataPropertyName = "AssistanceType";
            dgvAssistanceRequests.Columns["AssistanceType"].Width = 80;

            dgvAssistanceRequests.Columns.Add("RequestDetails", "Details");
            dgvAssistanceRequests.Columns["RequestDetails"].DataPropertyName = "RequestDetails";
            dgvAssistanceRequests.Columns["RequestDetails"].Width = 200;

            dgvAssistanceRequests.Columns.Add("Amount", "Amount");
            dgvAssistanceRequests.Columns["Amount"].DataPropertyName = "Amount";
            dgvAssistanceRequests.Columns["Amount"].Width = 80;
            dgvAssistanceRequests.Columns["Amount"].DefaultCellStyle.Format = "N2";

            dgvAssistanceRequests.Columns.Add("Status", "Status");
            dgvAssistanceRequests.Columns["Status"].DataPropertyName = "Status";
            dgvAssistanceRequests.Columns["Status"].Width = 80;

            dgvAssistanceRequests.Columns.Add("RequestDate", "Request Date");
            dgvAssistanceRequests.Columns["RequestDate"].DataPropertyName = "RequestDate";
            dgvAssistanceRequests.Columns["RequestDate"].Width = 100;
            dgvAssistanceRequests.Columns["RequestDate"].DefaultCellStyle.Format = "dd-MMM-yyyy";

            // Initialize assistance type combobox
            cmbAssistanceType.Items.Clear();
            cmbAssistanceType.Items.Add("Financial");
            cmbAssistanceType.Items.Add("Seed");
            cmbAssistanceType.Items.Add("Fertilizer");
            cmbAssistanceType.Items.Add("Equipment");
            cmbAssistanceType.Items.Add("Training");
            cmbAssistanceType.Items.Add("Other");
            cmbAssistanceType.SelectedIndex = 0;

            // Initialize status filter combobox
            cmbStatusFilter.Items.Clear();
            cmbStatusFilter.Items.Add("All");
            cmbStatusFilter.Items.Add("Pending");
            cmbStatusFilter.Items.Add("Under Review");
            cmbStatusFilter.Items.Add("Approved");
            cmbStatusFilter.Items.Add("Rejected");
            cmbStatusFilter.Items.Add("Disbursed");
            cmbStatusFilter.SelectedIndex = 0;

            // Initialize linked reports combobox
            LoadDamageReportsForComboBox();
        }

        private void ConfigureUIBasedOnRole()
        {
            // Configure UI based on user role
            if (currentUserRole == 2) // Farmer
            {
                // Farmers can request assistance and view their own requests
                pnlRequestAssistance.Visible = true;
                pnlProcessRequests.Visible = false;
                btnRefreshRequests.Visible = true;
                btnLinkToDamageReport.Visible = true;
            }
            else if (currentUserRole == 3) // Government official
            {
                // Government officials can process requests but not create them
                pnlRequestAssistance.Visible = false;
                pnlProcessRequests.Visible = true;
                btnRefreshRequests.Visible = true;
                btnLinkToDamageReport.Visible = false;
            }
            else if (currentUserRole == 1) // Admin
            {
                // Admins can see everything
                pnlRequestAssistance.Visible = true;
                pnlProcessRequests.Visible = true;
                btnRefreshRequests.Visible = true;
                btnLinkToDamageReport.Visible = true;
            }
            else // Other roles
            {
                // Other roles can only view
                pnlRequestAssistance.Visible = false;
                pnlProcessRequests.Visible = false;
                btnRefreshRequests.Visible = true;
                btnLinkToDamageReport.Visible = false;
            }
        }

        private void LoadAssistanceRequests()
        {
            try
            {
                string query = @"
                    SELECT 
                        ga.RequestID, 
                        u.FullName AS FarmerName, 
                        ga.AssistanceType,
                        ga.RequestDetails, 
                        ga.Amount,
                        ga.Status, 
                        ga.RequestDate,
                        ga.DamageReportID
                    FROM GovernmentAssistance ga
                    INNER JOIN Users u ON ga.FarmerID = u.UserID
                    WHERE 1=1 ";

                // Apply status filter if not "All"
                if (cmbStatusFilter.SelectedItem.ToString() != "All")
                {
                    query += " AND ga.Status = @Status";
                }

                // If user is a farmer, only show their requests
                if (currentUserRole == 2)
                {
                    query += " AND ga.FarmerID = @UserID";
                }

                query += " ORDER BY ga.RequestDate DESC";

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

                    dgvAssistanceRequests.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading assistance requests: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDamageReportsForComboBox()
        {
            try
            {
                string query = @"
                    SELECT dr.ReportID, 
                           'Report #' + CAST(dr.ReportID AS NVARCHAR) + ' - ' + 
                           CONVERT(NVARCHAR, dr.CreatedAt, 103) AS ReportDisplay
                    FROM DamageReports dr
                    WHERE dr.Status = 'Approved'";

                // If user is a farmer, only show their approved reports
                if (currentUserRole == 2)
                {
                    query += " AND dr.FarmerID = @FarmerID";
                }

                query += " ORDER BY dr.CreatedAt DESC";

                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (currentUserRole == 2)
                    {
                        cmd.Parameters.AddWithValue("@FarmerID", currentUserID);
                    }

                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    cmbDamageReport.DisplayMember = "ReportDisplay";
                    cmbDamageReport.ValueMember = "ReportID";
                    cmbDamageReport.DataSource = table;

                    // Add an option for "None"
                    DataRow newRow = table.NewRow();
                    newRow["ReportID"] = 0;
                    newRow["ReportDisplay"] = "-- None --";
                    table.Rows.InsertAt(newRow, 0);
                    cmbDamageReport.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading damage reports: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRequestAssistance_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRequestDetails.Text))
            {
                MessageBox.Show("Please enter request details.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtAmount.Text, out decimal amount) || amount <= 0)
            {
                MessageBox.Show("Please enter a valid amount.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int? damageReportID = null;
                if (cmbDamageReport.SelectedValue != null && Convert.ToInt32(cmbDamageReport.SelectedValue) > 0)
                {
                    damageReportID = Convert.ToInt32(cmbDamageReport.SelectedValue);
                }

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
                        INSERT INTO GovernmentAssistance (
                            FarmerID, AssistanceType, RequestDetails, Amount, Status, RequestDate, DamageReportID
                        ) VALUES (
                            @FarmerID, @AssistanceType, @RequestDetails, @Amount, 'Pending', GETDATE(), @DamageReportID
                        )";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FarmerID", currentUserID);
                        cmd.Parameters.AddWithValue("@AssistanceType", cmbAssistanceType.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@RequestDetails", txtRequestDetails.Text);
                        cmd.Parameters.AddWithValue("@Amount", amount);
                        cmd.Parameters.AddWithValue("@DamageReportID", (object)damageReportID ?? DBNull.Value);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Assistance request submitted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear inputs
                txtRequestDetails.Clear();
                txtAmount.Clear();
                cmbAssistanceType.SelectedIndex = 0;
                cmbDamageReport.SelectedIndex = 0;

                // Refresh requests
                LoadAssistanceRequests();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error submitting assistance request: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefreshRequests_Click(object sender, EventArgs e)
        {
            LoadAssistanceRequests();
        }

        private void cmbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAssistanceRequests();
        }

        private void dgvAssistanceRequests_SelectionChanged(object sender, EventArgs e)
        {
            // Enable or disable action buttons based on selection
            bool hasSelection = dgvAssistanceRequests.SelectedRows.Count > 0;
            btnApprove.Enabled = hasSelection && (currentUserRole == 1 || currentUserRole == 3);
            btnReject.Enabled = hasSelection && (currentUserRole == 1 || currentUserRole == 3);
            btnMarkReviewing.Enabled = hasSelection && (currentUserRole == 1 || currentUserRole == 3);
            btnDisburse.Enabled = hasSelection && (currentUserRole == 1 || currentUserRole == 3);

            if (hasSelection)
            {
                string status = dgvAssistanceRequests.SelectedRows[0].Cells["Status"].Value.ToString();

                // Can only approve/reject if status is Pending or Under Review
                bool canAct = (status == "Pending" || status == "Under Review");
                btnApprove.Enabled = canAct && (currentUserRole == 1 || currentUserRole == 3);
                btnReject.Enabled = canAct && (currentUserRole == 1 || currentUserRole == 3);

                // Can only disburse if status is Approved
                btnDisburse.Enabled = (status == "Approved") && (currentUserRole == 1 || currentUserRole == 3);
            }
        }

        private void btnLinkToDamageReport_Click(object sender, EventArgs e)
        {
            LoadDamageReportsForComboBox();
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (dgvAssistanceRequests.SelectedRows.Count == 0) return;

            int requestID = Convert.ToInt32(dgvAssistanceRequests.SelectedRows[0].Cells["RequestID"].Value);

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
                        UPDATE GovernmentAssistance 
                        SET Status = 'Approved', LastUpdated = GETDATE() 
                        WHERE RequestID = @RequestID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@RequestID", requestID);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Request approved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAssistanceRequests();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error approving request: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            if (dgvAssistanceRequests.SelectedRows.Count == 0) return;

            int requestID = Convert.ToInt32(dgvAssistanceRequests.SelectedRows[0].Cells["RequestID"].Value);

            string reason = Microsoft.VisualBasic.Interaction.InputBox("Please provide a reason for rejection:", "Reject Request", "");
            if (string.IsNullOrWhiteSpace(reason)) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
                        UPDATE GovernmentAssistance 
                        SET Status = 'Rejected', LastUpdated = GETDATE(), 
                            RequestDetails = RequestDetails + ' | Rejection Reason: ' + @Reason
                        WHERE RequestID = @RequestID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@RequestID", requestID);
                        cmd.Parameters.AddWithValue("@Reason", reason);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Request rejected successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAssistanceRequests();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error rejecting request: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMarkReviewing_Click(object sender, EventArgs e)
        {
            if (dgvAssistanceRequests.SelectedRows.Count == 0) return;

            int requestID = Convert.ToInt32(dgvAssistanceRequests.SelectedRows[0].Cells["RequestID"].Value);

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
                        UPDATE GovernmentAssistance 
                        SET Status = 'Under Review', LastUpdated = GETDATE()
                        WHERE RequestID = @RequestID AND Status = 'Pending'";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@RequestID", requestID);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Request status changed to Under Review!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAssistanceRequests();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating request status: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDisburse_Click(object sender, EventArgs e)
        {
            if (dgvAssistanceRequests.SelectedRows.Count == 0) return;

            int requestID = Convert.ToInt32(dgvAssistanceRequests.SelectedRows[0].Cells["RequestID"].Value);

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
                        UPDATE GovernmentAssistance 
                        SET Status = 'Disbursed', DisbursementDate = GETDATE(), LastUpdated = GETDATE()
                        WHERE RequestID = @RequestID AND Status = 'Approved'";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@RequestID", requestID);
                        cmd.ExecuteNonQuery();
                    }

                    // Log the disbursement
                    string logQuery = @"
                        INSERT INTO AssistanceDisbursements (
                            RequestID, DisbursedBy, DisbursedAmount, DisbursementDate, Notes
                        ) VALUES (
                            @RequestID, @DisbursedBy, (SELECT Amount FROM GovernmentAssistance WHERE RequestID = @RequestID), 
                            GETDATE(), 'Disbursed through system'
                        )";

                    using (SqlCommand logCmd = new SqlCommand(logQuery, conn))
                    {
                        logCmd.Parameters.AddWithValue("@RequestID", requestID);
                        logCmd.Parameters.AddWithValue("@DisbursedBy", currentUserID);
                        logCmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Assistance has been disbursed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAssistanceRequests();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error disbursing assistance: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GovernmentAssistance_Load(object sender, EventArgs e)
        {
            InitializeUI();
            LoadAssistanceRequests();
        }
    }
}