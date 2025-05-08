using RiceMgmtApp.Properties;

namespace RiceMgmtApp
{
    partial class UserManagement
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
            this.components = new System.ComponentModel.Container();
            this.topPanel = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.controlPanel = new System.Windows.Forms.Panel();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.exportPanel = new System.Windows.Forms.Panel();
            this.btn_exportExcel = new System.Windows.Forms.Button();
            this.btn_exportPdf = new System.Windows.Forms.Button();
            this.usersBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.riceProductionDB2DataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.riceProductionDB2DataSet = new RiceMgmtApp.RiceProductionDB2DataSet();
            this.usersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.usersTableAdapter = new RiceMgmtApp.RiceProductionDB2DataSetTableAdapters.UsersTableAdapter();
            this.sqlDataAdapter1 = new Microsoft.Data.SqlClient.SqlDataAdapter();
            this.dataGridViewusers = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.topPanel.SuspendLayout();
            this.controlPanel.SuspendLayout();
            this.searchPanel.SuspendLayout();
            this.exportPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.usersBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riceProductionDB2DataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riceProductionDB2DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewusers)).BeginInit();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(142)))), ((int)(((byte)(60)))));
            this.topPanel.Controls.Add(this.lblTitle);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(972, 50);
            this.topPanel.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(12, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(175, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "User Management";
            // 
            // controlPanel
            // 
            this.controlPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(245)))), ((int)(((byte)(233)))));
            this.controlPanel.Controls.Add(this.searchPanel);
            this.controlPanel.Controls.Add(this.exportPanel);
            this.controlPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.controlPanel.Location = new System.Drawing.Point(0, 50);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(972, 60);
            this.controlPanel.TabIndex = 1;
            // 
            // searchPanel
            // 
            this.searchPanel.Controls.Add(this.txtSearch);
            this.searchPanel.Controls.Add(this.btnSearch);
            this.searchPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.searchPanel.Location = new System.Drawing.Point(0, 0);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(343, 60);
            this.searchPanel.TabIndex = 1;
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(12, 17);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(250, 27);
            this.txtSearch.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(268, 17);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(58, 27);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // exportPanel
            // 
            this.exportPanel.Controls.Add(this.btn_exportExcel);
            this.exportPanel.Controls.Add(this.btn_exportPdf);
            this.exportPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.exportPanel.Location = new System.Drawing.Point(772, 0);
            this.exportPanel.Name = "exportPanel";
            this.exportPanel.Size = new System.Drawing.Size(200, 60);
            this.exportPanel.TabIndex = 0;
            // 
            // btn_exportExcel
            // 
            this.btn_exportExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_exportExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.btn_exportExcel.FlatAppearance.BorderSize = 0;
            this.btn_exportExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_exportExcel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_exportExcel.ForeColor = System.Drawing.Color.White;
            this.btn_exportExcel.Location = new System.Drawing.Point(23, 14);
            this.btn_exportExcel.Name = "btn_exportExcel";
            this.btn_exportExcel.Size = new System.Drawing.Size(75, 32);
            this.btn_exportExcel.TabIndex = 0;
            this.btn_exportExcel.Text = "Excel";
            this.btn_exportExcel.UseVisualStyleBackColor = false;
            this.btn_exportExcel.Click += new System.EventHandler(this.btn_exportExcel_Click);
            // 
            // btn_exportPdf
            // 
            this.btn_exportPdf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_exportPdf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.btn_exportPdf.FlatAppearance.BorderSize = 0;
            this.btn_exportPdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_exportPdf.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_exportPdf.ForeColor = System.Drawing.Color.White;
            this.btn_exportPdf.Location = new System.Drawing.Point(113, 14);
            this.btn_exportPdf.Name = "btn_exportPdf";
            this.btn_exportPdf.Size = new System.Drawing.Size(75, 32);
            this.btn_exportPdf.TabIndex = 1;
            this.btn_exportPdf.Text = "PDF";
            this.btn_exportPdf.UseVisualStyleBackColor = false;
            this.btn_exportPdf.Click += new System.EventHandler(this.btn_exportPdf_Click);
            // 
            // usersBindingSource1
            // 
            this.usersBindingSource1.DataMember = "Users";
            this.usersBindingSource1.DataSource = this.riceProductionDB2DataSetBindingSource;
            // 
            // riceProductionDB2DataSetBindingSource
            // 
            this.riceProductionDB2DataSetBindingSource.DataSource = this.riceProductionDB2DataSet;
            this.riceProductionDB2DataSetBindingSource.Position = 0;
            // 
            // riceProductionDB2DataSet
            // 
            this.riceProductionDB2DataSet.DataSetName = "RiceProductionDB2DataSet";
            this.riceProductionDB2DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // usersBindingSource
            // 
            this.usersBindingSource.DataMember = "Users";
            this.usersBindingSource.DataSource = this.riceProductionDB2DataSetBindingSource;
            // 
            // usersTableAdapter
            // 
            this.usersTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridViewusers
            // 
            this.dataGridViewusers.AllowUserToAddRows = false;
            this.dataGridViewusers.AllowUserToDeleteRows = false;
            this.dataGridViewusers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewusers.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewusers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewusers.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridViewusers.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewusers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewusers.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridViewusers.Location = new System.Drawing.Point(0, 110);
            this.dataGridViewusers.Name = "dataGridViewusers";
            this.dataGridViewusers.ReadOnly = true;
            this.dataGridViewusers.RowHeadersVisible = false;
            this.dataGridViewusers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewusers.Size = new System.Drawing.Size(972, 304);
            this.dataGridViewusers.TabIndex = 2;
            this.dataGridViewusers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewusers_CellClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(61, 4);
            // 
            // UserManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dataGridViewusers);
            this.Controls.Add(this.controlPanel);
            this.Controls.Add(this.topPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UserManagement";
            this.Size = new System.Drawing.Size(972, 517);
            this.Load += new System.EventHandler(this.UserManagement_Load);
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.controlPanel.ResumeLayout(false);
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            this.exportPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.usersBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riceProductionDB2DataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riceProductionDB2DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewusers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.BindingSource usersBindingSource;
        private System.Windows.Forms.BindingSource riceProductionDB2DataSetBindingSource;
        private RiceProductionDB2DataSet riceProductionDB2DataSet;
        private RiceProductionDB2DataSetTableAdapters.UsersTableAdapter usersTableAdapter;
        // private System.Windows.Forms.DataGridViewTextBoxColumn roleIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource usersBindingSource1;
        private Microsoft.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
        private System.Windows.Forms.DataGridView dataGridViewusers;
        //   private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        // private System.Windows.Forms.Button exportPdfBtn;
        // private System.Windows.Forms.Button exportExcelBtn;
        private System.Windows.Forms.Button btn_exportPdf;
        private System.Windows.Forms.Button btn_exportExcel;
        private System.Windows.Forms.Panel controlPanel;
        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel exportPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnAddUser;
    }
}