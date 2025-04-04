using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace RiceMgmtApp
{
    public partial class frm_login : Form
    {
        private readonly string connectionString = "Server=DESKTOP-O6K3I3U\\SQLEXPRESS;Database=RiceProductionDB2;Integrated Security=True;";

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

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT UserID, PasswordHash, RoleID, Status FROM Users WHERE Username = @Username";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int userId = reader.GetInt32(0);
                            string storedHash = reader.GetString(1);
                            int roleId = reader.GetInt32(2);
                            string status = reader.GetString(3);

                            if (status == "Suspended")
                            {
                                MessageBox.Show("Your account is suspended.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            if (VerifyPassword(password, storedHash))
                            {
                                LogAuthAttempt(userId, "Success");
                               // MessageBox.Show("Login successful!", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Redirect user based on role
                                RedirectUser(roleId);
                            }
                            else
                            {
                                LogAuthAttempt(userId, "Failure");
                                MessageBox.Show("Incorrect password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("User not found.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
        }

        //private bool VerifyPassword(string enteredPassword, string storedHash)
        //{
        //    string enteredHash = HashPassword(enteredPassword);
        //    return enteredHash == storedHash;
        //}

        //private bool VerifyPassword(string enteredPassword, string storedHash)
        //{
        //    string enteredHash = HashPassword(enteredPassword);
        //    // Debug - remove in production
        //    Console.WriteLine($"Entered hash: {enteredHash}");
        //    Console.WriteLine($"Stored hash: {storedHash}");
        //    return enteredHash == storedHash;
        //}

        private bool VerifyPassword(string enteredPassword, string storedHash)
        {
            return BCrypt.Net.BCrypt.Verify(enteredPassword, storedHash);
        }


        private void LogAuthAttempt(int userId, string status)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "INSERT INTO AuthLogs (UserID, Status) VALUES (@UserID, @Status)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    cmd.Parameters.AddWithValue("@Status", status);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        
        private void RedirectUser(int roleId)
        {
            string username = txt_username.Text.Trim(); // Get the logged-in username
            switch (roleId)
            {
                case 1: // Admin
                    //MessageBox.Show("Redirecting to Admin Panel...");
                    AdminDashboard adminForm = new AdminDashboard(username);
                    adminForm.Show();
                    this.Hide();
                    break;
                case 2: // Farmer
                    //MessageBox.Show("Redirecting to Farmer Dashboard...");
                    FarmerDashboard farmerForm = new FarmerDashboard();
                    farmerForm.Show();
                    this.Hide();
                    break;
                case 3: // Government Official
                    //MessageBox.Show("Redirecting to Government Panel...");
                    GovtOfficialDashboard govtForm = new GovtOfficialDashboard();
                    govtForm.Show();
                    this.Hide();
                    break;
                case 4: // Private Buyer
                  //  MessageBox.Show("Redirecting to Private Buyer Panel...");
                    BuyerDashboard buyerForm = new BuyerDashboard();
                    buyerForm.Show();
                    this.Hide();
                    break;
                default:
                    MessageBox.Show("Unknown role. Contact support.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

       
    }
}
