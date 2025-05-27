using System.Windows.Forms;
using System;
using System.Drawing;

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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.pnlSalesHistory = new System.Windows.Forms.Panel();
            this.dataGridViewSales = new System.Windows.Forms.DataGridView();
            this.pnlSalesHeader = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnGenerateInvoice = new System.Windows.Forms.Button();
            this.lblSalesHistory = new System.Windows.Forms.Label();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.pnlInvoice = new System.Windows.Forms.Panel();
            this.pnlInvoiceContent = new System.Windows.Forms.Panel();
            this.rtbInvoicePreview = new System.Windows.Forms.RichTextBox();
            this.pnlInvoiceActions = new System.Windows.Forms.Panel();
            this.btnPrintInvoice = new System.Windows.Forms.Button();
            this.btnSaveInvoice = new System.Windows.Forms.Button();
            this.pnlInvoiceHeader = new System.Windows.Forms.Panel();
            this.lblInvoicePreview = new System.Windows.Forms.Label();
            this.pnlSaleForm = new System.Windows.Forms.Panel();
            this.pnlFormContent = new System.Windows.Forms.Panel();
            this.pnlFormRow4 = new System.Windows.Forms.Panel();
            this.pnlActions = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnCreateSale = new System.Windows.Forms.Button();
            this.pnlTotalAmount = new System.Windows.Forms.Panel();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.pnlFormRow3 = new System.Windows.Forms.Panel();
            this.pnlQuantity = new System.Windows.Forms.Panel();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.pnlSalePrice = new System.Windows.Forms.Panel();
            this.txtSalePrice = new System.Windows.Forms.TextBox();
            this.lblSalePrice = new System.Windows.Forms.Label();
            this.pnlFormRow2 = new System.Windows.Forms.Panel();
            this.pnlPaymentStatus = new System.Windows.Forms.Panel();
            this.cmbPaymentStatus = new System.Windows.Forms.ComboBox();
            this.lblPaymentStatus = new System.Windows.Forms.Label();
            this.pnlBuyerType = new System.Windows.Forms.Panel();
            this.cmbBuyerType = new System.Windows.Forms.ComboBox();
            this.lblBuyerType = new System.Windows.Forms.Label();
            this.pnlFormRow1 = new System.Windows.Forms.Panel();
            this.pnlBuyer = new System.Windows.Forms.Panel();
            this.cmbBuyer = new System.Windows.Forms.ComboBox();
            this.lblBuyer = new System.Windows.Forms.Label();
            this.pnlStock = new System.Windows.Forms.Panel();
            this.lblSelectedStock = new System.Windows.Forms.Label();
            this.btnViewStock = new System.Windows.Forms.Button();
            this.lblStock = new System.Windows.Forms.Label();
            this.pnlFormHeader = new System.Windows.Forms.Panel();
            this.lblNewSale = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlSalesHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSales)).BeginInit();
            this.pnlSalesHeader.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlInvoice.SuspendLayout();
            this.pnlInvoiceContent.SuspendLayout();
            this.pnlInvoiceActions.SuspendLayout();
            this.pnlInvoiceHeader.SuspendLayout();
            this.pnlSaleForm.SuspendLayout();
            this.pnlFormContent.SuspendLayout();
            this.pnlFormRow4.SuspendLayout();
            this.pnlActions.SuspendLayout();
            this.pnlTotalAmount.SuspendLayout();
            this.pnlFormRow3.SuspendLayout();
            this.pnlQuantity.SuspendLayout();
            this.pnlSalePrice.SuspendLayout();
            this.pnlFormRow2.SuspendLayout();
            this.pnlPaymentStatus.SuspendLayout();
            this.pnlBuyerType.SuspendLayout();
            this.pnlFormRow1.SuspendLayout();
            this.pnlBuyer.SuspendLayout();
            this.pnlStock.SuspendLayout();
            this.pnlFormHeader.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.pnlMain.Controls.Add(this.pnlContent);
            this.pnlMain.Controls.Add(this.pnlHeader);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1060, 656);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.pnlRight);
            this.pnlContent.Controls.Add(this.pnlLeft);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 52);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1060, 604);
            this.pnlContent.TabIndex = 1;
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.pnlSalesHistory);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(514, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(546, 604);
            this.pnlRight.TabIndex = 1;
            // 
            // pnlSalesHistory
            // 
            this.pnlSalesHistory.BackColor = System.Drawing.Color.White;
            this.pnlSalesHistory.Controls.Add(this.dataGridViewSales);
            this.pnlSalesHistory.Controls.Add(this.pnlSalesHeader);
            this.pnlSalesHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSalesHistory.Location = new System.Drawing.Point(0, 0);
            this.pnlSalesHistory.Name = "pnlSalesHistory";
            this.pnlSalesHistory.Size = new System.Drawing.Size(546, 604);
            this.pnlSalesHistory.TabIndex = 0;
            // 
            // dataGridViewSales
            // 
            this.dataGridViewSales.AllowUserToAddRows = false;
            this.dataGridViewSales.AllowUserToDeleteRows = false;
            this.dataGridViewSales.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewSales.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewSales.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.dataGridViewSales.Location = new System.Drawing.Point(0, 43);
            this.dataGridViewSales.MultiSelect = false;
            this.dataGridViewSales.Name = "dataGridViewSales";
            this.dataGridViewSales.ReadOnly = true;
            this.dataGridViewSales.RowHeadersVisible = false;
            this.dataGridViewSales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSales.Size = new System.Drawing.Size(546, 561);
            this.dataGridViewSales.TabIndex = 1;
            // 
            // pnlSalesHeader
            // 
            this.pnlSalesHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(34)))));
            this.pnlSalesHeader.Controls.Add(this.btnRefresh);
            this.pnlSalesHeader.Controls.Add(this.btnGenerateInvoice);
            this.pnlSalesHeader.Controls.Add(this.lblSalesHistory);
            this.pnlSalesHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSalesHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlSalesHeader.Name = "pnlSalesHeader";
            this.pnlSalesHeader.Padding = new System.Windows.Forms.Padding(17, 0, 17, 0);
            this.pnlSalesHeader.Size = new System.Drawing.Size(546, 43);
            this.pnlSalesHeader.TabIndex = 0;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(184)))), ((int)(((byte)(92)))));
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(439, 8);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(90, 26);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnGenerateInvoice
            // 
            this.btnGenerateInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerateInvoice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(184)))), ((int)(((byte)(92)))));
            this.btnGenerateInvoice.FlatAppearance.BorderSize = 0;
            this.btnGenerateInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerateInvoice.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnGenerateInvoice.ForeColor = System.Drawing.Color.White;
            this.btnGenerateInvoice.Location = new System.Drawing.Point(260, 8);
            this.btnGenerateInvoice.Name = "btnGenerateInvoice";
            this.btnGenerateInvoice.Size = new System.Drawing.Size(173, 26);
            this.btnGenerateInvoice.TabIndex = 1;
            this.btnGenerateInvoice.Text = "Generate Invoice";
            this.btnGenerateInvoice.UseVisualStyleBackColor = false;
            this.btnGenerateInvoice.Click += new System.EventHandler(this.btnGenerateInvoice_Click);
            // 
            // lblSalesHistory
            // 
            this.lblSalesHistory.AutoSize = true;
            this.lblSalesHistory.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblSalesHistory.ForeColor = System.Drawing.Color.White;
            this.lblSalesHistory.Location = new System.Drawing.Point(20, 9);
            this.lblSalesHistory.Name = "lblSalesHistory";
            this.lblSalesHistory.Size = new System.Drawing.Size(127, 25);
            this.lblSalesHistory.TabIndex = 0;
            this.lblSalesHistory.Text = "Sales History";
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.pnlInvoice);
            this.pnlLeft.Controls.Add(this.pnlSaleForm);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(514, 604);
            this.pnlLeft.TabIndex = 0;
            // 
            // pnlInvoice
            // 
            this.pnlInvoice.BackColor = System.Drawing.Color.White;
            this.pnlInvoice.Controls.Add(this.pnlInvoiceContent);
            this.pnlInvoice.Controls.Add(this.pnlInvoiceActions);
            this.pnlInvoice.Controls.Add(this.pnlInvoiceHeader);
            this.pnlInvoice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInvoice.Location = new System.Drawing.Point(0, 381);
            this.pnlInvoice.Name = "pnlInvoice";
            this.pnlInvoice.Size = new System.Drawing.Size(514, 223);
            this.pnlInvoice.TabIndex = 1;
            this.pnlInvoice.Visible = false;
            // 
            // pnlInvoiceContent
            // 
            this.pnlInvoiceContent.Controls.Add(this.rtbInvoicePreview);
            this.pnlInvoiceContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInvoiceContent.Location = new System.Drawing.Point(0, 46);
            this.pnlInvoiceContent.Name = "pnlInvoiceContent";
            this.pnlInvoiceContent.Padding = new System.Windows.Forms.Padding(17, 9, 17, 9);
            this.pnlInvoiceContent.Size = new System.Drawing.Size(514, 134);
            this.pnlInvoiceContent.TabIndex = 2;
            // 
            // rtbInvoicePreview
            // 
            this.rtbInvoicePreview.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbInvoicePreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbInvoicePreview.Font = new System.Drawing.Font("Consolas", 9F);
            this.rtbInvoicePreview.Location = new System.Drawing.Point(17, 9);
            this.rtbInvoicePreview.Name = "rtbInvoicePreview";
            this.rtbInvoicePreview.ReadOnly = true;
            this.rtbInvoicePreview.Size = new System.Drawing.Size(480, 116);
            this.rtbInvoicePreview.TabIndex = 0;
            this.rtbInvoicePreview.Text = "";
            // 
            // pnlInvoiceActions
            // 
            this.pnlInvoiceActions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.pnlInvoiceActions.Controls.Add(this.btnPrintInvoice);
            this.pnlInvoiceActions.Controls.Add(this.btnSaveInvoice);
            this.pnlInvoiceActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlInvoiceActions.Location = new System.Drawing.Point(0, 180);
            this.pnlInvoiceActions.Name = "pnlInvoiceActions";
            this.pnlInvoiceActions.Padding = new System.Windows.Forms.Padding(17, 9, 17, 9);
            this.pnlInvoiceActions.Size = new System.Drawing.Size(514, 43);
            this.pnlInvoiceActions.TabIndex = 1;
            // 
            // btnPrintInvoice
            // 
            this.btnPrintInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintInvoice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnPrintInvoice.FlatAppearance.BorderSize = 0;
            this.btnPrintInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintInvoice.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnPrintInvoice.ForeColor = System.Drawing.Color.White;
            this.btnPrintInvoice.Location = new System.Drawing.Point(419, 9);
            this.btnPrintInvoice.Name = "btnPrintInvoice";
            this.btnPrintInvoice.Size = new System.Drawing.Size(77, 26);
            this.btnPrintInvoice.TabIndex = 1;
            this.btnPrintInvoice.Text = "Print";
            this.btnPrintInvoice.UseVisualStyleBackColor = false;
            this.btnPrintInvoice.Click += new System.EventHandler(this.btnPrintInvoice_Click);
            // 
            // btnSaveInvoice
            // 
            this.btnSaveInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveInvoice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(34)))));
            this.btnSaveInvoice.FlatAppearance.BorderSize = 0;
            this.btnSaveInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveInvoice.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSaveInvoice.ForeColor = System.Drawing.Color.White;
            this.btnSaveInvoice.Location = new System.Drawing.Point(334, 9);
            this.btnSaveInvoice.Name = "btnSaveInvoice";
            this.btnSaveInvoice.Size = new System.Drawing.Size(77, 26);
            this.btnSaveInvoice.TabIndex = 0;
            this.btnSaveInvoice.Text = "Save";
            this.btnSaveInvoice.UseVisualStyleBackColor = false;
            this.btnSaveInvoice.Click += new System.EventHandler(this.btnSaveInvoice_Click);
            // 
            // pnlInvoiceHeader
            // 
            this.pnlInvoiceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(34)))));
            this.pnlInvoiceHeader.Controls.Add(this.lblInvoicePreview);
            this.pnlInvoiceHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInvoiceHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlInvoiceHeader.Name = "pnlInvoiceHeader";
            this.pnlInvoiceHeader.Padding = new System.Windows.Forms.Padding(17, 0, 17, 0);
            this.pnlInvoiceHeader.Size = new System.Drawing.Size(514, 46);
            this.pnlInvoiceHeader.TabIndex = 0;
            // 
            // lblInvoicePreview
            // 
            this.lblInvoicePreview.AutoSize = true;
            this.lblInvoicePreview.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblInvoicePreview.ForeColor = System.Drawing.Color.White;
            this.lblInvoicePreview.Location = new System.Drawing.Point(17, 13);
            this.lblInvoicePreview.Name = "lblInvoicePreview";
            this.lblInvoicePreview.Size = new System.Drawing.Size(131, 21);
            this.lblInvoicePreview.TabIndex = 0;
            this.lblInvoicePreview.Text = "Invoice Preview";
            // 
            // pnlSaleForm
            // 
            this.pnlSaleForm.BackColor = System.Drawing.Color.White;
            this.pnlSaleForm.Controls.Add(this.pnlFormContent);
            this.pnlSaleForm.Controls.Add(this.pnlFormHeader);
            this.pnlSaleForm.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSaleForm.Location = new System.Drawing.Point(0, 0);
            this.pnlSaleForm.Name = "pnlSaleForm";
            this.pnlSaleForm.Size = new System.Drawing.Size(514, 381);
            this.pnlSaleForm.TabIndex = 0;
            // 
            // pnlFormContent
            // 
            this.pnlFormContent.Controls.Add(this.pnlActions);
            this.pnlFormContent.Controls.Add(this.pnlFormRow4);
            this.pnlFormContent.Controls.Add(this.pnlFormRow3);
            this.pnlFormContent.Controls.Add(this.pnlFormRow2);
            this.pnlFormContent.Controls.Add(this.pnlFormRow1);
            this.pnlFormContent.Location = new System.Drawing.Point(0, 43);
            this.pnlFormContent.Name = "pnlFormContent";
            this.pnlFormContent.Padding = new System.Windows.Forms.Padding(17);
            this.pnlFormContent.Size = new System.Drawing.Size(514, 338);
            this.pnlFormContent.TabIndex = 1;
            // 
            // pnlFormRow4
            // 
            this.pnlFormRow4.Controls.Add(this.pnlQuantity);
            this.pnlFormRow4.Controls.Add(this.pnlTotalAmount);
            this.pnlFormRow4.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFormRow4.Location = new System.Drawing.Point(17, 212);
            this.pnlFormRow4.Name = "pnlFormRow4";
            this.pnlFormRow4.Size = new System.Drawing.Size(480, 69);
            this.pnlFormRow4.TabIndex = 3;
            // 
            // pnlActions
            // 
            this.pnlActions.Controls.Add(this.btnClear);
            this.pnlActions.Controls.Add(this.btnCreateSale);
            this.pnlActions.Location = new System.Drawing.Point(15, 287);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Padding = new System.Windows.Forms.Padding(9, 22, 0, 0);
            this.pnlActions.Size = new System.Drawing.Size(217, 58);
            this.pnlActions.TabIndex = 1;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.btnClear.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(212)))), ((int)(((byte)(218)))));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.btnClear.Location = new System.Drawing.Point(109, 0);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(94, 35);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnCreateSale
            // 
            this.btnCreateSale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(34)))));
            this.btnCreateSale.FlatAppearance.BorderSize = 0;
            this.btnCreateSale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateSale.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCreateSale.ForeColor = System.Drawing.Color.White;
            this.btnCreateSale.Location = new System.Drawing.Point(0, 0);
            this.btnCreateSale.Name = "btnCreateSale";
            this.btnCreateSale.Size = new System.Drawing.Size(103, 35);
            this.btnCreateSale.TabIndex = 0;
            this.btnCreateSale.Text = "Create Sale";
            this.btnCreateSale.UseVisualStyleBackColor = false;
            this.btnCreateSale.Click += new System.EventHandler(this.btnCreateSale_Click);
            // 
            // pnlTotalAmount
            // 
            this.pnlTotalAmount.Controls.Add(this.txtTotalAmount);
            this.pnlTotalAmount.Controls.Add(this.lblTotalAmount);
            this.pnlTotalAmount.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlTotalAmount.Location = new System.Drawing.Point(0, 0);
            this.pnlTotalAmount.Name = "pnlTotalAmount";
            this.pnlTotalAmount.Size = new System.Drawing.Size(236, 69);
            this.pnlTotalAmount.TabIndex = 0;
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.txtTotalAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalAmount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txtTotalAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(34)))));
            this.txtTotalAmount.Location = new System.Drawing.Point(0, 35);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.ReadOnly = true;
            this.txtTotalAmount.Size = new System.Drawing.Size(215, 29);
            this.txtTotalAmount.TabIndex = 1;
            this.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.lblTotalAmount.Location = new System.Drawing.Point(0, 9);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(99, 19);
            this.lblTotalAmount.TabIndex = 0;
            this.lblTotalAmount.Text = "Total Amount";
            // 
            // pnlFormRow3
            // 
            this.pnlFormRow3.Controls.Add(this.pnlPaymentStatus);
            this.pnlFormRow3.Controls.Add(this.pnlSalePrice);
            this.pnlFormRow3.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFormRow3.Location = new System.Drawing.Point(17, 143);
            this.pnlFormRow3.Name = "pnlFormRow3";
            this.pnlFormRow3.Size = new System.Drawing.Size(480, 69);
            this.pnlFormRow3.TabIndex = 2;
            // 
            // pnlQuantity
            // 
            this.pnlQuantity.Controls.Add(this.txtQuantity);
            this.pnlQuantity.Controls.Add(this.lblQuantity);
            this.pnlQuantity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlQuantity.Location = new System.Drawing.Point(236, 0);
            this.pnlQuantity.Name = "pnlQuantity";
            this.pnlQuantity.Size = new System.Drawing.Size(244, 69);
            this.pnlQuantity.TabIndex = 1;
            // 
            // txtQuantity
            // 
            this.txtQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQuantity.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtQuantity.Location = new System.Drawing.Point(14, 36);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(215, 27);
            this.txtQuantity.TabIndex = 1;
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblQuantity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.lblQuantity.Location = new System.Drawing.Point(10, 9);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(90, 19);
            this.lblQuantity.TabIndex = 0;
            this.lblQuantity.Text = "Quantity (kg)";
            // 
            // pnlSalePrice
            // 
            this.pnlSalePrice.Controls.Add(this.txtSalePrice);
            this.pnlSalePrice.Controls.Add(this.lblSalePrice);
            this.pnlSalePrice.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSalePrice.Location = new System.Drawing.Point(0, 0);
            this.pnlSalePrice.Name = "pnlSalePrice";
            this.pnlSalePrice.Size = new System.Drawing.Size(236, 69);
            this.pnlSalePrice.TabIndex = 0;
            // 
            // txtSalePrice
            // 
            this.txtSalePrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSalePrice.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtSalePrice.Location = new System.Drawing.Point(0, 35);
            this.txtSalePrice.Name = "txtSalePrice";
            this.txtSalePrice.Size = new System.Drawing.Size(215, 27);
            this.txtSalePrice.TabIndex = 1;
            // 
            // lblSalePrice
            // 
            this.lblSalePrice.AutoSize = true;
            this.lblSalePrice.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSalePrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.lblSalePrice.Location = new System.Drawing.Point(0, 9);
            this.lblSalePrice.Name = "lblSalePrice";
            this.lblSalePrice.Size = new System.Drawing.Size(98, 19);
            this.lblSalePrice.TabIndex = 0;
            this.lblSalePrice.Text = "Sale Price (/kg)";
            // 
            // pnlFormRow2
            // 
            this.pnlFormRow2.Controls.Add(this.pnlBuyer);
            this.pnlFormRow2.Controls.Add(this.pnlBuyerType);
            this.pnlFormRow2.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFormRow2.Location = new System.Drawing.Point(17, 74);
            this.pnlFormRow2.Name = "pnlFormRow2";
            this.pnlFormRow2.Size = new System.Drawing.Size(480, 69);
            this.pnlFormRow2.TabIndex = 1;
            // 
            // pnlPaymentStatus
            // 
            this.pnlPaymentStatus.Controls.Add(this.cmbPaymentStatus);
            this.pnlPaymentStatus.Controls.Add(this.lblPaymentStatus);
            this.pnlPaymentStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPaymentStatus.Location = new System.Drawing.Point(236, 0);
            this.pnlPaymentStatus.Name = "pnlPaymentStatus";
            this.pnlPaymentStatus.Size = new System.Drawing.Size(244, 69);
            this.pnlPaymentStatus.TabIndex = 1;
            // 
            // cmbPaymentStatus
            // 
            this.cmbPaymentStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaymentStatus.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbPaymentStatus.FormattingEnabled = true;
            this.cmbPaymentStatus.Location = new System.Drawing.Point(14, 35);
            this.cmbPaymentStatus.Name = "cmbPaymentStatus";
            this.cmbPaymentStatus.Size = new System.Drawing.Size(215, 28);
            this.cmbPaymentStatus.TabIndex = 1;
            // 
            // lblPaymentStatus
            // 
            this.lblPaymentStatus.AutoSize = true;
            this.lblPaymentStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPaymentStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.lblPaymentStatus.Location = new System.Drawing.Point(10, 9);
            this.lblPaymentStatus.Name = "lblPaymentStatus";
            this.lblPaymentStatus.Size = new System.Drawing.Size(105, 19);
            this.lblPaymentStatus.TabIndex = 0;
            this.lblPaymentStatus.Text = "Payment Status";
            // 
            // pnlBuyerType
            // 
            this.pnlBuyerType.Controls.Add(this.cmbBuyerType);
            this.pnlBuyerType.Controls.Add(this.lblBuyerType);
            this.pnlBuyerType.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlBuyerType.Location = new System.Drawing.Point(0, 0);
            this.pnlBuyerType.Name = "pnlBuyerType";
            this.pnlBuyerType.Size = new System.Drawing.Size(236, 69);
            this.pnlBuyerType.TabIndex = 0;
            // 
            // cmbBuyerType
            // 
            this.cmbBuyerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBuyerType.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbBuyerType.FormattingEnabled = true;
            this.cmbBuyerType.Location = new System.Drawing.Point(0, 35);
            this.cmbBuyerType.Name = "cmbBuyerType";
            this.cmbBuyerType.Size = new System.Drawing.Size(215, 28);
            this.cmbBuyerType.TabIndex = 1;
            // 
            // lblBuyerType
            // 
            this.lblBuyerType.AutoSize = true;
            this.lblBuyerType.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblBuyerType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.lblBuyerType.Location = new System.Drawing.Point(0, 9);
            this.lblBuyerType.Name = "lblBuyerType";
            this.lblBuyerType.Size = new System.Drawing.Size(76, 19);
            this.lblBuyerType.TabIndex = 0;
            this.lblBuyerType.Text = "Buyer Type";
            // 
            // pnlFormRow1
            // 
            this.pnlFormRow1.Controls.Add(this.pnlStock);
            this.pnlFormRow1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFormRow1.Location = new System.Drawing.Point(17, 17);
            this.pnlFormRow1.Name = "pnlFormRow1";
            this.pnlFormRow1.Size = new System.Drawing.Size(480, 57);
            this.pnlFormRow1.TabIndex = 0;
            // 
            // pnlBuyer
            // 
            this.pnlBuyer.Controls.Add(this.cmbBuyer);
            this.pnlBuyer.Controls.Add(this.lblBuyer);
            this.pnlBuyer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBuyer.Location = new System.Drawing.Point(236, 0);
            this.pnlBuyer.Name = "pnlBuyer";
            this.pnlBuyer.Size = new System.Drawing.Size(244, 69);
            this.pnlBuyer.TabIndex = 1;
            // 
            // cmbBuyer
            // 
            this.cmbBuyer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBuyer.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbBuyer.FormattingEnabled = true;
            this.cmbBuyer.Location = new System.Drawing.Point(14, 35);
            this.cmbBuyer.Name = "cmbBuyer";
            this.cmbBuyer.Size = new System.Drawing.Size(215, 28);
            this.cmbBuyer.TabIndex = 1;
            // 
            // lblBuyer
            // 
            this.lblBuyer.AutoSize = true;
            this.lblBuyer.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblBuyer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.lblBuyer.Location = new System.Drawing.Point(10, 13);
            this.lblBuyer.Name = "lblBuyer";
            this.lblBuyer.Size = new System.Drawing.Size(44, 19);
            this.lblBuyer.TabIndex = 0;
            this.lblBuyer.Text = "Buyer";
            // 
            // pnlStock
            // 
            this.pnlStock.Controls.Add(this.lblSelectedStock);
            this.pnlStock.Controls.Add(this.btnViewStock);
            this.pnlStock.Controls.Add(this.lblStock);
            this.pnlStock.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlStock.Location = new System.Drawing.Point(0, 0);
            this.pnlStock.Name = "pnlStock";
            this.pnlStock.Size = new System.Drawing.Size(480, 57);
            this.pnlStock.TabIndex = 0;
            // 
            // lblSelectedStock
            // 
            this.lblSelectedStock.AutoSize = true;
            this.lblSelectedStock.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblSelectedStock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(34)))));
            this.lblSelectedStock.Location = new System.Drawing.Point(119, 29);
            this.lblSelectedStock.Name = "lblSelectedStock";
            this.lblSelectedStock.Size = new System.Drawing.Size(53, 13);
            this.lblSelectedStock.TabIndex = 2;
            this.lblSelectedStock.Text = "Selected:";
            this.lblSelectedStock.Visible = false;
            // 
            // btnViewStock
            // 
            this.btnViewStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(34)))));
            this.btnViewStock.FlatAppearance.BorderSize = 0;
            this.btnViewStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewStock.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnViewStock.ForeColor = System.Drawing.Color.White;
            this.btnViewStock.Location = new System.Drawing.Point(0, 22);
            this.btnViewStock.Name = "btnViewStock";
            this.btnViewStock.Size = new System.Drawing.Size(103, 26);
            this.btnViewStock.TabIndex = 1;
            this.btnViewStock.Text = "View My Stock";
            this.btnViewStock.UseVisualStyleBackColor = false;
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblStock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.lblStock.Location = new System.Drawing.Point(-4, 0);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(81, 19);
            this.lblStock.TabIndex = 0;
            this.lblStock.Text = "Select Stock";
            // 
            // pnlFormHeader
            // 
            this.pnlFormHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(34)))));
            this.pnlFormHeader.Controls.Add(this.lblNewSale);
            this.pnlFormHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFormHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlFormHeader.Name = "pnlFormHeader";
            this.pnlFormHeader.Padding = new System.Windows.Forms.Padding(17, 0, 17, 0);
            this.pnlFormHeader.Size = new System.Drawing.Size(514, 43);
            this.pnlFormHeader.TabIndex = 0;
            // 
            // lblNewSale
            // 
            this.lblNewSale.AutoSize = true;
            this.lblNewSale.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblNewSale.ForeColor = System.Drawing.Color.White;
            this.lblNewSale.Location = new System.Drawing.Point(17, 13);
            this.lblNewSale.Name = "lblNewSale";
            this.lblNewSale.Size = new System.Drawing.Size(134, 21);
            this.lblNewSale.TabIndex = 0;
            this.lblNewSale.Text = "Create New Sale";
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(34)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(17, 0, 17, 0);
            this.pnlHeader.Size = new System.Drawing.Size(1060, 52);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(17, 14);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(159, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Sell Rice/Pady";
            // 
            // SellPady
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlMain);
            this.Name = "SellPady";
            this.Size = new System.Drawing.Size(1060, 656);
            this.Load += new System.EventHandler(this.SellPady_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            this.pnlSalesHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSales)).EndInit();
            this.pnlSalesHeader.ResumeLayout(false);
            this.pnlSalesHeader.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            this.pnlInvoice.ResumeLayout(false);
            this.pnlInvoiceContent.ResumeLayout(false);
            this.pnlInvoiceActions.ResumeLayout(false);
            this.pnlInvoiceHeader.ResumeLayout(false);
            this.pnlInvoiceHeader.PerformLayout();
            this.pnlSaleForm.ResumeLayout(false);
            this.pnlFormContent.ResumeLayout(false);
            this.pnlFormRow4.ResumeLayout(false);
            this.pnlActions.ResumeLayout(false);
            this.pnlTotalAmount.ResumeLayout(false);
            this.pnlTotalAmount.PerformLayout();
            this.pnlFormRow3.ResumeLayout(false);
            this.pnlQuantity.ResumeLayout(false);
            this.pnlQuantity.PerformLayout();
            this.pnlSalePrice.ResumeLayout(false);
            this.pnlSalePrice.PerformLayout();
            this.pnlFormRow2.ResumeLayout(false);
            this.pnlPaymentStatus.ResumeLayout(false);
            this.pnlPaymentStatus.PerformLayout();
            this.pnlBuyerType.ResumeLayout(false);
            this.pnlBuyerType.PerformLayout();
            this.pnlFormRow1.ResumeLayout(false);
            this.pnlBuyer.ResumeLayout(false);
            this.pnlBuyer.PerformLayout();
            this.pnlStock.ResumeLayout(false);
            this.pnlStock.PerformLayout();
            this.pnlFormHeader.ResumeLayout(false);
            this.pnlFormHeader.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlSalesHistory;
        private System.Windows.Forms.DataGridView dataGridViewSales;
        private System.Windows.Forms.Panel pnlSalesHeader;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnGenerateInvoice;
        private System.Windows.Forms.Label lblSalesHistory;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlInvoice;
        private System.Windows.Forms.Panel pnlInvoiceContent;
        private System.Windows.Forms.RichTextBox rtbInvoicePreview;
        private System.Windows.Forms.Panel pnlInvoiceActions;
        private System.Windows.Forms.Button btnPrintInvoice;
        private System.Windows.Forms.Button btnSaveInvoice;
        private System.Windows.Forms.Panel pnlInvoiceHeader;
        private System.Windows.Forms.Label lblInvoicePreview;
        private System.Windows.Forms.Panel pnlSaleForm;
        private System.Windows.Forms.Panel pnlFormContent;
        private System.Windows.Forms.Panel pnlFormRow4;
        private System.Windows.Forms.Panel pnlActions;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnCreateSale;
        private System.Windows.Forms.Panel pnlTotalAmount;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Panel pnlFormRow3;
        private System.Windows.Forms.Panel pnlQuantity;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Panel pnlSalePrice;
        private System.Windows.Forms.TextBox txtSalePrice;
        private System.Windows.Forms.Label lblSalePrice;
        private System.Windows.Forms.Panel pnlFormRow2;
        private System.Windows.Forms.Panel pnlPaymentStatus;
        private System.Windows.Forms.ComboBox cmbPaymentStatus;
        private System.Windows.Forms.Label lblPaymentStatus;
        private System.Windows.Forms.Panel pnlBuyerType;
        private System.Windows.Forms.ComboBox cmbBuyerType;
        private System.Windows.Forms.Label lblBuyerType;
        private System.Windows.Forms.Panel pnlFormRow1;
        private System.Windows.Forms.Panel pnlBuyer;
        private System.Windows.Forms.ComboBox cmbBuyer;
        private System.Windows.Forms.Label lblBuyer;
        private System.Windows.Forms.Panel pnlStock;
        private System.Windows.Forms.Label lblSelectedStock;
        private System.Windows.Forms.Button btnViewStock;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.Panel pnlFormHeader;
        private System.Windows.Forms.Label lblNewSale;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;

    }
}