using System;
using System.Windows.Forms;

namespace RiceMgmtApp
{
    public partial class GovtOfficialDashboard : Form
    {
        private int _userId;
        private int _roleId;
        public string LoggedInUsername { get; set; }

        private bool sidebarExpanded;
        private int sidebarWidth;

        public GovtOfficialDashboard(int userId, int roleId)
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

        private void btnPrice_Monitoring_Click(object sender, EventArgs e)
        {
            Price_Monitoring pm = new Price_Monitoring(_roleId);
            LoadControl(pm);
        }

        private void panelContainer_Paint(object sender, PaintEventArgs e)
        {

        }

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
    }
}
