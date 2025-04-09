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
       // private readonly string connectionString = "Server=DESKTOP-O6K3I3U\\SQLEXPRESS;Database=RiceProductionDB2;Integrated Security=True;";

        public AdminDashboard(string log)
        {
            InitializeComponent();
        }

        

        private void HideSubMenu()
        {
            if (panel2submenu.Visible)
                panel2submenu.Visible = false;
            if (panel3side.Visible)
                panel3side.Visible = false;
        }

        private void ShowSection(Panel panel)
        {
            //panelDashboard.Visible = false;
           // panelUsers.Visible = false;
            //panelFarmers.Visible = false;
            //panelSales.Visible = false;

            panel.Visible = true;
        }

        private void ShowSubMenu(Panel subMenu)
        {
            if (!subMenu.Visible)
            {
                HideSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }


        private void HomeControl(UserControl homeControl) // Change HomeControl to UserControl
        {
            homeControl.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(homeControl);
            homeControl.BringToFront();
        }
        private void btn_Dashboard_Click(object sender, EventArgs e)
        {
           // ShowSection(panelDashboard);
            HideSubMenu();
          //  LoadDashboardData(); // Refresh dashboard data

            AdminHome ah = new AdminHome();
            HomeControl(ah);
           
        }

        private void btn_manUser_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panel2submenu);
        }
        private void AllUsersControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(userControl);
            userControl.BringToFront();
        }
        private void btn_AllUsers_Click(object sender, EventArgs e)
        {
            UserManagement um = new UserManagement();
            AllUsersControl(um);
        }

        private void AddUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(userControl);
            userControl.BringToFront();
        }


        

     

        private void btn_Farmers_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panel3side);
        }

        private void btn_FarmersList_Click(object sender, EventArgs e)
        {
           // LoadFarmerManagement();
          //  ShowSection(panelFarmers); // Make sure to show the panel after loading data
        }

        

        private void btn_logout_Click(object sender, EventArgs e)
        {
            frm_login fl = new frm_login();
            fl.Show();
            this.Hide();
        }

        private void FieldsControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(userControl);
            userControl.BringToFront();
        }


        private void btn_Fields_Click(object sender, EventArgs e)
        {
            Fields fie = new Fields();

            FieldsControl(fie);

        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'riceProductionDB2DataSet.Users' table. You can move, or remove it, as needed.
            this.usersTableAdapter.Fill(this.riceProductionDB2DataSet.Users);

        }


        private void btn_AddUsers_Click(object sender, EventArgs e)
        {
            UsersAdd ua = new UsersAdd();
            AddUserControl(ua);
        }

        private void AllFarmersControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void btn_AllFarmers_Click(object sender, EventArgs e)
        {
            FarmerManagement fm = new FarmerManagement();
            
            AllFarmersControl(fm);
        }

        private void SalesManagementControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void btn_Sales_Click(object sender, EventArgs e)
        {
            SalesManagement sm = new SalesManagement();
            SalesManagementControl(sm);
        }
        private void StockManagementControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(userControl);
            userControl.BringToFront();
        }
        private void btn_StockManagement_Click(object sender, EventArgs e)
        {
            StockManagement stm = new StockManagement();
            StockManagementControl(stm);
        }
    }
}