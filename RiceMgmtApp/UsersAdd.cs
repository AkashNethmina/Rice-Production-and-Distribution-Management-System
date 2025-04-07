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

        private void LoadRoles()
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

        

        

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text) || cmbRole.SelectedItem == null)
            {
                MessageBox.Show("Please fill all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(txtPassword.Text);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Users (Username, FullName, PasswordHash, Email, ContactNumber, RoleID, Status) VALUES (@Username, @FullName, @PasswordHash, @Email, @ContactNumber, @RoleID, 'Active')", conn);
                cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                cmd.Parameters.AddWithValue("@FullName", txtFullName.Text);
                cmd.Parameters.AddWithValue("@PasswordHash", hashedPassword);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@ContactNumber", txtContact.Text);
                cmd.Parameters.AddWithValue("@RoleID", ((dynamic)cmbRole.SelectedItem).RoleID);
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("User added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // Remove the following lines as they are not applicable for UserControl
            // this.DialogResult = DialogResult.OK;
            // this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Add logic to handle cancel action appropriately for UserControl
            // For example, you might want to clear the form or navigate away
            this.Parent.Controls.Remove(this);
        }
    }
}
