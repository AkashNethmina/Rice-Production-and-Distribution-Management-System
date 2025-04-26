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
    public partial class BuyerDashboard : Form
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

        public BuyerDashboard(int userId, int roleId)
        {
            InitializeComponent();
            InitializeProgressBar();
            InitializeBreadcrumb();
            _userId = userId;
            _roleId = roleId;

            // Add event handlers for resizing
            this.Resize += BuyerDashboard_Resize;

            // Set minimum form size
            this.MinimumSize = new Size(900, 600);
        }

        private void LoadUserControl(UserControl userControl)
        {
            // Show loading indicator
            ShowLoadingIndicator();
            // Check if progressBar is initialized
            if (progressBar != null)
            {
                progressBar.Visible = true;
                progressBar.StartLoading();
            }
            else
            {
                // Initialize progressBar if it's null
                InitializeProgressBar();
                progressBar.Visible = true;
                progressBar.StartLoading();
            }

            // Use Task to load control asynchronously
            Task.Run(() => {
                // Simulate loading time or actual initialization
                Thread.Sleep(300);

                this.Invoke((MethodInvoker)delegate {
                    progressBar.StopLoading();

                    userControl.Dock = DockStyle.Fill;
                    panelContainer.Controls.Clear();
                    panelContainer.Controls.Add(userControl);
                    userControl.BringToFront();

                    // Hide loading indicator and progress bar after a delay
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
            frm_login fl = new frm_login();
            fl.Show();
            this.Close();
        }
        private void btn_logout_MouseEnter(object sender, EventArgs e)
        {
            btn_logout.BackColor = System.Drawing.Color.FromArgb(200, 35, 51); // Darker red on hover
        }

        private void btn_logout_MouseLeave(object sender, EventArgs e)
        {
            btn_logout.BackColor = System.Drawing.Color.FromArgb(220, 53, 69); // Back to original red
        }

        private void btn_Sales_Click(object sender, EventArgs e)
        {
            BuyPaddy buyPaddy = new BuyPaddy(_userId);
            LoadUserControl(buyPaddy);
            SetActiveButton(btn_Sales);
            UpdateBreadcrumb("Buy Paddy");
        }

        private void btnPrice_Monitoring_Click(object sender, EventArgs e)
        {
            Price_Monitoring pm = new Price_Monitoring(_roleId);
            LoadUserControl(pm);
            SetActiveButton(btnPrice_Monitoring);
            UpdateBreadcrumb("Price Monitoring");
        }

        private void btn_StockManagement_Click(object sender, EventArgs e)
        {
            RequestPaddy requestPaddy = new RequestPaddy(_userId, _roleId);
            LoadUserControl(requestPaddy);
        }

        private void BuyerDashboard_Load(object sender, EventArgs e)
        {
            // Configure based on screen resolution
            ConfigureForScreenResolution();

            // Initialize UI elements
            InitializeProgressBar();
            AddUserProfileSection();
            InitializeBreadcrumb();
            ModernizeUI();

            // Show PrivateBuyerHome as default on load
            PrivateBuyerHome pbh = new PrivateBuyerHome();
            LoadUserControl(pbh);
            SetActiveButton(btn_Dashboard);
            UpdateBreadcrumb("Dashboard");
        }

        #region Responsive Design Implementation

        private void BuyerDashboard_Resize(object sender, EventArgs e)
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
            if (this.Width < 800)
            {
                CollapseMenu();
            }
            else
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
            panelsideMenu.Width = 60;
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
            panelsideMenu.Width = 250;
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
            usernameLabel.Text = LoggedInUsername ?? "Buyer User";
            usernameLabel.Font = new Font("Outfit", 12, FontStyle.Bold);
            usernameLabel.ForeColor = Color.White;
            usernameLabel.Location = new Point(60, 10);
            usernameLabel.AutoSize = true;

            Label roleLabel = new Label();
            roleLabel.Text = "Buyer";
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
                string username = LoggedInUsername ?? "B";
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



        #endregion

        private void btn_Dashboard_Click(object sender, EventArgs e)
        {
            PrivateBuyerHome privateBuyerHome = new PrivateBuyerHome();
            LoadUserControl(privateBuyerHome);
            SetActiveButton(btn_Dashboard);
            UpdateBreadcrumb("Dashboard");
        }

        private void btn_DamageReporting_Click(object sender, EventArgs e)
        {

        }

        private void btn_ReportsAnalytics_Click(object sender, EventArgs e)
        {
            DataAnalytics_Reports dataAnalytics_Reports = new DataAnalytics_Reports();
            LoadUserControl(dataAnalytics_Reports);
        }

        
    }

    // Make sure to include these classes if they're not already defined elsewhere

    // If LoadingProgressBar is not defined in another file, include it here
    /* 
    // Loading progress bar for visual feedback
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
    */
}