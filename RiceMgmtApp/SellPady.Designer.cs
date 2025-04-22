using System.Windows.Forms;
using System;

namespace RiceMgmtApp
{
    partial class SellPady
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.panelActionButtons = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.panelSaleForm = new System.Windows.Forms.Panel();
            this.groupBoxSaleDetails = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelForm = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanelButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCreateSale = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblSelectedStock = new System.Windows.Forms.Label();
            this.flowLayoutPanelBuyerType = new System.Windows.Forms.FlowLayoutPanel();
            this.lblBuyerType = new System.Windows.Forms.Label();
            this.cmbBuyerType = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanelBuyer = new System.Windows.Forms.FlowLayoutPanel();
            this.lblBuyer = new System.Windows.Forms.Label();
            this.cmbBuyer = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanelPrice = new System.Windows.Forms.FlowLayoutPanel();
            this.lblSalePrice = new System.Windows.Forms.Label();
            this.txtSalePrice = new System.Windows.Forms.TextBox();
            this.flowLayoutPanelQuantity = new System.Windows.Forms.FlowLayoutPanel();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.flowLayoutPanelTotal = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.flowLayoutPanelPayment = new System.Windows.Forms.FlowLayoutPanel();
            this.lblPaymentStatus = new System.Windows.Forms.Label();
            this.cmbPaymentStatus = new System.Windows.Forms.ComboBox();
            this.btnViewStock = new System.Windows.Forms.Button();
            this.panelSalesGrid = new System.Windows.Forms.Panel();
            this.flowLayoutPanelInvoiceButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnGenerateInvoice = new System.Windows.Forms.Button();
            this.btnSaveInvoice = new System.Windows.Forms.Button();
            this.btnPrintInvoice = new System.Windows.Forms.Button();
            this.panelInvoice = new System.Windows.Forms.Panel();
            this.pnlInvoice = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridViewSales = new System.Windows.Forms.DataGridView();
            this.groupBoxInvoice = new System.Windows.Forms.GroupBox();
            this.rtbInvoicePreview = new System.Windows.Forms.RichTextBox();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblFarmerName = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanelMain.SuspendLayout();
            this.panelActionButtons.SuspendLayout();
            this.panelSaleForm.SuspendLayout();
            this.groupBoxSaleDetails.SuspendLayout();
            this.tableLayoutPanelForm.SuspendLayout();
            this.flowLayoutPanelButtons.SuspendLayout();
            this.flowLayoutPanelBuyerType.SuspendLayout();
            this.flowLayoutPanelBuyer.SuspendLayout();
            this.flowLayoutPanelPrice.SuspendLayout();
            this.flowLayoutPanelQuantity.SuspendLayout();
            this.flowLayoutPanelTotal.SuspendLayout();
            this.flowLayoutPanelPayment.SuspendLayout();
            this.panelSalesGrid.SuspendLayout();
            this.flowLayoutPanelInvoiceButtons.SuspendLayout();
            this.panelInvoice.SuspendLayout();
            this.pnlInvoice.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSales)).BeginInit();
            this.groupBoxInvoice.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanelMain, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pnlHeader, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1116, 604);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.AutoSize = true;
            this.tableLayoutPanelMain.ColumnCount = 2;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanelMain.Controls.Add(this.panelActionButtons, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.panelSaleForm, 0, 1);
            this.tableLayoutPanelMain.Controls.Add(this.panelSalesGrid, 1, 0);
            this.tableLayoutPanelMain.Controls.Add(this.panelInvoice, 1, 1);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(8, 68);
            this.tableLayoutPanelMain.Margin = new System.Windows.Forms.Padding(8);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 2;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(1100, 528);
            this.tableLayoutPanelMain.TabIndex = 1;
            // 
            // panelActionButtons
            // 
            this.panelActionButtons.Controls.Add(this.btnRefresh);
            this.panelActionButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelActionButtons.Location = new System.Drawing.Point(0, 0);
            this.panelActionButtons.Margin = new System.Windows.Forms.Padding(0);
            this.panelActionButtons.Name = "panelActionButtons";
            this.panelActionButtons.Size = new System.Drawing.Size(440, 45);
            this.panelActionButtons.TabIndex = 0;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRefresh.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(2, 2);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(120, 36);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Text = "🔄 Refresh Data";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // panelSaleForm
            // 
            this.panelSaleForm.Controls.Add(this.groupBoxSaleDetails);
            this.panelSaleForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSaleForm.Location = new System.Drawing.Point(0, 45);
            this.panelSaleForm.Margin = new System.Windows.Forms.Padding(0);
            this.panelSaleForm.Name = "panelSaleForm";
            this.panelSaleForm.Padding = new System.Windows.Forms.Padding(4);
            this.panelSaleForm.Size = new System.Drawing.Size(440, 483);
            this.panelSaleForm.TabIndex = 1;
            // 
            // groupBoxSaleDetails
            // 
            this.groupBoxSaleDetails.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBoxSaleDetails.Controls.Add(this.tableLayoutPanelForm);
            this.groupBoxSaleDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxSaleDetails.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxSaleDetails.ForeColor = System.Drawing.Color.ForestGreen;
            this.groupBoxSaleDetails.Location = new System.Drawing.Point(4, 4);
            this.groupBoxSaleDetails.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxSaleDetails.Name = "groupBoxSaleDetails";
            this.groupBoxSaleDetails.Padding = new System.Windows.Forms.Padding(8);
            this.groupBoxSaleDetails.Size = new System.Drawing.Size(432, 475);
            this.groupBoxSaleDetails.TabIndex = 0;
            this.groupBoxSaleDetails.TabStop = false;
            this.groupBoxSaleDetails.Text = "Create New Sale";
            // 
            // tableLayoutPanelForm
            // 
            this.tableLayoutPanelForm.ColumnCount = 1;
            this.tableLayoutPanelForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelForm.Controls.Add(this.flowLayoutPanelButtons, 0, 8);
            this.tableLayoutPanelForm.Controls.Add(this.lblSelectedStock, 0, 0);
            this.tableLayoutPanelForm.Controls.Add(this.flowLayoutPanelBuyerType, 0, 1);
            this.tableLayoutPanelForm.Controls.Add(this.flowLayoutPanelBuyer, 0, 2);
            this.tableLayoutPanelForm.Controls.Add(this.flowLayoutPanelPrice, 0, 3);
            this.tableLayoutPanelForm.Controls.Add(this.flowLayoutPanelQuantity, 0, 4);
            this.tableLayoutPanelForm.Controls.Add(this.flowLayoutPanelTotal, 0, 5);
            this.tableLayoutPanelForm.Controls.Add(this.flowLayoutPanelPayment, 0, 6);
            this.tableLayoutPanelForm.Controls.Add(this.btnViewStock, 0, 7);
            this.tableLayoutPanelForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelForm.Location = new System.Drawing.Point(8, 27);
            this.tableLayoutPanelForm.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanelForm.Name = "tableLayoutPanelForm";
            this.tableLayoutPanelForm.RowCount = 9;
            this.tableLayoutPanelForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanelForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanelForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanelForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanelForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanelForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanelForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanelForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanelForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelForm.Size = new System.Drawing.Size(416, 440);
            this.tableLayoutPanelForm.TabIndex = 0;
            // 
            // flowLayoutPanelButtons
            // 
            this.flowLayoutPanelButtons.Controls.Add(this.btnCreateSale);
            this.flowLayoutPanelButtons.Controls.Add(this.btnClear);
            this.flowLayoutPanelButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelButtons.Location = new System.Drawing.Point(2, 432);
            this.flowLayoutPanelButtons.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanelButtons.Name = "flowLayoutPanelButtons";
            this.flowLayoutPanelButtons.Size = new System.Drawing.Size(412, 6);
            this.flowLayoutPanelButtons.TabIndex = 8;
            // 
            // btnCreateSale
            // 
            this.btnCreateSale.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCreateSale.BackColor = System.Drawing.Color.ForestGreen;
            this.btnCreateSale.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCreateSale.FlatAppearance.BorderSize = 0;
            this.btnCreateSale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateSale.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateSale.ForeColor = System.Drawing.Color.White;
            this.btnCreateSale.Location = new System.Drawing.Point(2, 2);
            this.btnCreateSale.Margin = new System.Windows.Forms.Padding(2);
            this.btnCreateSale.Name = "btnCreateSale";
            this.btnCreateSale.Size = new System.Drawing.Size(160, 41);
            this.btnCreateSale.TabIndex = 0;
            this.btnCreateSale.Text = "💰 Process Sale";
            this.btnCreateSale.UseVisualStyleBackColor = false;
            this.btnCreateSale.Click += new System.EventHandler(this.btnCreateSale_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnClear.BackColor = System.Drawing.Color.DarkGray;
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(166, 2);
            this.btnClear.Margin = new System.Windows.Forms.Padding(2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(120, 41);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "❌ Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblSelectedStock
            // 
            this.lblSelectedStock.BackColor = System.Drawing.Color.PaleGreen;
            this.lblSelectedStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSelectedStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSelectedStock.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedStock.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblSelectedStock.Location = new System.Drawing.Point(2, 0);
            this.lblSelectedStock.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSelectedStock.Name = "lblSelectedStock";
            this.lblSelectedStock.Padding = new System.Windows.Forms.Padding(4);
            this.lblSelectedStock.Size = new System.Drawing.Size(412, 50);
            this.lblSelectedStock.TabIndex = 1;
            this.lblSelectedStock.Text = "No stock selected";
            this.lblSelectedStock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSelectedStock.Visible = false;
            // 
            // flowLayoutPanelBuyerType
            // 
            this.flowLayoutPanelBuyerType.AutoSize = true;
            this.flowLayoutPanelBuyerType.Controls.Add(this.lblBuyerType);
            this.flowLayoutPanelBuyerType.Controls.Add(this.cmbBuyerType);
            this.flowLayoutPanelBuyerType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelBuyerType.Location = new System.Drawing.Point(2, 52);
            this.flowLayoutPanelBuyerType.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanelBuyerType.Name = "flowLayoutPanelBuyerType";
            this.flowLayoutPanelBuyerType.Padding = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanelBuyerType.Size = new System.Drawing.Size(412, 51);
            this.flowLayoutPanelBuyerType.TabIndex = 2;
            // 
            // lblBuyerType
            // 
            this.lblBuyerType.AutoSize = true;
            this.lblBuyerType.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuyerType.ForeColor = System.Drawing.Color.Black;
            this.lblBuyerType.Location = new System.Drawing.Point(6, 12);
            this.lblBuyerType.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.lblBuyerType.Name = "lblBuyerType";
            this.lblBuyerType.Size = new System.Drawing.Size(79, 19);
            this.lblBuyerType.TabIndex = 0;
            this.lblBuyerType.Text = "Buyer Type:";
            // 
            // cmbBuyerType
            // 
            this.cmbBuyerType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbBuyerType.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBuyerType.FormattingEnabled = true;
            this.cmbBuyerType.Location = new System.Drawing.Point(93, 6);
            this.cmbBuyerType.Margin = new System.Windows.Forms.Padding(4);
            this.cmbBuyerType.Name = "cmbBuyerType";
            this.cmbBuyerType.Size = new System.Drawing.Size(220, 27);
            this.cmbBuyerType.TabIndex = 1;
            // 
            // flowLayoutPanelBuyer
            // 
            this.flowLayoutPanelBuyer.AutoSize = true;
            this.flowLayoutPanelBuyer.Controls.Add(this.lblBuyer);
            this.flowLayoutPanelBuyer.Controls.Add(this.cmbBuyer);
            this.flowLayoutPanelBuyer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelBuyer.Location = new System.Drawing.Point(2, 107);
            this.flowLayoutPanelBuyer.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanelBuyer.Name = "flowLayoutPanelBuyer";
            this.flowLayoutPanelBuyer.Padding = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanelBuyer.Size = new System.Drawing.Size(412, 51);
            this.flowLayoutPanelBuyer.TabIndex = 3;
            // 
            // lblBuyer
            // 
            this.lblBuyer.AutoSize = true;
            this.lblBuyer.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuyer.ForeColor = System.Drawing.Color.Black;
            this.lblBuyer.Location = new System.Drawing.Point(6, 12);
            this.lblBuyer.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.lblBuyer.Name = "lblBuyer";
            this.lblBuyer.Size = new System.Drawing.Size(47, 19);
            this.lblBuyer.TabIndex = 0;
            this.lblBuyer.Text = "Buyer:";
            // 
            // cmbBuyer
            // 
            this.cmbBuyer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbBuyer.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBuyer.FormattingEnabled = true;
            this.cmbBuyer.Location = new System.Drawing.Point(61, 6);
            this.cmbBuyer.Margin = new System.Windows.Forms.Padding(4);
            this.cmbBuyer.Name = "cmbBuyer";
            this.cmbBuyer.Size = new System.Drawing.Size(250, 27);
            this.cmbBuyer.TabIndex = 1;
            // 
            // flowLayoutPanelPrice
            // 
            this.flowLayoutPanelPrice.AutoSize = true;
            this.flowLayoutPanelPrice.Controls.Add(this.lblSalePrice);
            this.flowLayoutPanelPrice.Controls.Add(this.txtSalePrice);
            this.flowLayoutPanelPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelPrice.Location = new System.Drawing.Point(2, 162);
            this.flowLayoutPanelPrice.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanelPrice.Name = "flowLayoutPanelPrice";
            this.flowLayoutPanelPrice.Padding = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanelPrice.Size = new System.Drawing.Size(412, 51);
            this.flowLayoutPanelPrice.TabIndex = 4;
            // 
            // lblSalePrice
            // 
            this.lblSalePrice.AutoSize = true;
            this.lblSalePrice.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalePrice.ForeColor = System.Drawing.Color.Black;
            this.lblSalePrice.Location = new System.Drawing.Point(6, 6);
            this.lblSalePrice.Margin = new System.Windows.Forms.Padding(4);
            this.lblSalePrice.Name = "lblSalePrice";
            this.lblSalePrice.Size = new System.Drawing.Size(85, 19);
            this.lblSalePrice.TabIndex = 0;
            this.lblSalePrice.Text = "Price per Kg:";
            // 
            // txtSalePrice
            // 
            this.txtSalePrice.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalePrice.Location = new System.Drawing.Point(99, 6);
            this.txtSalePrice.Margin = new System.Windows.Forms.Padding(4);
            this.txtSalePrice.Name = "txtSalePrice";
            this.txtSalePrice.Size = new System.Drawing.Size(226, 26);
            this.txtSalePrice.TabIndex = 1;
            // 
            // flowLayoutPanelQuantity
            // 
            this.flowLayoutPanelQuantity.Controls.Add(this.lblQuantity);
            this.flowLayoutPanelQuantity.Controls.Add(this.txtQuantity);
            this.flowLayoutPanelQuantity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelQuantity.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelQuantity.Location = new System.Drawing.Point(2, 217);
            this.flowLayoutPanelQuantity.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanelQuantity.Name = "flowLayoutPanelQuantity";
            this.flowLayoutPanelQuantity.Size = new System.Drawing.Size(412, 51);
            this.flowLayoutPanelQuantity.TabIndex = 5;
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantity.ForeColor = System.Drawing.Color.Black;
            this.lblQuantity.Location = new System.Drawing.Point(4, 4);
            this.lblQuantity.Margin = new System.Windows.Forms.Padding(4);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(93, 19);
            this.lblQuantity.TabIndex = 0;
            this.lblQuantity.Text = "Quantity (kg):";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantity.Location = new System.Drawing.Point(105, 4);
            this.txtQuantity.Margin = new System.Windows.Forms.Padding(4);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(218, 26);
            this.txtQuantity.TabIndex = 1;
            // 
            // flowLayoutPanelTotal
            // 
            this.flowLayoutPanelTotal.Controls.Add(this.lblTotalAmount);
            this.flowLayoutPanelTotal.Controls.Add(this.txtTotalAmount);
            this.flowLayoutPanelTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelTotal.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelTotal.Location = new System.Drawing.Point(2, 272);
            this.flowLayoutPanelTotal.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanelTotal.Name = "flowLayoutPanelTotal";
            this.flowLayoutPanelTotal.Size = new System.Drawing.Size(412, 51);
            this.flowLayoutPanelTotal.TabIndex = 6;
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.ForeColor = System.Drawing.Color.Black;
            this.lblTotalAmount.Location = new System.Drawing.Point(4, 4);
            this.lblTotalAmount.Margin = new System.Windows.Forms.Padding(4);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(95, 19);
            this.lblTotalAmount.TabIndex = 0;
            this.lblTotalAmount.Text = "Total Amount:";
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalAmount.Location = new System.Drawing.Point(107, 4);
            this.txtTotalAmount.Margin = new System.Windows.Forms.Padding(4);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.ReadOnly = true;
            this.txtTotalAmount.Size = new System.Drawing.Size(216, 26);
            this.txtTotalAmount.TabIndex = 1;
            // 
            // flowLayoutPanelPayment
            // 
            this.flowLayoutPanelPayment.Controls.Add(this.lblPaymentStatus);
            this.flowLayoutPanelPayment.Controls.Add(this.cmbPaymentStatus);
            this.flowLayoutPanelPayment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelPayment.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelPayment.Location = new System.Drawing.Point(2, 327);
            this.flowLayoutPanelPayment.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanelPayment.Name = "flowLayoutPanelPayment";
            this.flowLayoutPanelPayment.Size = new System.Drawing.Size(412, 51);
            this.flowLayoutPanelPayment.TabIndex = 7;
            // 
            // lblPaymentStatus
            // 
            this.lblPaymentStatus.AutoSize = true;
            this.lblPaymentStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentStatus.ForeColor = System.Drawing.Color.Black;
            this.lblPaymentStatus.Location = new System.Drawing.Point(4, 4);
            this.lblPaymentStatus.Margin = new System.Windows.Forms.Padding(4);
            this.lblPaymentStatus.Name = "lblPaymentStatus";
            this.lblPaymentStatus.Size = new System.Drawing.Size(108, 19);
            this.lblPaymentStatus.TabIndex = 0;
            this.lblPaymentStatus.Text = "Payment Status:";
            // 
            // cmbPaymentStatus
            // 
            this.cmbPaymentStatus.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPaymentStatus.FormattingEnabled = true;
            this.cmbPaymentStatus.Location = new System.Drawing.Point(120, 4);
            this.cmbPaymentStatus.Margin = new System.Windows.Forms.Padding(4);
            this.cmbPaymentStatus.Name = "cmbPaymentStatus";
            this.cmbPaymentStatus.Size = new System.Drawing.Size(203, 27);
            this.cmbPaymentStatus.TabIndex = 1;
            // 
            // btnViewStock
            // 
            this.btnViewStock.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.btnViewStock.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnViewStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnViewStock.FlatAppearance.BorderSize = 0;
            this.btnViewStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewStock.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewStock.ForeColor = System.Drawing.Color.White;
            this.btnViewStock.Location = new System.Drawing.Point(2, 382);
            this.btnViewStock.Margin = new System.Windows.Forms.Padding(2);
            this.btnViewStock.Name = "btnViewStock";
            this.btnViewStock.Size = new System.Drawing.Size(412, 46);
            this.btnViewStock.TabIndex = 7;
            this.btnViewStock.Text = "🌾 Select Stock to Sell";
            this.btnViewStock.UseVisualStyleBackColor = false;
            // 
            // panelSalesGrid
            // 
            this.panelSalesGrid.Controls.Add(this.flowLayoutPanelInvoiceButtons);
            this.panelSalesGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSalesGrid.Location = new System.Drawing.Point(440, 0);
            this.panelSalesGrid.Margin = new System.Windows.Forms.Padding(0);
            this.panelSalesGrid.Name = "panelSalesGrid";
            this.panelSalesGrid.Padding = new System.Windows.Forms.Padding(4);
            this.panelSalesGrid.Size = new System.Drawing.Size(660, 45);
            this.panelSalesGrid.TabIndex = 2;
            // 
            // flowLayoutPanelInvoiceButtons
            // 
            this.flowLayoutPanelInvoiceButtons.Controls.Add(this.btnGenerateInvoice);
            this.flowLayoutPanelInvoiceButtons.Controls.Add(this.btnSaveInvoice);
            this.flowLayoutPanelInvoiceButtons.Controls.Add(this.btnPrintInvoice);
            this.flowLayoutPanelInvoiceButtons.Location = new System.Drawing.Point(2, 2);
            this.flowLayoutPanelInvoiceButtons.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanelInvoiceButtons.Name = "flowLayoutPanelInvoiceButtons";
            this.flowLayoutPanelInvoiceButtons.Size = new System.Drawing.Size(652, 57);
            this.flowLayoutPanelInvoiceButtons.TabIndex = 1;
            // 
            // btnGenerateInvoice
            // 
            this.btnGenerateInvoice.BackColor = System.Drawing.Color.Teal;
            this.btnGenerateInvoice.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerateInvoice.FlatAppearance.BorderSize = 0;
            this.btnGenerateInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerateInvoice.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateInvoice.ForeColor = System.Drawing.Color.White;
            this.btnGenerateInvoice.Location = new System.Drawing.Point(2, 2);
            this.btnGenerateInvoice.Margin = new System.Windows.Forms.Padding(2);
            this.btnGenerateInvoice.Name = "btnGenerateInvoice";
            this.btnGenerateInvoice.Size = new System.Drawing.Size(112, 32);
            this.btnGenerateInvoice.TabIndex = 0;
            this.btnGenerateInvoice.Text = "🔄 Generate";
            this.btnGenerateInvoice.UseVisualStyleBackColor = false;
            this.btnGenerateInvoice.Click += new System.EventHandler(this.btnGenerateInvoice_Click);
            // 
            // btnSaveInvoice
            // 
            this.btnSaveInvoice.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.btnSaveInvoice.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveInvoice.FlatAppearance.BorderSize = 0;
            this.btnSaveInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveInvoice.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveInvoice.ForeColor = System.Drawing.Color.White;
            this.btnSaveInvoice.Location = new System.Drawing.Point(118, 2);
            this.btnSaveInvoice.Margin = new System.Windows.Forms.Padding(2);
            this.btnSaveInvoice.Name = "btnSaveInvoice";
            this.btnSaveInvoice.Size = new System.Drawing.Size(112, 32);
            this.btnSaveInvoice.TabIndex = 1;
            this.btnSaveInvoice.Text = "💾 Save";
            this.btnSaveInvoice.UseVisualStyleBackColor = false;
            this.btnSaveInvoice.Click += new System.EventHandler(this.btnSaveInvoice_Click);
            // 
            // btnPrintInvoice
            // 
            this.btnPrintInvoice.BackColor = System.Drawing.Color.SlateGray;
            this.btnPrintInvoice.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrintInvoice.FlatAppearance.BorderSize = 0;
            this.btnPrintInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintInvoice.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintInvoice.ForeColor = System.Drawing.Color.White;
            this.btnPrintInvoice.Location = new System.Drawing.Point(234, 2);
            this.btnPrintInvoice.Margin = new System.Windows.Forms.Padding(2);
            this.btnPrintInvoice.Name = "btnPrintInvoice";
            this.btnPrintInvoice.Size = new System.Drawing.Size(112, 32);
            this.btnPrintInvoice.TabIndex = 2;
            this.btnPrintInvoice.Text = "🖨️ Print";
            this.btnPrintInvoice.UseVisualStyleBackColor = false;
            this.btnPrintInvoice.Click += new System.EventHandler(this.btnPrintInvoice_Click);
            // 
            // panelInvoice
            // 
            this.panelInvoice.Controls.Add(this.pnlInvoice);
            this.panelInvoice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelInvoice.Location = new System.Drawing.Point(440, 45);
            this.panelInvoice.Margin = new System.Windows.Forms.Padding(0);
            this.panelInvoice.Name = "panelInvoice";
            this.panelInvoice.Padding = new System.Windows.Forms.Padding(4);
            this.panelInvoice.Size = new System.Drawing.Size(660, 483);
            this.panelInvoice.TabIndex = 3;
            // 
            // pnlInvoice
            // 
            this.pnlInvoice.Controls.Add(this.groupBox1);
            this.pnlInvoice.Controls.Add(this.groupBoxInvoice);
            this.pnlInvoice.Location = new System.Drawing.Point(4, 6);
            this.pnlInvoice.Margin = new System.Windows.Forms.Padding(2);
            this.pnlInvoice.Name = "pnlInvoice";
            this.pnlInvoice.Size = new System.Drawing.Size(652, 473);
            this.pnlInvoice.TabIndex = 0;
            this.pnlInvoice.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridViewSales);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.ForestGreen;
            this.groupBox1.Location = new System.Drawing.Point(0, 89);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(8);
            this.groupBox1.Size = new System.Drawing.Size(652, 376);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sales History";
            // 
            // dataGridViewSales
            // 
            this.dataGridViewSales.AllowUserToAddRows = false;
            this.dataGridViewSales.AllowUserToDeleteRows = false;
            this.dataGridViewSales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewSales.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewSales.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.ForestGreen;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.ForestGreen;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewSales.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewSales.ColumnHeadersHeight = 45;
            this.dataGridViewSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.ForestGreen;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightGreen;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewSales.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewSales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewSales.EnableHeadersVisualStyles = false;
            this.dataGridViewSales.GridColor = System.Drawing.Color.LightGray;
            this.dataGridViewSales.Location = new System.Drawing.Point(8, 27);
            this.dataGridViewSales.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewSales.Name = "dataGridViewSales";
            this.dataGridViewSales.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightGreen;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewSales.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewSales.RowHeadersVisible = false;
            this.dataGridViewSales.RowHeadersWidth = 51;
            this.dataGridViewSales.RowTemplate.Height = 28;
            this.dataGridViewSales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSales.Size = new System.Drawing.Size(636, 341);
            this.dataGridViewSales.TabIndex = 0;
          //  this.dataGridViewSales.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSales_CellContentClick);
            // 
            // groupBoxInvoice
            // 
            this.groupBoxInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxInvoice.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBoxInvoice.Controls.Add(this.rtbInvoicePreview);
            this.groupBoxInvoice.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxInvoice.ForeColor = System.Drawing.Color.ForestGreen;
            this.groupBoxInvoice.Location = new System.Drawing.Point(2, 2);
            this.groupBoxInvoice.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxInvoice.Name = "groupBoxInvoice";
            this.groupBoxInvoice.Padding = new System.Windows.Forms.Padding(11, 12, 11, 12);
            this.groupBoxInvoice.Size = new System.Drawing.Size(647, 85);
            this.groupBoxInvoice.TabIndex = 0;
            this.groupBoxInvoice.TabStop = false;
            this.groupBoxInvoice.Text = "Invoice Preview";
            // 
            // rtbInvoicePreview
            // 
            this.rtbInvoicePreview.BackColor = System.Drawing.Color.White;
            this.rtbInvoicePreview.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbInvoicePreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbInvoicePreview.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbInvoicePreview.Location = new System.Drawing.Point(11, 31);
            this.rtbInvoicePreview.Margin = new System.Windows.Forms.Padding(2);
            this.rtbInvoicePreview.Name = "rtbInvoicePreview";
            this.rtbInvoicePreview.ReadOnly = true;
            this.rtbInvoicePreview.Size = new System.Drawing.Size(625, 42);
            this.rtbInvoicePreview.TabIndex = 0;
            this.rtbInvoicePreview.Text = "";
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.ForestGreen;
            this.pnlHeader.Controls.Add(this.lblFarmerName);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1116, 60);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblFarmerName
            // 
            this.lblFarmerName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFarmerName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFarmerName.ForeColor = System.Drawing.Color.White;
            this.lblFarmerName.Location = new System.Drawing.Point(794, 18);
            this.lblFarmerName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFarmerName.Name = "lblFarmerName";
            this.lblFarmerName.Size = new System.Drawing.Size(312, 25);
            this.lblFarmerName.TabIndex = 1;
            this.lblFarmerName.Text = "Farmer Name";
            this.lblFarmerName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(11, 15);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(213, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Sell Rice Production";
            // 
            // SellPady
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "SellPady";
            this.Size = new System.Drawing.Size(1116, 604);
            this.Resize += new System.EventHandler(this.SellPady_Resize);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.panelActionButtons.ResumeLayout(false);
            this.panelSaleForm.ResumeLayout(false);
            this.groupBoxSaleDetails.ResumeLayout(false);
            this.tableLayoutPanelForm.ResumeLayout(false);
            this.tableLayoutPanelForm.PerformLayout();
            this.flowLayoutPanelButtons.ResumeLayout(false);
            this.flowLayoutPanelBuyerType.ResumeLayout(false);
            this.flowLayoutPanelBuyerType.PerformLayout();
            this.flowLayoutPanelBuyer.ResumeLayout(false);
            this.flowLayoutPanelBuyer.PerformLayout();
            this.flowLayoutPanelPrice.ResumeLayout(false);
            this.flowLayoutPanelPrice.PerformLayout();
            this.flowLayoutPanelQuantity.ResumeLayout(false);
            this.flowLayoutPanelQuantity.PerformLayout();
            this.flowLayoutPanelTotal.ResumeLayout(false);
            this.flowLayoutPanelTotal.PerformLayout();
            this.flowLayoutPanelPayment.ResumeLayout(false);
            this.flowLayoutPanelPayment.PerformLayout();
            this.panelSalesGrid.ResumeLayout(false);
            this.flowLayoutPanelInvoiceButtons.ResumeLayout(false);
            this.panelInvoice.ResumeLayout(false);
            this.pnlInvoice.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSales)).EndInit();
            this.groupBoxInvoice.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblFarmerName;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.Panel panelActionButtons;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel panelSaleForm;
        private System.Windows.Forms.GroupBox groupBoxSaleDetails;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelForm;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelButtons;
        private System.Windows.Forms.Button btnCreateSale;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblSelectedStock;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelBuyerType;
        private System.Windows.Forms.Label lblBuyerType;
        private System.Windows.Forms.ComboBox cmbBuyerType;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelBuyer;
        private System.Windows.Forms.Label lblBuyer;
        private System.Windows.Forms.ComboBox cmbBuyer;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelPrice;
        private System.Windows.Forms.Label lblSalePrice;
        private System.Windows.Forms.TextBox txtSalePrice;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelQuantity;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelTotal;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelPayment;
        private System.Windows.Forms.Label lblPaymentStatus;
        private System.Windows.Forms.ComboBox cmbPaymentStatus;
        private System.Windows.Forms.Button btnViewStock;
        private System.Windows.Forms.Panel panelSalesGrid;
        private System.Windows.Forms.Panel panelInvoice;
        private System.Windows.Forms.Panel pnlInvoice;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelInvoiceButtons;
        private System.Windows.Forms.Button btnGenerateInvoice;
        private System.Windows.Forms.Button btnSaveInvoice;
        private System.Windows.Forms.Button btnPrintInvoice;
        private System.Windows.Forms.GroupBox groupBoxInvoice;
        private System.Windows.Forms.RichTextBox rtbInvoicePreview;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridViewSales;

    }
}