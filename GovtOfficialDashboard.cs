using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace RiceMgmtApp
{
    public partial class GovtOfficialDashboard: Form
    {
        private bool sidebarExpanded = true;
        private int sidebarWidth = 200;
        private int sidebarCollapsedWidth = 60;
        private int animationSpeed = 10;
        private Timer sidebarTimer = new Timer();
        private List<Button> menuButtons = new List<Button>();
        private Button activeButton = null;
        private Panel activeIndicator;

        public MainForm()
        {
            InitializeComponent();
            SetupSidebar();
        }

        private void SetupSidebar()
        {
            // Configure form
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.FromArgb(245, 246, 248);

            // Create sidebar panel
            Panel sidebar = new Panel
            {
                Width = sidebarWidth,
                Height = this.ClientSize.Height,
                BackColor = Color.FromArgb(35, 40, 45),
                Dock = DockStyle.Left
            };
            this.Controls.Add(sidebar);

            // Create logo panel
            Panel logoPanel = new Panel
            {
                Height = 80,
                Dock = DockStyle.Top,
                BackColor = Color.FromArgb(30, 35, 40)
            };
            sidebar.Controls.Add(logoPanel);

            // Add logo/app name
            Label appName = new Label
            {
                Text = "MyApp",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };
            logoPanel.Controls.Add(appName);

            // Create toggle button
            Button toggleButton = new Button
            {
                Size = new Size(30, 30),
                Location = new Point(sidebarWidth - 40, 25),
                FlatStyle = FlatStyle.Flat,
                Text = "?",
                Font = new Font("Arial", 15),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                FlatAppearance = { BorderSize = 0 }
            };
            toggleButton.Click += (s, e) => ToggleSidebar();
            logoPanel.Controls.Add(toggleButton);

            // Create menu container panel
            Panel menuContainer = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.Transparent
            };
            sidebar.Controls.Add(menuContainer);

            // Create active indicator
            activeIndicator = new Panel
            {
                Width = 4,
                Height = 40,
                BackColor = Color.FromArgb(0, 126, 249),
                Location = new Point(0, 0),
                Visible = false
            };
            menuContainer.Controls.Add(activeIndicator);

            // Add menu buttons
            AddMenuButton(menuContainer, "Dashboard", "??", 0);
            AddMenuButton(menuContainer, "Analytics", "??", 1);
            AddMenuButton(menuContainer, "Orders", "??", 2);
            AddMenuButton(menuContainer, "Customers", "??", 3);
            AddMenuButton(menuContainer, "Settings", "??", 4);

            // Configure sidebar animation timer
            sidebarTimer.Interval = 1;
            sidebarTimer.Tick += SidebarAnimation_Tick;

            // Create content panel
            Panel contentPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(245, 246, 248)
            };
            this.Controls.Add(contentPanel);

            // Add header to content panel
            Panel headerPanel = new Panel
            {
                Height = 60,
                Dock = DockStyle.Top,
                BackColor = Color.White
            };
            contentPanel.Controls.Add(headerPanel);

            // Add sample content label
            Label contentLabel = new Label
            {
                Text = "Dashboard",
                Font = new Font("Segoe UI", 24, FontStyle.Regular),
                ForeColor = Color.FromArgb(60, 60, 60),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };
            contentPanel.Controls.Add(contentLabel);
        }

        private void AddMenuButton(Panel container, string text, string icon, int index)
        {
            // Create button
            Button btn = new Button
            {
                Text = "  " + text,
                TextAlign = ContentAlignment.MiddleLeft,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(sidebarWidth, 45),
                Location = new Point(0, 80 + (index * 55)),
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                ImageAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(15, 0, 0, 0),
                FlatAppearance = { BorderSize = 0 },
                Cursor = Cursors.Hand,
                Tag = text
            };

            // Add icon
            Label iconLabel = new Label
            {
                Text = icon,
                AutoSize = false,
                Size = new Size(25, 25),
                Location = new Point(15, 10),
                Font = new Font("Segoe UI", 12),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleCenter
            };
            btn.Controls.Add(iconLabel);

            // Configure button events
            btn.MouseEnter += (s, e) =>
            {
                if (btn != activeButton)
                    btn.BackColor = Color.FromArgb(45, 50, 55);
            };

            btn.MouseLeave += (s, e) =>
            {
                if (btn != activeButton)
                    btn.BackColor = Color.Transparent;
            };

            btn.Click += (s, e) =>
            {
                // Set active button
                if (activeButton != null)
                    activeButton.BackColor = Color.Transparent;

                btn.BackColor = Color.FromArgb(50, 55, 60);
                activeButton = btn;

                // Move indicator
                activeIndicator.Height = btn.Height;
                activeIndicator.Location = new Point(0, btn.Location.Y);
                activeIndicator.Visible = true;
                activeIndicator.BringToFront();

                // Update content
                foreach (Control c in this.Controls)
                {
                    if (c is Panel panel && panel.Dock == DockStyle.Fill)
                    {
                        foreach (Control child in panel.Controls)
                        {
                            if (child is Label contentLabel && contentLabel.Font.Size > 20)
                            {
                                contentLabel.Text = btn.Tag.ToString();
                            }
                        }
                    }
                }
            };

            container.Controls.Add(btn);
            menuButtons.Add(btn);
        }

        private void ToggleSidebar()
        {
            sidebarTimer.Start();
        }

        private void SidebarAnimation_Tick(object sender, EventArgs e)
        {
            if (sidebarExpanded)
            {
                // Collapse sidebar
                foreach (Panel panel in this.Controls)
                {
                    if (panel.Dock == DockStyle.Left)
                    {
                        panel.Width -= animationSpeed;
                        if (panel.Width <= sidebarCollapsedWidth)
                        {
                            panel.Width = sidebarCollapsedWidth;
                            sidebarExpanded = false;
                            sidebarTimer.Stop();

                            // Update button text
                            foreach (Button btn in menuButtons)
                            {
                                btn.Text = "";
                                btn.Padding = new Padding(0, 0, 0, 0);

                                // Center the icon
                                foreach (Control c in btn.Controls)
                                {
                                    if (c is Label iconLabel)
                                    {
                                        iconLabel.Location = new Point((sidebarCollapsedWidth - iconLabel.Width) / 2, 10);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                // Expand sidebar
                foreach (Panel panel in this.Controls)
                {
                    if (panel.Dock == DockStyle.Left)
                    {
                        panel.Width += animationSpeed;
                        if (panel.Width >= sidebarWidth)
                        {
                            panel.Width = sidebarWidth;
                            sidebarExpanded = true;
                            sidebarTimer.Stop();

                            // Restore button text
                            foreach (Button btn in menuButtons)
                            {
                                btn.Text = "  " + btn.Tag.ToString();
                                btn.Padding = new Padding(15, 0, 0, 0);

                                // Restore icon position
                                foreach (Control c in btn.Controls)
                                {
                                    if (c is Label iconLabel)
                                    {
                                        iconLabel.Location = new Point(15, 10);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        // Custom methods for rounded corners (optional)
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Create rounded corners for the form
            int radius = 10;
            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
            GraphicsPath path = new GraphicsPath();

            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.X + rect.Width - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.X + rect.Width - radius, rect.Y + rect.Height - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Y + rect.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();

            this.Region = new Region(path);
        }

        // For moving the form (as we're using FormBorderStyle.None)
        private bool isDragging = false;
        private Point startPoint = new Point(0, 0);

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            isDragging = true;
            startPoint = new Point(e.X, e.Y);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (isDragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - startPoint.X, p.Y - startPoint.Y);
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            isDragging = false;
        }
    }
}
