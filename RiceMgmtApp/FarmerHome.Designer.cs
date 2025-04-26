namespace RiceMgmtApp
{
    partial class FarmerHome
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
            this.lblDashboardTitle = new System.Windows.Forms.Label();
            this.tableLayoutPanelCharts = new System.Windows.Forms.TableLayoutPanel();
            this.chartSales = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartStock = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.panelFields = new System.Windows.Forms.Panel();
            this.lblFieldCount = new System.Windows.Forms.Label();
            this.lblFieldsTitle = new System.Windows.Forms.Label();
            this.panelTotalField = new System.Windows.Forms.Panel();
            this.lblTotalFieldSize = new System.Windows.Forms.Label();
            this.lblTotalFieldTitle = new System.Windows.Forms.Label();
            this.panelStats = new System.Windows.Forms.TableLayoutPanel();
            this.panelTotalStock = new System.Windows.Forms.Panel();
            this.lblTotalStock = new System.Windows.Forms.Label();
            this.lblTotalStockTitle = new System.Windows.Forms.Label();
            this.panelSales = new System.Windows.Forms.Panel();
            this.lblTotalSales = new System.Windows.Forms.Label();
            this.lblSalesTitle = new System.Windows.Forms.Label();
            this.tableLayoutPanelCharts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartStock)).BeginInit();
            this.panelFields.SuspendLayout();
            this.panelTotalField.SuspendLayout();
            this.panelStats.SuspendLayout();
            this.panelTotalStock.SuspendLayout();
            this.panelSales.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDashboardTitle
            // 
            this.lblDashboardTitle.AutoSize = true;
            this.lblDashboardTitle.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDashboardTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblDashboardTitle.Location = new System.Drawing.Point(15, 15);
            this.lblDashboardTitle.Name = "lblDashboardTitle";
            this.lblDashboardTitle.Size = new System.Drawing.Size(229, 30);
            this.lblDashboardTitle.TabIndex = 1;
            this.lblDashboardTitle.Text = "My Farmer Dashboard";
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
            // panelFields
            // 
            this.panelFields.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.panelFields.Controls.Add(this.lblFieldCount);
            this.panelFields.Controls.Add(this.lblFieldsTitle);
            this.panelFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFields.Location = new System.Drawing.Point(493, 3);
            this.panelFields.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.panelFields.Name = "panelFields";
            this.panelFields.Size = new System.Drawing.Size(211, 94);
            this.panelFields.TabIndex = 2;
            // 
            // lblFieldCount
            // 
            this.lblFieldCount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFieldCount.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFieldCount.ForeColor = System.Drawing.Color.White;
            this.lblFieldCount.Location = new System.Drawing.Point(0, 27);
            this.lblFieldCount.Name = "lblFieldCount";
            this.lblFieldCount.Size = new System.Drawing.Size(211, 67);
            this.lblFieldCount.TabIndex = 2;
            this.lblFieldCount.Text = "0";
            this.lblFieldCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFieldsTitle
            // 
            this.lblFieldsTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblFieldsTitle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFieldsTitle.ForeColor = System.Drawing.Color.White;
            this.lblFieldsTitle.Location = new System.Drawing.Point(0, 0);
            this.lblFieldsTitle.Name = "lblFieldsTitle";
            this.lblFieldsTitle.Size = new System.Drawing.Size(211, 27);
            this.lblFieldsTitle.TabIndex = 1;
            this.lblFieldsTitle.Text = "FIELD COUNT";
            this.lblFieldsTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelTotalField
            // 
            this.panelTotalField.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.panelTotalField.Controls.Add(this.lblTotalFieldSize);
            this.panelTotalField.Controls.Add(this.lblTotalFieldTitle);
            this.panelTotalField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTotalField.Location = new System.Drawing.Point(3, 3);
            this.panelTotalField.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.panelTotalField.Name = "panelTotalField";
            this.panelTotalField.Size = new System.Drawing.Size(217, 94);
            this.panelTotalField.TabIndex = 0;
            // 
            // lblTotalFieldSize
            // 
            this.lblTotalFieldSize.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalFieldSize.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalFieldSize.ForeColor = System.Drawing.Color.White;
            this.lblTotalFieldSize.Location = new System.Drawing.Point(0, 27);
            this.lblTotalFieldSize.Name = "lblTotalFieldSize";
            this.lblTotalFieldSize.Size = new System.Drawing.Size(217, 67);
            this.lblTotalFieldSize.TabIndex = 1;
            this.lblTotalFieldSize.Text = "0";
            this.lblTotalFieldSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalFieldTitle
            // 
            this.lblTotalFieldTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTotalFieldTitle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalFieldTitle.ForeColor = System.Drawing.Color.White;
            this.lblTotalFieldTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTotalFieldTitle.Name = "lblTotalFieldTitle";
            this.lblTotalFieldTitle.Size = new System.Drawing.Size(217, 27);
            this.lblTotalFieldTitle.TabIndex = 0;
            this.lblTotalFieldTitle.Text = "TOTAL FIELD SIZE";
            this.lblTotalFieldTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelStats
            // 
            this.panelStats.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelStats.ColumnCount = 5;
            this.panelStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.95833F));
            this.panelStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.08333F));
            this.panelStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.33333F));
            this.panelStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.8333333F));
            this.panelStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.6875F));
            this.panelStats.Controls.Add(this.panelTotalField, 0, 0);
            this.panelStats.Controls.Add(this.panelTotalStock, 1, 0);
            this.panelStats.Controls.Add(this.panelFields, 2, 0);
            this.panelStats.Controls.Add(this.panelSales, 4, 0);
            this.panelStats.Location = new System.Drawing.Point(20, 60);
            this.panelStats.Name = "panelStats";
            this.panelStats.RowCount = 1;
            this.panelStats.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelStats.Size = new System.Drawing.Size(960, 100);
            this.panelStats.TabIndex = 0;
            // 
            // panelTotalStock
            // 
            this.panelTotalStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.panelTotalStock.Controls.Add(this.lblTotalStock);
            this.panelTotalStock.Controls.Add(this.lblTotalStockTitle);
            this.panelTotalStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTotalStock.Location = new System.Drawing.Point(233, 3);
            this.panelTotalStock.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.panelTotalStock.Name = "panelTotalStock";
            this.panelTotalStock.Size = new System.Drawing.Size(247, 94);
            this.panelTotalStock.TabIndex = 1;
            // 
            // lblTotalStock
            // 
            this.lblTotalStock.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalStock.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalStock.ForeColor = System.Drawing.Color.White;
            this.lblTotalStock.Location = new System.Drawing.Point(24, 27);
            this.lblTotalStock.Name = "lblTotalStock";
            this.lblTotalStock.Size = new System.Drawing.Size(179, 67);
            this.lblTotalStock.TabIndex = 2;
            this.lblTotalStock.Text = "0";
            this.lblTotalStock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalStockTitle
            // 
            this.lblTotalStockTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTotalStockTitle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalStockTitle.ForeColor = System.Drawing.Color.White;
            this.lblTotalStockTitle.Location = new System.Drawing.Point(24, 0);
            this.lblTotalStockTitle.Name = "lblTotalStockTitle";
            this.lblTotalStockTitle.Size = new System.Drawing.Size(179, 27);
            this.lblTotalStockTitle.TabIndex = 1;
            this.lblTotalStockTitle.Text = "TOTAL STOCK";
            this.lblTotalStockTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelSales
            // 
            this.panelSales.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.panelSales.Controls.Add(this.lblTotalSales);
            this.panelSales.Controls.Add(this.lblSalesTitle);
            this.panelSales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSales.Location = new System.Drawing.Point(725, 3);
            this.panelSales.Name = "panelSales";
            this.panelSales.Size = new System.Drawing.Size(232, 94);
            this.panelSales.TabIndex = 4;
            // 
            // lblTotalSales
            // 
            this.lblTotalSales.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalSales.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalSales.ForeColor = System.Drawing.Color.White;
            this.lblTotalSales.Location = new System.Drawing.Point(25, 27);
            this.lblTotalSales.Name = "lblTotalSales";
            this.lblTotalSales.Size = new System.Drawing.Size(186, 67);
            this.lblTotalSales.TabIndex = 2;
            this.lblTotalSales.Text = "0";
            this.lblTotalSales.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSalesTitle
            // 
            this.lblSalesTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSalesTitle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalesTitle.ForeColor = System.Drawing.Color.White;
            this.lblSalesTitle.Location = new System.Drawing.Point(25, 0);
            this.lblSalesTitle.Name = "lblSalesTitle";
            this.lblSalesTitle.Size = new System.Drawing.Size(186, 27);
            this.lblSalesTitle.TabIndex = 1;
            this.lblSalesTitle.Text = "TOTAL SALES";
            this.lblSalesTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FarmerHome
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
            this.Name = "FarmerHome";
            this.Size = new System.Drawing.Size(1000, 568);
            this.tableLayoutPanelCharts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartSales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartStock)).EndInit();
            this.panelFields.ResumeLayout(false);
            this.panelTotalField.ResumeLayout(false);
            this.panelStats.ResumeLayout(false);
            this.panelTotalStock.ResumeLayout(false);
            this.panelSales.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblDashboardTitle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelCharts;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSales;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartStock;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel panelFields;
        private System.Windows.Forms.Label lblFieldCount;
        private System.Windows.Forms.Label lblFieldsTitle;
        private System.Windows.Forms.Panel panelTotalField;
        private System.Windows.Forms.Label lblTotalFieldSize;
        private System.Windows.Forms.Label lblTotalFieldTitle;
        private System.Windows.Forms.TableLayoutPanel panelStats;
        private System.Windows.Forms.Panel panelTotalStock;
        private System.Windows.Forms.Label lblTotalStock;
        private System.Windows.Forms.Label lblTotalStockTitle;
        private System.Windows.Forms.Panel panelSales;
        private System.Windows.Forms.Label lblTotalSales;
        private System.Windows.Forms.Label lblSalesTitle;


    }
}
