namespace RiceMgmtApp
{
    partial class AuthLogs
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.dgvAuthLogs = new System.Windows.Forms.DataGridView();
            this.pnlFilters = new System.Windows.Forms.Panel();
            this.pnlFilterContent = new System.Windows.Forms.Panel();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            this.pnlStatusFilter = new System.Windows.Forms.Panel();
            this.cmbFilterStatus = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.pnlToDate = new System.Windows.Forms.Panel();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.lblToDate = new System.Windows.Forms.Label();
            this.pnlFromDate = new System.Windows.Forms.Panel();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.pnlStats = new System.Windows.Forms.Panel();
            this.pnlStatCard3 = new System.Windows.Forms.Panel();
            this.lblFailedLogins = new System.Windows.Forms.Label();
            this.lblFailedTitle = new System.Windows.Forms.Label();
            this.pnlStatCard2 = new System.Windows.Forms.Panel();
            this.lblSuccessfulLogins = new System.Windows.Forms.Label();
            this.lblSuccessTitle = new System.Windows.Forms.Label();
            this.pnlStatCard1 = new System.Windows.Forms.Panel();
            this.lblTotalLogs = new System.Windows.Forms.Label();
            this.lblTotalTitle = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuthLogs)).BeginInit();
            this.pnlFilters.SuspendLayout();
            this.pnlFilterContent.SuspendLayout();
            this.pnlStatusFilter.SuspendLayout();
            this.pnlToDate.SuspendLayout();
            this.pnlFromDate.SuspendLayout();
            this.pnlStats.SuspendLayout();
            this.pnlStatCard3.SuspendLayout();
            this.pnlStatCard2.SuspendLayout();
            this.pnlStatCard1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.pnlMain.Controls.Add(this.pnlGrid);
            this.pnlMain.Controls.Add(this.pnlFilters);
            this.pnlMain.Controls.Add(this.pnlStats);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(20);
            this.pnlMain.Size = new System.Drawing.Size(925, 535);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlGrid
            // 
            this.pnlGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlGrid.BackColor = System.Drawing.Color.White;
            this.pnlGrid.Controls.Add(this.dgvAuthLogs);
            this.pnlGrid.Location = new System.Drawing.Point(20, 219);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Padding = new System.Windows.Forms.Padding(1);
            this.pnlGrid.Size = new System.Drawing.Size(885, 296);
            this.pnlGrid.TabIndex = 2;
            // 
            // dgvAuthLogs
            // 
            this.dgvAuthLogs.AllowUserToAddRows = false;
            this.dgvAuthLogs.AllowUserToDeleteRows = false;
            this.dgvAuthLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAuthLogs.BackgroundColor = System.Drawing.Color.White;
            this.dgvAuthLogs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAuthLogs.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvAuthLogs.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAuthLogs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvAuthLogs.ColumnHeadersHeight = 40;
            this.dgvAuthLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAuthLogs.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvAuthLogs.EnableHeadersVisualStyles = false;
            this.dgvAuthLogs.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.dgvAuthLogs.Location = new System.Drawing.Point(1, 1);
            this.dgvAuthLogs.Name = "dgvAuthLogs";
            this.dgvAuthLogs.ReadOnly = true;
            this.dgvAuthLogs.RowHeadersVisible = false;
            this.dgvAuthLogs.RowTemplate.Height = 35;
            this.dgvAuthLogs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAuthLogs.Size = new System.Drawing.Size(883, 294);
            this.dgvAuthLogs.TabIndex = 0;
            this.dgvAuthLogs.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DgvAuthLogs_CellFormatting);
            // 
            // pnlFilters
            // 
            this.pnlFilters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFilters.BackColor = System.Drawing.Color.White;
            this.pnlFilters.Controls.Add(this.pnlFilterContent);
            this.pnlFilters.Location = new System.Drawing.Point(20, 139);
            this.pnlFilters.MinimumSize = new System.Drawing.Size(600, 80);
            this.pnlFilters.Name = "pnlFilters";
            this.pnlFilters.Size = new System.Drawing.Size(885, 80);
            this.pnlFilters.TabIndex = 1;
            // 
            // pnlFilterContent
            // 
            this.pnlFilterContent.Controls.Add(this.btnExport);
            this.pnlFilterContent.Controls.Add(this.btnRefresh);
            this.pnlFilterContent.Controls.Add(this.btnFilter);
            this.pnlFilterContent.Controls.Add(this.pnlStatusFilter);
            this.pnlFilterContent.Controls.Add(this.pnlToDate);
            this.pnlFilterContent.Controls.Add(this.pnlFromDate);
            this.pnlFilterContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFilterContent.Location = new System.Drawing.Point(0, 0);
            this.pnlFilterContent.Name = "pnlFilterContent";
            this.pnlFilterContent.Padding = new System.Windows.Forms.Padding(20);
            this.pnlFilterContent.Size = new System.Drawing.Size(885, 80);
            this.pnlFilterContent.TabIndex = 0;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.btnExport.FlatAppearance.BorderSize = 0;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(760, 25);
            this.btnExport.MinimumSize = new System.Drawing.Size(80, 30);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(100, 35);
            this.btnExport.TabIndex = 5;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(650, 25);
            this.btnRefresh.MinimumSize = new System.Drawing.Size(80, 30);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 35);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(197)))), ((int)(((byte)(94)))));
            this.btnFilter.FlatAppearance.BorderSize = 0;
            this.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilter.ForeColor = System.Drawing.Color.White;
            this.btnFilter.Location = new System.Drawing.Point(540, 25);
            this.btnFilter.MinimumSize = new System.Drawing.Size(80, 30);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(100, 35);
            this.btnFilter.TabIndex = 3;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = false;
            this.btnFilter.Click += new System.EventHandler(this.BtnFilter_Click);
            // 
            // pnlStatusFilter
            // 
            this.pnlStatusFilter.Controls.Add(this.cmbFilterStatus);
            this.pnlStatusFilter.Controls.Add(this.lblStatus);
            this.pnlStatusFilter.Location = new System.Drawing.Point(420, 20);
            this.pnlStatusFilter.MinimumSize = new System.Drawing.Size(100, 45);
            this.pnlStatusFilter.Name = "pnlStatusFilter";
            this.pnlStatusFilter.Size = new System.Drawing.Size(110, 45);
            this.pnlStatusFilter.TabIndex = 2;
            // 
            // cmbFilterStatus
            // 
            this.cmbFilterStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFilterStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.cmbFilterStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbFilterStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFilterStatus.FormattingEnabled = true;
            this.cmbFilterStatus.Items.AddRange(new object[] {
            "All",
            "Success",
            "Failure"});
            this.cmbFilterStatus.Location = new System.Drawing.Point(0, 18);
            this.cmbFilterStatus.Name = "cmbFilterStatus";
            this.cmbFilterStatus.Size = new System.Drawing.Size(110, 23);
            this.cmbFilterStatus.TabIndex = 1;
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.lblStatus.Location = new System.Drawing.Point(0, 2);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(110, 16);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Status";
            // 
            // pnlToDate
            // 
            this.pnlToDate.Controls.Add(this.dtpToDate);
            this.pnlToDate.Controls.Add(this.lblToDate);
            this.pnlToDate.Location = new System.Drawing.Point(220, 20);
            this.pnlToDate.MinimumSize = new System.Drawing.Size(150, 45);
            this.pnlToDate.Name = "pnlToDate";
            this.pnlToDate.Size = new System.Drawing.Size(180, 45);
            this.pnlToDate.TabIndex = 1;
            // 
            // dtpToDate
            // 
            this.dtpToDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpToDate.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.dtpToDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDate.Location = new System.Drawing.Point(0, 18);
            this.dtpToDate.MinimumSize = new System.Drawing.Size(150, 23);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(180, 23);
            this.dtpToDate.TabIndex = 1;
            // 
            // lblToDate
            // 
            this.lblToDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblToDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.lblToDate.Location = new System.Drawing.Point(0, 2);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(180, 16);
            this.lblToDate.TabIndex = 0;
            this.lblToDate.Text = "To Date";
            // 
            // pnlFromDate
            // 
            this.pnlFromDate.Controls.Add(this.dtpFromDate);
            this.pnlFromDate.Controls.Add(this.lblFromDate);
            this.pnlFromDate.Location = new System.Drawing.Point(20, 20);
            this.pnlFromDate.MinimumSize = new System.Drawing.Size(150, 45);
            this.pnlFromDate.Name = "pnlFromDate";
            this.pnlFromDate.Size = new System.Drawing.Size(180, 45);
            this.pnlFromDate.TabIndex = 0;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFromDate.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.dtpFromDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new System.Drawing.Point(0, 18);
            this.dtpFromDate.MinimumSize = new System.Drawing.Size(150, 23);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(180, 23);
            this.dtpFromDate.TabIndex = 1;
            // 
            // lblFromDate
            // 
            this.lblFromDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFromDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.lblFromDate.Location = new System.Drawing.Point(0, 2);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(180, 16);
            this.lblFromDate.TabIndex = 0;
            this.lblFromDate.Text = "From Date";
            // 
            // pnlStats
            // 
            this.pnlStats.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlStats.BackColor = System.Drawing.Color.Transparent;
            this.pnlStats.Controls.Add(this.pnlStatCard3);
            this.pnlStats.Controls.Add(this.pnlStatCard2);
            this.pnlStats.Controls.Add(this.pnlStatCard1);
            this.pnlStats.Location = new System.Drawing.Point(20, 20);
            this.pnlStats.MinimumSize = new System.Drawing.Size(600, 119);
            this.pnlStats.Name = "pnlStats";
            this.pnlStats.Size = new System.Drawing.Size(885, 119);
            this.pnlStats.TabIndex = 0;
            // 
            // pnlStatCard3
            // 
            this.pnlStatCard3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlStatCard3.BackColor = System.Drawing.Color.White;
            this.pnlStatCard3.Controls.Add(this.lblFailedLogins);
            this.pnlStatCard3.Controls.Add(this.lblFailedTitle);
            this.pnlStatCard3.Location = new System.Drawing.Point(595, 10);
            this.pnlStatCard3.MinimumSize = new System.Drawing.Size(200, 93);
            this.pnlStatCard3.Name = "pnlStatCard3";
            this.pnlStatCard3.Size = new System.Drawing.Size(280, 93);
            this.pnlStatCard3.TabIndex = 2;
            // 
            // lblFailedLogins
            // 
            this.lblFailedLogins.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFailedLogins.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFailedLogins.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.lblFailedLogins.Location = new System.Drawing.Point(15, 35);
            this.lblFailedLogins.Name = "lblFailedLogins";
            this.lblFailedLogins.Size = new System.Drawing.Size(250, 45);
            this.lblFailedLogins.TabIndex = 1;
            this.lblFailedLogins.Text = "0";
            // 
            // lblFailedTitle
            // 
            this.lblFailedTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFailedTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFailedTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblFailedTitle.Location = new System.Drawing.Point(15, 15);
            this.lblFailedTitle.Name = "lblFailedTitle";
            this.lblFailedTitle.Size = new System.Drawing.Size(250, 20);
            this.lblFailedTitle.TabIndex = 0;
            this.lblFailedTitle.Text = "Failed Logins";
            // 
            // pnlStatCard2
            // 
            this.pnlStatCard2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnlStatCard2.BackColor = System.Drawing.Color.White;
            this.pnlStatCard2.Controls.Add(this.lblSuccessfulLogins);
            this.pnlStatCard2.Controls.Add(this.lblSuccessTitle);
            this.pnlStatCard2.Location = new System.Drawing.Point(302, 10);
            this.pnlStatCard2.MinimumSize = new System.Drawing.Size(200, 93);
            this.pnlStatCard2.Name = "pnlStatCard2";
            this.pnlStatCard2.Size = new System.Drawing.Size(280, 93);
            this.pnlStatCard2.TabIndex = 1;
            // 
            // lblSuccessfulLogins
            // 
            this.lblSuccessfulLogins.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSuccessfulLogins.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSuccessfulLogins.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(197)))), ((int)(((byte)(94)))));
            this.lblSuccessfulLogins.Location = new System.Drawing.Point(15, 35);
            this.lblSuccessfulLogins.Name = "lblSuccessfulLogins";
            this.lblSuccessfulLogins.Size = new System.Drawing.Size(250, 45);
            this.lblSuccessfulLogins.TabIndex = 1;
            this.lblSuccessfulLogins.Text = "0";
            // 
            // lblSuccessTitle
            // 
            this.lblSuccessTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSuccessTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSuccessTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblSuccessTitle.Location = new System.Drawing.Point(15, 15);
            this.lblSuccessTitle.Name = "lblSuccessTitle";
            this.lblSuccessTitle.Size = new System.Drawing.Size(250, 20);
            this.lblSuccessTitle.TabIndex = 0;
            this.lblSuccessTitle.Text = "Successful Logins";
            // 
            // pnlStatCard1
            // 
            this.pnlStatCard1.BackColor = System.Drawing.Color.White;
            this.pnlStatCard1.Controls.Add(this.lblTotalLogs);
            this.pnlStatCard1.Controls.Add(this.lblTotalTitle);
            this.pnlStatCard1.Location = new System.Drawing.Point(10, 10);
            this.pnlStatCard1.MinimumSize = new System.Drawing.Size(200, 93);
            this.pnlStatCard1.Name = "pnlStatCard1";
            this.pnlStatCard1.Size = new System.Drawing.Size(280, 93);
            this.pnlStatCard1.TabIndex = 0;
            // 
            // lblTotalLogs
            // 
            this.lblTotalLogs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalLogs.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalLogs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.lblTotalLogs.Location = new System.Drawing.Point(15, 35);
            this.lblTotalLogs.Name = "lblTotalLogs";
            this.lblTotalLogs.Size = new System.Drawing.Size(250, 45);
            this.lblTotalLogs.TabIndex = 1;
            this.lblTotalLogs.Text = "0";
            // 
            // lblTotalTitle
            // 
            this.lblTotalTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblTotalTitle.Location = new System.Drawing.Point(15, 15);
            this.lblTotalTitle.Name = "lblTotalTitle";
            this.lblTotalTitle.Size = new System.Drawing.Size(250, 20);
            this.lblTotalTitle.TabIndex = 0;
            this.lblTotalTitle.Text = "Total Logs";
            // 
            // AuthLogs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.pnlMain);
            this.Name = "AuthLogs";
            this.Size = new System.Drawing.Size(925, 535);
            this.Load += new System.EventHandler(this.AuthLogs_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuthLogs)).EndInit();
            this.pnlFilters.ResumeLayout(false);
            this.pnlFilterContent.ResumeLayout(false);
            this.pnlStatusFilter.ResumeLayout(false);
            this.pnlToDate.ResumeLayout(false);
            this.pnlFromDate.ResumeLayout(false);
            this.pnlStats.ResumeLayout(false);
            this.pnlStatCard3.ResumeLayout(false);
            this.pnlStatCard2.ResumeLayout(false);
            this.pnlStatCard1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.DataGridView dgvAuthLogs;
        private System.Windows.Forms.Panel pnlFilters;
        private System.Windows.Forms.Panel pnlFilterContent;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Panel pnlStatusFilter;
        private System.Windows.Forms.ComboBox cmbFilterStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Panel pnlToDate;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.Panel pnlFromDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.Panel pnlStats;
        private System.Windows.Forms.Panel pnlStatCard3;
        private System.Windows.Forms.Label lblFailedLogins;
        private System.Windows.Forms.Label lblFailedTitle;
        private System.Windows.Forms.Panel pnlStatCard2;
        private System.Windows.Forms.Label lblSuccessfulLogins;
        private System.Windows.Forms.Label lblSuccessTitle;
        private System.Windows.Forms.Panel pnlStatCard1;
        private System.Windows.Forms.Label lblTotalLogs;
        private System.Windows.Forms.Label lblTotalTitle;
    }
}
