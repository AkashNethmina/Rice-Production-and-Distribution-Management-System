using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace RiceMgmtApp
{
    public partial class Form1: Form
    {
        private readonly string connectionString = "Server=DESKTOP-O6K3I3U\\SQLEXPRESS;Database=RiceProductionDB2;Integrated Security=True;";
        //SqlConnection con = new SqlConnection(Properties.Settings.Default.RiceProductionDB2ConnectionString);
        //SqlDataAdapter da;
        //SqlCommand cmd;
        public Form1()
        {
            InitializeComponent();
        }

        private void show_password_CheckedChanged(object sender, EventArgs e)
        {
            if (show_password.Checked)
            {
                txt_password.UseSystemPasswordChar = false;
            }
            else
            {
                txt_password.UseSystemPasswordChar = true;
            }
        }
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txt_username_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_password_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            string username = txt_username.Text.Trim();
            string password = txt_password.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    string query = @"
                SELECT U.UserID, U.RoleID, R.RoleName 
                FROM Users U 
                JOIN Roles R ON U.RoleID = R.RoleID 
                WHERE U.Username = @username 
                AND U.PasswordHash = @password 
                AND U.Status = 'Active'";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password); // Ensure password is hashed

                        using (SqlDataReader reader = cmd.ExecuteReader())  // ✅ Using block ensures closing
                        {
                            if (reader.Read())
                            {
                                int userId = Convert.ToInt32(reader["UserID"]);
                                string role = reader["RoleName"].ToString();

                                MessageBox.Show($"Login successful! Role: {role}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                reader.Close(); // ✅ Ensure reader is closed before executing another query

                                // Open dashboard based on role
                                Form dashboard = null;
                                switch (role)
                                {
                                    case "Admin":
                                        dashboard = new AdminDashboard();
                                        break;
                                    case "Farmer":
                                        dashboard = new FarmerDashboard();
                                        break;
                                    case "Government Official":
                                        dashboard = new GovtOfficialDashboard();
                                        break;
                                    case "Private Buyer":
                                        dashboard = new BuyerDashboard();
                                        break;
                                }

                                if (dashboard != null)
                                {
                                    dashboard.Show();
                                    this.Hide();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        } // ✅ SqlDataReader is closed automatically here
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Logs authentication attempts in the AuthLogs table.
        /// </summary>
        private void LogAuthAttempt(SqlConnection con, int? userId, string status)
        {
            string logQuery = "INSERT INTO AuthLogs (UserID, Status) VALUES (@userId, @status)";
            using (SqlCommand logCmd = new SqlCommand(logQuery, con))
            {
                logCmd.Parameters.AddWithValue("@userId", (object)userId ?? DBNull.Value);
                logCmd.Parameters.AddWithValue("@status", status);
                logCmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Computes SHA-256 hash for password security.
        /// </summary>
        private string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
