namespace RiceMgmtApp
{
    partial class SalesManagement
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
            this.dataGridViewSales = new System.Windows.Forms.DataGridView();
            this.txtSalePrice = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.cmbFarmer = new System.Windows.Forms.ComboBox();
            this.riceProductionDB2DataSet = new RiceMgmtApp.RiceProductionDB2DataSet();
            this.cmbBuyer = new System.Windows.Forms.ComboBox();
            this.cmbBuyerType = new System.Windows.Forms.ComboBox();
            this.cmbPaymentStatus = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.riceProductionDB2DataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.usersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.usersTableAdapter = new RiceMgmtApp.RiceProductionDB2DataSetTableAdapters.UsersTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riceProductionDB2DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riceProductionDB2DataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewSales
            // 
            this.dataGridViewSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSales.Location = new System.Drawing.Point(149, 124);
            this.dataGridViewSales.Name = "dataGridViewSales";
            this.dataGridViewSales.Size = new System.Drawing.Size(240, 150);
            this.dataGridViewSales.TabIndex = 0;
            // 
            // txtSalePrice
            // 
            this.txtSalePrice.Location = new System.Drawing.Point(178, 32);
            this.txtSalePrice.Name = "txtSalePrice";
            this.txtSalePrice.Size = new System.Drawing.Size(100, 20);
            this.txtSalePrice.TabIndex = 1;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(337, 31);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(100, 20);
            this.txtQuantity.TabIndex = 2;
            // 
            // cmbFarmer
            // 
            this.cmbFarmer.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.riceProductionDB2DataSet, "Users.Username", true));
            this.cmbFarmer.FormattingEnabled = true;
            this.cmbFarmer.Location = new System.Drawing.Point(178, 75);
            this.cmbFarmer.Name = "cmbFarmer";
            this.cmbFarmer.Size = new System.Drawing.Size(121, 21);
            this.cmbFarmer.TabIndex = 3;
            // 
            // riceProductionDB2DataSet
            // 
            this.riceProductionDB2DataSet.DataSetName = "RiceProductionDB2DataSet";
            this.riceProductionDB2DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cmbBuyer
            // 
            this.cmbBuyer.FormattingEnabled = true;
            this.cmbBuyer.Location = new System.Drawing.Point(353, 75);
            this.cmbBuyer.Name = "cmbBuyer";
            this.cmbBuyer.Size = new System.Drawing.Size(121, 21);
            this.cmbBuyer.TabIndex = 4;
    //        this.cmbBuyer.SelectedIndexChanged += new System.EventHandler(this.cmbBuyer_SelectedIndexChanged);
            // 
            // cmbBuyerType
            // 
            this.cmbBuyerType.FormattingEnabled = true;
            this.cmbBuyerType.Location = new System.Drawing.Point(480, 75);
            this.cmbBuyerType.Name = "cmbBuyerType";
            this.cmbBuyerType.Size = new System.Drawing.Size(121, 21);
            this.cmbBuyerType.TabIndex = 5;
            // 
            // cmbPaymentStatus
            // 
            this.cmbPaymentStatus.FormattingEnabled = true;
            this.cmbPaymentStatus.Location = new System.Drawing.Point(637, 75);
            this.cmbPaymentStatus.Name = "cmbPaymentStatus";
            this.cmbPaymentStatus.Size = new System.Drawing.Size(121, 21);
            this.cmbPaymentStatus.TabIndex = 6;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(398, 159);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(552, 181);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 8;
            this.btnUpdate.Text = "btnUpdate";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(509, 210);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "btnDelete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(613, 234);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "btnSearch";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // riceProductionDB2DataSetBindingSource
            // 
            this.riceProductionDB2DataSetBindingSource.DataSource = this.riceProductionDB2DataSet;
            this.riceProductionDB2DataSetBindingSource.Position = 0;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(732, 124);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(100, 20);
            this.txtSearch.TabIndex = 9;
            // 
            // usersBindingSource
            // 
            this.usersBindingSource.DataMember = "Users";
            this.usersBindingSource.DataSource = this.riceProductionDB2DataSet;
            // 
            // usersTableAdapter
            // 
            this.usersTableAdapter.ClearBeforeFill = true;
            // 
            // SalesManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.cmbPaymentStatus);
            this.Controls.Add(this.cmbBuyerType);
            this.Controls.Add(this.cmbBuyer);
            this.Controls.Add(this.cmbFarmer);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.txtSalePrice);
            this.Controls.Add(this.dataGridViewSales);
            this.Name = "SalesManagement";
            this.Size = new System.Drawing.Size(845, 431);
            this.Load += new System.EventHandler(this.SalesManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riceProductionDB2DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riceProductionDB2DataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewSales;
        private System.Windows.Forms.TextBox txtSalePrice;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.ComboBox cmbFarmer;
        private System.Windows.Forms.ComboBox cmbBuyer;
        private System.Windows.Forms.ComboBox cmbBuyerType;
        private System.Windows.Forms.ComboBox cmbPaymentStatus;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSearch;
        private RiceProductionDB2DataSet riceProductionDB2DataSet;
        private System.Windows.Forms.BindingSource riceProductionDB2DataSetBindingSource;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.BindingSource usersBindingSource;
        private RiceProductionDB2DataSetTableAdapters.UsersTableAdapter usersTableAdapter;
    }
}
