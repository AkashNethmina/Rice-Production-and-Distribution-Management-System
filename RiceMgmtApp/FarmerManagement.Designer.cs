namespace RiceMgmtApp
{
    partial class FarmerManagement
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.ExportExcel = new System.Windows.Forms.Button();
            this.ExportPDF = new System.Windows.Forms.Button();
            this.dgvFarmerManage = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFarmerManage)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel1.Controls.Add(this.ExportExcel);
            this.panel1.Controls.Add(this.ExportPDF);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(853, 48);
            this.panel1.TabIndex = 1;
            // 
            // ExportExcel
            // 
            this.ExportExcel.Location = new System.Drawing.Point(638, 16);
            this.ExportExcel.Name = "ExportExcel";
            this.ExportExcel.Size = new System.Drawing.Size(75, 23);
            this.ExportExcel.TabIndex = 1;
            this.ExportExcel.Text = "Excel";
            this.ExportExcel.UseVisualStyleBackColor = true;
            this.ExportExcel.Click += new System.EventHandler(this.ExportExcel_Click);
            // 
            // ExportPDF
            // 
            this.ExportPDF.Location = new System.Drawing.Point(727, 16);
            this.ExportPDF.Name = "ExportPDF";
            this.ExportPDF.Size = new System.Drawing.Size(75, 23);
            this.ExportPDF.TabIndex = 0;
            this.ExportPDF.Text = "PDF";
            this.ExportPDF.UseVisualStyleBackColor = true;
            this.ExportPDF.Click += new System.EventHandler(this.ExportPDF_Click);
            // 
            // dgvFarmerManage
            // 
            this.dgvFarmerManage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFarmerManage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFarmerManage.Location = new System.Drawing.Point(0, 48);
            this.dgvFarmerManage.Name = "dgvFarmerManage";
            this.dgvFarmerManage.Size = new System.Drawing.Size(853, 433);
            this.dgvFarmerManage.TabIndex = 2;
            this.dgvFarmerManage.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFarmerManage_CellContentClick);
            // 
            // FarmerManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvFarmerManage);
            this.Controls.Add(this.panel1);
            this.Name = "FarmerManagement";
            this.Size = new System.Drawing.Size(853, 481);
            this.Load += new System.EventHandler(this.FarmerManagement_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFarmerManage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvFarmerManage;
        private System.Windows.Forms.Button ExportPDF;
        private System.Windows.Forms.Button ExportExcel;
    }
}
