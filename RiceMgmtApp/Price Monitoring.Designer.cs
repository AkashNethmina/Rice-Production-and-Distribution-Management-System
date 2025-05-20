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

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.panelHeader = new System.Windows.Forms.Panel();
            this.refreshTimer = new System.Windows.Forms.Timer(this.components);
            this.panelAlerts = new System.Windows.Forms.FlowLayoutPanel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.lblLastUpdated = new System.Windows.Forms.Label();
            this.filterPanel = new System.Windows.Forms.Panel();
            this.lblFilter = new System.Windows.Forms.Label();
            this.comFilterCrop = new System.Windows.Forms.ComboBox();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelContent = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPriceMonitoring)).BeginInit();
            this.grpPriceDetails.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.filterPanel.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelContent.SuspendLayout();
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
            this.dgvPriceMonitoring.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvPriceMonitoring.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(194)))), ((int)(((byte)(88)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(194)))), ((int)(((byte)(88)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPriceMonitoring.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPriceMonitoring.ColumnHeadersHeight = 45;
            this.dgvPriceMonitoring.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(8, 5, 8, 5);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(245)))), ((int)(((byte)(233)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPriceMonitoring.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPriceMonitoring.EnableHeadersVisualStyles = false;
            this.dgvPriceMonitoring.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.dgvPriceMonitoring.Location = new System.Drawing.Point(0, 75);
            this.dgvPriceMonitoring.MultiSelect = false;
            this.dgvPriceMonitoring.Name = "dgvPriceMonitoring";
            this.dgvPriceMonitoring.ReadOnly = true;
            this.dgvPriceMonitoring.RowHeadersVisible = false;
            this.dgvPriceMonitoring.RowTemplate.Height = 35;
            this.dgvPriceMonitoring.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPriceMonitoring.Size = new System.Drawing.Size(720, 202);
            this.dgvPriceMonitoring.TabIndex = 1;
            this.dgvPriceMonitoring.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvPriceMonitoring_CellClick);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Outfit", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(23, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(221, 34);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Price Monitoring";
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
            this.grpPriceDetails.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpPriceDetails.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.grpPriceDetails.Location = new System.Drawing.Point(0, 297);
            this.grpPriceDetails.Name = "grpPriceDetails";
            this.grpPriceDetails.Padding = new System.Windows.Forms.Padding(20, 15, 20, 20);
            this.grpPriceDetails.Size = new System.Drawing.Size(717, 220);
            this.grpPriceDetails.TabIndex = 3;
            this.grpPriceDetails.TabStop = false;
            this.grpPriceDetails.Text = "Price Management";
            // 
            // comCropType
            // 
            this.comCropType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comCropType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comCropType.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comCropType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.comCropType.FormattingEnabled = true;
            this.comCropType.Location = new System.Drawing.Point(180, 45);
            this.comCropType.Name = "comCropType";
            this.comCropType.Size = new System.Drawing.Size(220, 25);
            this.comCropType.TabIndex = 11;
            // 
            // lblCropType
            // 
            this.lblCropType.AutoSize = true;
            this.lblCropType.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCropType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblCropType.Location = new System.Drawing.Point(30, 48);
            this.lblCropType.Name = "lblCropType";
            this.lblCropType.Size = new System.Drawing.Size(74, 19);
            this.lblCropType.TabIndex = 0;
            this.lblCropType.Text = "Crop Type:";
            // 
            // lblAvgPrice
            // 
            this.lblAvgPrice.AutoSize = true;
            this.lblAvgPrice.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvgPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblAvgPrice.Location = new System.Drawing.Point(30, 88);
            this.lblAvgPrice.Name = "lblAvgPrice";
            this.lblAvgPrice.Size = new System.Drawing.Size(95, 19);
            this.lblAvgPrice.TabIndex = 2;
            this.lblAvgPrice.Text = "Average Price:";
            // 
            // txtAvgPrice
            // 
            this.txtAvgPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.txtAvgPrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAvgPrice.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAvgPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.txtAvgPrice.Location = new System.Drawing.Point(185, 88);
            this.txtAvgPrice.Name = "txtAvgPrice";
            this.txtAvgPrice.Size = new System.Drawing.Size(215, 18);
            this.txtAvgPrice.TabIndex = 3;
            // 
            // lblGovtPrice
            // 
            this.lblGovtPrice.AutoSize = true;
            this.lblGovtPrice.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGovtPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblGovtPrice.Location = new System.Drawing.Point(30, 128);
            this.lblGovtPrice.Name = "lblGovtPrice";
            this.lblGovtPrice.Size = new System.Drawing.Size(122, 19);
            this.lblGovtPrice.TabIndex = 4;
            this.lblGovtPrice.Text = "Government Price:";
            // 
            // txtGovtPrice
            // 
            this.txtGovtPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.txtGovtPrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtGovtPrice.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGovtPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.txtGovtPrice.Location = new System.Drawing.Point(185, 128);
            this.txtGovtPrice.Name = "txtGovtPrice";
            this.txtGovtPrice.Size = new System.Drawing.Size(215, 18);
            this.txtGovtPrice.TabIndex = 5;
            // 
            // lblPriceDeviation
            // 
            this.lblPriceDeviation.AutoSize = true;
            this.lblPriceDeviation.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPriceDeviation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblPriceDeviation.Location = new System.Drawing.Point(30, 168);
            this.lblPriceDeviation.Name = "lblPriceDeviation";
            this.lblPriceDeviation.Size = new System.Drawing.Size(103, 19);
            this.lblPriceDeviation.TabIndex = 6;
            this.lblPriceDeviation.Text = "Price Deviation:";
            // 
            // txtPriceDeviation
            // 
            this.txtPriceDeviation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.txtPriceDeviation.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPriceDeviation.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPriceDeviation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.txtPriceDeviation.Location = new System.Drawing.Point(185, 168);
            this.txtPriceDeviation.Name = "txtPriceDeviation";
            this.txtPriceDeviation.ReadOnly = true;
            this.txtPriceDeviation.Size = new System.Drawing.Size(215, 18);
            this.txtPriceDeviation.TabIndex = 7;
            // 
            // btnAddUpdate
            // 
            this.btnAddUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(194)))), ((int)(((byte)(88)))));
            this.btnAddUpdate.FlatAppearance.BorderSize = 0;
            this.btnAddUpdate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(174)))), ((int)(((byte)(79)))));
            this.btnAddUpdate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(154)))), ((int)(((byte)(70)))));
            this.btnAddUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddUpdate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddUpdate.ForeColor = System.Drawing.Color.White;
            this.btnAddUpdate.Location = new System.Drawing.Point(487, 80);
            this.btnAddUpdate.Name = "btnAddUpdate";
            this.btnAddUpdate.Size = new System.Drawing.Size(150, 35);
            this.btnAddUpdate.TabIndex = 8;
            this.btnAddUpdate.Text = "Add / Update";
            this.btnAddUpdate.UseVisualStyleBackColor = false;
            this.btnAddUpdate.Click += new System.EventHandler(this.BtnAddUpdate_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.btnClear.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(212)))), ((int)(((byte)(218)))));
            this.btnClear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.btnClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(243)))), ((int)(((byte)(245)))));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.btnClear.Location = new System.Drawing.Point(487, 125);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(150, 35);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(35)))), ((int)(((byte)(51)))));
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(32)))), ((int)(((byte)(45)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(487, 170);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(150, 35);
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
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblStatus.Location = new System.Drawing.Point(0, 532);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 15);
            this.lblStatus.TabIndex = 12;
            // 
            // lblPriceAlert
            // 
            this.lblPriceAlert.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPriceAlert.AutoSize = true;
            this.lblPriceAlert.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPriceAlert.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.lblPriceAlert.Location = new System.Drawing.Point(0, 277);
            this.lblPriceAlert.Name = "lblPriceAlert";
            this.lblPriceAlert.Size = new System.Drawing.Size(0, 19);
            this.lblPriceAlert.TabIndex = 2;
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(194)))), ((int)(((byte)(88)))));
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(720, 63);
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
            this.panelAlerts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(224)))));
            this.panelAlerts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelAlerts.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.panelAlerts.Location = new System.Drawing.Point(0, 277);
            this.panelAlerts.Name = "panelAlerts";
            this.panelAlerts.Padding = new System.Windows.Forms.Padding(10);
            this.panelAlerts.Size = new System.Drawing.Size(680, 0);
            this.panelAlerts.TabIndex = 15;
            this.panelAlerts.WrapContents = false;
            // 
            // lblLastUpdated
            // 
            this.lblLastUpdated.AutoSize = true;
            this.lblLastUpdated.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastUpdated.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblLastUpdated.Location = new System.Drawing.Point(3, 55);
            this.lblLastUpdated.Name = "lblLastUpdated";
            this.lblLastUpdated.Size = new System.Drawing.Size(88, 15);
            this.lblLastUpdated.TabIndex = 16;
            this.lblLastUpdated.Text = "Last updated: -";
            // 
            // filterPanel
            // 
            this.filterPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.filterPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.filterPanel.Controls.Add(this.lblFilter);
            this.filterPanel.Controls.Add(this.comFilterCrop);
            this.filterPanel.Location = new System.Drawing.Point(0, 5);
            this.filterPanel.Name = "filterPanel";
            this.filterPanel.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.filterPanel.Size = new System.Drawing.Size(720, 47);
            this.filterPanel.TabIndex = 17;
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblFilter.Location = new System.Drawing.Point(24, 14);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(61, 19);
            this.lblFilter.TabIndex = 0;
            this.lblFilter.Text = "Filter by:";
            // 
            // comFilterCrop
            // 
            this.comFilterCrop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comFilterCrop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comFilterCrop.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comFilterCrop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.comFilterCrop.FormattingEnabled = true;
            this.comFilterCrop.Location = new System.Drawing.Point(94, 13);
            this.comFilterCrop.Name = "comFilterCrop";
            this.comFilterCrop.Size = new System.Drawing.Size(200, 25);
            this.comFilterCrop.TabIndex = 1;
            this.comFilterCrop.SelectedIndexChanged += new System.EventHandler(this.comFilterCrop_SelectedIndexChanged);
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.panelMain.Controls.Add(this.panelContent);
            this.panelMain.Controls.Add(this.panelHeader);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(720, 620);
            this.panelMain.TabIndex = 18;
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.White;
            this.panelContent.Controls.Add(this.filterPanel);
            this.panelContent.Controls.Add(this.lblLastUpdated);
            this.panelContent.Controls.Add(this.panelAlerts);
            this.panelContent.Controls.Add(this.lblStatus);
            this.panelContent.Controls.Add(this.grpPriceDetails);
            this.panelContent.Controls.Add(this.lblPriceAlert);
            this.panelContent.Controls.Add(this.dgvPriceMonitoring);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 63);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(20);
            this.panelContent.Size = new System.Drawing.Size(720, 557);
            this.panelContent.TabIndex = 19;
            // 
            // Price_Monitoring
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.panelMain.ResumeLayout(false);
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            this.ResumeLayout(false);

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
       // private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Timer refreshTimer;
        private System.Windows.Forms.FlowLayoutPanel panelAlerts;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label lblLastUpdated;
        private System.Windows.Forms.Panel filterPanel;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.ComboBox comFilterCrop;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelContent;
    }
}