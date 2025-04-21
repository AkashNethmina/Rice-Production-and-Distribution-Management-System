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
            this.dgvDamageReports = new System.Windows.Forms.DataGridView();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlReportCreation = new System.Windows.Forms.Panel();
            this.btnSubmitReport = new System.Windows.Forms.Button();
            this.txtDamageDetails = new System.Windows.Forms.TextBox();
            this.lblDamageDetails = new System.Windows.Forms.Label();
            this.lblReportDamage = new System.Windows.Forms.Label();
            this.pnlReviewActions = new System.Windows.Forms.Panel();
            this.btnReject = new System.Windows.Forms.Button();
            this.btnApprove = new System.Windows.Forms.Button();
            this.btnReview = new System.Windows.Forms.Button();
            this.lblReports = new System.Windows.Forms.Label();
            this.btnRefreshReports = new System.Windows.Forms.Button();
            this.lblFilter = new System.Windows.Forms.Label();
            this.cmbStatusFilter = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDamageReports)).BeginInit();
            this.pnlReportCreation.SuspendLayout();
            this.pnlReviewActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDamageReports
            // 
            this.dgvDamageReports.AllowUserToAddRows = false;
            this.dgvDamageReports.AllowUserToDeleteRows = false;
            this.dgvDamageReports.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDamageReports.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvDamageReports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDamageReports.Location = new System.Drawing.Point(20, 350);
            this.dgvDamageReports.MultiSelect = false;
            this.dgvDamageReports.Name = "dgvDamageReports";
            this.dgvDamageReports.ReadOnly = true;
            this.dgvDamageReports.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDamageReports.Size = new System.Drawing.Size(760, 250);
            this.dgvDamageReports.TabIndex = 0;
            this.dgvDamageReports.SelectionChanged += new System.EventHandler(this.dgvDamageReports_SelectionChanged);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(16, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(228, 24);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Damage Report System";
            // 
            // pnlReportCreation
            // 
            this.pnlReportCreation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlReportCreation.Controls.Add(this.btnSubmitReport);
            this.pnlReportCreation.Controls.Add(this.txtDamageDetails);
            this.pnlReportCreation.Controls.Add(this.lblDamageDetails);
            this.pnlReportCreation.Controls.Add(this.lblReportDamage);
            this.pnlReportCreation.Location = new System.Drawing.Point(20, 60);
            this.pnlReportCreation.Name = "pnlReportCreation";
            this.pnlReportCreation.Size = new System.Drawing.Size(370, 240);
            this.pnlReportCreation.TabIndex = 2;
            // 
            // btnSubmitReport
            // 
            this.btnSubmitReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(0)))));
            this.btnSubmitReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmitReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmitReport.ForeColor = System.Drawing.Color.White;
            this.btnSubmitReport.Location = new System.Drawing.Point(20, 190);
            this.btnSubmitReport.Name = "btnSubmitReport";
            this.btnSubmitReport.Size = new System.Drawing.Size(332, 35);
            this.btnSubmitReport.TabIndex = 5;
            this.btnSubmitReport.Text = "Submit Report";
            this.btnSubmitReport.UseVisualStyleBackColor = false;
            this.btnSubmitReport.Click += new System.EventHandler(this.btnSubmitReport_Click);
            // 
            // txtDamageDetails
            // 
            this.txtDamageDetails.Location = new System.Drawing.Point(20, 115);
            this.txtDamageDetails.Multiline = true;
            this.txtDamageDetails.Name = "txtDamageDetails";
            this.txtDamageDetails.Size = new System.Drawing.Size(332, 65);
            this.txtDamageDetails.TabIndex = 4;
            // 
            // lblDamageDetails
            // 
            this.lblDamageDetails.AutoSize = true;
            this.lblDamageDetails.Location = new System.Drawing.Point(17, 95);
            this.lblDamageDetails.Name = "lblDamageDetails";
            this.lblDamageDetails.Size = new System.Drawing.Size(85, 13);
            this.lblDamageDetails.TabIndex = 3;
            this.lblDamageDetails.Text = "Damage Details:";
            // 
            // lblReportDamage
            // 
            this.lblReportDamage.AutoSize = true;
            this.lblReportDamage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReportDamage.Location = new System.Drawing.Point(17, 15);
            this.lblReportDamage.Name = "lblReportDamage";
            this.lblReportDamage.Size = new System.Drawing.Size(121, 17);
            this.lblReportDamage.TabIndex = 0;
            this.lblReportDamage.Text = "Report Damage";
            // 
            // pnlReviewActions
            // 
            this.pnlReviewActions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlReviewActions.Controls.Add(this.btnReject);
            this.pnlReviewActions.Controls.Add(this.btnApprove);
            this.pnlReviewActions.Controls.Add(this.btnReview);
            this.pnlReviewActions.Location = new System.Drawing.Point(410, 60);
            this.pnlReviewActions.Name = "pnlReviewActions";
            this.pnlReviewActions.Size = new System.Drawing.Size(370, 240);
            this.pnlReviewActions.TabIndex = 3;
            // 
            // btnReject
            // 
            this.btnReject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnReject.Enabled = false;
            this.btnReject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReject.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReject.ForeColor = System.Drawing.Color.White;
            this.btnReject.Location = new System.Drawing.Point(20, 130);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(332, 35);
            this.btnReject.TabIndex = 2;
            this.btnReject.Text = "Reject Selected Report";
            this.btnReject.UseVisualStyleBackColor = false;
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            // 
            // btnApprove
            // 
            this.btnApprove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(0)))));
            this.btnApprove.Enabled = false;
            this.btnApprove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApprove.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApprove.ForeColor = System.Drawing.Color.White;
            this.btnApprove.Location = new System.Drawing.Point(20, 80);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(332, 35);
            this.btnApprove.TabIndex = 1;
            this.btnApprove.Text = "Approve Selected Report";
            this.btnApprove.UseVisualStyleBackColor = false;
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // btnReview
            // 
            this.btnReview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnReview.Enabled = false;
            this.btnReview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReview.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReview.ForeColor = System.Drawing.Color.White;
            this.btnReview.Location = new System.Drawing.Point(20, 30);
            this.btnReview.Name = "btnReview";
            this.btnReview.Size = new System.Drawing.Size(332, 35);
            this.btnReview.TabIndex = 0;
            this.btnReview.Text = "Mark as Under Review";
            this.btnReview.UseVisualStyleBackColor = false;
            this.btnReview.Click += new System.EventHandler(this.btnReview_Click);
            // 
            // lblReports
            // 
            this.lblReports.AutoSize = true;
            this.lblReports.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReports.Location = new System.Drawing.Point(20, 320);
            this.lblReports.Name = "lblReports";
            this.lblReports.Size = new System.Drawing.Size(129, 17);
            this.lblReports.TabIndex = 4;
            this.lblReports.Text = "Damage Reports";
            // 
            // btnRefreshReports
            // 
            this.btnRefreshReports.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnRefreshReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshReports.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshReports.ForeColor = System.Drawing.Color.White;
            this.btnRefreshReports.Location = new System.Drawing.Point(696, 317);
            this.btnRefreshReports.Name = "btnRefreshReports";
            this.btnRefreshReports.Size = new System.Drawing.Size(84, 25);
            this.btnRefreshReports.TabIndex = 5;
            this.btnRefreshReports.Text = "Refresh";
            this.btnRefreshReports.UseVisualStyleBackColor = false;
            this.btnRefreshReports.Click += new System.EventHandler(this.btnRefreshReports_Click);
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Location = new System.Drawing.Point(407, 323);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(32, 13);
            this.lblFilter.TabIndex = 6;
            this.lblFilter.Text = "Filter:";
            // 
            // cmbStatusFilter
            // 
            this.cmbStatusFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatusFilter.FormattingEnabled = true;
            this.cmbStatusFilter.Location = new System.Drawing.Point(450, 320);
            this.cmbStatusFilter.Name = "cmbStatusFilter";
            this.cmbStatusFilter.Size = new System.Drawing.Size(121, 21);
            this.cmbStatusFilter.TabIndex = 7;
            this.cmbStatusFilter.SelectedIndexChanged += new System.EventHandler(this.cmbStatusFilter_SelectedIndexChanged);
            // 
            // DamageReporting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbStatusFilter);
            this.Controls.Add(this.lblFilter);
            this.Controls.Add(this.btnRefreshReports);
            this.Controls.Add(this.lblReports);
            this.Controls.Add(this.pnlReviewActions);
            this.Controls.Add(this.pnlReportCreation);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.dgvDamageReports);
            this.Name = "DamageReporting";
            this.Size = new System.Drawing.Size(800, 620);
            this.Load += new System.EventHandler(this.DamageReporting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDamageReports)).EndInit();
            this.pnlReportCreation.ResumeLayout(false);
            this.pnlReportCreation.PerformLayout();
            this.pnlReviewActions.ResumeLayout(false);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn ReportID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DamageType;
        private System.Windows.Forms.DataGridViewTextBoxColumn DamageDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReportedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReportDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReviewedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReviewDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReviewStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReviewComments;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReportedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReportedByUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReportedByName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReportedByRole;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReportedByDepartment;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReportedByContact;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReportedByEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReportedByAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReportedByCity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReportedByState;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReportedByCountry;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReportedByZip;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReportedByPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReportedByFax;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReportedByWebsite;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReportedBySocialMedia;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReportedByLinkedIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReportedByTwitter;
        
    }
}
