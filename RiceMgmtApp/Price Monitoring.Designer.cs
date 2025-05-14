using System.Windows.Forms;

namespace RiceMgmtApp
{
    partial class Price_Monitoring
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private DataGridView dataGridViewPrices;
        private ComboBox cmbCropType;
        private NumericUpDown numThreshold;
        private Button btnRefresh;
        private Button btnSetPrice;
        private Panel pnlAlerts;


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

            if (refreshTimer != null)
            {
                refreshTimer.Stop();
                refreshTimer.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        //private void InitializeComponent()
        //{
        //    this.SuspendLayout();
        //    // 
        //    // Price_Monitoring
        //    // 
        //    this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        //    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        //    this.Name = "Price_Monitoring";
        //    this.Size = new System.Drawing.Size(831, 458);
        //    this.Load += new System.EventHandler(this.Price_Monitoring_Load);
        //    this.ResumeLayout(false);

        //}
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dgvPriceMonitoring = new System.Windows.Forms.DataGridView();
            this.lblTitle = new System.Windows.Forms.Label();
            this.grpPriceDetails = new System.Windows.Forms.GroupBox();
            this.comCropType = new System.Windows.Forms.ComboBox();
            this.lblCropType = new System.Windows.Forms.Label();
            this.lblAvgPrice = new System.Windows.Forms.Label();
            this.txtAvgPrice = new System.Windows.Forms.TextBox();
            this.lblGovtPrice = new System.Windows.Forms.Label();
            this.txtGovtPrice = new System.Windows.Forms.TextBox();
            this.lblPriceDeviation = new System.Windows.Forms.Label();
            this.txtPriceDeviation = new System.Windows.Forms.TextBox();
            this.btnAddUpdate = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblPriceAlert = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.refreshTimer = new System.Windows.Forms.Timer(this.components);
            this.panelAlerts = new System.Windows.Forms.FlowLayoutPanel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.lblLastUpdated = new System.Windows.Forms.Label();
            this.filterPanel = new System.Windows.Forms.Panel();
            this.lblFilter = new System.Windows.Forms.Label();
            this.comFilterCrop = new System.Windows.Forms.ComboBox();
            this.chkShowAlerts = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPriceMonitoring)).BeginInit();
            this.grpPriceDetails.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.filterPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvPriceMonitoring
            // 
            this.dgvPriceMonitoring.AllowUserToAddRows = false;
            this.dgvPriceMonitoring.AllowUserToDeleteRows = false;
            this.dgvPriceMonitoring.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPriceMonitoring.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPriceMonitoring.BackgroundColor = System.Drawing.Color.White;
            this.dgvPriceMonitoring.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPriceMonitoring.ColumnHeadersHeight = 35;
            this.dgvPriceMonitoring.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvPriceMonitoring.Location = new System.Drawing.Point(20, 135);
            this.dgvPriceMonitoring.MultiSelect = false;
            this.dgvPriceMonitoring.Name = "dgvPriceMonitoring";
            this.dgvPriceMonitoring.ReadOnly = true;
            this.dgvPriceMonitoring.RowHeadersVisible = false;
            this.dgvPriceMonitoring.RowTemplate.Height = 28;
            this.dgvPriceMonitoring.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPriceMonitoring.Size = new System.Drawing.Size(680, 220);
            this.dgvPriceMonitoring.TabIndex = 1;
            this.dgvPriceMonitoring.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvPriceMonitoring_CellClick);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(15, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(259, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Paddy Price Monitoring";
            // 
            // grpPriceDetails
            // 
            this.grpPriceDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpPriceDetails.Controls.Add(this.comCropType);
            this.grpPriceDetails.Controls.Add(this.lblCropType);
            this.grpPriceDetails.Controls.Add(this.lblAvgPrice);
            this.grpPriceDetails.Controls.Add(this.txtAvgPrice);
            this.grpPriceDetails.Controls.Add(this.lblGovtPrice);
            this.grpPriceDetails.Controls.Add(this.txtGovtPrice);
            this.grpPriceDetails.Controls.Add(this.lblPriceDeviation);
            this.grpPriceDetails.Controls.Add(this.txtPriceDeviation);
            this.grpPriceDetails.Controls.Add(this.btnAddUpdate);
            this.grpPriceDetails.Controls.Add(this.btnClear);
            this.grpPriceDetails.Controls.Add(this.btnDelete);
            this.grpPriceDetails.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpPriceDetails.Location = new System.Drawing.Point(20, 380);
            this.grpPriceDetails.Name = "grpPriceDetails";
            this.grpPriceDetails.Size = new System.Drawing.Size(680, 210);
            this.grpPriceDetails.TabIndex = 3;
            this.grpPriceDetails.TabStop = false;
            this.grpPriceDetails.Text = "Price Details";
            // 
            // comCropType
            // 
            this.comCropType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comCropType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comCropType.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comCropType.FormattingEnabled = true;
            this.comCropType.Location = new System.Drawing.Point(150, 33);
            this.comCropType.Name = "comCropType";
            this.comCropType.Size = new System.Drawing.Size(200, 23);
            this.comCropType.TabIndex = 11;
            // 
            // lblCropType
            // 
            this.lblCropType.AutoSize = true;
            this.lblCropType.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCropType.Location = new System.Drawing.Point(20, 35);
            this.lblCropType.Name = "lblCropType";
            this.lblCropType.Size = new System.Drawing.Size(63, 15);
            this.lblCropType.TabIndex = 0;
            this.lblCropType.Text = "Crop Type:";
            // 
            // lblAvgPrice
            // 
            this.lblAvgPrice.AutoSize = true;
            this.lblAvgPrice.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvgPrice.Location = new System.Drawing.Point(20, 75);
            this.lblAvgPrice.Name = "lblAvgPrice";
            this.lblAvgPrice.Size = new System.Drawing.Size(82, 15);
            this.lblAvgPrice.TabIndex = 2;
            this.lblAvgPrice.Text = "Average Price:";
            // 
            // txtAvgPrice
            // 
            this.txtAvgPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAvgPrice.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAvgPrice.Location = new System.Drawing.Point(150, 73);
            this.txtAvgPrice.Name = "txtAvgPrice";
            this.txtAvgPrice.Size = new System.Drawing.Size(200, 23);
            this.txtAvgPrice.TabIndex = 3;
            // 
            // lblGovtPrice
            // 
            this.lblGovtPrice.AutoSize = true;
            this.lblGovtPrice.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGovtPrice.Location = new System.Drawing.Point(20, 115);
            this.lblGovtPrice.Name = "lblGovtPrice";
            this.lblGovtPrice.Size = new System.Drawing.Size(105, 15);
            this.lblGovtPrice.TabIndex = 4;
            this.lblGovtPrice.Text = "Government Price:";
            // 
            // txtGovtPrice
            // 
            this.txtGovtPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGovtPrice.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGovtPrice.Location = new System.Drawing.Point(150, 113);
            this.txtGovtPrice.Name = "txtGovtPrice";
            this.txtGovtPrice.Size = new System.Drawing.Size(200, 23);
            this.txtGovtPrice.TabIndex = 5;
            // 
            // lblPriceDeviation
            // 
            this.lblPriceDeviation.AutoSize = true;
            this.lblPriceDeviation.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPriceDeviation.Location = new System.Drawing.Point(20, 155);
            this.lblPriceDeviation.Name = "lblPriceDeviation";
            this.lblPriceDeviation.Size = new System.Drawing.Size(89, 15);
            this.lblPriceDeviation.TabIndex = 6;
            this.lblPriceDeviation.Text = "Price Deviation:";
            // 
            // txtPriceDeviation
            // 
            this.txtPriceDeviation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPriceDeviation.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPriceDeviation.Location = new System.Drawing.Point(150, 153);
            this.txtPriceDeviation.Name = "txtPriceDeviation";
            this.txtPriceDeviation.ReadOnly = true;
            this.txtPriceDeviation.Size = new System.Drawing.Size(200, 23);
            this.txtPriceDeviation.TabIndex = 7;
            // 
            // btnAddUpdate
            // 
            this.btnAddUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnAddUpdate.FlatAppearance.BorderSize = 0;
            this.btnAddUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddUpdate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddUpdate.ForeColor = System.Drawing.Color.White;
            this.btnAddUpdate.Location = new System.Drawing.Point(400, 70);
            this.btnAddUpdate.Name = "btnAddUpdate";
            this.btnAddUpdate.Size = new System.Drawing.Size(120, 30);
            this.btnAddUpdate.TabIndex = 8;
            this.btnAddUpdate.Text = "Add / Update";
            this.btnAddUpdate.UseVisualStyleBackColor = false;
            this.btnAddUpdate.Click += new System.EventHandler(this.BtnAddUpdate_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnClear.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.Black;
            this.btnClear.Location = new System.Drawing.Point(400, 110);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(120, 30);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(17)))), ((int)(((byte)(35)))));
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(400, 150);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(120, 30);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(20, 595);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 15);
            this.lblStatus.TabIndex = 12;
            // 
            // lblPriceAlert
            // 
            this.lblPriceAlert.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPriceAlert.AutoSize = true;
            this.lblPriceAlert.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPriceAlert.ForeColor = System.Drawing.Color.Red;
            this.lblPriceAlert.Location = new System.Drawing.Point(20, 360);
            this.lblPriceAlert.Name = "lblPriceAlert";
            this.lblPriceAlert.Size = new System.Drawing.Size(0, 15);
            this.lblPriceAlert.TabIndex = 2;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(580, 97);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(120, 30);
            this.btnRefresh.TabIndex = 13;
            this.btnRefresh.Text = "Refresh Data";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // panelHeader
            // 
            this.panelHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(720, 55);
            this.panelHeader.TabIndex = 14;
            // 
            // refreshTimer
            // 
            this.refreshTimer.Interval = 300000;
            // 
            // panelAlerts
            // 
            this.panelAlerts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelAlerts.AutoScroll = true;
            this.panelAlerts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.panelAlerts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelAlerts.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.panelAlerts.Location = new System.Drawing.Point(20, 360);
            this.panelAlerts.Name = "panelAlerts";
            this.panelAlerts.Size = new System.Drawing.Size(680, 0);
            this.panelAlerts.TabIndex = 15;
            this.panelAlerts.WrapContents = false;
            // 
            // lblLastUpdated
            // 
            this.lblLastUpdated.AutoSize = true;
            this.lblLastUpdated.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastUpdated.Location = new System.Drawing.Point(22, 115);
            this.lblLastUpdated.Name = "lblLastUpdated";
            this.lblLastUpdated.Size = new System.Drawing.Size(77, 13);
            this.lblLastUpdated.TabIndex = 16;
            this.lblLastUpdated.Text = "Last updated: -";
            // 
            // filterPanel
            // 
            this.filterPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.filterPanel.Controls.Add(this.lblFilter);
            this.filterPanel.Controls.Add(this.comFilterCrop);
            this.filterPanel.Controls.Add(this.chkShowAlerts);
            this.filterPanel.Location = new System.Drawing.Point(20, 65);
            this.filterPanel.Name = "filterPanel";
            this.filterPanel.Size = new System.Drawing.Size(680, 30);
            this.filterPanel.TabIndex = 17;
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilter.Location = new System.Drawing.Point(10, 7);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(52, 15);
            this.lblFilter.TabIndex = 0;
            this.lblFilter.Text = "Filter by:";
            // 
            // comFilterCrop
            // 
            this.comFilterCrop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comFilterCrop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comFilterCrop.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comFilterCrop.FormattingEnabled = true;
            this.comFilterCrop.Location = new System.Drawing.Point(70, 4);
            this.comFilterCrop.Name = "comFilterCrop";
            this.comFilterCrop.Size = new System.Drawing.Size(150, 21);
            this.comFilterCrop.TabIndex = 1;
