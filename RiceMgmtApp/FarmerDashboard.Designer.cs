namespace RiceMgmtApp
{
    partial class FarmerDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FarmerDashboard));
            this.panelsideMenu = new System.Windows.Forms.Panel();
            this.RequestPaddy = new System.Windows.Forms.Button();
            this.btnPrice_Monitoring = new System.Windows.Forms.Button();
            this.btn_DamageReporting = new System.Windows.Forms.Button();
            this.btn_StockManagement = new System.Windows.Forms.Button();
            this.btn_Sales = new System.Windows.Forms.Button();
            this.btn_Farmers = new System.Windows.Forms.Button();
            this.btn_logout = new System.Windows.Forms.Button();
            this.btn_profile = new System.Windows.Forms.Button();
            this.btn_Dashboard = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.panelsideMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelsideMenu
            // 
            this.panelsideMenu.AutoScroll = true;
            this.panelsideMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(179)))), ((int)(((byte)(86)))));
            this.panelsideMenu.Controls.Add(this.RequestPaddy);
            this.panelsideMenu.Controls.Add(this.btnPrice_Monitoring);
            this.panelsideMenu.Controls.Add(this.btn_DamageReporting);
            this.panelsideMenu.Controls.Add(this.btn_StockManagement);
            this.panelsideMenu.Controls.Add(this.btn_Sales);
            this.panelsideMenu.Controls.Add(this.btn_Farmers);
            this.panelsideMenu.Controls.Add(this.btn_logout);
            this.panelsideMenu.Controls.Add(this.btn_profile);
            this.panelsideMenu.Controls.Add(this.btn_Dashboard);
            this.panelsideMenu.Controls.Add(this.pictureBox1);
            this.panelsideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelsideMenu.Location = new System.Drawing.Point(0, 0);
            this.panelsideMenu.Name = "panelsideMenu";
            this.panelsideMenu.Padding = new System.Windows.Forms.Padding(10, 0, 10, 48);
            this.panelsideMenu.Size = new System.Drawing.Size(250, 749);
            this.panelsideMenu.TabIndex = 4;
            // 
            // RequestPaddy
            // 
            this.RequestPaddy.Dock = System.Windows.Forms.DockStyle.Top;
            this.RequestPaddy.FlatAppearance.BorderSize = 0;
            this.RequestPaddy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RequestPaddy.Font = new System.Drawing.Font("Outfit", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RequestPaddy.ForeColor = System.Drawing.Color.White;
            this.RequestPaddy.Location = new System.Drawing.Point(10, 420);
            this.RequestPaddy.Name = "RequestPaddy";
            this.RequestPaddy.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.RequestPaddy.Size = new System.Drawing.Size(230, 45);
            this.RequestPaddy.TabIndex = 16;
            this.RequestPaddy.Text = "Requests";
            this.RequestPaddy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RequestPaddy.UseVisualStyleBackColor = true;
            this.RequestPaddy.Click += new System.EventHandler(this.RequestPaddy_Click);
            // 
            // btnPrice_Monitoring
            // 
            this.btnPrice_Monitoring.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPrice_Monitoring.FlatAppearance.BorderSize = 0;
            this.btnPrice_Monitoring.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrice_Monitoring.Font = new System.Drawing.Font("Outfit", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrice_Monitoring.ForeColor = System.Drawing.Color.White;
            this.btnPrice_Monitoring.Location = new System.Drawing.Point(10, 375);
            this.btnPrice_Monitoring.Name = "btnPrice_Monitoring";
            this.btnPrice_Monitoring.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnPrice_Monitoring.Size = new System.Drawing.Size(230, 45);
            this.btnPrice_Monitoring.TabIndex = 15;
            this.btnPrice_Monitoring.Text = "Price Monitoring";
            this.btnPrice_Monitoring.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrice_Monitoring.UseVisualStyleBackColor = true;
            this.btnPrice_Monitoring.Click += new System.EventHandler(this.btnPrice_Monitoring_Click);
            // 
            // btn_DamageReporting
            // 
            this.btn_DamageReporting.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_DamageReporting.FlatAppearance.BorderSize = 0;
            this.btn_DamageReporting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DamageReporting.Font = new System.Drawing.Font("Outfit", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DamageReporting.ForeColor = System.Drawing.Color.White;
            this.btn_DamageReporting.Location = new System.Drawing.Point(10, 330);
            this.btn_DamageReporting.Name = "btn_DamageReporting";
            this.btn_DamageReporting.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_DamageReporting.Size = new System.Drawing.Size(230, 45);
            this.btn_DamageReporting.TabIndex = 14;
            this.btn_DamageReporting.Text = "Damage Reporting";
            this.btn_DamageReporting.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_DamageReporting.UseVisualStyleBackColor = true;
            this.btn_DamageReporting.Click += new System.EventHandler(this.btn_DamageReporting_Click);
            // 
            // btn_StockManagement
            // 
            this.btn_StockManagement.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_StockManagement.FlatAppearance.BorderSize = 0;
            this.btn_StockManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_StockManagement.Font = new System.Drawing.Font("Outfit", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_StockManagement.ForeColor = System.Drawing.Color.White;
            this.btn_StockManagement.Location = new System.Drawing.Point(10, 285);
            this.btn_StockManagement.Name = "btn_StockManagement";
            this.btn_StockManagement.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_StockManagement.Size = new System.Drawing.Size(230, 45);
            this.btn_StockManagement.TabIndex = 11;
            this.btn_StockManagement.Text = "Stock Management";
            this.btn_StockManagement.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_StockManagement.UseVisualStyleBackColor = true;
            this.btn_StockManagement.Click += new System.EventHandler(this.btn_StockManagement_Click);
            // 
            // btn_Sales
            // 
            this.btn_Sales.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Sales.FlatAppearance.BorderSize = 0;
            this.btn_Sales.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Sales.Font = new System.Drawing.Font("Outfit", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Sales.ForeColor = System.Drawing.Color.White;
            this.btn_Sales.Location = new System.Drawing.Point(10, 240);
            this.btn_Sales.Name = "btn_Sales";
            this.btn_Sales.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_Sales.Size = new System.Drawing.Size(230, 45);
            this.btn_Sales.TabIndex = 10;
            this.btn_Sales.Text = "Pady Sales";
            this.btn_Sales.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Sales.UseVisualStyleBackColor = true;
            this.btn_Sales.Click += new System.EventHandler(this.btn_Sales_Click);
            // 
            // btn_Farmers
            // 
            this.btn_Farmers.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Farmers.FlatAppearance.BorderSize = 0;
            this.btn_Farmers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Farmers.Font = new System.Drawing.Font("Outfit", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Farmers.ForeColor = System.Drawing.Color.White;
            this.btn_Farmers.Location = new System.Drawing.Point(10, 195);
            this.btn_Farmers.Name = "btn_Farmers";
            this.btn_Farmers.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_Farmers.Size = new System.Drawing.Size(230, 45);
            this.btn_Farmers.TabIndex = 7;
            this.btn_Farmers.Text = "Field Management";
            this.btn_Farmers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Farmers.UseVisualStyleBackColor = true;
            this.btn_Farmers.Click += new System.EventHandler(this.btn_Farmers_Click);
            // 
            // btn_logout
            // 
            this.btn_logout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btn_logout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_logout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_logout.FlatAppearance.BorderSize = 0;
            this.btn_logout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_logout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btn_logout.ForeColor = System.Drawing.Color.White;
            this.btn_logout.Location = new System.Drawing.Point(10, 660);
            this.btn_logout.Name = "btn_logout";
            this.btn_logout.Size = new System.Drawing.Size(230, 41);
            this.btn_logout.TabIndex = 6;
            this.btn_logout.Text = "Logout";
            this.btn_logout.UseVisualStyleBackColor = false;
            this.btn_logout.Click += new System.EventHandler(this.btn_logout_Click);
            // 
            // btn_profile
            // 
            this.btn_profile.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_profile.FlatAppearance.BorderSize = 0;
            this.btn_profile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_profile.Font = new System.Drawing.Font("Outfit", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_profile.ForeColor = System.Drawing.Color.White;
            this.btn_profile.Location = new System.Drawing.Point(10, 150);
            this.btn_profile.Name = "btn_profile";
            this.btn_profile.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_profile.Size = new System.Drawing.Size(230, 45);
            this.btn_profile.TabIndex = 3;
            this.btn_profile.Text = "Profile";
            this.btn_profile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_profile.UseVisualStyleBackColor = true;
            this.btn_profile.Click += new System.EventHandler(this.btn_profile_Click);
            // 
            // btn_Dashboard
            // 
            this.btn_Dashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Dashboard.FlatAppearance.BorderSize = 0;
            this.btn_Dashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Dashboard.Font = new System.Drawing.Font("Outfit", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Dashboard.ForeColor = System.Drawing.Color.White;
            this.btn_Dashboard.Location = new System.Drawing.Point(10, 105);
            this.btn_Dashboard.Name = "btn_Dashboard";
            this.btn_Dashboard.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_Dashboard.Size = new System.Drawing.Size(230, 45);
            this.btn_Dashboard.TabIndex = 1;
            this.btn_Dashboard.Text = "Dashboard";
            this.btn_Dashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Dashboard.UseVisualStyleBackColor = true;
            this.btn_Dashboard.Click += new System.EventHandler(this.btn_Dashboard_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(179)))), ((int)(((byte)(86)))));
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::RiceMgmtApp.Properties.Resources.Frame_1;
            this.pictureBox1.Location = new System.Drawing.Point(10, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(230, 105);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panelContainer
            // 
            this.panelContainer.AutoScroll = true;
            this.panelContainer.AutoSize = true;
            this.panelContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(247)))));
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(250, 0);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(974, 749);
            this.panelContainer.TabIndex = 6;
            // 
            // FarmerDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(1224, 749);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.panelsideMenu);
            this.Font = new System.Drawing.Font("Outfit", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MinimumSize = new System.Drawing.Size(1240, 726);
            this.Name = "FarmerDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FarmerDashboard_Load);
            this.panelsideMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        // Add this method to the FarmerDashboard class
        //private void panelsideMenu_Paint(object sender, PaintEventArgs e)
        //{
        //    // You can leave this empty or add custom painting logic if needed
        //}

        #endregion

        private System.Windows.Forms.Panel panelsideMenu;
        private System.Windows.Forms.Button btn_DamageReporting;
        private System.Windows.Forms.Button btn_StockManagement;
        private System.Windows.Forms.Button btn_Sales;
        private System.Windows.Forms.Button btn_Farmers;
        private System.Windows.Forms.Button btn_logout;
        private System.Windows.Forms.Button btn_profile;
        private System.Windows.Forms.Button btn_Dashboard;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnPrice_Monitoring;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.Button RequestPaddy;
    }
}