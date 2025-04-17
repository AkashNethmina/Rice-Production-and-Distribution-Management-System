using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace RiceMgmtApp
{
    public partial class UsersAdd : UserControl
    {
        private readonly string connectionString = "Server=DESKTOP-O6K3I3U\\SQLEXPRESS;Database=RiceProductionDB2;Integrated Security=True;";

        public UsersAdd()
        {
            InitializeComponent();
            LoadRoles();
        }
        private void LoadUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            userControl.BringToFront();
        }

        private void LoadRoles()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT RoleID, RoleName FROM Roles", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    cmbRole.DisplayMember = "RoleName";
                    cmbRole.ValueMember = "RoleID";

                    while (reader.Read())
                    {
                        cmbRole.Items.Add(new { RoleID = reader["RoleID"], RoleName = reader["RoleName"].ToString() });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading roles: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                cmbRole.SelectedItem == null)
            {
                MessageBox.Show("Please fill all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(txtPassword.Text);

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Check if username already exists
                    SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM Users WHERE Username = @Username", conn);
                    checkCmd.Parameters.AddWithValue("@Username", txtUsername.Text);

                    int userExists = (int)checkCmd.ExecuteScalar();
                    if (userExists > 0)
                    {
                        MessageBox.Show("Username already exists. Please choose a different username.",
                            "Duplicate Username", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Insert new user
                    SqlCommand cmd = new SqlCommand(
                        "INSERT INTO Users (Username, FullName, PasswordHash, Email, ContactNumber, RoleID, Status) " +
                        "VALUES (@Username, @FullName, @PasswordHash, @Email, @ContactNumber, @RoleID, 'Active')", conn);

                    cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                    cmd.Parameters.AddWithValue("@FullName", txtFullName.Text);
                    cmd.Parameters.AddWithValue("@PasswordHash", hashedPassword);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@ContactNumber", txtContact.Text);
                    cmd.Parameters.AddWithValue("@RoleID", ((dynamic)cmbRole.SelectedItem).RoleID);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("User added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding user: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Clear the form and navigate back to user management
            if (MessageBox.Show("Are you sure you want to cancel? All entered data will be lost.",
                "Confirm Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Check if Parent exists before using it
                if (this.Parent != null)
                {
                    // Navigate back to the User Management screen
                    UserManagement um = new UserManagement();
                    
                    this.Parent.Controls.Clear();
                    //this.Parent.Controls.Add(um);
                    LoadUserControl(um);
                }
                else
                {
                    // Handle the case where Parent is null
                    MessageBox.Show("Cannot navigate back. The control is not properly attached to a parent.",
                        "Navigation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ClearForm()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtFullName.Clear();
            txtEmail.Clear();
            txtContact.Clear();
            cmbRole.SelectedIndex = -1;
            txtUsername.Focus();
        }

        private void txtFullName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}