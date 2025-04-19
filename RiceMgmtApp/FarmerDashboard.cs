using System;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;

namespace RiceMgmtApp
{
    public partial class FarmerDashboard : Form
    {
        private int _userId;
        private int _roleId;
        public string LoggedInUsername { get; set; }

        public FarmerDashboard(int userId, int roleId)
        {
            InitializeComponent();
            _userId = userId;
            _roleId = roleId;
        }

        // Generic method to load any UserControl into the container panel
        private void LoadControl(UserControl control)
        {
            control.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(control);
            control.BringToFront();
        }

        // Load Dashboard view
        private void btn_Dashboard_Click(object sender, EventArgs e)
        {
            FarmerHome farmerHome = new FarmerHome();
            LoadControl(farmerHome);
        }

        // Load Profile view with logged-in username
        private void btn_profile_Click(object sender, EventArgs e)
        {
            profileControl pc = new profileControl();
            pc.LoggedInUsername = LoggedInUsername;
            pc.LoadUserDetails(); // Make sure this method exists in your profileControl
            LoadControl(pc);
        }

        // Logout and return to login form
        private void btn_logout_Click(object sender, EventArgs e)
        {
            frm_login fl = new frm_login();
            fl.Show();
            this.Close(); // Close instead of Hide for better resource management
        }

        private void FarmerDashboard_Load(object sender, EventArgs e)
        {
            // Optionally load a default control when form loads
           
        }

        private void btn_Farmers_Click(object sender, EventArgs e)
        {
            int currentUserId = _userId; // Replace with the actual user ID
            int currentUserRoleId = _roleId; // Replace with the actual role ID

            Fields fie = new Fields(currentUserId, currentUserRoleId);
            LoadControl(fie);
        }

        private void panelsideMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnPrice_Monitoring_Click(object sender, EventArgs e)
        {
            Price_Monitoring pm = new Price_Monitoring(_roleId);
            LoadControl(pm);
        }

        private void btn_Sales_Click(object sender, EventArgs e)
        {
            SellPady sellPady = new SellPady(_userId); // Pass _userId as the buyerID
            LoadControl(sellPady);
        }

        private void btn_StockManagement_Click(object sender, EventArgs e)
        {
            StockManagement sm = new StockManagement(_userId, _roleId);
            LoadControl(sm);
        }

        private void btn_DamageReporting_Click(object sender, EventArgs e)
        {
            DamageReporting damageReporting = new DamageReporting();
            LoadControl(damageReporting);
        }
    }
}
