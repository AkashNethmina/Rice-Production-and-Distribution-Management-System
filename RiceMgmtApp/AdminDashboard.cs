using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RiceMgmtApp
{
    public partial class AdminDashboard : Form
    {
        private readonly string connectionString = "Server=DESKTOP-O6K3I3U\\SQLEXPRESS;Database=RiceProductionDB2;Integrated Security=True;";

        public AdminDashboard(string log)
        {
            InitializeComponent();
            LoadDashboardData();
            customizeDashboard();
        }

        private void customizeDashboard()
        {
            panelDashboard.Visible = true;
            panelUsers.Visible = false;
            panelFarmers.Visible = false;
            panelSales.Visible = false;
        }
        private void hideSubMenu()
        {
            //if (panelsubmenu.Visible == true)
            //    panelsubmenu.Visible = false;
            if (panel2submenu.Visible == true)
                panel2submenu.Visible = false;
        }

        private void showSection(Panel panel)
        {
            panelDashboard.Visible = false;
            panelUsers.Visible = false;
            panelFarmers.Visible = false;
            panelSales.Visible = false;

            panel.Visible = true; // Show selected panel
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        private void LoadDashboardData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Fetch total users
                    SqlCommand cmdUsers = new SqlCommand("SELECT COUNT(*) FROM Users", conn);
                    lblTotalUsers.Text = cmdUsers.ExecuteScalar().ToString();

                    // Fetch total farmers
                    SqlCommand cmdFarmers = new SqlCommand("SELECT COUNT(*) FROM Users WHERE RoleID = (SELECT RoleID FROM Roles WHERE RoleName = 'Farmer')", conn);
                    lblTotalFarmers.Text = cmdFarmers.ExecuteScalar().ToString();

                    // Fetch total sales
                    SqlCommand cmdSales = new SqlCommand("SELECT COUNT(*) FROM Sales", conn);
                    lblTotalSales.Text = cmdSales.ExecuteScalar().ToString();

                    // Fetch pending damage reports
                    SqlCommand cmdDamage = new SqlCommand("SELECT COUNT(*) FROM DamageReports WHERE Status = 'Pending'", conn);
                    lblPendingReports.Text = cmdDamage.ExecuteScalar().ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading dashboard data: " + ex.Message);
            }
        }

        // Button Click Events to Show Panels
        private void btn_Dashboard_Click(object sender, EventArgs e)
        {
            showSection(panelDashboard);
            hideSubMenu();
        }

        private void btn_manUser_Click(object sender, EventArgs e)
        {
            showSubMenu(panel2submenu);
            
        }

        private void btn_Farmers_Click(object sender, EventArgs e)
        {
            showSection(panelFarmers);
            hideSubMenu();
        }

        private void btn_Sales_Click(object sender, EventArgs e)
        {
            showSection(panelSales);
            hideSubMenu();
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            frm_login fl = new frm_login();
            fl.Show();
            this.Hide();
        }
    }
}

