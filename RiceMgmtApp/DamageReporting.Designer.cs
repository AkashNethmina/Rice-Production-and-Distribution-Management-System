using System.Windows.Forms;

namespace RiceMgmtApp
{
    partial class DamageReporting
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvDamageReports = new System.Windows.Forms.DataGridView();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlReportCreation = new System.Windows.Forms.Panel();
            this.btnSubmitReport = new System.Windows.Forms.Button();
            this.txtDamageDetails = new System.Windows.Forms.TextBox();
            this.lblDamageDetails = new System.Windows.Forms.Label();
            this.lblReportDamage = new System.Windows.Forms.Label();
            this.pnlReviewActions = new System.Windows.Forms.Panel();
            this.lblReviewInstructions = new System.Windows.Forms.Label();
            this.btnReject = new System.Windows.Forms.Button();
            this.btnApprove = new System.Windows.Forms.Button();
            this.btnReview = new System.Windows.Forms.Button();
            this.lblReports = new System.Windows.Forms.Label();
            this.btnRefreshReports = new System.Windows.Forms.Button();
            this.lblFilter = new System.Windows.Forms.Label();
            this.cmbStatusFilter = new System.Windows.Forms.ComboBox();
            this.pnlHeader = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDamageReports)).BeginInit();
            this.pnlReportCreation.SuspendLayout();
            this.pnlReviewActions.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDamageReports
            // 
            this.dgvDamageReports.AllowUserToAddRows = false;
            this.dgvDamageReports.AllowUserToDeleteRows = false;
            this.dgvDamageReports.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDamageReports.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDamageReports.BackgroundColor = System.Drawing.Color.White;
            this.dgvDamageReports.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDamageReports.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDamageReports.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDamageReports.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvDamageReports.ColumnHeadersHeight = 40;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDamageReports.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvDamageReports.EnableHeadersVisualStyles = false;
            this.dgvDamageReports.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvDamageReports.Location = new System.Drawing.Point(23, 369);
            this.dgvDamageReports.MultiSelect = false;
            this.dgvDamageReports.Name = "dgvDamageReports";
            this.dgvDamageReports.ReadOnly = true;
            this.dgvDamageReports.RowHeadersVisible = false;
            this.dgvDamageReports.RowTemplate.Height = 35;
            this.dgvDamageReports.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDamageReports.Size = new System.Drawing.Size(753, 230);
            this.dgvDamageReports.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(18, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(256, 30);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Damage Report System";
            // 
            // pnlReportCreation
            // 
            this.pnlReportCreation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlReportCreation.BackColor = System.Drawing.Color.White;
            this.pnlReportCreation.Controls.Add(this.btnSubmitReport);
            this.pnlReportCreation.Controls.Add(this.txtDamageDetails);
            this.pnlReportCreation.Controls.Add(this.lblDamageDetails);
            this.pnlReportCreation.Controls.Add(this.lblReportDamage);
            this.pnlReportCreation.Location = new System.Drawing.Point(24, 80);
            this.pnlReportCreation.Name = "pnlReportCreation";
            this.pnlReportCreation.Size = new System.Drawing.Size(752, 240);
            this.pnlReportCreation.TabIndex = 2;
            // 
            // btnSubmitReport
            // 
            this.btnSubmitReport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubmitReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(123)))), ((int)(((byte)(86)))));
            this.btnSubmitReport.FlatAppearance.BorderSize = 0;
            this.btnSubmitReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmitReport.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmitReport.ForeColor = System.Drawing.Color.White;
            this.btnSubmitReport.Location = new System.Drawing.Point(20, 190);
            this.btnSubmitReport.Name = "btnSubmitReport";
            this.btnSubmitReport.Size = new System.Drawing.Size(698, 35);
            this.btnSubmitReport.TabIndex = 5;
            this.btnSubmitReport.Text = "Submit Report";
            this.btnSubmitReport.UseVisualStyleBackColor = false;
            this.btnSubmitReport.Click += new System.EventHandler(this.btnSubmitReport_Click);
            // 
            // txtDamageDetails
            // 
            this.txtDamageDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDamageDetails.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtDamageDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDamageDetails.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDamageDetails.Location = new System.Drawing.Point(20, 73);
            this.txtDamageDetails.Multiline = true;
            this.txtDamageDetails.Name = "txtDamageDetails";
            this.txtDamageDetails.Size = new System.Drawing.Size(698, 107);
            this.txtDamageDetails.TabIndex = 4;
            // 
            // lblDamageDetails
            // 
            this.lblDamageDetails.AutoSize = true;
            this.lblDamageDetails.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDamageDetails.Location = new System.Drawing.Point(17, 53);
            this.lblDamageDetails.Name = "lblDamageDetails";
            this.lblDamageDetails.Size = new System.Drawing.Size(103, 17);
            this.lblDamageDetails.TabIndex = 3;
            this.lblDamageDetails.Text = "Damage Details:";
            // 
            // lblReportDamage
            // 
            this.lblReportDamage.AutoSize = true;
            this.lblReportDamage.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReportDamage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(123)))), ((int)(((byte)(86)))));
            this.lblReportDamage.Location = new System.Drawing.Point(16, 15);
            this.lblReportDamage.Name = "lblReportDamage";
            this.lblReportDamage.Size = new System.Drawing.Size(125, 21);
            this.lblReportDamage.TabIndex = 0;
            this.lblReportDamage.Text = "Report Damage";
            // 
            // pnlReviewActions
            // 
            this.pnlReviewActions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlReviewActions.BackColor = System.Drawing.Color.White;
            this.pnlReviewActions.Controls.Add(this.lblReviewInstructions);
            this.pnlReviewActions.Controls.Add(this.btnReject);
            this.pnlReviewActions.Controls.Add(this.btnApprove);
            this.pnlReviewActions.Controls.Add(this.btnReview);
            this.pnlReviewActions.Location = new System.Drawing.Point(23, 80);
            this.pnlReviewActions.Name = "pnlReviewActions";
            this.pnlReviewActions.Size = new System.Drawing.Size(753, 240);
            this.pnlReviewActions.TabIndex = 3;
            // 
            // lblReviewInstructions
            // 
            this.lblReviewInstructions.AutoSize = true;
            this.lblReviewInstructions.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReviewInstructions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(123)))), ((int)(((byte)(86)))));
            this.lblReviewInstructions.Location = new System.Drawing.Point(16, 15);
            this.lblReviewInstructions.Name = "lblReviewInstructions";
            this.lblReviewInstructions.Size = new System.Drawing.Size(120, 21);
            this.lblReviewInstructions.TabIndex = 3;
            this.lblReviewInstructions.Text = "Report Actions";
            // 
            // btnReject
            // 
            this.btnReject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.btnReject.Enabled = false;
            this.btnReject.FlatAppearance.BorderSize = 0;
            this.btnReject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReject.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReject.ForeColor = System.Drawing.Color.White;
            this.btnReject.Location = new System.Drawing.Point(20, 145);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(699, 35);
            this.btnReject.TabIndex = 2;
            this.btnReject.Text = "Reject Selected Report";
            this.btnReject.UseVisualStyleBackColor = false;
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            // 
            // btnApprove
            // 
            this.btnApprove.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApprove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(123)))), ((int)(((byte)(86)))));
            this.btnApprove.Enabled = false;
            this.btnApprove.FlatAppearance.BorderSize = 0;
            this.btnApprove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApprove.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApprove.ForeColor = System.Drawing.Color.White;
            this.btnApprove.Location = new System.Drawing.Point(20, 99);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(699, 35);
            this.btnApprove.TabIndex = 1;
            this.btnApprove.Text = "Approve Selected Report";
            this.btnApprove.UseVisualStyleBackColor = false;
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // btnReview
            // 
            this.btnReview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(200)))));
            this.btnReview.Enabled = false;
            this.btnReview.FlatAppearance.BorderSize = 0;
            this.btnReview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReview.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReview.ForeColor = System.Drawing.Color.White;
            this.btnReview.Location = new System.Drawing.Point(20, 53);
            this.btnReview.Name = "btnReview";
            this.btnReview.Size = new System.Drawing.Size(699, 35);
            this.btnReview.TabIndex = 0;
            this.btnReview.Text = "Mark as Under Review";
            this.btnReview.UseVisualStyleBackColor = false;
            this.btnReview.Click += new System.EventHandler(this.btnReview_Click);
            // 
            // lblReports
            // 
            this.lblReports.AutoSize = true;
            this.lblReports.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReports.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblReports.Location = new System.Drawing.Point(22, 337);
            this.lblReports.Name = "lblReports";
            this.lblReports.Size = new System.Drawing.Size(122, 20);
            this.lblReports.TabIndex = 4;
            this.lblReports.Text = "Damage Reports";
            // 
            // btnRefreshReports
            // 
            this.btnRefreshReports.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshReports.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.btnRefreshReports.FlatAppearance.BorderSize = 0;
            this.btnRefreshReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshReports.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshReports.ForeColor = System.Drawing.Color.White;
            this.btnRefreshReports.Location = new System.Drawing.Point(692, 335);
            this.btnRefreshReports.Name = "btnRefreshReports";
            this.btnRefreshReports.Size = new System.Drawing.Size(84, 28);
            this.btnRefreshReports.TabIndex = 5;
            this.btnRefreshReports.Text = "Refresh";
            this.btnRefreshReports.UseVisualStyleBackColor = false;
            this.btnRefreshReports.Click += new System.EventHandler(this.btnRefreshReports_Click);
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilter.Location = new System.Drawing.Point(507, 341);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(50, 17);
            this.lblFilter.TabIndex = 6;
            this.lblFilter.Text = "Status: ";
            // 
            // cmbStatusFilter
            // 
            this.cmbStatusFilter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmbStatusFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatusFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbStatusFilter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStatusFilter.FormattingEnabled = true;
            this.cmbStatusFilter.Location = new System.Drawing.Point(563, 338);
            this.cmbStatusFilter.Name = "cmbStatusFilter";
            this.cmbStatusFilter.Size = new System.Drawing.Size(121, 23);
            this.cmbStatusFilter.TabIndex = 7;
            this.cmbStatusFilter.SelectedIndexChanged += new System.EventHandler(this.cmbStatusFilter_SelectedIndexChanged);
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(123)))), ((int)(((byte)(86)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(800, 55);
            this.pnlHeader.TabIndex = 8;
            // 
            // DamageReporting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.cmbStatusFilter);
            this.Controls.Add(this.lblFilter);
            this.Controls.Add(this.btnRefreshReports);
            this.Controls.Add(this.lblReports);
            this.Controls.Add(this.pnlReviewActions);
            this.Controls.Add(this.pnlReportCreation);
            this.Controls.Add(this.dgvDamageReports);
            this.Name = "DamageReporting";
            this.Size = new System.Drawing.Size(800, 620);
            this.Load += new System.EventHandler(this.DamageReporting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDamageReports)).EndInit();
            this.pnlReportCreation.ResumeLayout(false);
            this.pnlReportCreation.PerformLayout();
            this.pnlReviewActions.ResumeLayout(false);
            this.pnlReviewActions.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDamageReports;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlReportCreation;
        private System.Windows.Forms.Button btnSubmitReport;
        private System.Windows.Forms.TextBox txtDamageDetails;
        private System.Windows.Forms.Label lblDamageDetails;
        private System.Windows.Forms.Label lblReportDamage;
        private System.Windows.Forms.Panel pnlReviewActions;
        private System.Windows.Forms.Button btnReject;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.Button btnReview;
        private System.Windows.Forms.Label lblReports;
        private System.Windows.Forms.Button btnRefreshReports;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.ComboBox cmbStatusFilter;
        private System.Windows.Forms.Label lblReviewInstructions;
        private System.Windows.Forms.Panel pnlHeader;
    }
}