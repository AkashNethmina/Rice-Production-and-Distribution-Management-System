namespace RiceMgmtApp
{
    partial class PrivateBuyerHome
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panelStats = new System.Windows.Forms.TableLayoutPanel();
            this.panelTotalUsers = new System.Windows.Forms.Panel();
            this.lblTotalUsers = new System.Windows.Forms.Label();
            this.lblTotalUsersTitle = new System.Windows.Forms.Label();
            this.panelAdmins = new System.Windows.Forms.Panel();
            this.lblAdminCount = new System.Windows.Forms.Label();
            this.lblAdminTitle = new System.Windows.Forms.Label();
            this.panelFarmers = new System.Windows.Forms.Panel();
            this.lblFarmerCount = new System.Windows.Forms.Label();
            this.lblFarmerTitle = new System.Windows.Forms.Label();
            this.panelGovernment = new System.Windows.Forms.Panel();
            this.lblGovernmentCount = new System.Windows.Forms.Label();
            this.lblGovernmentTitle = new System.Windows.Forms.Label();
            this.panelPrivate = new System.Windows.Forms.Panel();
            this.lblPrivateBuyerCount = new System.Windows.Forms.Label();
            this.lblPrivateBuyerTitle = new System.Windows.Forms.Label();
            this.lblDashboardTitle = new System.Windows.Forms.Label();
            this.tableLayoutPanelCharts = new System.Windows.Forms.TableLayoutPanel();
            this.chartSales = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartStock = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.panelStats.SuspendLayout();
            this.panelTotalUsers.SuspendLayout();
            this.panelAdmins.SuspendLayout();
            this.panelFarmers.SuspendLayout();
            this.panelGovernment.SuspendLayout();
            this.panelPrivate.SuspendLayout();
            this.tableLayoutPanelCharts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartStock)).BeginInit();
            this.SuspendLayout();
            // 
            // panelStats
            // 
            this.panelStats.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelStats.ColumnCount = 5;
            this.panelStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.panelStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.panelStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.panelStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.panelStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.panelStats.Controls.Add(this.panelTotalUsers, 0, 0);
            this.panelStats.Controls.Add(this.panelAdmins, 1, 0);
            this.panelStats.Controls.Add(this.panelFarmers, 2, 0);
            this.panelStats.Controls.Add(this.panelGovernment, 3, 0);
            this.panelStats.Controls.Add(this.panelPrivate, 4, 0);
            this.panelStats.Location = new System.Drawing.Point(20, 60);
            this.panelStats.Name = "panelStats";
            this.panelStats.RowCount = 1;
            this.panelStats.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelStats.Size = new System.Drawing.Size(960, 100);
            this.panelStats.TabIndex = 0;
            // 
            // panelTotalUsers
            // 
            this.panelTotalUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.panelTotalUsers.Controls.Add(this.lblTotalUsers);
            this.panelTotalUsers.Controls.Add(this.lblTotalUsersTitle);
            this.panelTotalUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTotalUsers.Location = new System.Drawing.Point(3, 3);
            this.panelTotalUsers.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.panelTotalUsers.Name = "panelTotalUsers";
            this.panelTotalUsers.Size = new System.Drawing.Size(179, 94);
            this.panelTotalUsers.TabIndex = 0;
            // 
            // lblTotalUsers
            // 
            this.lblTotalUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalUsers.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalUsers.ForeColor = System.Drawing.Color.White;
            this.lblTotalUsers.Location = new System.Drawing.Point(0, 27);
            this.lblTotalUsers.Name = "lblTotalUsers";
            this.lblTotalUsers.Size = new System.Drawing.Size(179, 67);
            this.lblTotalUsers.TabIndex = 1;
            this.lblTotalUsers.Text = "0";
            this.lblTotalUsers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalUsersTitle
            // 
            this.lblTotalUsersTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTotalUsersTitle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalUsersTitle.ForeColor = System.Drawing.Color.White;
            this.lblTotalUsersTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTotalUsersTitle.Name = "lblTotalUsersTitle";
            this.lblTotalUsersTitle.Size = new System.Drawing.Size(179, 27);
            this.lblTotalUsersTitle.TabIndex = 0;
            this.lblTotalUsersTitle.Text = "TOTAL USERS";
            this.lblTotalUsersTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelAdmins
            // 
            this.panelAdmins.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.panelAdmins.Controls.Add(this.lblAdminCount);
            this.panelAdmins.Controls.Add(this.lblAdminTitle);
            this.panelAdmins.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAdmins.Location = new System.Drawing.Point(195, 3);
            this.panelAdmins.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.panelAdmins.Name = "panelAdmins";
            this.panelAdmins.Size = new System.Drawing.Size(179, 94);
            this.panelAdmins.TabIndex = 1;
            // 
            // lblAdminCount
            // 
            this.lblAdminCount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAdminCount.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdminCount.ForeColor = System.Drawing.Color.White;
            this.lblAdminCount.Location = new System.Drawing.Point(0, 27);
            this.lblAdminCount.Name = "lblAdminCount";
            this.lblAdminCount.Size = new System.Drawing.Size(179, 67);
            this.lblAdminCount.TabIndex = 2;
            this.lblAdminCount.Text = "0";
            this.lblAdminCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAdminTitle
            // 
            this.lblAdminTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAdminTitle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdminTitle.ForeColor = System.Drawing.Color.White;
            this.lblAdminTitle.Location = new System.Drawing.Point(0, 0);
            this.lblAdminTitle.Name = "lblAdminTitle";
            this.lblAdminTitle.Size = new System.Drawing.Size(179, 27);
            this.lblAdminTitle.TabIndex = 1;
            this.lblAdminTitle.Text = "ADMINS";
            this.lblAdminTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelFarmers
            // 
            this.panelFarmers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.panelFarmers.Controls.Add(this.lblFarmerCount);
            this.panelFarmers.Controls.Add(this.lblFarmerTitle);
            this.panelFarmers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFarmers.Location = new System.Drawing.Point(387, 3);
            this.panelFarmers.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.panelFarmers.Name = "panelFarmers";
            this.panelFarmers.Size = new System.Drawing.Size(179, 94);
            this.panelFarmers.TabIndex = 2;
            // 
            // lblFarmerCount
            // 
            this.lblFarmerCount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFarmerCount.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFarmerCount.ForeColor = System.Drawing.Color.White;
            this.lblFarmerCount.Location = new System.Drawing.Point(0, 27);
            this.lblFarmerCount.Name = "lblFarmerCount";
            this.lblFarmerCount.Size = new System.Drawing.Size(179, 67);
            this.lblFarmerCount.TabIndex = 2;
            this.lblFarmerCount.Text = "0";
            this.lblFarmerCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFarmerTitle
            // 
            this.lblFarmerTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblFarmerTitle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFarmerTitle.ForeColor = System.Drawing.Color.White;
            this.lblFarmerTitle.Location = new System.Drawing.Point(0, 0);
            this.lblFarmerTitle.Name = "lblFarmerTitle";
            this.lblFarmerTitle.Size = new System.Drawing.Size(179, 27);
            this.lblFarmerTitle.TabIndex = 1;
            this.lblFarmerTitle.Text = "FARMERS";
            this.lblFarmerTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelGovernment
            // 
            this.panelGovernment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            this.panelGovernment.Controls.Add(this.lblGovernmentCount);
            this.panelGovernment.Controls.Add(this.lblGovernmentTitle);
            this.panelGovernment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGovernment.Location = new System.Drawing.Point(579, 3);
            this.panelGovernment.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.panelGovernment.Name = "panelGovernment";
            this.panelGovernment.Size = new System.Drawing.Size(179, 94);
            this.panelGovernment.TabIndex = 3;
            // 
            // lblGovernmentCount
            // 
            this.lblGovernmentCount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGovernmentCount.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGovernmentCount.ForeColor = System.Drawing.Color.White;
            this.lblGovernmentCount.Location = new System.Drawing.Point(0, 27);
            this.lblGovernmentCount.Name = "lblGovernmentCount";
            this.lblGovernmentCount.Size = new System.Drawing.Size(179, 67);
            this.lblGovernmentCount.TabIndex = 2;
            this.lblGovernmentCount.Text = "0";
            this.lblGovernmentCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblGovernmentTitle
            // 
            this.lblGovernmentTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblGovernmentTitle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGovernmentTitle.ForeColor = System.Drawing.Color.White;
            this.lblGovernmentTitle.Location = new System.Drawing.Point(0, 0);
            this.lblGovernmentTitle.Name = "lblGovernmentTitle";
            this.lblGovernmentTitle.Size = new System.Drawing.Size(179, 27);
            this.lblGovernmentTitle.TabIndex = 1;
            this.lblGovernmentTitle.Text = "GOVERNMENT";
            this.lblGovernmentTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelPrivate
            // 
            this.panelPrivate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.panelPrivate.Controls.Add(this.lblPrivateBuyerCount);
            this.panelPrivate.Controls.Add(this.lblPrivateBuyerTitle);
            this.panelPrivate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPrivate.Location = new System.Drawing.Point(771, 3);
            this.panelPrivate.Name = "panelPrivate";
            this.panelPrivate.Size = new System.Drawing.Size(186, 94);
            this.panelPrivate.TabIndex = 4;
            // 
            // lblPrivateBuyerCount
            // 
            this.lblPrivateBuyerCount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPrivateBuyerCount.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrivateBuyerCount.ForeColor = System.Drawing.Color.White;
            this.lblPrivateBuyerCount.Location = new System.Drawing.Point(0, 27);
            this.lblPrivateBuyerCount.Name = "lblPrivateBuyerCount";
            this.lblPrivateBuyerCount.Size = new System.Drawing.Size(186, 67);
            this.lblPrivateBuyerCount.TabIndex = 2;
            this.lblPrivateBuyerCount.Text = "0";
            this.lblPrivateBuyerCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPrivateBuyerTitle
            // 
            this.lblPrivateBuyerTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPrivateBuyerTitle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrivateBuyerTitle.ForeColor = System.Drawing.Color.White;
            this.lblPrivateBuyerTitle.Location = new System.Drawing.Point(0, 0);
            this.lblPrivateBuyerTitle.Name = "lblPrivateBuyerTitle";
            this.lblPrivateBuyerTitle.Size = new System.Drawing.Size(186, 27);
            this.lblPrivateBuyerTitle.TabIndex = 1;
            this.lblPrivateBuyerTitle.Text = "PRIVATE BUYERS";
            this.lblPrivateBuyerTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDashboardTitle
            // 
            this.lblDashboardTitle.AutoSize = true;
            this.lblDashboardTitle.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDashboardTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblDashboardTitle.Location = new System.Drawing.Point(15, 15);
            this.lblDashboardTitle.Name = "lblDashboardTitle";
            this.lblDashboardTitle.Size = new System.Drawing.Size(182, 30);
            this.lblDashboardTitle.TabIndex = 1;
            this.lblDashboardTitle.Text = "Private Buyer Dashboard";
            // 
            // tableLayoutPanelCharts
            // 
            this.tableLayoutPanelCharts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelCharts.ColumnCount = 2;
            this.tableLayoutPanelCharts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelCharts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelCharts.Controls.Add(this.chartSales, 0, 0);
            this.tableLayoutPanelCharts.Controls.Add(this.chartStock, 1, 0);
            this.tableLayoutPanelCharts.Location = new System.Drawing.Point(20, 177);
            this.tableLayoutPanelCharts.Name = "tableLayoutPanelCharts";
            this.tableLayoutPanelCharts.RowCount = 1;
            this.tableLayoutPanelCharts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelCharts.Size = new System.Drawing.Size(960, 370);
            this.tableLayoutPanelCharts.TabIndex = 2;
            // 
            // chartSales
            // 
            this.chartSales.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chartSales.BorderlineColor = System.Drawing.Color.Silver;
            this.chartSales.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.chartSales.BorderlineWidth = 1;
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisX.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisY.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.BackColor = System.Drawing.Color.White;
            chartArea1.Name = "ChartArea1";
            this.chartSales.ChartAreas.Add(chartArea1);
            this.chartSales.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Enabled = false;
            legend1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            this.chartSales.Legends.Add(legend1);
            this.chartSales.Location = new System.Drawing.Point(10, 10);
            this.chartSales.Margin = new System.Windows.Forms.Padding(10);
            this.chartSales.Name = "chartSales";
            this.chartSales.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series1.ChartArea = "ChartArea1";
            series1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.IsValueShownAsLabel = true;
            series1.Legend = "Legend1";
            series1.Name = "Sales";
            this.chartSales.Series.Add(series1);
            this.chartSales.Size = new System.Drawing.Size(460, 350);
            this.chartSales.TabIndex = 0;
            this.chartSales.Text = "Sales Chart";
            // 
            // chartStock
            // 
            this.chartStock.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chartStock.BorderlineColor = System.Drawing.Color.Silver;
            this.chartStock.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.chartStock.BorderlineWidth = 1;
            chartArea2.BackColor = System.Drawing.Color.White;
            chartArea2.Name = "ChartArea1";
            this.chartStock.ChartAreas.Add(chartArea2);
            this.chartStock.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend2.IsTextAutoFit = false;
            legend2.Name = "Legend1";
            this.chartStock.Legends.Add(legend2);
            this.chartStock.Location = new System.Drawing.Point(490, 10);
            this.chartStock.Margin = new System.Windows.Forms.Padding(10);
            this.chartStock.Name = "chartStock";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series2.IsValueShownAsLabel = true;
            series2.Legend = "Legend1";
            series2.Name = "Stock";
            this.chartStock.Series.Add(series2);
            this.chartStock.Size = new System.Drawing.Size(460, 350);
            this.chartStock.TabIndex = 1;
            this.chartStock.Text = "Stock Chart";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(860, 15);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(120, 35);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Refresh Data";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // PrivateBuyerHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.tableLayoutPanelCharts);
            this.Controls.Add(this.lblDashboardTitle);
            this.Controls.Add(this.panelStats);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PrivateBuyerHome";
            this.Size = new System.Drawing.Size(1000, 568);
            this.panelStats.ResumeLayout(false);
            this.panelTotalUsers.ResumeLayout(false);
            this.panelAdmins.ResumeLayout(false);
            this.panelFarmers.ResumeLayout(false);
            this.panelGovernment.ResumeLayout(false);
            this.panelPrivate.ResumeLayout(false);
            this.tableLayoutPanelCharts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartSales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartStock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelStats;
        private System.Windows.Forms.Panel panelTotalUsers;
        private System.Windows.Forms.Label lblTotalUsersTitle;
        private System.Windows.Forms.Panel panelAdmins;
        private System.Windows.Forms.Label lblAdminTitle;
        private System.Windows.Forms.Panel panelFarmers;
        private System.Windows.Forms.Label lblFarmerTitle;
        private System.Windows.Forms.Panel panelGovernment;
        private System.Windows.Forms.Label lblGovernmentTitle;
        private System.Windows.Forms.Panel panelPrivate;
        private System.Windows.Forms.Label lblPrivateBuyerTitle;
        private System.Windows.Forms.Label lblDashboardTitle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelCharts;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSales;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartStock;
        private System.Windows.Forms.Label lblTotalUsers;
        private System.Windows.Forms.Label lblAdminCount;
        private System.Windows.Forms.Label lblFarmerCount;
        private System.Windows.Forms.Label lblGovernmentCount;
        private System.Windows.Forms.Label lblPrivateBuyerCount;
        private System.Windows.Forms.Button btnRefresh;
    }
}
