using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;

namespace RiceMgmtApp
{
    public partial class BuyerDashboard: Form
    {
        private int _userId;
        private int _roleId;
        public string LoggedInUsername { get; set; }

        public BuyerDashboard(int userId, int roleId)
        {
            InitializeComponent();
            _userId = userId;
            _roleId = roleId;
        }
        private void LoadControl(UserControl control)
        {
            control.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(control);
            control.BringToFront();
        }

        private void btn_Dashboard_Click(object sender, EventArgs e)
        {
            AdminHome ah = new AdminHome();
            LoadControl(ah);
        }

        // Load Profile view with logged-in username
        private void btn_profile_Click(object sender, EventArgs e)
        {
            profileControl pc = new profileControl();
            pc.LoggedInUsername = LoggedInUsername;
            pc.LoadUserDetails(); // Make sure this method exists in your profileControl
            LoadControl(pc);
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            frm_login fl = new frm_login();
            fl.Show();
            this.Close(); // Close instead of Hide for better resource management
        }

        private void btn_Sales_Click(object sender, EventArgs e)
        {
            BuyPaddy buyPaddy = new BuyPaddy(_userId); // Pass _userId as the buyerID
            LoadControl(buyPaddy);
        }

        private void btnPrice_Monitoring_Click(object sender, EventArgs e)
        {
            Price_Monitoring pm = new Price_Monitoring(_roleId);
            LoadControl(pm);
        }

        private void btn_Dashboard_Click_1(object sender, EventArgs e)
        {
            PrivateBuyerHome privateBuyerHome = new PrivateBuyerHome();
            LoadControl(privateBuyerHome);
        }

        private void btn_StockManagement_Click(object sender, EventArgs e)
        {
            StockManagement sm = new StockManagement(_userId, _roleId);
            LoadControl(sm);
        }
    }
}
