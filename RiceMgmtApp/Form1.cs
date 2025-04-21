using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace RiceMgmtApp
{
    public partial class frm_login : Form
    {
        // Store connection string in a more secure way in production
        private readonly string _connectionString = "Server=DESKTOP-O6K3I3U\\SQLEXPRESS;Database=RiceProductionDB2;Integrated Security=True;";

        public frm_login()
        {
            InitializeComponent();
        }

        private void show_password_CheckedChanged(object sender, EventArgs e)
        {
            txt_password.UseSystemPasswordChar = !show_password.Checked;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            string username = txt_username.Text.Trim();
            string password = txt_password.Text.Trim();

            // Validate inputs
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Login Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    var userInfo = GetUserInfo(connection, username);

                    if (userInfo == null)
                    {
                        MessageBox.Show("User not found.", "Login Failed",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Check account status
                    if (userInfo.Status == "Suspended")
                    {
                        MessageBox.Show("Your account is suspended.", "Access Denied",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Verify password
                    if (VerifyPassword(password, userInfo.PasswordHash))
                    {
                        LogAuthAttempt(connection, userInfo.UserId, "Success");
                        RedirectUser(userInfo.RoleId, userInfo.UserId, username);
                    }
                    else
                    {
                        LogAuthAttempt(connection, userInfo.UserId, "Failure");
                        MessageBox.Show("Incorrect password.", "Login Failed",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private UserInfo GetUserInfo(SqlConnection connection, string username)
        {
            string query = "SELECT UserID, PasswordHash, RoleID, Status FROM Users WHERE Username = @Username";

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@Username", username);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new UserInfo
                        {
                            UserId = reader.GetInt32(0),
                            PasswordHash = reader.GetString(1),
                            RoleId = reader.GetInt32(2),
                            Status = reader.GetString(3)
                        };
                    }
                }
            }

            return null;
        }

        private bool VerifyPassword(string enteredPassword, string storedHash)
        {
            return BCrypt.Net.BCrypt.Verify(enteredPassword, storedHash);
        }

        private void LogAuthAttempt(SqlConnection connection, int userId, string status)
        {
            string query = "INSERT INTO AuthLogs (UserID, Status) VALUES (@UserID, @Status)";

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@UserID", userId);
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.ExecuteNonQuery();
            }
        }

        private void RedirectUser(int roleId, int userId, string username)
        {
            Form dashboard = null;
            string redirectMessage = string.Empty;

            switch (roleId)
            {
                case 1: // Admin
                    redirectMessage = "Redirecting to Admin Panel...";
                    dashboard = new AdminDashboard(userId, roleId);
                    break;
                case 2: // Farmer
                    redirectMessage = "Redirecting to Farmer Dashboard...";
                    dashboard = new FarmerDashboard(userId, roleId);
                    break;
                case 3: // Government Official
                    redirectMessage = "Redirecting to Government Panel...";
                    dashboard = new GovtOfficialDashboard(userId, roleId);
                    break;
                case 4: // Private Buyer
                    redirectMessage = "Redirecting to Private Buyer Panel...";
                    dashboard = new BuyerDashboard(userId, roleId);
                    break;
                default:
                    MessageBox.Show("Unknown role. Contact support.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }

            if (dashboard != null)
            {
                MessageBox.Show(redirectMessage);

                // Set username property using reflection to handle different form types
                var usernameProperty = dashboard.GetType().GetProperty("LoggedInUsername");
                if (usernameProperty != null)
                {
                    usernameProperty.SetValue(dashboard, username);
                }

                dashboard.Show();
                this.Hide();
            }
        }
    }

    // Helper class to store user information
    internal class UserInfo
    {
        public int UserId { get; set; }
        public string PasswordHash { get; set; }
        public int RoleId { get; set; }
        public string Status { get; set; }
    }
}