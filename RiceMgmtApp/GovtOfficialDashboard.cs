using System;
using System.Windows.Forms;

namespace RiceMgmtApp
{
    public partial class GovtOfficialDashboard : Form
    {
        private bool sidebarExpanded;
        private int sidebarWidth;

        public GovtOfficialDashboard()
        {
            InitializeComponent();
            sidebarWidth = sidebarPanel.Width; // Store the original width
        }

        private void btnToggle_Click(object sender, EventArgs e)
        {
            sidebarTimer.Start();
        }

        private void sidebarTimer_Tick(object sender, EventArgs e)
        {
            if (sidebarExpanded)
            {
                // Collapse sidebar
                sidebarPanel.Width -= 10;
                if (sidebarPanel.Width <= 50)
                {
                    sidebarExpanded = false;
                    sidebarTimer.Stop();
                }
            }
            else
            {
                // Expand sidebar
                sidebarPanel.Width += 10;
                if (sidebarPanel.Width >= sidebarWidth)
                {
                    sidebarExpanded = true;
                    sidebarTimer.Stop();
                }
            }
        }
    }
}
