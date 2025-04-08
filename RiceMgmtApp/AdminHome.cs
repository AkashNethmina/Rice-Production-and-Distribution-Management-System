using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RiceMgmtApp
{
    public partial class AdminHome : UserControl
    {
        private readonly string connectionString = "Server=DESKTOP-O6K3I3U\\SQLEXPRESS;Database=RiceProductionDB2;Integrated Security=True;";
        public AdminHome()
        {
            InitializeComponent();
            LoadDashboardData();
        }

        private void LoadDashboardData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    lblTotalUsers.Text = ExecuteScalarQuery(conn, "SELECT COUNT(*) FROM Users");
                    lblTotalFarmers.Text = ExecuteScalarQuery(conn, "SELECT COUNT(*) FROM Users WHERE RoleID = (SELECT RoleID FROM Roles WHERE RoleName = 'Farmer')");
                    lblTotalSales.Text = ExecuteScalarQuery(conn, "SELECT COUNT(*) FROM Sales");
                    lblPendingReports.Text = ExecuteScalarQuery(conn, "SELECT COUNT(*) FROM DamageReports WHERE Status = 'Pending'");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading dashboard data: " + ex.Message);
            }
        }

        private string ExecuteScalarQuery(SqlConnection conn, string query)
        {
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                object result = cmd.ExecuteScalar();
                return result != null ? result.ToString() : "0";
            }
        }
    }
}