//            this.comFilterCrop.SelectedIndexChanged += new System.EventHandler(this.comFilterCrop_SelectedIndexChanged);
            // 
            // chkShowAlerts
            // 
            this.chkShowAlerts.AutoSize = true;
            this.chkShowAlerts.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkShowAlerts.Location = new System.Drawing.Point(240, 6);
            this.chkShowAlerts.Name = "chkShowAlerts";
            this.chkShowAlerts.Size = new System.Drawing.Size(114, 17);
            this.chkShowAlerts.TabIndex = 2;
            this.chkShowAlerts.Text = "Show price alerts";
            this.chkShowAlerts.UseVisualStyleBackColor = true;
            // 
            // Price_Monitoring
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.filterPanel);
            this.Controls.Add(this.lblLastUpdated);
            this.Controls.Add(this.panelAlerts);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.grpPriceDetails);
            this.Controls.Add(this.lblPriceAlert);
            this.Controls.Add(this.dgvPriceMonitoring);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Price_Monitoring";
            this.Size = new System.Drawing.Size(720, 620);
            this.Load += new System.EventHandler(this.Price_Monitoring_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPriceMonitoring)).EndInit();
            this.grpPriceDetails.ResumeLayout(false);
            this.grpPriceDetails.PerformLayout();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.filterPanel.ResumeLayout(false);
            this.filterPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        


        #endregion
        private System.Windows.Forms.DataGridView dgvPriceMonitoring;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpPriceDetails;
        private System.Windows.Forms.Label lblCropType;
        private System.Windows.Forms.Label lblAvgPrice;
        private System.Windows.Forms.TextBox txtAvgPrice;
        private System.Windows.Forms.Label lblGovtPrice;
        private System.Windows.Forms.TextBox txtGovtPrice;
        private System.Windows.Forms.Label lblPriceDeviation;
        private System.Windows.Forms.TextBox txtPriceDeviation;
        private System.Windows.Forms.Button btnAddUpdate;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblPriceAlert;
        private System.Windows.Forms.ComboBox comCropType;
        //private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Timer refreshTimer;
        private System.Windows.Forms.FlowLayoutPanel panelAlerts;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label lblLastUpdated;
        private System.Windows.Forms.Panel filterPanel;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.ComboBox comFilterCrop;
        private System.Windows.Forms.CheckBox chkShowAlerts;

    }
}
