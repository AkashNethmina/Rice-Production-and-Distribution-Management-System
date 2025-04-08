using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace RiceMgmtApp
{
    public partial class UserManagement : UserControl
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["RiceMgmtApp.Properties.Settings.RiceProductionDB2ConnectionString"].ConnectionString;

        public UserManagement()
        {
            InitializeComponent();
            this.Load += UserManagement_Load;
            this.dataGridViewusers.CellClick += dataGridViewusers_CellClick;
        }

        private void UserManagement_Load(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void LoadUsers()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            U.UserID, 
                            U.FullName, 
                            U.Username, 
                            U.Email, 
                            U.ContactNumber, 
                            R.RoleName, 
                            U.Status 
                        FROM Users U
                        INNER JOIN Roles R ON U.RoleID = R.RoleID";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridViewusers.DataSource = dt;

                    AddActionButtons();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading users: " + ex.Message);
                }
            }
        }

        private void AddActionButtons()
        {
            // Avoid adding buttons again
            if (!dataGridViewusers.Columns.Contains("EditButton"))
            {
                // Edit
                DataGridViewButtonColumn editBtn = new DataGridViewButtonColumn
                {
                    Name = "EditButton",
                    HeaderText = "Edit",
                    Text = "Edit",
                    UseColumnTextForButtonValue = true
                };
                dataGridViewusers.Columns.Add(editBtn);

                // Suspend
                DataGridViewButtonColumn suspendBtn = new DataGridViewButtonColumn
                {
                    Name = "SuspendButton",
                    HeaderText = "Suspend",
                    Text = "Suspend",
                    UseColumnTextForButtonValue = true
                };
                dataGridViewusers.Columns.Add(suspendBtn);

                // Delete
                DataGridViewButtonColumn deleteBtn = new DataGridViewButtonColumn
                {
                    Name = "DeleteButton",
                    HeaderText = "Delete",
                    Text = "Delete",
                    UseColumnTextForButtonValue = true
                };
                dataGridViewusers.Columns.Add(deleteBtn);
            }
        }

        private void dataGridViewusers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int userId = Convert.ToInt32(dataGridViewusers.Rows[e.RowIndex].Cells["UserID"].Value);
            string status = dataGridViewusers.Rows[e.RowIndex].Cells["Status"].Value.ToString();
            string columnName = dataGridViewusers.Columns[e.ColumnIndex].Name;

            switch (columnName)
            {
                case "EditButton":
                    LoadEditUserControl(userId);
                    break;

                case "SuspendButton":
                    string newStatus = status == "Active" ? "Suspended" : "Active";
                    UpdateUserStatus(userId, newStatus);
                    break;

                case "DeleteButton":
                    DialogResult result = MessageBox.Show("Are you sure to delete this user?", "Confirm Delete", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        DeleteUser(userId);
                    }
                    break;
            }
        }

        private void LoadEditUserControl(int userId)
        {
            EditUser editUserControl = new EditUser();
            editUserControl.Dock = DockStyle.Fill;
            editUserControl.LoadUserData(userId);

            Control parent = this.Parent;
            if (parent != null)
            {
                parent.Controls.Clear();
                parent.Controls.Add(editUserControl);
            }
        }

        private void UpdateUserStatus(int userId, string newStatus)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Users SET Status = @Status WHERE UserID = @UserID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Status", newStatus);
                cmd.Parameters.AddWithValue("@UserID", userId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }

            LoadUsers();
        }

        private void DeleteUser(int userId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Users WHERE UserID = @UserID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserID", userId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }

            LoadUsers();
        }
    }
}
