namespace RiceMgmtApp
{
    partial class GovernmentHome
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panelStats = new System.Windows.Forms.TableLayoutPanel();
            this.panelTotalUsers = new System.Windows.Forms.Panel();
            this.lblFarmerCount = new System.Windows.Forms.Label();
            this.lblFarmerTitle = new System.Windows.Forms.Label();
            this.panelAdmins = new System.Windows.Forms.Panel();
            this.lblPrivateBuyerCount = new System.Windows.Forms.Label();
            this.lblPriveteBuyersTitle = new System.Windows.Forms.Label();
            this.panelFarmers = new System.Windows.Forms.Panel();
            this.lblFarmerTitle1 = new System.Windows.Forms.Label();
            this.panelGovernment = new System.Windows.Forms.Panel();
            this.lblGovernmentTitle = new System.Windows.Forms.Label();
            this.lblDashboardTitle = new System.Windows.Forms.Label();
            this.tableLayoutPanelCharts = new System.Windows.Forms.TableLayoutPanel();
            this.mychartStock = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.mychartSales = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartSales = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartStock = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lbltotalPurchaseQuantity = new System.Windows.Forms.Label();
            this.lblTotalPendingRequests = new System.Windows.Forms.Label();
            this.panelStats.SuspendLayout();
            this.panelTotalUsers.SuspendLayout();
            this.panelAdmins.SuspendLayout();
            this.panelFarmers.SuspendLayout();
            this.panelGovernment.SuspendLayout();
            this.tableLayoutPanelCharts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mychartStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mychartSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartStock)).BeginInit();
            this.SuspendLayout();
            // 
            // panelStats
            // 
            this.panelStats.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelStats.ColumnCount = 4;
            this.panelStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.panelStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.panelStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.panelStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.panelStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.panelStats.Controls.Add(this.panelTotalUsers, 0, 0);
            this.panelStats.Controls.Add(this.panelAdmins, 1, 0);
            this.panelStats.Controls.Add(this.panelFarmers, 2, 0);
            this.panelStats.Controls.Add(this.panelGovernment, 3, 0);
            this.panelStats.Location = new System.Drawing.Point(20, 60);
            this.panelStats.Name = "panelStats";
            this.panelStats.RowCount = 1;
            this.panelStats.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelStats.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.panelStats.Size = new System.Drawing.Size(960, 100);
            this.panelStats.TabIndex = 0;
            // 
            // panelTotalUsers
            // 
            this.panelTotalUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.panelTotalUsers.Controls.Add(this.lblFarmerCount);
            this.panelTotalUsers.Controls.Add(this.lblFarmerTitle);
            this.panelTotalUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTotalUsers.Location = new System.Drawing.Point(3, 3);
            this.panelTotalUsers.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.panelTotalUsers.Name = "panelTotalUsers";
            this.panelTotalUsers.Size = new System.Drawing.Size(227, 94);
            this.panelTotalUsers.TabIndex = 0;
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
            this.lblFarmerCount.Size = new System.Drawing.Size(227, 67);
            this.lblFarmerCount.TabIndex = 2;
            this.lblFarmerCount.Text = "0";
            this.lblFarmerCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFarmerTitle
            // 
            this.lblFarmerTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.lblFarmerTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblFarmerTitle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFarmerTitle.ForeColor = System.Drawing.Color.White;
            this.lblFarmerTitle.Location = new System.Drawing.Point(0, 0);
            this.lblFarmerTitle.Name = "lblFarmerTitle";
            this.lblFarmerTitle.Size = new System.Drawing.Size(227, 27);
            this.lblFarmerTitle.TabIndex = 0;
            this.lblFarmerTitle.Text = "TOTAL FARMERS";
            this.lblFarmerTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelAdmins
            // 
            this.panelAdmins.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            this.panelAdmins.Controls.Add(this.lblPrivateBuyerCount);
            this.panelAdmins.Controls.Add(this.lblPriveteBuyersTitle);
            this.panelAdmins.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAdmins.Location = new System.Drawing.Point(243, 3);
            this.panelAdmins.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.panelAdmins.Name = "panelAdmins";
            this.panelAdmins.Size = new System.Drawing.Size(227, 94);
            this.panelAdmins.TabIndex = 1;
            // 
            // lblPrivateBuyerCount
            // 
            this.lblPrivateBuyerCount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPrivateBuyerCount.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrivateBuyerCount.ForeColor = System.Drawing.Color.White;
            this.lblPrivateBuyerCount.Location = new System.Drawing.Point(0, 30);
            this.lblPrivateBuyerCount.Name = "lblPrivateBuyerCount";
            this.lblPrivateBuyerCount.Size = new System.Drawing.Size(227, 67);
            this.lblPrivateBuyerCount.TabIndex = 2;
            this.lblPrivateBuyerCount.Text = "0";
            this.lblPrivateBuyerCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPriveteBuyersTitle
            // 
            this.lblPriveteBuyersTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPriveteBuyersTitle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPriveteBuyersTitle.ForeColor = System.Drawing.Color.White;
            this.lblPriveteBuyersTitle.Location = new System.Drawing.Point(0, 0);
            this.lblPriveteBuyersTitle.Name = "lblPriveteBuyersTitle";
            this.lblPriveteBuyersTitle.Size = new System.Drawing.Size(227, 27);
            this.lblPriveteBuyersTitle.TabIndex = 1;
            this.lblPriveteBuyersTitle.Text = "TOTAL PRIVATE BUYERS";
            this.lblPriveteBuyersTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelFarmers
            // 
            this.panelFarmers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.panelFarmers.Controls.Add(this.lbltotalPurchaseQuantity);
            this.panelFarmers.Controls.Add(this.lblFarmerTitle1);
            this.panelFarmers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFarmers.Location = new System.Drawing.Point(483, 3);
            this.panelFarmers.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.panelFarmers.Name = "panelFarmers";
            this.panelFarmers.Size = new System.Drawing.Size(227, 94);
            this.panelFarmers.TabIndex = 2;
            // 
            // lblFarmerTitle1
            // 
            this.lblFarmerTitle1.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblFarmerTitle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFarmerTitle1.ForeColor = System.Drawing.Color.White;
            this.lblFarmerTitle1.Location = new System.Drawing.Point(0, 0);
            this.lblFarmerTitle1.Name = "lblFarmerTitle1";
            this.lblFarmerTitle1.Size = new System.Drawing.Size(227, 27);
            this.lblFarmerTitle1.TabIndex = 1;
            this.lblFarmerTitle1.Text = "TOTAL PURCHASES STOCK";
            this.lblFarmerTitle1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelGovernment
            // 
            this.panelGovernment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.panelGovernment.Controls.Add(this.lblTotalPendingRequests);
            this.panelGovernment.Controls.Add(this.lblGovernmentTitle);
            this.panelGovernment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGovernment.Location = new System.Drawing.Point(723, 3);
            this.panelGovernment.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.panelGovernment.Name = "panelGovernment";
            this.panelGovernment.Size = new System.Drawing.Size(227, 94);
            this.panelGovernment.TabIndex = 3;
            // 
            // lblGovernmentTitle
            // 
            this.lblGovernmentTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblGovernmentTitle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGovernmentTitle.ForeColor = System.Drawing.Color.White;
            this.lblGovernmentTitle.Location = new System.Drawing.Point(0, 0);
            this.lblGovernmentTitle.Name = "lblGovernmentTitle";
            this.lblGovernmentTitle.Size = new System.Drawing.Size(227, 27);
            this.lblGovernmentTitle.TabIndex = 1;
            this.lblGovernmentTitle.Text = " TOTAL PADDY (PENDING) REQUESTS";
            this.lblGovernmentTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDashboardTitle
            // 
            this.lblDashboardTitle.AutoSize = true;
            this.lblDashboardTitle.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDashboardTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblDashboardTitle.Location = new System.Drawing.Point(15, 15);
            this.lblDashboardTitle.Name = "lblDashboardTitle";
            this.lblDashboardTitle.Size = new System.Drawing.Size(247, 30);
            this.lblDashboardTitle.TabIndex = 1;
            this.lblDashboardTitle.Text = "Government Dashboard";
            // 
            // tableLayoutPanelCharts
            // 
            this.tableLayoutPanelCharts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelCharts.ColumnCount = 2;
            this.tableLayoutPanelCharts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelCharts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelCharts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tableLayoutPanelCharts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tableLayoutPanelCharts.Controls.Add(this.mychartStock, 1, 1);
            this.tableLayoutPanelCharts.Controls.Add(this.mychartSales, 0, 1);
            this.tableLayoutPanelCharts.Controls.Add(this.chartSales, 0, 0);
            this.tableLayoutPanelCharts.Controls.Add(this.chartStock, 1, 0);
            this.tableLayoutPanelCharts.Location = new System.Drawing.Point(20, 177);
            this.tableLayoutPanelCharts.Name = "tableLayoutPanelCharts";
            this.tableLayoutPanelCharts.RowCount = 2;
            this.tableLayoutPanelCharts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelCharts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 216F));
            this.tableLayoutPanelCharts.Size = new System.Drawing.Size(960, 439);
            this.tableLayoutPanelCharts.TabIndex = 2;
            // 
            // mychartStock
            // 
            this.mychartStock.BackColor = System.Drawing.Color.WhiteSmoke;
            this.mychartStock.BorderlineColor = System.Drawing.Color.Silver;
            this.mychartStock.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.BackColor = System.Drawing.Color.White;
            chartArea1.Name = "ChartArea1";
            this.mychartStock.ChartAreas.Add(chartArea1);
            this.mychartStock.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            this.mychartStock.Legends.Add(legend1);
            this.mychartStock.Location = new System.Drawing.Point(490, 233);
            this.mychartStock.Margin = new System.Windows.Forms.Padding(10);
            this.mychartStock.Name = "mychartStock";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.IsValueShownAsLabel = true;
            series1.Legend = "Legend1";
            series1.Name = "Stock";
            this.mychartStock.Series.Add(series1);
            this.mychartStock.Size = new System.Drawing.Size(460, 196);
            this.mychartStock.TabIndex = 3;
            this.mychartStock.Text = "My Stock Chart";
            // 
            // mychartSales
            // 
            this.mychartSales.BackColor = System.Drawing.Color.WhiteSmoke;
            this.mychartSales.BorderlineColor = System.Drawing.Color.Silver;
            this.mychartSales.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea2.AxisX.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea2.AxisX.LineColor = System.Drawing.Color.Silver;
            chartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea2.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea2.AxisX.TitleFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea2.AxisY.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea2.AxisY.LineColor = System.Drawing.Color.Silver;
            chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea2.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea2.AxisY.TitleFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea2.BackColor = System.Drawing.Color.White;
            chartArea2.Name = "ChartArea1";
            this.mychartSales.ChartAreas.Add(chartArea2);
            this.mychartSales.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Enabled = false;
            legend2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend2.IsTextAutoFit = false;
            legend2.Name = "Legend1";
            this.mychartSales.Legends.Add(legend2);
            this.mychartSales.Location = new System.Drawing.Point(10, 233);
            this.mychartSales.Margin = new System.Windows.Forms.Padding(10);
            this.mychartSales.Name = "mychartSales";
            this.mychartSales.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series2.ChartArea = "ChartArea1";
            series2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series2.IsValueShownAsLabel = true;
            series2.Legend = "Legend1";
            series2.Name = "Sales";
            this.mychartSales.Series.Add(series2);
            this.mychartSales.Size = new System.Drawing.Size(460, 196);
            this.mychartSales.TabIndex = 2;
            this.mychartSales.Text = "My Sales Chart";
