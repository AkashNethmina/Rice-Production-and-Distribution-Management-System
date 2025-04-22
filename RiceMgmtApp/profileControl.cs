using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RiceMgmtApp
{
    public partial class profileControl : UserControl
    {
        private readonly string connectionString = "Server=DESKTOP-O6K3I3U\\SQLEXPRESS;Database=RiceProductionDB2;Integrated Security=True;";
        public string LoggedInUsername { get; set; }

        public profileControl()
        {
            InitializeComponent();
        }

        private void profileControl_Load(object sender, EventArgs e)
        {
            LoadUserDetails();
        }

        public void LoadUserDetails()
        {
            if (string.IsNullOrEmpty(LoggedInUsername))
            {
                MessageBox.Show("Username is not set. Cannot load profile.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
                        SELECT U.UserID, U.FullName, U.Username, U.Email, U.ContactNumber, U.Status, R.RoleName
                        FROM Users U
                        JOIN Roles R ON U.RoleID = R.RoleID
                        WHERE U.Username = @Username";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", LoggedInUsername);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtFullName.Text = reader["FullName"].ToString();
                                txtUsername.Text = reader["Username"].ToString();
                                txtEmail.Text = reader["Email"].ToString();
                                txtContact.Text = reader["ContactNumber"].ToString();
                                txtStatus.Text = reader["Status"].ToString();
                                txtRole.Text = reader["RoleName"].ToString();

                                txtUsername.ReadOnly = true;
                                txtRole.ReadOnly = true;
                                txtStatus.ReadOnly = true;
                            }
                            else
                            {
                                MessageBox.Show("User not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading user data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateProfile(bool updatePassword = false)
        {
            if (string.IsNullOrEmpty(LoggedInUsername))
            {
                MessageBox.Show("Username not set.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Update basic profile details
                    string updateQuery = @"
                        UPDATE Users 
                        SET FullName = @FullName, Email = @Email, ContactNumber = @Contact 
                        WHERE Username = @Username";

                    using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@FullName", txtFullName.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@Contact", txtContact.Text.Trim());
                        cmd.Parameters.AddWithValue("@Username", LoggedInUsername);
                        cmd.ExecuteNonQuery();
                    }

                    // If password change is requested
                    if (updatePassword && !string.IsNullOrWhiteSpace(txtNewPassword.Text))
                    {
                        if (txtNewPassword.Text != txtConfirmPassword.Text)
                        {
                            MessageBox.Show("Passwords do not match.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(txtNewPassword.Text);
                        string passwordUpdateQuery = "UPDATE Users SET PasswordHash = @Hash WHERE Username = @Username";

                        using (SqlCommand cmd = new SqlCommand(passwordUpdateQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@Hash", hashedPassword);
                            cmd.Parameters.AddWithValue("@Username", LoggedInUsername);
                            cmd.ExecuteNonQuery();
                        }

                        txtNewPassword.Clear();
                        txtConfirmPassword.Clear();
                    }

                    MessageBox.Show("Profile updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadUserDetails();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating profile: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateProfile(updatePassword: false); // Only updates name, email, contact
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            UpdateProfile(updatePassword: true); // Updates password (and profile if needed)
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = chkShowPassword.Checked;

            txtNewPassword.UseSystemPasswordChar = !isChecked;
            txtConfirmPassword.UseSystemPasswordChar = !isChecked;
        }
    }
}