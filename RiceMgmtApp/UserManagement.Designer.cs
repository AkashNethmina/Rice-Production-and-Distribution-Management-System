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
            this.panel1 = new System.Windows.Forms.Panel();
            this.usersBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.riceProductionDB2DataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.riceProductionDB2DataSet = new RiceMgmtApp.RiceProductionDB2DataSet();
            this.usersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.usersTableAdapter = new RiceMgmtApp.RiceProductionDB2DataSetTableAdapters.UsersTableAdapter();
            this.dataGridViewusers = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.usersBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riceProductionDB2DataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riceProductionDB2DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewusers)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(972, 47);
            this.panel1.TabIndex = 0;
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
            this.dataGridViewusers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewusers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewusers.Location = new System.Drawing.Point(0, 47);
            this.dataGridViewusers.Name = "dataGridViewusers";
            this.dataGridViewusers.ReadOnly = true;
            this.dataGridViewusers.Size = new System.Drawing.Size(972, 425);
            this.dataGridViewusers.TabIndex = 1;
            // 
            // UserManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridViewusers);
            this.Controls.Add(this.panel1);
            this.Name = "UserManagement";
            this.Size = new System.Drawing.Size(972, 472);
            this.Load += new System.EventHandler(this.UserManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.usersBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riceProductionDB2DataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riceProductionDB2DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewusers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.BindingSource usersBindingSource;
        private System.Windows.Forms.BindingSource riceProductionDB2DataSetBindingSource;
        private RiceProductionDB2DataSet riceProductionDB2DataSet;
        private RiceProductionDB2DataSetTableAdapters.UsersTableAdapter usersTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn roleIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource usersBindingSource1;
        private System.Windows.Forms.DataGridView dataGridViewusers;
    }
}
