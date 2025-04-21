namespace RiceMgmtApp
{
    partial class GovernmentAssistance
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
            this.dgvAssistanceRequests = new System.Windows.Forms.DataGridView();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlRequestAssistance = new System.Windows.Forms.Panel();
            this.btnLinkToDamageReport = new System.Windows.Forms.Button();
            this.cmbDamageReport = new System.Windows.Forms.ComboBox();
            this.lblDamageReport = new System.Windows.Forms.Label();
            this.btnRequestAssistance = new System.Windows.Forms.Button();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.lblAmount = new System.Windows.Forms.Label();
            this.txtRequestDetails = new System.Windows.Forms.TextBox();
            this.lblRequestDetails = new System.Windows.Forms.Label();
            this.cmbAssistanceType = new System.Windows.Forms.ComboBox();
            this.lblAssistanceType = new System.Windows.Forms.Label();
            this.lblRequestAssistance = new System.Windows.Forms.Label();
            this.pnlProcessRequests = new System.Windows.Forms.Panel();
            this.btnDisburse = new System.Windows.Forms.Button();
            this.btnReject = new System.Windows.Forms.Button();
            this.btnApprove = new System.Windows.Forms.Button();
            this.btnMarkReviewing = new System.Windows.Forms.Button();
            this.lblRequests = new System.Windows.Forms.Label();
            this.btnRefreshRequests = new System.Windows.Forms.Button();
            this.lblFilter = new System.Windows.Forms.Label();
            this.cmbStatusFilter = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssistanceRequests)).BeginInit();
            this.pnlRequestAssistance.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvAssistanceRequests
            // 
            this.dgvAssistanceRequests.AllowUserToAddRows = false;
            this.dgvAssistanceRequests.AllowUserToDeleteRows = false;
            this.dgvAssistanceRequests.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAssistanceRequests.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvAssistanceRequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAssistanceRequests.Location = new System.Drawing.Point(20, 350);
            this.dgvAssistanceRequests.MultiSelect = false;
            this.dgvAssistanceRequests.Name = "dgvAssistanceRequests";
            this.dgvAssistanceRequests.ReadOnly = true;
            this.dgvAssistanceRequests.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAssistanceRequests.Size = new System.Drawing.Size(760, 250);
            this.dgvAssistanceRequests.TabIndex = 0;
            this.dgvAssistanceRequests.SelectionChanged += new System.EventHandler(this.dgvAssistanceRequests_SelectionChanged);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(16, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(268, 24);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Government Assistance";
            // 
            // pnlRequestAssistance
            // 
            this.pnlRequestAssistance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRequestAssistance.Controls.Add(this.btnLinkToDamageReport);
            this.pnlRequestAssistance.Controls.Add(this.cmbDamageReport);
            this.pnlRequestAssistance.Controls.Add(this.lblDamageReport);
            this.pnlRequestAssistance.Controls.Add(this.btnRequestAssistance);
            this.pnlRequestAssistance.Controls.Add(this.txtAmount);
            this.pnlRequestAssistance.Controls.Add(this.lblAmount);
            this.pnlRequestAssistance.Controls.Add(this.txtRequestDetails);
            this.pnlRequestAssistance.Controls.Add(this.lblRequestDetails);
            this.pnlRequestAssistance.Controls.Add(this.cmbAssistanceType);
            this.pnlRequestAssistance.Controls.Add(this.lblAssistanceType);
            this.pnlRequestAssistance.Controls.Add(this.lblRequestAssistance);
            this.pnlRequestAssistance.Location = new System.Drawing.Point(20, 60);
            this.pnlRequestAssistance.Name = "pnlRequestAssistance";
            this.pnlRequestAssistance.Size = new System.Drawing.Size(370, 240);
            this.pnlRequestAssistance.TabIndex = 2;
            // 
            // btnLinkToDamageReport
            // 
            this.btnLinkToDamageReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnLinkToDamageReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLinkToDamageReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLinkToDamageReport.ForeColor = System.Drawing.Color.White;
            this.btnLinkToDamageReport.Location = new System.Drawing.Point(262, 95);
            this.btnLinkToDamageReport.Name = "btnLinkToDamageReport";
            this.btnLinkToDamageReport.Size = new System.Drawing.Size(90, 23);
            this.btnLinkToDamageReport.TabIndex = 10;
            this.btnLinkToDamageReport.Text = "Refresh";
            this.btnLinkToDamageReport.UseVisualStyleBackColor = false;
            this.btnLinkToDamageReport.Click += new System.EventHandler(this.btnLinkToDamageReport_Click);
            // 
            // cmbDamageReport
            // 
            this.cmbDamageReport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDamageReport.FormattingEnabled = true;
            this.cmbDamageReport.Location = new System.Drawing.Point(20, 95);
            this.cmbDamageReport.Name = "cmbDamageReport";
            this.cmbDamageReport.Size = new System.Drawing.Size(236, 21);
            this.cmbDamageReport.TabIndex = 9;
            // 
            // lblDamageReport
            // 
            this.lblDamageReport.AutoSize = true;
            this.lblDamageReport.Location = new System.Drawing.Point(17, 75);
            this.lblDamageReport.Name = "lblDamageReport";
            this.lblDamageReport.Size = new System.Drawing.Size(120, 13);
            this.lblDamageReport.TabIndex = 8;
            this.lblDamageReport.Text = "Link to Damage Report:";
            // 
            // btnRequestAssistance
            // 
            this.btnRequestAssistance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(0)))));
            this.btnRequestAssistance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRequestAssistance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRequestAssistance.ForeColor = System.Drawing.Color.White;
            this.btnRequestAssistance.Location = new System.Drawing.Point(20, 190);
            this.btnRequestAssistance.Name = "btnRequestAssistance";
            this.btnRequestAssistance.Size = new System.Drawing.Size(332, 35);
            this.btnRequestAssistance.TabIndex = 7;
            this.btnRequestAssistance.Text = "Submit Request";
            this.btnRequestAssistance.UseVisualStyleBackColor = false;
            this.btnRequestAssistance.Click += new System.EventHandler(this.btnRequestAssistance_Click);
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(262, 45);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(90, 20);
            this.txtAmount.TabIndex = 6;
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(259, 25);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(46, 13);
            this.lblAmount.TabIndex = 5;
            this.lblAmount.Text = "Amount:";
            // 
            // txtRequestDetails
            // 
            this.txtRequestDetails.Location = new System.Drawing.Point(20, 135);
            this.txtRequestDetails.Multiline = true;
            this.txtRequestDetails.Name = "txtRequestDetails";
            this.txtRequestDetails.Size = new System.Drawing.Size(332, 45);
            this.txtRequestDetails.TabIndex = 4;
            // 
            // lblRequestDetails
            // 
            this.lblRequestDetails.AutoSize = true;
            this.lblRequestDetails.Location = new System.Drawing.Point(17, 120);
            this.lblRequestDetails.Name = "lblRequestDetails";
            this.lblRequestDetails.Size = new System.Drawing.Size(85, 13);
            this.lblRequestDetails.TabIndex = 3;
            this.lblRequestDetails.Text = "Request Details:";
            // 
            // cmbAssistanceType
            // 
            this.cmbAssistanceType.Location = new System.Drawing.Point(0, 0);
            this.cmbAssistanceType.Name = "cmbAssistanceType";
            this.cmbAssistanceType.Size = new System.Drawing.Size(121, 21);
            this.cmbAssistanceType.TabIndex = 11;
            // 
            // lblAssistanceType
            // 
            this.lblAssistanceType.Location = new System.Drawing.Point(0, 0);
            this.lblAssistanceType.Name = "lblAssistanceType";
            this.lblAssistanceType.Size = new System.Drawing.Size(100, 23);
            this.lblAssistanceType.TabIndex = 12;
            // 
            // lblRequestAssistance
            // 
            this.lblRequestAssistance.Location = new System.Drawing.Point(0, 0);
            this.lblRequestAssistance.Name = "lblRequestAssistance";
            this.lblRequestAssistance.Size = new System.Drawing.Size(100, 23);
            this.lblRequestAssistance.TabIndex = 13;
            // 
            // pnlProcessRequests
            // 
            this.pnlProcessRequests.Location = new System.Drawing.Point(0, 0);
            this.pnlProcessRequests.Name = "pnlProcessRequests";
            this.pnlProcessRequests.Size = new System.Drawing.Size(200, 100);
            this.pnlProcessRequests.TabIndex = 0;
            // 
            // btnDisburse
            // 
            this.btnDisburse.Location = new System.Drawing.Point(0, 0);
            this.btnDisburse.Name = "btnDisburse";
            this.btnDisburse.Size = new System.Drawing.Size(75, 23);
            this.btnDisburse.TabIndex = 0;
            // 
            // btnReject
            // 
            this.btnReject.Location = new System.Drawing.Point(0, 0);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(75, 23);
            this.btnReject.TabIndex = 0;
            // 
            // btnApprove
            // 
            this.btnApprove.Location = new System.Drawing.Point(0, 0);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(75, 23);
            this.btnApprove.TabIndex = 0;
            // 
            // btnMarkReviewing
            // 
            this.btnMarkReviewing.Location = new System.Drawing.Point(0, 0);
            this.btnMarkReviewing.Name = "btnMarkReviewing";
            this.btnMarkReviewing.Size = new System.Drawing.Size(75, 23);
            this.btnMarkReviewing.TabIndex = 0;
            // 
            // lblRequests
            // 
            this.lblRequests.Location = new System.Drawing.Point(0, 0);
            this.lblRequests.Name = "lblRequests";
            this.lblRequests.Size = new System.Drawing.Size(100, 23);
            this.lblRequests.TabIndex = 0;
            // 
            // btnRefreshRequests
            // 
            this.btnRefreshRequests.Location = new System.Drawing.Point(0, 0);
            this.btnRefreshRequests.Name = "btnRefreshRequests";
            this.btnRefreshRequests.Size = new System.Drawing.Size(75, 23);
            this.btnRefreshRequests.TabIndex = 0;
            // 
            // lblFilter
            // 
            this.lblFilter.Location = new System.Drawing.Point(0, 0);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(100, 23);
            this.lblFilter.TabIndex = 0;
            // 
            // cmbStatusFilter
            // 
            this.cmbStatusFilter.Location = new System.Drawing.Point(0, 0);
            this.cmbStatusFilter.Name = "cmbStatusFilter";
            this.cmbStatusFilter.Size = new System.Drawing.Size(121, 21);
            this.cmbStatusFilter.TabIndex = 0;
            // 
            // GovernmentAssistance
            // 
            this.Name = "GovernmentAssistance";
            this.Size = new System.Drawing.Size(960, 420);
            this.Load += new System.EventHandler(this.GovernmentAssistance_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssistanceRequests)).EndInit();
            this.pnlRequestAssistance.ResumeLayout(false);
            this.pnlRequestAssistance.PerformLayout();
            this.ResumeLayout(false);
            //
            // cmbAssistanceType
            // 
            this.cmbAssistanceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAssistanceType.FormattingEnabled = true;
            this.cmbAssistanceType.Location = new System.Drawing.Point(20, 45);
            this.cmbAssistanceType.Name = "cmbAssistanceType";
            this.cmbAssistanceType.Size = new System.Drawing.Size(236, 21);
            this.cmbAssistanceType.TabIndex = 2;

            // lblAssistanceType
            this.lblAssistanceType.AutoSize = true;
            this.lblAssistanceType.Location = new System.Drawing.Point(17, 25);
            this.lblAssistanceType.Name = "lblAssistanceType";
            this.lblAssistanceType.Size = new System.Drawing.Size(89, 13);
            this.lblAssistanceType.TabIndex = 1;
            this.lblAssistanceType.Text = "Assistance Type:";

            // lblRequestAssistance
            this.lblRequestAssistance.AutoSize = true;
            this.lblRequestAssistance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequestAssistance.Location = new System.Drawing.Point(3, 3);
            this.lblRequestAssistance.Name = "lblRequestAssistance";
            this.lblRequestAssistance.Size = new System.Drawing.Size(145, 17);
            this.lblRequestAssistance.TabIndex = 0;
            this.lblRequestAssistance.Text = "Request Assistance";

            // pnlProcessRequests
            this.pnlProcessRequests.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlProcessRequests.Controls.Add(this.btnDisburse);
            this.pnlProcessRequests.Controls.Add(this.btnReject);
            this.pnlProcessRequests.Controls.Add(this.btnApprove);
            this.pnlProcessRequests.Controls.Add(this.btnMarkReviewing);
            this.pnlProcessRequests.Location = new System.Drawing.Point(410, 60);
            this.pnlProcessRequests.Name = "pnlProcessRequests";
            this.pnlProcessRequests.Size = new System.Drawing.Size(370, 240);
            this.pnlProcessRequests.TabIndex = 3;

            // btnDisburse
            this.btnDisburse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnDisburse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDisburse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisburse.ForeColor = System.Drawing.Color.White;
            this.btnDisburse.Location = new System.Drawing.Point(20, 190);
            this.btnDisburse.Name = "btnDisburse";
            this.btnDisburse.Size = new System.Drawing.Size(332, 35);
            this.btnDisburse.TabIndex = 8;
            this.btnDisburse.Text = "Mark as Disbursed";
            this.btnDisburse.UseVisualStyleBackColor = false;
            this.btnDisburse.Click += new System.EventHandler(this.btnDisburse_Click);

            // btnReject
            this.btnReject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnReject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReject.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReject.ForeColor = System.Drawing.Color.White;
            this.btnReject.Location = new System.Drawing.Point(20, 145);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(332, 35);
            this.btnReject.TabIndex = 7;
            this.btnReject.Text = "Reject Request";
            this.btnReject.UseVisualStyleBackColor = false;
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);

            // btnApprove
            this.btnApprove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(0)))));
            this.btnApprove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApprove.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApprove.ForeColor = System.Drawing.Color.White;
            this.btnApprove.Location = new System.Drawing.Point(20, 100);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(332, 35);
            this.btnApprove.TabIndex = 6;
            this.btnApprove.Text = "Approve Request";
            this.btnApprove.UseVisualStyleBackColor = false;
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);

            // btnMarkReviewing
            this.btnMarkReviewing.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnMarkReviewing.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMarkReviewing.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMarkReviewing.ForeColor = System.Drawing.Color.White;
            this.btnMarkReviewing.Location = new System.Drawing.Point(20, 55);
            this.btnMarkReviewing.Name = "btnMarkReviewing";
            this.btnMarkReviewing.Size = new System.Drawing.Size(332, 35);
            this.btnMarkReviewing.TabIndex = 5;
            this.btnMarkReviewing.Text = "Mark as Under Review";
            this.btnMarkReviewing.UseVisualStyleBackColor = false;
            this.btnMarkReviewing.Click += new System.EventHandler(this.btnMarkReviewing_Click);

            // lblRequests
            this.lblRequests.AutoSize = true;
            this.lblRequests.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequests.Location = new System.Drawing.Point(20, 320);
            this.lblRequests.Name = "lblRequests";
            this.lblRequests.Size = new System.Drawing.Size(159, 17);
            this.lblRequests.TabIndex = 4;
            this.lblRequests.Text = "Assistance Requests";

            // btnRefreshRequests
            this.btnRefreshRequests.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnRefreshRequests.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshRequests.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshRequests.ForeColor = System.Drawing.Color.White;
            this.btnRefreshRequests.Location = new System.Drawing.Point(680, 320);
            this.btnRefreshRequests.Name = "btnRefreshRequests";
            this.btnRefreshRequests.Size = new System.Drawing.Size(100, 25);
            this.btnRefreshRequests.TabIndex = 8;
            this.btnRefreshRequests.Text = "Refresh";
            this.btnRefreshRequests.UseVisualStyleBackColor = false;
            this.btnRefreshRequests.Click += new System.EventHandler(this.btnRefreshRequests_Click);

            // lblFilter
            this.lblFilter.AutoSize = true;
            this.lblFilter.Location = new System.Drawing.Point(426, 320);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(37, 13);
            this.lblFilter.TabIndex = 5;
            this.lblFilter.Text = "Filter:";

            // cmbStatusFilter
            this.cmbStatusFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatusFilter.FormattingEnabled = true;
            this.cmbStatusFilter.Location = new System.Drawing.Point(469, 320);
            this.cmbStatusFilter.Name = "cmbStatusFilter";
            this.cmbStatusFilter.Size = new System.Drawing.Size(200, 21);
            this.cmbStatusFilter.TabIndex = 6;
            this.cmbStatusFilter.SelectedIndexChanged += new System.EventHandler(this.cmbStatusFilter_SelectedIndexChanged);

            // GovernmentAssistance
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbStatusFilter);
            this.Controls.Add(this.lblFilter);
            this.Controls.Add(this.btnRefreshRequests);
            this.Controls.Add(this.lblRequests);
            this.Controls.Add(this.pnlProcessRequests);
            this.Controls.Add(this.pnlRequestAssistance);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.dgvAssistanceRequests);
            this.Name = "GovernmentAssistance";
            this.Size = new System.Drawing.Size(800, 620);
            this.Load += new System.EventHandler(this.GovernmentAssistance_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssistanceRequests)).EndInit();
            this.pnlRequestAssistance.ResumeLayout(false);
            this.pnlRequestAssistance.PerformLayout();
            this.pnlProcessRequests.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAssistanceRequests;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlRequestAssistance;
        private System.Windows.Forms.Button btnLinkToDamageReport;
        private System.Windows.Forms.ComboBox cmbDamageReport;
        private System.Windows.Forms.Label lblDamageReport;
        private System.Windows.Forms.Button btnRequestAssistance;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.TextBox txtRequestDetails;
        private System.Windows.Forms.Label lblRequestDetails;
        private System.Windows.Forms.ComboBox cmbAssistanceType;
        private System.Windows.Forms.Label lblAssistanceType;
        private System.Windows.Forms.Label lblRequestAssistance;
        private System.Windows.Forms.Panel pnlProcessRequests;
        private System.Windows.Forms.Button btnDisburse;
        private System.Windows.Forms.Button btnReject;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.Button btnMarkReviewing;
        private System.Windows.Forms.Label lblRequests;
        private System.Windows.Forms.Button btnRefreshRequests;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.ComboBox cmbStatusFilter;
        private System.Windows.Forms.DataGridViewTextBoxColumn RequestID;
        private System.Windows.Forms.DataGridViewTextBoxColumn FarmerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn AssistanceType;
        private System.Windows.Forms.DataGridViewTextBoxColumn RequestDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn DamageReportID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateRequested;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateProcessed;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProcessedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProcessedStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProcessedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProcessedByUserID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProcessedByRoleID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProcessedByUsername;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProcessedByRole;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProcessedByFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProcessedByEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProcessedByPhone;
       

    }
}
