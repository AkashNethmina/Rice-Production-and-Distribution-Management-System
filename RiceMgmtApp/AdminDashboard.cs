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
using Microsoft.VisualBasic.ApplicationServices;

namespace RiceMgmtApp
{
    public partial class AdminDashboard : Form
    {
        private int _userId;
        private int _roleId;

        public string LoggedInUsername { get; set; }

        public AdminDashboard(int userId, int roleId)
        {
            InitializeComponent();
            _userId = userId;
            _roleId = roleId;
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

        private void LoadUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void btn_Dashboard_Click(object sender, EventArgs e)
        {
            HideSubMenu();
            AdminHome ah = new AdminHome();
            LoadUserControl(ah);
        }

        private void btn_manUser_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panel2submenu);
        }

        private void btn_AllUsers_Click(object sender, EventArgs e)
        {
            UserManagement um = new UserManagement();
            LoadUserControl(um);
        }

        private void btn_AddUsers_Click(object sender, EventArgs e)
        {
            UsersAdd ua = new UsersAdd();
            LoadUserControl(ua);
        }

        private void btn_Farmers_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panel3side);
        }

        private void btn_AllFarmers_Click(object sender, EventArgs e)
        {
            FarmerManagement fm = new FarmerManagement();
            LoadUserControl(fm);
        }

        private void btn_Fields_Click(object sender, EventArgs e)
        {
            Fields fie = new Fields(_userId, _roleId);
            LoadUserControl(fie);
        }

        private void btn_Sales_Click(object sender, EventArgs e)
        {
            SalesManagement sm = new SalesManagement();
            LoadUserControl(sm);
        }

        private void btn_StockManagement_Click(object sender, EventArgs e)
        {
            StockManagement stm = new StockManagement();
            LoadUserControl(stm);
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            frm_login fl = new frm_login();
            fl.Show();
            this.Hide();
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            // Show AdminHome as default on load
            AdminHome ah = new AdminHome();
            LoadUserControl(ah);
        }

        private void btn_Cultivation_Click(object sender, EventArgs e)
        {
            Cultivation ca = new Cultivation();
            LoadUserControl(ca);
        }

        private void btn_DamageReporting_Click(object sender, EventArgs e)
        {

        }

        private void btn_PriceSetting_Click(object sender, EventArgs e)
        {
            Price_Monitoring pm = new Price_Monitoring(_roleId);
            LoadUserControl(pm);
        }
    }
}