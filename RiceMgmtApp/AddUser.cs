using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RiceMgmtApp
{
    public partial class AddUser : Form
    {
        private readonly string connectionString = "Server=DESKTOP-O6K3I3U\\SQLEXPRESS;Database=RiceProductionDB2;Integrated Security=True;";

        public AddUser()
        {
            InitializeComponent();
            LoadRoles();
        }

        private void LoadRoles()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT RoleID, RoleName FROM Roles", conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable rolesTable = new DataTable();
                adapter.Fill(rolesTable);

                cmbRole.DisplayMember = "RoleName";
                cmbRole.ValueMember = "RoleID";
                cmbRole.DataSource = rolesTable;
            }
        }

        private void RedirectToUserManagement()
        {
            UserManagement userMgmt = new UserManagement();
            userMgmt.Show(); // Show the UserManagement form
            this.Close();    // Close the current form (if appropriate)
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) ||
        string.IsNullOrWhiteSpace(txtPassword.Text) ||
        cmbRole.SelectedValue == null)
            {
                MessageBox.Show("Please fill all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(txtPassword.Text);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Users (Username, FullName, PasswordHash, Email, ContactNumber, RoleID, Status) VALUES (@Username, @FullName, @PasswordHash, @Email, @ContactNumber, @RoleID, 'Active')", conn);
                cmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
                cmd.Parameters.AddWithValue("@FullName", txtFullName.Text.Trim());
                cmd.Parameters.AddWithValue("@PasswordHash", hashedPassword);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@ContactNumber", txtContact.Text.Trim());
                cmd.Parameters.AddWithValue("@RoleID", cmbRole.SelectedValue);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("User added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Redirect to UserManagement screen
            RedirectToUserManagement();
        }

        

        private void btnCancel_Click(object sender, EventArgs e)
        {
            RedirectToUserManagement();
        }
    }
}
