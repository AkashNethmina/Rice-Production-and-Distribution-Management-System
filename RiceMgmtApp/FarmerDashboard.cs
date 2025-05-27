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
using System.Runtime.InteropServices;
using System.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace RiceMgmtApp
{
    public partial class FarmerDashboard : Form
    {
        private int _userId;
        private int _roleId;
        private Button activeButton;
        private Panel loadingPanel;
        private LoadingProgressBar progressBar;

        public string LoggedInUsername { get; set; }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );

        public FarmerDashboard(int userId, int roleId)
        {
            InitializeComponent();
            InitializeProgressBar();
            InitializeBreadcrumb();
            _userId = userId;
            _roleId = roleId;

          
            this.Resize += FarmerDashboard_Resize;

       
            this.MinimumSize = new Size(900, 600);
        }

        private void FarmerDashboard_Load(object sender, EventArgs e)
        {
           
            ConfigureForScreenResolution();

            InitializeProgressBar();
            AddUserProfileSection();
            InitializeBreadcrumb();

            FarmerHome fh = new FarmerHome(_userId);
            LoadUserControl(fh);
            SetActiveButton(btn_Dashboard);
            UpdateBreadcrumb("Dashboard");
        }

        private void LoadUserControl(UserControl userControl)
        {
           
            ShowLoadingIndicator();
          
            if (progressBar != null)
            {
                progressBar.Visible = true;
                progressBar.StartLoading();
            }
            else
            {
                
                InitializeProgressBar();
                progressBar.Visible = true;
                progressBar.StartLoading();
            }

          
            Task.Run(() => {
               
                Thread.Sleep(300);

                this.Invoke((MethodInvoker)delegate {
                    progressBar.StopLoading();

                    userControl.Dock = DockStyle.Fill;
                    panelContainer.Controls.Clear();
                    panelContainer.Controls.Add(userControl);
                    userControl.BringToFront();

                    
                    Task.Delay(200).ContinueWith(t => {
                        this.Invoke((MethodInvoker)delegate {
                            HideLoadingIndicator();
                            progressBar.Visible = false;
                        });
                    });
                });
            });
        }

        private void btn_profile_Click(object sender, EventArgs e)
        {
            profileControl pc = new profileControl();
            pc.LoggedInUsername = LoggedInUsername;
            pc.LoadUserDetails();
            LoadUserControl(pc);
            SetActiveButton(btn_profile);
            UpdateBreadcrumb("Profile");
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to log out?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                frm_login fl = new frm_login();
                fl.Show();
                this.Close();
            }
        }

      
        private void btn_Dashboard_Click(object sender, EventArgs e)
        {
            FarmerHome farmerHome = new FarmerHome(_userId);
            LoadUserControl(farmerHome);
            SetActiveButton(btn_Dashboard);
            UpdateBreadcrumb("Dashboard");
        }

        private void btn_Farmers_Click(object sender, EventArgs e)
        {
            Fields fields = new Fields(_userId, _roleId);
            LoadUserControl(fields);
            SetActiveButton(btn_Farmers);
            UpdateBreadcrumb("Fields");
        }

        private void btnPrice_Monitoring_Click(object sender, EventArgs e)
        {
            Price_Monitoring pm = new Price_Monitoring(_roleId);
            LoadUserControl(pm);
            SetActiveButton(btnPrice_Monitoring);
            UpdateBreadcrumb("Price Monitoring");
        }

        private void btn_Sales_Click(object sender, EventArgs e)
        {
            SellPady sellPady = new SellPady(_userId);
            LoadUserControl(sellPady);
            SetActiveButton(btn_Sales);
            UpdateBreadcrumb("Sell Paddy");
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
            DamageReporting damageReporting = new DamageReporting();
            damageReporting.SetUserContext(_userId, _roleId);
            LoadUserControl(damageReporting);
            SetActiveButton(btn_DamageReporting);
            UpdateBreadcrumb("Damage Reporting");
        }

       

        private void RequestPaddy_Click(object sender, EventArgs e)
        {
            RequestPaddy requestPaddy = new RequestPaddy(_userId, _roleId);
            LoadUserControl(requestPaddy);
            SetActiveButton(RequestPaddy);
            UpdateBreadcrumb("Request Paddy");
        }

        #region Responsive Design Implementation

        private void FarmerDashboard_Resize(object sender, EventArgs e)
        {
           
            ResizeUI();
        }

        private void ResizeUI()
        {
            
            int margin = this.Width < 1000 ? 10 : 20;
            panelContainer.Padding = new Padding(margin);

           
            if (this.Width < 800)
            {
                CollapseMenu();
            }
            else
            {
                ExpandMenu();
            }

            
            panelContainer.Region = System.Drawing.Region.FromHrgn(
                CreateRoundRectRgn(0, 0, panelContainer.Width, panelContainer.Height, 15, 15)
            );
        }

        private void CollapseMenu()
        {
            panelsideMenu.Width = 60;
            foreach (Control ctrl in panelsideMenu.Controls)
            {
                if (ctrl is Button btn && !(ctrl is Panel))
                {
                    btn.ImageAlign = ContentAlignment.MiddleCenter;
                    btn.Padding = new Padding(0);
                    
                    btn.Tag = btn.Text;
                    btn.Text = "";
                }
            }
        }

        private void ExpandMenu()
        {
            panelsideMenu.Width = 250;
            foreach (Control ctrl in panelsideMenu.Controls)
            {
                if (ctrl is Button btn && !(ctrl is Panel))
                {
                    if (btn.Tag != null && btn.Tag is string)
                    {
                    
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
          
            Screen screen = Screen.FromControl(this);
            int screenWidth = screen.Bounds.Width;
            int screenHeight = screen.Bounds.Height;

          
            if (screenWidth <= 1366) 
            {
                this.Font = new Font(this.Font.FontFamily, this.Font.Size - 1);
                if (this.Width < 1200)
                {
                    CollapseMenu();
                }
            }
            else if (screenWidth >= 1920) 
            {
            
                this.Font = new Font(this.Font.FontFamily, this.Font.Size + 1);
                panelContainer.Padding = new Padding(20);
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
                activeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(179)))), ((int)(((byte)(86)))));
                activeButton.ForeColor = Color.White;
            }

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
            usernameLabel.Text = LoggedInUsername ?? "Farmer User";
            usernameLabel.Font = new Font("Outfit", 12, FontStyle.Bold);
            usernameLabel.ForeColor = Color.White;
            usernameLabel.Location = new Point(60, 10);
            usernameLabel.AutoSize = true;

            Label roleLabel = new Label();
            roleLabel.Text = "Farmer";
            roleLabel.Font = new Font("Outfit", 9, FontStyle.Regular);
            roleLabel.ForeColor = Color.White;
            roleLabel.Location = new Point(60, 30);
            roleLabel.AutoSize = true;

           
            Panel avatarPanel = new Panel();
            avatarPanel.Size = new Size(40, 40);
            avatarPanel.Location = new Point(10, 10);
            avatarPanel.BackColor = Color.White;
            avatarPanel.Paint += (s, e) => {
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(179)))), ((int)(((byte)(86)))))))
                {
                    e.Graphics.FillEllipse(brush, 0, 0, avatarPanel.Width, avatarPanel.Height);
                }
               
                string username = LoggedInUsername ?? "F";
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

    }
    #endregion

}