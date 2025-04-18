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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminDashboard));
            this.sqlCommandBuilder1 = new Microsoft.Data.SqlClient.SqlCommandBuilder();
            this.panelsideMenu = new System.Windows.Forms.Panel();
            this.btn_SystemSettings = new System.Windows.Forms.Button();
            this.btn_DamageReporting = new System.Windows.Forms.Button();
            this.btn_ReportsAnalytics = new System.Windows.Forms.Button();
            this.btn_PriceSetting = new System.Windows.Forms.Button();
            this.btn_StockManagement = new System.Windows.Forms.Button();
            this.btn_Sales = new System.Windows.Forms.Button();
            this.panel3side = new System.Windows.Forms.Panel();
            this.btn_Cultivation = new System.Windows.Forms.Button();
            this.btn_Fields = new System.Windows.Forms.Button();
            this.btn_AllFarmers = new System.Windows.Forms.Button();
            this.btn_Farmers = new System.Windows.Forms.Button();
            this.btn_logout = new System.Windows.Forms.Button();
            this.panel2submenu = new System.Windows.Forms.Panel();
            this.btn_AddUsers = new System.Windows.Forms.Button();
            this.btn_AllUsers = new System.Windows.Forms.Button();
            this.btn_manUser = new System.Windows.Forms.Button();
            this.btn_Dashboard = new System.Windows.Forms.Button();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.riceProductionDB2DataSet = new RiceMgmtApp.RiceProductionDB2DataSet();
            this.usersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.usersTableAdapter = new RiceMgmtApp.RiceProductionDB2DataSetTableAdapters.UsersTableAdapter();
            this.usersTableAdapter1 = new RiceMgmtApp.RiceProductionDB2DataSetTableAdapters.UsersTableAdapter();
            this.usersTableAdapter2 = new RiceMgmtApp.RiceProductionDB2DataSetTableAdapters.UsersTableAdapter();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelsideMenu.SuspendLayout();
            this.panel3side.SuspendLayout();
            this.panel2submenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.riceProductionDB2DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelsideMenu
            // 
            this.panelsideMenu.AutoScroll = true;
            this.panelsideMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(179)))), ((int)(((byte)(86)))));
            this.panelsideMenu.Controls.Add(this.btn_SystemSettings);
            this.panelsideMenu.Controls.Add(this.btn_DamageReporting);
            this.panelsideMenu.Controls.Add(this.btn_ReportsAnalytics);
            this.panelsideMenu.Controls.Add(this.btn_PriceSetting);
            this.panelsideMenu.Controls.Add(this.btn_StockManagement);
            this.panelsideMenu.Controls.Add(this.btn_Sales);
            this.panelsideMenu.Controls.Add(this.panel3side);
            this.panelsideMenu.Controls.Add(this.btn_Farmers);
            this.panelsideMenu.Controls.Add(this.btn_logout);
            this.panelsideMenu.Controls.Add(this.panel2submenu);
            this.panelsideMenu.Controls.Add(this.btn_manUser);
            this.panelsideMenu.Controls.Add(this.btn_Dashboard);
            this.panelsideMenu.Controls.Add(this.pictureBox1);
            this.panelsideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelsideMenu.Location = new System.Drawing.Point(0, 0);
            this.panelsideMenu.Name = "panelsideMenu";
            this.panelsideMenu.Size = new System.Drawing.Size(250, 749);
            this.panelsideMenu.TabIndex = 3;
            // 
            // btn_SystemSettings
            // 
            this.btn_SystemSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_SystemSettings.FlatAppearance.BorderSize = 0;
            this.btn_SystemSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SystemSettings.Font = new System.Drawing.Font("Outfit", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SystemSettings.ForeColor = System.Drawing.Color.White;
            this.btn_SystemSettings.Location = new System.Drawing.Point(0, 672);
            this.btn_SystemSettings.Name = "btn_SystemSettings";
            this.btn_SystemSettings.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_SystemSettings.Size = new System.Drawing.Size(233, 45);
            this.btn_SystemSettings.TabIndex = 15;
            this.btn_SystemSettings.Text = "System Settings";
            this.btn_SystemSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_SystemSettings.UseVisualStyleBackColor = true;
            // 
            // btn_DamageReporting
            // 
            this.btn_DamageReporting.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_DamageReporting.FlatAppearance.BorderSize = 0;
            this.btn_DamageReporting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DamageReporting.Font = new System.Drawing.Font("Outfit", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DamageReporting.ForeColor = System.Drawing.Color.White;
            this.btn_DamageReporting.Location = new System.Drawing.Point(0, 627);
            this.btn_DamageReporting.Name = "btn_DamageReporting";
            this.btn_DamageReporting.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_DamageReporting.Size = new System.Drawing.Size(233, 45);
            this.btn_DamageReporting.TabIndex = 14;
            this.btn_DamageReporting.Text = "Damage Reporting";
            this.btn_DamageReporting.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_DamageReporting.UseVisualStyleBackColor = true;
            this.btn_DamageReporting.Click += new System.EventHandler(this.btn_DamageReporting_Click);
            // 
            // btn_ReportsAnalytics
            // 
            this.btn_ReportsAnalytics.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_ReportsAnalytics.FlatAppearance.BorderSize = 0;
            this.btn_ReportsAnalytics.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ReportsAnalytics.Font = new System.Drawing.Font("Outfit", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ReportsAnalytics.ForeColor = System.Drawing.Color.White;
            this.btn_ReportsAnalytics.Location = new System.Drawing.Point(0, 582);
            this.btn_ReportsAnalytics.Name = "btn_ReportsAnalytics";
            this.btn_ReportsAnalytics.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_ReportsAnalytics.Size = new System.Drawing.Size(233, 45);
            this.btn_ReportsAnalytics.TabIndex = 13;
            this.btn_ReportsAnalytics.Text = "Reports and Analytics";
            this.btn_ReportsAnalytics.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_ReportsAnalytics.UseVisualStyleBackColor = true;
            // 
            // btn_PriceSetting
            // 
            this.btn_PriceSetting.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_PriceSetting.FlatAppearance.BorderSize = 0;
            this.btn_PriceSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_PriceSetting.Font = new System.Drawing.Font("Outfit", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_PriceSetting.ForeColor = System.Drawing.Color.White;
            this.btn_PriceSetting.Location = new System.Drawing.Point(0, 537);
            this.btn_PriceSetting.Name = "btn_PriceSetting";
            this.btn_PriceSetting.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_PriceSetting.Size = new System.Drawing.Size(233, 45);
            this.btn_PriceSetting.TabIndex = 12;
            this.btn_PriceSetting.Text = "Price Setting";
            this.btn_PriceSetting.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_PriceSetting.UseVisualStyleBackColor = true;
            this.btn_PriceSetting.Click += new System.EventHandler(this.btn_PriceSetting_Click);
            // 
            // btn_StockManagement
            // 
            this.btn_StockManagement.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_StockManagement.FlatAppearance.BorderSize = 0;
            this.btn_StockManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_StockManagement.Font = new System.Drawing.Font("Outfit", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_StockManagement.ForeColor = System.Drawing.Color.White;
            this.btn_StockManagement.Location = new System.Drawing.Point(0, 492);
            this.btn_StockManagement.Name = "btn_StockManagement";
            this.btn_StockManagement.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_StockManagement.Size = new System.Drawing.Size(233, 45);
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
            this.btn_Sales.Location = new System.Drawing.Point(0, 447);
            this.btn_Sales.Name = "btn_Sales";
            this.btn_Sales.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_Sales.Size = new System.Drawing.Size(233, 45);
            this.btn_Sales.TabIndex = 10;
            this.btn_Sales.Text = "Sales Records";
            this.btn_Sales.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Sales.UseVisualStyleBackColor = true;
            this.btn_Sales.Click += new System.EventHandler(this.btn_Sales_Click);
            // 
            // panel3side
            // 
            this.panel3side.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(240)))), ((int)(((byte)(112)))));
            this.panel3side.Controls.Add(this.btn_Cultivation);
            this.panel3side.Controls.Add(this.btn_Fields);
            this.panel3side.Controls.Add(this.btn_AllFarmers);
            this.panel3side.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3side.Location = new System.Drawing.Point(0, 320);
            this.panel3side.Name = "panel3side";
            this.panel3side.Size = new System.Drawing.Size(233, 127);
            this.panel3side.TabIndex = 9;
            // 
            // btn_Cultivation
            // 
            this.btn_Cultivation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(250)))), ((int)(((byte)(206)))));
            this.btn_Cultivation.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Cultivation.FlatAppearance.BorderSize = 0;
            this.btn_Cultivation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cultivation.Font = new System.Drawing.Font("Outfit SemiBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cultivation.ForeColor = System.Drawing.Color.Black;
            this.btn_Cultivation.Location = new System.Drawing.Point(0, 87);
            this.btn_Cultivation.Name = "btn_Cultivation";
            this.btn_Cultivation.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btn_Cultivation.Size = new System.Drawing.Size(233, 40);
            this.btn_Cultivation.TabIndex = 6;
            this.btn_Cultivation.Text = "Cultivation";
            this.btn_Cultivation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Cultivation.UseVisualStyleBackColor = false;
            this.btn_Cultivation.Click += new System.EventHandler(this.btn_Cultivation_Click);
            // 
            // btn_Fields
            // 
            this.btn_Fields.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(250)))), ((int)(((byte)(206)))));
            this.btn_Fields.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Fields.FlatAppearance.BorderSize = 0;
            this.btn_Fields.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Fields.Font = new System.Drawing.Font("Outfit SemiBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Fields.ForeColor = System.Drawing.Color.Black;
            this.btn_Fields.Location = new System.Drawing.Point(0, 40);
            this.btn_Fields.Name = "btn_Fields";
            this.btn_Fields.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btn_Fields.Size = new System.Drawing.Size(233, 47);
            this.btn_Fields.TabIndex = 5;
            this.btn_Fields.Text = "Field Management";
            this.btn_Fields.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Fields.UseVisualStyleBackColor = false;
            this.btn_Fields.Click += new System.EventHandler(this.btn_Fields_Click);
            // 
            // btn_AllFarmers
            // 
            this.btn_AllFarmers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(250)))), ((int)(((byte)(206)))));
            this.btn_AllFarmers.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_AllFarmers.FlatAppearance.BorderSize = 0;
            this.btn_AllFarmers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AllFarmers.Font = new System.Drawing.Font("Outfit SemiBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AllFarmers.ForeColor = System.Drawing.Color.Black;
            this.btn_AllFarmers.Location = new System.Drawing.Point(0, 0);
            this.btn_AllFarmers.Name = "btn_AllFarmers";
            this.btn_AllFarmers.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btn_AllFarmers.Size = new System.Drawing.Size(233, 40);
            this.btn_AllFarmers.TabIndex = 4;
            this.btn_AllFarmers.Text = "All Farmers";
            this.btn_AllFarmers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_AllFarmers.UseVisualStyleBackColor = false;
            this.btn_AllFarmers.Click += new System.EventHandler(this.btn_AllFarmers_Click);
            // 
            // btn_Farmers
            // 
            this.btn_Farmers.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Farmers.FlatAppearance.BorderSize = 0;
            this.btn_Farmers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Farmers.Font = new System.Drawing.Font("Outfit", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Farmers.ForeColor = System.Drawing.Color.White;
            this.btn_Farmers.Location = new System.Drawing.Point(0, 275);
            this.btn_Farmers.Name = "btn_Farmers";
            this.btn_Farmers.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_Farmers.Size = new System.Drawing.Size(233, 45);
            this.btn_Farmers.TabIndex = 7;
            this.btn_Farmers.Text = "Farmers";
            this.btn_Farmers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Farmers.UseVisualStyleBackColor = true;
            this.btn_Farmers.Click += new System.EventHandler(this.btn_Farmers_Click);
            // 
            // btn_logout
            // 
            this.btn_logout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_logout.Location = new System.Drawing.Point(0, 717);
            this.btn_logout.Name = "btn_logout";
            this.btn_logout.Size = new System.Drawing.Size(233, 41);
            this.btn_logout.TabIndex = 6;
            this.btn_logout.Text = "Logout";
            this.btn_logout.UseVisualStyleBackColor = true;
            this.btn_logout.Click += new System.EventHandler(this.btn_logout_Click);
            // 
            // panel2submenu
            // 
            this.panel2submenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(250)))), ((int)(((byte)(206)))));
            this.panel2submenu.Controls.Add(this.btn_AddUsers);
            this.panel2submenu.Controls.Add(this.btn_AllUsers);
            this.panel2submenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2submenu.Location = new System.Drawing.Point(0, 195);
            this.panel2submenu.Name = "panel2submenu";
            this.panel2submenu.Size = new System.Drawing.Size(233, 80);
            this.panel2submenu.TabIndex = 4;
            // 
            // btn_AddUsers
            // 
            this.btn_AddUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(250)))), ((int)(((byte)(206)))));
            this.btn_AddUsers.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_AddUsers.FlatAppearance.BorderSize = 0;
            this.btn_AddUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AddUsers.Font = new System.Drawing.Font("Outfit SemiBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AddUsers.ForeColor = System.Drawing.Color.Black;
            this.btn_AddUsers.Location = new System.Drawing.Point(0, 40);
            this.btn_AddUsers.Name = "btn_AddUsers";
            this.btn_AddUsers.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btn_AddUsers.Size = new System.Drawing.Size(233, 40);
            this.btn_AddUsers.TabIndex = 5;
            this.btn_AddUsers.Text = "Add New Users";
            this.btn_AddUsers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_AddUsers.UseVisualStyleBackColor = false;
            this.btn_AddUsers.Click += new System.EventHandler(this.btn_AddUsers_Click);
            // 
            // btn_AllUsers
            // 
            this.btn_AllUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(250)))), ((int)(((byte)(206)))));
            this.btn_AllUsers.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_AllUsers.FlatAppearance.BorderSize = 0;
            this.btn_AllUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AllUsers.Font = new System.Drawing.Font("Outfit SemiBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AllUsers.ForeColor = System.Drawing.Color.Black;
            this.btn_AllUsers.Location = new System.Drawing.Point(0, 0);
            this.btn_AllUsers.Name = "btn_AllUsers";
            this.btn_AllUsers.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btn_AllUsers.Size = new System.Drawing.Size(233, 40);
            this.btn_AllUsers.TabIndex = 3;
            this.btn_AllUsers.Text = "All Users";
            this.btn_AllUsers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_AllUsers.UseVisualStyleBackColor = false;
            this.btn_AllUsers.Click += new System.EventHandler(this.btn_AllUsers_Click);
            // 
            // btn_manUser
            // 
            this.btn_manUser.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_manUser.FlatAppearance.BorderSize = 0;
            this.btn_manUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_manUser.Font = new System.Drawing.Font("Outfit", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_manUser.ForeColor = System.Drawing.Color.White;
            this.btn_manUser.Location = new System.Drawing.Point(0, 150);
            this.btn_manUser.Name = "btn_manUser";
            this.btn_manUser.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_manUser.Size = new System.Drawing.Size(233, 45);
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
            this.btn_Dashboard.Location = new System.Drawing.Point(0, 105);
            this.btn_Dashboard.Name = "btn_Dashboard";
            this.btn_Dashboard.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_Dashboard.Size = new System.Drawing.Size(233, 45);
            this.btn_Dashboard.TabIndex = 1;
            this.btn_Dashboard.Text = "Dashboard";
            this.btn_Dashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Dashboard.UseVisualStyleBackColor = true;
            this.btn_Dashboard.Click += new System.EventHandler(this.btn_Dashboard_Click);
            // 
            // panelContainer
            // 
            this.panelContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(247)))));
            this.panelContainer.Location = new System.Drawing.Point(268, 27);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(934, 697);
            this.panelContainer.TabIndex = 5;
            // 
            // riceProductionDB2DataSet
            // 
            this.riceProductionDB2DataSet.DataSetName = "RiceProductionDB2DataSet";
            this.riceProductionDB2DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // usersBindingSource
            // 
            this.usersBindingSource.DataMember = "Users";
            this.usersBindingSource.DataSource = this.riceProductionDB2DataSet;
            // 
            // usersTableAdapter
            // 
            this.usersTableAdapter.ClearBeforeFill = true;
            // 
            // usersTableAdapter1
            // 
            this.usersTableAdapter1.ClearBeforeFill = true;
            // 
            // usersTableAdapter2
            // 
            this.usersTableAdapter2.ClearBeforeFill = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(179)))), ((int)(((byte)(86)))));
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::RiceMgmtApp.Properties.Resources.Frame_1;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(233, 105);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // AdminDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(247)))));
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(1224, 749);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.panelsideMenu);
            this.Font = new System.Drawing.Font("Outfit", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AdminDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panelsideMenu.ResumeLayout(false);
            this.panel3side.ResumeLayout(false);
            this.panel2submenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.riceProductionDB2DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.Button btn_AllUsers;
        private System.Windows.Forms.Button btn_Farmers;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.Panel panel3side;
        private System.Windows.Forms.Button btn_Sales;
        private System.Windows.Forms.Button btn_Fields;
        private System.Windows.Forms.Button btn_AllFarmers;
        private RiceProductionDB2DataSet riceProductionDB2DataSet;
        private System.Windows.Forms.BindingSource usersBindingSource;
        private RiceProductionDB2DataSetTableAdapters.UsersTableAdapter usersTableAdapter;
      //  private System.Windows.Forms.DataGridView dgvUsers;
        private RiceProductionDB2DataSetTableAdapters.UsersTableAdapter usersTableAdapter1;
        private RiceProductionDB2DataSetTableAdapters.UsersTableAdapter usersTableAdapter2;
        private System.Windows.Forms.Button btn_AddUsers;
        private System.Windows.Forms.Button btn_SystemSettings;
        private System.Windows.Forms.Button btn_DamageReporting;
        private System.Windows.Forms.Button btn_ReportsAnalytics;
        private System.Windows.Forms.Button btn_PriceSetting;
        private System.Windows.Forms.Button btn_StockManagement;
        private System.Windows.Forms.Button btn_Cultivation;
        // private FontAwesome.Sharp.IconToolStripButton iconToolStripButton1;
        // private FontAwesome.Sharp.IconMenuItem iconMenuItem1;
    }
}