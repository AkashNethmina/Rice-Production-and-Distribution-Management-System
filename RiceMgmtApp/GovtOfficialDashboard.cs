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
using System.Runtime.InteropServices;
using System.Threading;

namespace RiceMgmtApp
{
    public partial class GovtOfficialDashboard : Form
    {
        private int _userId;
        private int _roleId;
        private Button activeButton;
        private Panel loadingPanel;
        private LoadingProgressBar progressBar;

        public string LoggedInUsername { get; set; }
        private bool sidebarExpanded = true;
        private int expandedSidebarWidth = 250;
        private int collapsedSidebarWidth = 60;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );

        public GovtOfficialDashboard(int userId, int roleId)
        {
            InitializeComponent();
            InitializeProgressBar();
            InitializeBreadcrumb();
            _userId = userId;
            _roleId = roleId;

            // Add event handlers for resizing
            this.Resize += GovtOfficialDashboard_Resize;

            // Set minimum form size
            this.MinimumSize = new Size(900, 600);
        }

        private async void LoadUserControl(UserControl userControl)
        {
            ShowLoadingIndicator();

            if (progressBar == null)
                InitializeProgressBar();

            progressBar.Visible = true;
            progressBar.StartLoading();

            // Simulate loading time (or do real async init here)
            await Task.Delay(300);

            progressBar.StopLoading();

            userControl.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(userControl);
            userControl.BringToFront();

            await Task.Delay(200); // slight delay for smooth UI
            HideLoadingIndicator();
            progressBar.Visible = false;
        }


        private void btnPrice_Monitoring_Click(object sender, EventArgs e)
        {
            Price_Monitoring pm = new Price_Monitoring(_roleId);
            LoadUserControl(pm);
            SetActiveButton(btnPrice_Monitoring);
            UpdateBreadcrumb("Price Monitoring");
        }

        private void btn_profile_Click(object sender, EventArgs e)
        {
            profileControl pc = new profileControl();
            pc.LoggedInUsername = LoggedInUsername;
            pc.LoadUserDetails( ); // Make sure this method exists in your profileControl
            LoadUserControl(pc);
            SetActiveButton(btn_profile);
            UpdateBreadcrumb("Profile");
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            frm_login fl = new frm_login();
            fl.Show();
            this.Close(); // Close instead of Hide for better resource management
        }
        private void btn_logout_MouseEnter(object sender, EventArgs e)
        {
            btn_logout.BackColor = System.Drawing.Color.FromArgb(200, 35, 51); // Darker red on hover
        }

        private void btn_logout_MouseLeave(object sender, EventArgs e)
        {
            btn_logout.BackColor = System.Drawing.Color.FromArgb(220, 53, 69); // Back to original red
        }

        private void btn_Dashboard_Click(object sender, EventArgs e)
        {
            GovernmentHome governmentHome = new GovernmentHome(_userId); // Pass the required parameter
            LoadUserControl(governmentHome);
            SetActiveButton(btn_Dashboard);
            UpdateBreadcrumb("Dashboard");
        }

        private void btn_StockManagement_Click(object sender, EventArgs e)
        {
            StockManagement sm = new StockManagement(_userId, _roleId);
            LoadUserControl(sm);
            SetActiveButton(btn_StockManagement);
            UpdateBreadcrumb("Stock Management");
        }

        private void btn_DamageReporting_Click(object sender, EventArgs e)
        {
            DamageReporting dr = new DamageReporting();
            dr.SetUserContext(_userId, _roleId); // Set user context after instantiation
            LoadUserControl(dr);
        }

       

        private void panelContainer_Paint(object sender, PaintEventArgs e)
        {
            // Can be used for custom painting if needed
        }

        #region Responsive Design Implementation

        private void GovtOfficialDashboard_Resize(object sender, EventArgs e)
        {
            // Adjust UI elements based on form size
            ResizeUI();
        }

        private void ResizeUI()
        {
            // Adjust panel container margins based on window size
            int margin = this.Width < 1000 ? 10 : 20;
            panelContainer.Padding = new Padding(margin);

            // Potentially collapse side menu to icons only when window is narrow
            if (this.Width < 800 && sidebarExpanded)
            {
                CollapseMenu();
            }
            else if (this.Width >= 800 && !sidebarExpanded)
            {
                ExpandMenu();
            }

            // Make container panel slightly rounded
            panelContainer.Region = System.Drawing.Region.FromHrgn(
                CreateRoundRectRgn(0, 0, panelContainer.Width, panelContainer.Height, 15, 15)
            );
        }

        private void CollapseMenu()
        {
            sidebarExpanded = false;
            panelsideMenu.Width = collapsedSidebarWidth;
            foreach (Control ctrl in panelsideMenu.Controls)
            {
                if (ctrl is Button btn && !(ctrl is Panel))
                {
                    btn.ImageAlign = ContentAlignment.MiddleCenter;
                    btn.Padding = new Padding(0);
                    // Store text somewhere if you need to restore it later
                    btn.Tag = btn.Text;
                    btn.Text = "";
                }
            }
        }

