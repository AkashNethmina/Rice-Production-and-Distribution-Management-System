using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace RiceMgmtApp
{
    public partial class EditUser : UserControl
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["RiceMgmtApp.Properties.Settings.RiceProductionDB2ConnectionString"].ConnectionString;
        private int currentUserId;
        private bool isLoading = false;

        public EditUser()
        {
            InitializeComponent();
            this.Load += EditUser_Load;
        }

        public void LoadUserData(int userId)
        {
            isLoading = true;
            currentUserId = userId;

            LoadStatusOptions();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT U.FullName, U.Username, U.Email, U.ContactNumber, U.RoleID, U.Status
            FROM Users U
            WHERE U.UserID = @UserID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserID", userId);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    txtFullName.Text = reader["FullName"].ToString();
                    txtUsername.Text = reader["Username"].ToString();
                    txtEmail.Text = reader["Email"].ToString();
                    txtContact.Text = reader["ContactNumber"].ToString();
                   
                    string status = reader["Status"] != DBNull.Value ? reader["Status"].ToString() : "Active";

                    if (comboStatus.Items.Contains(status))
                    {
                        comboStatus.SelectedItem = status;
                    }
                    else
                    {
                        comboStatus.SelectedItem = "Active";
                    }
                    if (reader["RoleID"] != DBNull.Value)
                    {
                        comboRole.SelectedValue = Convert.ToInt32(reader["RoleID"]);
                    }
                }

                reader.Close();
            }

            isLoading = false;
        }

        private void EditUser_Load(object sender, EventArgs e)
        {
            LoadRoles();
            LoadStatusOptions();
        }

        private void LoadRoles()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT RoleID, RoleName FROM Roles";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                comboRole.DataSource = dt;
                comboRole.DisplayMember = "RoleName";
                comboRole.ValueMember = "RoleID";
            }
        }

        private void LoadStatusOptions()
        {
            comboStatus.Items.Clear();
            comboStatus.Items.Add("Active");
            comboStatus.Items.Add("Suspended");
        }

        private void comboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoading || comboStatus.SelectedItem == null)
                return;

            string selectedStatus = comboStatus.SelectedItem.ToString();

            if (selectedStatus == "Active")
            {
                MessageBox.Show("User is now Active.", "Status Changed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = true;
            }
            else if (selectedStatus == "Suspended")
            {
                MessageBox.Show("User is Suspended.", "Status Changed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnSave.Enabled = true;
            }
            else
            {
                MessageBox.Show("Unknown status selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            if (comboStatus.SelectedItem == null)
            {
                comboStatus.SelectedItem = "Active"; 
            }

            if (comboRole.SelectedValue == null)
            {
                MessageBox.Show("Please select a role before saving.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
            UPDATE Users
            SET FullName = @FullName,
                Username = @Username,
                Email = @Email,
                ContactNumber = @Contact,
                RoleID = @RoleID,
                Status = @Status
            WHERE UserID = @UserID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FullName", txtFullName.Text);
                cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Contact", txtContact.Text);
                cmd.Parameters.AddWithValue("@RoleID", comboRole.SelectedValue);
                cmd.Parameters.AddWithValue("@Status", comboStatus.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@UserID", currentUserId);

                conn.Open();
                cmd.ExecuteNonQuery();

                MessageBox.Show("User updated successfully.");
            }

            RedirectToUserManagement();
        }

        private void RedirectToUserManagement()
        {
            UserManagement userMgmt = new UserManagement(); // ensure this UserControl exists
            Control parent = this.Parent;

            if (parent != null)
            {
                parent.Controls.Clear();
                userMgmt.Dock = DockStyle.Fill;
                parent.Controls.Add(userMgmt);
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            RedirectToUserManagement();
        }
    }
}
