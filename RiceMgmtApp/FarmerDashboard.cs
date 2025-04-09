using System;
using System.Windows.Forms;

namespace RiceMgmtApp
{
    public partial class FarmerDashboard : Form
    {
        public string LoggedInUsername { get; set; }

        public FarmerDashboard()
        {
            InitializeComponent();
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
            AdminHome defaultHome = new AdminHome();
            LoadControl(defaultHome);
        }
    }
}