        private void ExpandMenu()
        {
            sidebarExpanded = true;
            panelsideMenu.Width = expandedSidebarWidth;
            foreach (Control ctrl in panelsideMenu.Controls)
            {
                if (ctrl is Button btn && !(ctrl is Panel))
                {
                    if (btn.Tag != null && btn.Tag is string)
                    {
                        // Restore original text from tag
                        btn.Text = (string)btn.Tag;
                        btn.Tag = null;
                    }
                    btn.TextAlign = ContentAlignment.MiddleLeft;
                    btn.Padding = new Padding(10, 0, 0, 0);
                }
            }
        }

        private void ConfigureForScreenResolution()
        {
            // Get screen resolution
            Screen screen = Screen.FromControl(this);
            int screenWidth = screen.Bounds.Width;
            int screenHeight = screen.Bounds.Height;

            // Adjust based on resolution
            if (screenWidth <= 1366) // Common laptop resolution
            {
                this.Font = new Font(this.Font.FontFamily, this.Font.Size - 1);
                if (this.Width < 1200)
                {
                    CollapseMenu();
                }
            }
            else if (screenWidth >= 1920) // Full HD and higher
            {
                // Can increase padding, font sizes for better readability
                this.Font = new Font(this.Font.FontFamily, this.Font.Size + 1);
                panelContainer.Padding = new Padding(20);
            }
        }

        // Toggle sidebar expansion
        private void btnToggleSidebar_Click(object sender, EventArgs e)
        {
            if (sidebarExpanded)
            {
                CollapseMenu();
            }
            else
            {
                ExpandMenu();
            }
        }

        #endregion

        #region UI Enhancement Methods

        private Label breadcrumbLabel;

        private void InitializeBreadcrumb()
        {
            breadcrumbLabel = new Label();
            breadcrumbLabel.Font = new Font("Outfit", 12, FontStyle.Regular);
            breadcrumbLabel.ForeColor = Color.FromArgb(80, 80, 80);
            breadcrumbLabel.Location = new Point(270, 5);
            breadcrumbLabel.AutoSize = true;
            this.Controls.Add(breadcrumbLabel);
        }

        private void UpdateBreadcrumb(string currentPage)
        {
            if (breadcrumbLabel == null)
            {
                InitializeBreadcrumb();
            }

            breadcrumbLabel.Text = "Home > " + currentPage;
        }

