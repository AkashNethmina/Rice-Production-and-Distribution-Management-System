namespace RiceMgmtApp
{
    partial class AdminDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.sqlCommandBuilder1 = new Microsoft.Data.SqlClient.SqlCommandBuilder();
            this.panelsideMenu = new System.Windows.Forms.Panel();
            this.btn_logout = new System.Windows.Forms.Button();
            this.panel2submenu = new System.Windows.Forms.Panel();
            this.btn_AddUsers = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_manUser = new System.Windows.Forms.Button();
            this.btn_Dashboard = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelDashboard = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.lblPendingReports = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.lblTotalSales = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.lblTotalFarmers = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.lblTotalUsers = new System.Windows.Forms.Label();
            this.btn_Farmers = new System.Windows.Forms.Button();
            this.btn_Sales = new System.Windows.Forms.Button();
            this.panelUsers = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelFarmers = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panelSales = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panelsideMenu.SuspendLayout();
            this.panel2submenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelDashboard.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            this.panelUsers.SuspendLayout();
            this.panelFarmers.SuspendLayout();
            this.panelSales.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelsideMenu
            // 
            this.panelsideMenu.AutoScroll = true;
            this.panelsideMenu.BackColor = System.Drawing.Color.RoyalBlue;
            this.panelsideMenu.Controls.Add(this.btn_Sales);
            this.panelsideMenu.Controls.Add(this.btn_Farmers);
            this.panelsideMenu.Controls.Add(this.btn_logout);
            this.panelsideMenu.Controls.Add(this.panel2submenu);
            this.panelsideMenu.Controls.Add(this.btn_manUser);
            this.panelsideMenu.Controls.Add(this.btn_Dashboard);
            this.panelsideMenu.Controls.Add(this.pictureBox1);
            this.panelsideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelsideMenu.Location = new System.Drawing.Point(0, 0);
            this.panelsideMenu.Name = "panelsideMenu";
            this.panelsideMenu.Size = new System.Drawing.Size(250, 666);
            this.panelsideMenu.TabIndex = 3;
            // 
            // btn_logout
            // 
            this.btn_logout.Location = new System.Drawing.Point(81, 577);
            this.btn_logout.Name = "btn_logout";
            this.btn_logout.Size = new System.Drawing.Size(75, 41);
            this.btn_logout.TabIndex = 6;
            this.btn_logout.Text = "Logout";
            this.btn_logout.UseVisualStyleBackColor = true;
            this.btn_logout.Click += new System.EventHandler(this.btn_logout_Click);
            // 
            // panel2submenu
            // 
            this.panel2submenu.BackColor = System.Drawing.Color.AliceBlue;
            this.panel2submenu.Controls.Add(this.btn_AddUsers);
            this.panel2submenu.Controls.Add(this.button1);
            this.panel2submenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2submenu.Location = new System.Drawing.Point(0, 180);
            this.panel2submenu.Name = "panel2submenu";
            this.panel2submenu.Size = new System.Drawing.Size(250, 81);
            this.panel2submenu.TabIndex = 4;
            // 
            // btn_AddUsers
            // 
            this.btn_AddUsers.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_AddUsers.FlatAppearance.BorderSize = 0;
            this.btn_AddUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AddUsers.Font = new System.Drawing.Font("Outfit Medium", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AddUsers.Location = new System.Drawing.Point(0, 40);
            this.btn_AddUsers.Name = "btn_AddUsers";
            this.btn_AddUsers.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btn_AddUsers.Size = new System.Drawing.Size(250, 40);
            this.btn_AddUsers.TabIndex = 4;
            this.btn_AddUsers.Text = "Add New Users";
            this.btn_AddUsers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_AddUsers.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Outfit Medium", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.button1.Size = new System.Drawing.Size(250, 40);
            this.button1.TabIndex = 3;
            this.button1.Text = "All Users";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btn_manUser
            // 
            this.btn_manUser.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_manUser.FlatAppearance.BorderSize = 0;
            this.btn_manUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_manUser.Font = new System.Drawing.Font("Outfit", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_manUser.ForeColor = System.Drawing.Color.White;
            this.btn_manUser.Location = new System.Drawing.Point(0, 135);
            this.btn_manUser.Name = "btn_manUser";
            this.btn_manUser.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_manUser.Size = new System.Drawing.Size(250, 45);
            this.btn_manUser.TabIndex = 3;
            this.btn_manUser.Text = "Manage Users";
            this.btn_manUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_manUser.UseVisualStyleBackColor = true;
            this.btn_manUser.Click += new System.EventHandler(this.btn_manUser_Click);
            // 
            // btn_Dashboard
            // 
            this.btn_Dashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Dashboard.FlatAppearance.BorderSize = 0;
            this.btn_Dashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Dashboard.Font = new System.Drawing.Font("Outfit", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Dashboard.ForeColor = System.Drawing.Color.White;
            this.btn_Dashboard.Location = new System.Drawing.Point(0, 90);
            this.btn_Dashboard.Name = "btn_Dashboard";
            this.btn_Dashboard.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_Dashboard.Size = new System.Drawing.Size(250, 45);
            this.btn_Dashboard.TabIndex = 1;
            this.btn_Dashboard.Text = "Dashboard";
            this.btn_Dashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Dashboard.UseVisualStyleBackColor = true;
            this.btn_Dashboard.Click += new System.EventHandler(this.btn_Dashboard_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(250, 90);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panelDashboard
            // 
            this.panelDashboard.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDashboard.Controls.Add(this.panel12);
            this.panelDashboard.Controls.Add(this.panel11);
            this.panelDashboard.Controls.Add(this.panel10);
            this.panelDashboard.Controls.Add(this.panel9);
            this.panelDashboard.Location = new System.Drawing.Point(256, 39);
            this.panelDashboard.Name = "panelDashboard";
            this.panelDashboard.Size = new System.Drawing.Size(956, 100);
            this.panelDashboard.TabIndex = 4;
            // 
            // panel12
            // 
            this.panel12.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel12.BackColor = System.Drawing.Color.White;
            this.panel12.Controls.Add(this.lblPendingReports);
            this.panel12.Location = new System.Drawing.Point(714, 0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(200, 100);
            this.panel12.TabIndex = 13;
            // 
            // lblPendingReports
            // 
            this.lblPendingReports.AutoSize = true;
            this.lblPendingReports.Font = new System.Drawing.Font("Outfit", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPendingReports.Location = new System.Drawing.Point(18, 37);
            this.lblPendingReports.Name = "lblPendingReports";
            this.lblPendingReports.Size = new System.Drawing.Size(164, 26);
            this.lblPendingReports.TabIndex = 0;
            this.lblPendingReports.Text = "PendingReports";
            // 
            // panel11
            // 
            this.panel11.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel11.BackColor = System.Drawing.Color.White;
            this.panel11.Controls.Add(this.lblTotalSales);
            this.panel11.Location = new System.Drawing.Point(490, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(200, 100);
            this.panel11.TabIndex = 14;
            // 
            // lblTotalSales
            // 
            this.lblTotalSales.AutoSize = true;
            this.lblTotalSales.Font = new System.Drawing.Font("Outfit", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalSales.Location = new System.Drawing.Point(45, 37);
            this.lblTotalSales.Name = "lblTotalSales";
            this.lblTotalSales.Size = new System.Drawing.Size(111, 26);
            this.lblTotalSales.TabIndex = 0;
            this.lblTotalSales.Text = "TotalSales";
            // 
            // panel10
            // 
            this.panel10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel10.BackColor = System.Drawing.Color.White;
            this.panel10.Controls.Add(this.lblTotalFarmers);
            this.panel10.Location = new System.Drawing.Point(266, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(200, 100);
            this.panel10.TabIndex = 12;
            // 
            // lblTotalFarmers
            // 
            this.lblTotalFarmers.AutoSize = true;
            this.lblTotalFarmers.Font = new System.Drawing.Font("Outfit", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalFarmers.Location = new System.Drawing.Point(28, 37);
            this.lblTotalFarmers.Name = "lblTotalFarmers";
            this.lblTotalFarmers.Size = new System.Drawing.Size(144, 26);
            this.lblTotalFarmers.TabIndex = 0;
            this.lblTotalFarmers.Text = "Total Farmers";
            // 
            // panel9
            // 
            this.panel9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel9.BackColor = System.Drawing.Color.White;
            this.panel9.Controls.Add(this.pictureBox8);
            this.panel9.Controls.Add(this.lblTotalUsers);
            this.panel9.Location = new System.Drawing.Point(42, 1);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(200, 99);
            this.panel9.TabIndex = 11;
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = global::RiceMgmtApp.Properties.Resources._9385289;
            this.pictureBox8.Location = new System.Drawing.Point(30, 31);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(43, 36);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox8.TabIndex = 1;
            this.pictureBox8.TabStop = false;
            // 
            // lblTotalUsers
            // 
            this.lblTotalUsers.AutoSize = true;
            this.lblTotalUsers.Font = new System.Drawing.Font("Outfit", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalUsers.Location = new System.Drawing.Point(76, 36);
            this.lblTotalUsers.Name = "lblTotalUsers";
            this.lblTotalUsers.Size = new System.Drawing.Size(102, 26);
            this.lblTotalUsers.TabIndex = 0;
            this.lblTotalUsers.Text = "Users Tot";
            // 
            // btn_Farmers
            // 
            this.btn_Farmers.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Farmers.FlatAppearance.BorderSize = 0;
            this.btn_Farmers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Farmers.Font = new System.Drawing.Font("Outfit", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Farmers.ForeColor = System.Drawing.Color.White;
            this.btn_Farmers.Location = new System.Drawing.Point(0, 261);
            this.btn_Farmers.Name = "btn_Farmers";
            this.btn_Farmers.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_Farmers.Size = new System.Drawing.Size(250, 45);
            this.btn_Farmers.TabIndex = 7;
            this.btn_Farmers.Text = "Farmers";
            this.btn_Farmers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Farmers.UseVisualStyleBackColor = true;
            this.btn_Farmers.Click += new System.EventHandler(this.btn_Farmers_Click);
            // 
            // btn_Sales
            // 
            this.btn_Sales.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Sales.FlatAppearance.BorderSize = 0;
            this.btn_Sales.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Sales.Font = new System.Drawing.Font("Outfit", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Sales.ForeColor = System.Drawing.Color.White;
            this.btn_Sales.Location = new System.Drawing.Point(0, 306);
            this.btn_Sales.Name = "btn_Sales";
            this.btn_Sales.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_Sales.Size = new System.Drawing.Size(250, 45);
            this.btn_Sales.TabIndex = 8;
            this.btn_Sales.Text = "Sales";
            this.btn_Sales.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Sales.UseVisualStyleBackColor = true;
            this.btn_Sales.Click += new System.EventHandler(this.btn_Sales_Click);
            // 
            // panelUsers
            // 
            this.panelUsers.Controls.Add(this.label1);
            this.panelUsers.Location = new System.Drawing.Point(256, 220);
            this.panelUsers.Name = "panelUsers";
            this.panelUsers.Size = new System.Drawing.Size(956, 100);
            this.panelUsers.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(177, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "user";
            // 
            // panelFarmers
            // 
            this.panelFarmers.Controls.Add(this.label2);
            this.panelFarmers.Location = new System.Drawing.Point(256, 360);
            this.panelFarmers.Name = "panelFarmers";
            this.panelFarmers.Size = new System.Drawing.Size(956, 100);
            this.panelFarmers.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(177, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 14);
            this.label2.TabIndex = 0;
            this.label2.Text = "panelFarmers";
            // 
            // panelSales
            // 
            this.panelSales.Controls.Add(this.label3);
            this.panelSales.Location = new System.Drawing.Point(256, 482);
            this.panelSales.Name = "panelSales";
            this.panelSales.Size = new System.Drawing.Size(956, 100);
            this.panelSales.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(177, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 14);
            this.label3.TabIndex = 0;
            this.label3.Text = "panelSales";
            // 
            // AdminDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(247)))));
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(1224, 666);
            this.Controls.Add(this.panelSales);
            this.Controls.Add(this.panelFarmers);
            this.Controls.Add(this.panelUsers);
            this.Controls.Add(this.panelDashboard);
            this.Controls.Add(this.panelsideMenu);
            this.Font = new System.Drawing.Font("Outfit", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AdminDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panelsideMenu.ResumeLayout(false);
            this.panel2submenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelDashboard.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            this.panelUsers.ResumeLayout(false);
            this.panelUsers.PerformLayout();
            this.panelFarmers.ResumeLayout(false);
            this.panelFarmers.PerformLayout();
            this.panelSales.ResumeLayout(false);
            this.panelSales.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Microsoft.Data.SqlClient.SqlCommandBuilder sqlCommandBuilder1;
        private System.Windows.Forms.Panel panelsideMenu;
        private System.Windows.Forms.Button btn_Dashboard;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_manUser;
        private System.Windows.Forms.Panel panel2submenu;
        private System.Windows.Forms.Button btn_logout;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_AddUsers;
        private System.Windows.Forms.Panel panelDashboard;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Label lblPendingReports;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Label lblTotalSales;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label lblTotalFarmers;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.Label lblTotalUsers;
        private System.Windows.Forms.Button btn_Farmers;
        private System.Windows.Forms.Button btn_Sales;
        private System.Windows.Forms.Panel panelUsers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelFarmers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelSales;
        private System.Windows.Forms.Label label3;
        // private FontAwesome.Sharp.IconToolStripButton iconToolStripButton1;
        // private FontAwesome.Sharp.IconMenuItem iconMenuItem1;
    }
}