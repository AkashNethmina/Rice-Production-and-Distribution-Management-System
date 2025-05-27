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
    public partial class AdminDashboard : Form
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

        public AdminDashboard(int userId, int roleId)
        {
            InitializeComponent();
            InitializeProgressBar();
            InitializeBreadcrumb();
            _userId = userId;
            _roleId = roleId;

         
            this.Resize += AdminDashboard_Resize;

          
            this.MinimumSize = new Size(900, 600);
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {

            ConfigureForScreenResolution();
            HideAllSubMenus();
            InitializeProgressBar();
            AddUserProfileSection();
            InitializeBreadcrumb();
            AdminHome ah = new AdminHome();
            LoadUserControl(ah);
            SetActiveButton(btn_Dashboard);
            UpdateBreadcrumb("Dashboard");
        }

        private void HideSubMenu()
        {
            if (panel2submenu.Visible)
                panel2submenu.Visible = false;
           
        }

        private void ShowSubMenu(Panel subMenu)
        {
            if (!subMenu.Visible)
            {
                HideAllSubMenus();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        private void HideAllSubMenus()
        {
            panel2submenu.Visible = false;
            
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

        private void btn_Dashboard_Click(object sender, EventArgs e)
        {
            HideSubMenu();
            AdminHome ah = new AdminHome();
            LoadUserControl(ah);
            SetActiveButton(btn_Dashboard);
            UpdateBreadcrumb("Dashboard");
        }

        private void btn_manUser_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panel2submenu);
            SetActiveButton(btn_manUser);
        }

        private void btn_AllUsers_Click(object sender, EventArgs e)
        {
            UserManagement um = new UserManagement();
            LoadUserControl(um);
            UpdateBreadcrumb("Manage Users > All Users");
        }

        private void btn_AddUsers_Click(object sender, EventArgs e)
        {
            UsersAdd ua = new UsersAdd();
            LoadUserControl(ua);
            UpdateBreadcrumb("Manage Users > Add New Users");
        }

        

        private void btn_AllFarmers_Click(object sender, EventArgs e)
        {
            FarmerManagement fm = new FarmerManagement();
            LoadUserControl(fm);
            UpdateBreadcrumb("Farmers > All Farmers");
        }

       

        private void btn_Sales_Click(object sender, EventArgs e)
        {
            SalesManagement sm = new SalesManagement();
            LoadUserControl(sm);
            SetActiveButton(btn_Sales);
            UpdateBreadcrumb("Sales Records");
        }

        private void btn_StockManagement_Click(object sender, EventArgs e)
        {
            StockManagement stm = new StockManagement(_userId, _roleId);
            LoadUserControl(stm);
            SetActiveButton(btn_StockManagement);
            UpdateBreadcrumb("Stock Management");
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



        private void btn_DamageReporting_Click(object sender, EventArgs e)
        {
           
            DamageReporting dr = new DamageReporting();
            dr.SetUserContext(_userId, _roleId);
            LoadUserControl(dr);
            SetActiveButton(btn_DamageReporting);
            UpdateBreadcrumb("Damage Reporting");
        }

        private void btn_PriceSetting_Click(object sender, EventArgs e)
        {
            Price_Monitoring pm = new Price_Monitoring(_roleId);
            LoadUserControl(pm);
            SetActiveButton(btn_PriceSetting);
            UpdateBreadcrumb("Price Setting");
        }

        private void AdminDashboard_Resize(object sender, EventArgs e)
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
            
            panel2submenu.Visible = false;
         
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
            usernameLabel.Text = LoggedInUsername ?? "Admin User";
            usernameLabel.Font = new Font("Outfit", 12, FontStyle.Bold);
            usernameLabel.ForeColor = Color.White;
            usernameLabel.Location = new Point(60, 10);
            usernameLabel.AutoSize = true;

            Label roleLabel = new Label();
            roleLabel.Text = "Administrator";
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
              
                string username = LoggedInUsername ?? "A";
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

        private void btn_profile_Click(object sender, EventArgs e)
        {
            profileControl profileControl = new profileControl();
            profileControl.LoggedInUsername = LoggedInUsername;
            profileControl.LoadUserDetails();
            LoadUserControl(profileControl);
            SetActiveButton(btn_profile);
            UpdateBreadcrumb("Profile");
        }

        private void btn_Fields_Click(object sender, EventArgs e)
        {
            Fields fie = new Fields(_userId, _roleId);
            LoadUserControl(fie);
            UpdateBreadcrumb("Farmers > Field Management");
        }

        private void btn_AuthLogs_Click(object sender, EventArgs e)
        {
            AuthLogs authLogs = new AuthLogs(_roleId);
            LoadUserControl(authLogs);
            UpdateBreadcrumb("Authentication Logs");
        }
    }


    public class LoadingProgressBar : Control
    {
        private int _value = 0;
        private System.Windows.Forms.Timer _timer;

        public LoadingProgressBar()
        {
            this.Height = 5;
            this.BackColor = Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(247)))));

            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = 15;
            _timer.Tick += Timer_Tick;
        }

        public void StartLoading()
        {
            _value = 0;
            _timer.Start();
        }

        public void StopLoading()
        {
            _timer.Stop();
            _value = 100;
            this.Invalidate();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (_value < 100)
            {
                _value += 3;
                if (_value > 100) _value = 100;
                this.Invalidate();
            }
            else
            {
                _timer.Stop();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using (SolidBrush brush = new SolidBrush(Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(179)))), ((int)(((byte)(86)))))))
            {
                int width = (int)((float)_value / 100 * this.Width);
                e.Graphics.FillRectangle(brush, 0, 0, width, this.Height);
            }
        }
    }
   
    public class ResponsivePanel : Panel
    {
        private int _columns = 12;
        private int _gutter = 10;

        public ResponsivePanel()
        {
            this.Resize += ResponsivePanel_Resize;
        }

        private void ResponsivePanel_Resize(object sender, EventArgs e)
        {
            AdjustChildControls();
        }

        private void AdjustChildControls()
        {
            int colWidth = (this.Width - ((_columns + 1) * _gutter)) / _columns;

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl.Tag != null)
                {
                    string[] tagParts = ctrl.Tag.ToString().Split(',');
                    if (tagParts.Length >= 4)
                    {
                        int colSpan = int.Parse(tagParts[0]);
                        int rowSpan = int.Parse(tagParts[1]);
                        int colStart = int.Parse(tagParts[2]);
                        int rowStart = int.Parse(tagParts[3]);

                        int rowHeight = 50; 

                        ctrl.Width = (colSpan * colWidth) + ((colSpan - 1) * _gutter);
                        ctrl.Height = (rowSpan * rowHeight) + ((rowSpan - 1) * _gutter);
                        ctrl.Left = colStart * (colWidth + _gutter) + _gutter;
                        ctrl.Top = rowStart * (rowHeight + _gutter) + _gutter;
                    }
                }
            }
        }
    }
    #endregion

}
    