        private void SetActiveButton(Button button)
        {
            if (activeButton != null)
            {
                // Reset previous active button
                activeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(179)))), ((int)(((byte)(86)))));
                activeButton.ForeColor = Color.White;
            }

            // Set new active button
            activeButton = button;
            activeButton.BackColor = Color.White;
            activeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(179)))), ((int)(((byte)(86)))));
        }

        private void InitializeProgressBar()
        {
            progressBar = new LoadingProgressBar();
            progressBar.Dock = DockStyle.Top;
            progressBar.Visible = false;
            this.Controls.Add(progressBar);
        }

        private void ShowLoadingIndicator()
        {
            if (loadingPanel == null)
            {
                loadingPanel = new Panel();
                loadingPanel.BackColor = Color.FromArgb(200, 255, 255, 255);
                loadingPanel.Dock = DockStyle.Fill;

                Label loadingLabel = new Label();
                loadingLabel.Text = "Loading...";
                loadingLabel.Font = new Font("Outfit", 14, FontStyle.Bold);
                loadingLabel.AutoSize = true;
                loadingLabel.Location = new Point(
                    (panelContainer.Width - 100) / 2,
                    (panelContainer.Height - 30) / 2
                );

                loadingPanel.Controls.Add(loadingLabel);
            }

            panelContainer.Controls.Add(loadingPanel);
            loadingPanel.BringToFront();
            loadingPanel.Refresh();
        }

        private void HideLoadingIndicator()
        {
            if (loadingPanel != null && panelContainer.Controls.Contains(loadingPanel))
            {
                panelContainer.Controls.Remove(loadingPanel);
            }
        }

        private void AddUserProfileSection()
        {
            Panel profilePanel = new Panel();
            profilePanel.BackColor = Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(240)))), ((int)(((byte)(112)))));
            profilePanel.Dock = DockStyle.Bottom;
            profilePanel.Height = 60;
            profilePanel.Padding = new Padding(10);

            Label usernameLabel = new Label();
            usernameLabel.Text = LoggedInUsername ?? "Government Official";
            usernameLabel.Font = new Font("Outfit", 12, FontStyle.Bold);
            usernameLabel.ForeColor = Color.White;
            usernameLabel.Location = new Point(60, 10);
            usernameLabel.AutoSize = true;

            Label roleLabel = new Label();
            roleLabel.Text = "Government Official";
            roleLabel.Font = new Font("Outfit", 9, FontStyle.Regular);
            roleLabel.ForeColor = Color.White;
            roleLabel.Location = new Point(60, 30);
            roleLabel.AutoSize = true;

            // Add circular avatar placeholder
            Panel avatarPanel = new Panel();
            avatarPanel.Size = new Size(40, 40);
            avatarPanel.Location = new Point(10, 10);
            avatarPanel.BackColor = Color.White;
            avatarPanel.Paint += (s, e) => {
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(179)))), ((int)(((byte)(86)))))))
                {
                    e.Graphics.FillEllipse(brush, 0, 0, avatarPanel.Width, avatarPanel.Height);
                }
                // Draw first letter of username
                string username = LoggedInUsername ?? "G";
                if (!string.IsNullOrEmpty(username))
                {
                    using (Font font = new Font("Outfit", 16, FontStyle.Bold))
                    using (SolidBrush brush = new SolidBrush(Color.White))
                    {
                        string firstLetter = username.Substring(0, 1).ToUpper();
                        SizeF size = e.Graphics.MeasureString(firstLetter, font);
                        e.Graphics.DrawString(
                            firstLetter,
                            font,
                            brush,
                            (avatarPanel.Width - size.Width) / 2,
                            (avatarPanel.Height - size.Height) / 2
                        );
                    }
                }
            };

            profilePanel.Controls.Add(avatarPanel);
            profilePanel.Controls.Add(usernameLabel);
            profilePanel.Controls.Add(roleLabel);

            panelsideMenu.Controls.Add(profilePanel);
        }

        private void ModernizeUI()
        {
            // Add hover effects to buttons
            foreach (Control ctrl in panelsideMenu.Controls)
            {
                if (ctrl is Button btn)
                {
                    btn.MouseEnter += Button_MouseEnter;
                    btn.MouseLeave += Button_MouseLeave;
                }
            }

            // Make container panel slightly rounded
            panelContainer.Region = System.Drawing.Region.FromHrgn(
                CreateRoundRectRgn(0, 0, panelContainer.Width, panelContainer.Height, 15, 15)
            );

            // Add shadow effect (simplified approach)
            Panel shadowPanel = new Panel();
            shadowPanel.BackColor = Color.FromArgb(20, 0, 0, 0);
            shadowPanel.Size = new Size(panelContainer.Width + 6, panelContainer.Height + 6);
            shadowPanel.Location = new Point(panelContainer.Left - 3, panelContainer.Top - 3);
            this.Controls.Add(shadowPanel);
            shadowPanel.SendToBack();

            // Add toggle sidebar button
            Button btnToggleSidebar = new Button();
            btnToggleSidebar.Size = new Size(30, 30);
            btnToggleSidebar.Location = new Point(5, 5);
            btnToggleSidebar.BackColor = Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(179)))), ((int)(((byte)(86)))));
            btnToggleSidebar.ForeColor = Color.White;
            btnToggleSidebar.Text = "≡";
            btnToggleSidebar.Font = new Font("Arial", 12, FontStyle.Bold);
            btnToggleSidebar.FlatStyle = FlatStyle.Flat;
            btnToggleSidebar.FlatAppearance.BorderSize = 0;
            btnToggleSidebar.Click += btnToggleSidebar_Click;
            this.Controls.Add(btnToggleSidebar);
        }

        private void Button_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != activeButton)
            {
                btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(150)))), ((int)(((byte)(70)))));
            }
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != activeButton)
            {
                btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(179)))), ((int)(((byte)(86)))));
            }
        }

      

        private void btn_Farmers_Click(object sender, EventArgs e)
        {
            Fields fields = new Fields(_userId, _roleId); // Pass the required parameters
            LoadUserControl(fields);
        }

        // Update the constructor call in GovtOfficialDashboard
        private void btn_Sales_Click(object sender, EventArgs e)
        {
           
            BuyPaddy buypaddy = new BuyPaddy(_userId); // Pass the required parameter
            LoadUserControl(buypaddy);
        }
       
       

        // Update the constructor call in GovtOfficialDashboard_Load
        private void GovtOfficialDashboard_Load(object sender, EventArgs e)
        {
            // Configure based on screen resolution
            ConfigureForScreenResolution();

            // Initialize UI elements
            InitializeProgressBar();
            AddUserProfileSection();
            InitializeBreadcrumb();
            ModernizeUI();

            // Show GovernmentHome as default on load
            GovernmentHome gh = new GovernmentHome(_userId); // Pass the required parameter
            LoadUserControl(gh);
            SetActiveButton(btn_Dashboard);
            UpdateBreadcrumb("Dashboard");
        }

        private void btn_RequestPaddy_Click(object sender, EventArgs e)
        {
            RequestPaddy requestPaddy = new RequestPaddy(_userId, _roleId);
            LoadUserControl(requestPaddy);
        }
    }
    #endregion
}
    