//            this.mychartSales.Click += new System.EventHandler(this.chart1_Click);
            // 
            // chartSales
            // 
            this.chartSales.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chartSales.BorderlineColor = System.Drawing.Color.Silver;
            this.chartSales.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea3.AxisX.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea3.AxisX.LineColor = System.Drawing.Color.Silver;
            chartArea3.AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea3.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea3.AxisX.TitleFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea3.AxisY.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea3.AxisY.LineColor = System.Drawing.Color.Silver;
            chartArea3.AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea3.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea3.AxisY.TitleFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea3.BackColor = System.Drawing.Color.White;
            chartArea3.Name = "ChartArea1";
            this.chartSales.ChartAreas.Add(chartArea3);
            this.chartSales.Dock = System.Windows.Forms.DockStyle.Fill;
            legend3.Enabled = false;
            legend3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend3.IsTextAutoFit = false;
            legend3.Name = "Legend1";
            this.chartSales.Legends.Add(legend3);
            this.chartSales.Location = new System.Drawing.Point(10, 10);
            this.chartSales.Margin = new System.Windows.Forms.Padding(10);
            this.chartSales.Name = "chartSales";
            this.chartSales.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series3.ChartArea = "ChartArea1";
            series3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series3.IsValueShownAsLabel = true;
            series3.Legend = "Legend1";
            series3.Name = "Sales";
            this.chartSales.Series.Add(series3);
            this.chartSales.Size = new System.Drawing.Size(460, 203);
            this.chartSales.TabIndex = 0;
            this.chartSales.Text = "Sales Chart";
            // 
            // chartStock
            // 
            this.chartStock.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chartStock.BorderlineColor = System.Drawing.Color.Silver;
            this.chartStock.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea4.BackColor = System.Drawing.Color.White;
            chartArea4.Name = "ChartArea1";
            this.chartStock.ChartAreas.Add(chartArea4);
            this.chartStock.Dock = System.Windows.Forms.DockStyle.Fill;
            legend4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend4.IsTextAutoFit = false;
            legend4.Name = "Legend1";
            this.chartStock.Legends.Add(legend4);
            this.chartStock.Location = new System.Drawing.Point(490, 10);
            this.chartStock.Margin = new System.Windows.Forms.Padding(10);
            this.chartStock.Name = "chartStock";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series4.IsValueShownAsLabel = true;
            series4.Legend = "Legend1";
            series4.Name = "Stock";
            this.chartStock.Series.Add(series4);
            this.chartStock.Size = new System.Drawing.Size(460, 203);
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
            // lbltotalPurchaseQuantity
            // 
            this.lbltotalPurchaseQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbltotalPurchaseQuantity.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltotalPurchaseQuantity.ForeColor = System.Drawing.Color.White;
            this.lbltotalPurchaseQuantity.Location = new System.Drawing.Point(0, 27);
            this.lbltotalPurchaseQuantity.Name = "lbltotalPurchaseQuantity";
            this.lbltotalPurchaseQuantity.Size = new System.Drawing.Size(227, 67);
            this.lbltotalPurchaseQuantity.TabIndex = 3;
            this.lbltotalPurchaseQuantity.Text = "0";
            this.lbltotalPurchaseQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalPendingRequests
            // 
            this.lblTotalPendingRequests.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalPendingRequests.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPendingRequests.ForeColor = System.Drawing.Color.White;
            this.lblTotalPendingRequests.Location = new System.Drawing.Point(0, 27);
            this.lblTotalPendingRequests.Name = "lblTotalPendingRequests";
            this.lblTotalPendingRequests.Size = new System.Drawing.Size(227, 67);
            this.lblTotalPendingRequests.TabIndex = 4;
            this.lblTotalPendingRequests.Text = "0";
            this.lblTotalPendingRequests.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GovernmentHome
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
            this.Name = "GovernmentHome";
            this.Size = new System.Drawing.Size(1000, 630);
            this.panelStats.ResumeLayout(false);
            this.panelTotalUsers.ResumeLayout(false);
            this.panelAdmins.ResumeLayout(false);
            this.panelFarmers.ResumeLayout(false);
            this.panelGovernment.ResumeLayout(false);
            this.tableLayoutPanelCharts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mychartStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mychartSales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartStock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelStats;
        private System.Windows.Forms.Panel panelFarmers;
        private System.Windows.Forms.Label lblFarmerTitle1;
        private System.Windows.Forms.Panel panelGovernment;
        private System.Windows.Forms.Label lblGovernmentTitle;
        private System.Windows.Forms.Label lblDashboardTitle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelCharts;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSales;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartStock;
        private System.Windows.Forms.Label lblFarmerCount;
        private System.Windows.Forms.Label lblPrivateBuyerCount;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel panelTotalUsers;
        private System.Windows.Forms.Panel panelAdmins;
        private System.Windows.Forms.Label lblPriveteBuyersTitle;
        private System.Windows.Forms.Label lblFarmerTitle;
        private System.Windows.Forms.DataVisualization.Charting.Chart mychartStock;
        private System.Windows.Forms.DataVisualization.Charting.Chart mychartSales;
        private System.Windows.Forms.Label lbltotalPurchaseQuantity;
        private System.Windows.Forms.Label lblTotalPendingRequests;
    }
}
