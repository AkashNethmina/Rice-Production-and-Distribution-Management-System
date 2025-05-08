using System;

namespace RiceMgmtApp
{
    partial class BuyPaddy
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.pnlInvoice = new System.Windows.Forms.Panel();
            this.groupBoxInvoice = new System.Windows.Forms.GroupBox();
            this.rtbInvoicePreview = new System.Windows.Forms.RichTextBox();
            this.pnlInvoiceButtons = new System.Windows.Forms.Panel();
            this.btnSaveInvoice = new System.Windows.Forms.Button();
            this.btnPrintInvoice = new System.Windows.Forms.Button();
            this.panelSalesGrid = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridViewSales = new System.Windows.Forms.DataGridView();
            this.btnGenerateInvoice = new System.Windows.Forms.Button();
            this.flowLayoutPanelBuyerType = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanelBuyer = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanelInvoiceButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.panelInvoice = new System.Windows.Forms.Panel();
            this.dataGridViewPurchases = new System.Windows.Forms.DataGridView();
            this.lblInvoicePreview = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblInvoiceTotalValue = new System.Windows.Forms.Label();
            this.lblInvoiceTotal = new System.Windows.Forms.Label();
            this.lblInvoicePaymentStatusValue = new System.Windows.Forms.Label();
            this.lblInvoicePaymentStatus = new System.Windows.Forms.Label();
            this.lblInvoiceBuyerName = new System.Windows.Forms.Label();
            this.lblInvoiceBuyer = new System.Windows.Forms.Label();
            this.lblInvoiceDateValue = new System.Windows.Forms.Label();
            this.lblInvoiceDate = new System.Windows.Forms.Label();
            this.lblInvoiceNumber = new System.Windows.Forms.Label();
            this.lblInvoiceTitle = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlInvoice.SuspendLayout();
            this.groupBoxInvoice.SuspendLayout();
            this.pnlInvoiceButtons.SuspendLayout();
            this.panelSalesGrid.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPurchases)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.pnlHeader.Controls.Add(this.lblHeader);
            this.pnlHeader.Location = new System.Drawing.Point(7, 7);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1060, 65);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblHeader
            // 
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(3, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblHeader.Size = new System.Drawing.Size(1057, 65);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Buy Paddy";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlInvoice
            // 
            this.pnlInvoice.AutoScroll = true;
            this.pnlInvoice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.pnlInvoice.Controls.Add(this.groupBoxInvoice);
            this.pnlInvoice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInvoice.Location = new System.Drawing.Point(3, 11);
            this.pnlInvoice.Name = "pnlInvoice";
            this.pnlInvoice.Padding = new System.Windows.Forms.Padding(10);
            this.pnlInvoice.Size = new System.Drawing.Size(1043, 290);
            this.pnlInvoice.TabIndex = 1;
            this.pnlInvoice.Visible = false;
            // 
            // groupBoxInvoice
            // 
            this.groupBoxInvoice.Controls.Add(this.rtbInvoicePreview);
            this.groupBoxInvoice.Controls.Add(this.pnlInvoiceButtons);
            this.groupBoxInvoice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxInvoice.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.groupBoxInvoice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.groupBoxInvoice.Location = new System.Drawing.Point(10, 10);
            this.groupBoxInvoice.Name = "groupBoxInvoice";
            this.groupBoxInvoice.Padding = new System.Windows.Forms.Padding(10);
            this.groupBoxInvoice.Size = new System.Drawing.Size(1023, 270);
            this.groupBoxInvoice.TabIndex = 0;
            this.groupBoxInvoice.TabStop = false;
            this.groupBoxInvoice.Text = "Invoice Preview";
            // 
            // rtbInvoicePreview
            // 
            this.rtbInvoicePreview.BackColor = System.Drawing.Color.White;
            this.rtbInvoicePreview.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbInvoicePreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbInvoicePreview.Font = new System.Drawing.Font("Consolas", 9F);
            this.rtbInvoicePreview.Location = new System.Drawing.Point(10, 32);
            this.rtbInvoicePreview.Name = "rtbInvoicePreview";
            this.rtbInvoicePreview.ReadOnly = true;
            this.rtbInvoicePreview.Size = new System.Drawing.Size(1003, 178);
            this.rtbInvoicePreview.TabIndex = 0;
            this.rtbInvoicePreview.Text = "";
            // 
            // pnlInvoiceButtons
            // 
            this.pnlInvoiceButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.pnlInvoiceButtons.Controls.Add(this.btnSaveInvoice);
            this.pnlInvoiceButtons.Controls.Add(this.btnPrintInvoice);
            this.pnlInvoiceButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlInvoiceButtons.Location = new System.Drawing.Point(10, 210);
            this.pnlInvoiceButtons.Name = "pnlInvoiceButtons";
            this.pnlInvoiceButtons.Size = new System.Drawing.Size(1003, 50);
            this.pnlInvoiceButtons.TabIndex = 1;
            // 
            // btnSaveInvoice
            // 
            this.btnSaveInvoice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnSaveInvoice.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveInvoice.FlatAppearance.BorderSize = 0;
            this.btnSaveInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveInvoice.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnSaveInvoice.ForeColor = System.Drawing.Color.White;
            this.btnSaveInvoice.Location = new System.Drawing.Point(10, 10);
            this.btnSaveInvoice.Name = "btnSaveInvoice";
            this.btnSaveInvoice.Size = new System.Drawing.Size(130, 35);
            this.btnSaveInvoice.TabIndex = 0;
            this.btnSaveInvoice.Text = "Save Invoice";
            this.btnSaveInvoice.UseVisualStyleBackColor = false;
            this.btnSaveInvoice.Click += new System.EventHandler(this.btnSaveInvoice_Click);
            // 
            // btnPrintInvoice
            // 
            this.btnPrintInvoice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnPrintInvoice.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrintInvoice.FlatAppearance.BorderSize = 0;
            this.btnPrintInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintInvoice.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnPrintInvoice.ForeColor = System.Drawing.Color.White;
            this.btnPrintInvoice.Location = new System.Drawing.Point(150, 10);
            this.btnPrintInvoice.Name = "btnPrintInvoice";
            this.btnPrintInvoice.Size = new System.Drawing.Size(130, 35);
            this.btnPrintInvoice.TabIndex = 1;
            this.btnPrintInvoice.Text = "Print Invoice";
            this.btnPrintInvoice.UseVisualStyleBackColor = false;
            this.btnPrintInvoice.Click += new System.EventHandler(this.btnPrintInvoice_Click);
            // 
            // panelSalesGrid
            // 
            this.panelSalesGrid.BackColor = System.Drawing.Color.White;
            this.panelSalesGrid.Controls.Add(this.groupBox1);
            this.panelSalesGrid.Location = new System.Drawing.Point(18, 78);
            this.panelSalesGrid.Name = "panelSalesGrid";
            this.panelSalesGrid.Padding = new System.Windows.Forms.Padding(10);
            this.panelSalesGrid.Size = new System.Drawing.Size(1049, 314);
            this.panelSalesGrid.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dataGridViewSales);
            this.groupBox1.Controls.Add(this.btnGenerateInvoice);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox1.Size = new System.Drawing.Size(1026, 294);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Purchase History";
            // 
            // dataGridViewSales
            // 
            this.dataGridViewSales.AllowUserToAddRows = false;
            this.dataGridViewSales.AllowUserToDeleteRows = false;
            this.dataGridViewSales.AllowUserToResizeRows = false;
            this.dataGridViewSales.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewSales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewSales.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewSales.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewSales.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridViewSales.Location = new System.Drawing.Point(0, 35);
            this.dataGridViewSales.MultiSelect = false;
            this.dataGridViewSales.Name = "dataGridViewSales";
            this.dataGridViewSales.ReadOnly = true;
            this.dataGridViewSales.RowHeadersVisible = false;
            this.dataGridViewSales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSales.Size = new System.Drawing.Size(1013, 189);
            this.dataGridViewSales.TabIndex = 0;
            // 
            // btnGenerateInvoice
            // 
            this.btnGenerateInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGenerateInvoice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnGenerateInvoice.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerateInvoice.FlatAppearance.BorderSize = 0;
            this.btnGenerateInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerateInvoice.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnGenerateInvoice.ForeColor = System.Drawing.Color.White;
            this.btnGenerateInvoice.Location = new System.Drawing.Point(-2, 246);
            this.btnGenerateInvoice.Name = "btnGenerateInvoice";
            this.btnGenerateInvoice.Size = new System.Drawing.Size(150, 35);
            this.btnGenerateInvoice.TabIndex = 1;
            this.btnGenerateInvoice.Text = "Generate Invoice";
            this.btnGenerateInvoice.UseVisualStyleBackColor = false;
            this.btnGenerateInvoice.Click += new System.EventHandler(this.btnGenerateInvoice_Click);
            // 
            // flowLayoutPanelBuyerType
            // 
            this.flowLayoutPanelBuyerType.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelBuyerType.Name = "flowLayoutPanelBuyerType";
            this.flowLayoutPanelBuyerType.Size = new System.Drawing.Size(200, 100);
            this.flowLayoutPanelBuyerType.TabIndex = 0;
            // 
            // flowLayoutPanelBuyer
            // 
            this.flowLayoutPanelBuyer.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelBuyer.Name = "flowLayoutPanelBuyer";
            this.flowLayoutPanelBuyer.Size = new System.Drawing.Size(200, 100);
            this.flowLayoutPanelBuyer.TabIndex = 0;
            // 
            // flowLayoutPanelInvoiceButtons
            // 
            this.flowLayoutPanelInvoiceButtons.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelInvoiceButtons.Name = "flowLayoutPanelInvoiceButtons";
            this.flowLayoutPanelInvoiceButtons.Size = new System.Drawing.Size(200, 100);
            this.flowLayoutPanelInvoiceButtons.TabIndex = 0;
            // 
            // panelInvoice
            // 
            this.panelInvoice.Location = new System.Drawing.Point(0, 0);
            this.panelInvoice.Name = "panelInvoice";
            this.panelInvoice.Size = new System.Drawing.Size(200, 100);
            this.panelInvoice.TabIndex = 0;
            // 
            // dataGridViewPurchases
            // 
            this.dataGridViewPurchases.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewPurchases.Name = "dataGridViewPurchases";
            this.dataGridViewPurchases.Size = new System.Drawing.Size(240, 150);
            this.dataGridViewPurchases.TabIndex = 0;
            // 
            // lblInvoicePreview
            // 
            this.lblInvoicePreview.Location = new System.Drawing.Point(0, 0);
            this.lblInvoicePreview.Name = "lblInvoicePreview";
            this.lblInvoicePreview.Size = new System.Drawing.Size(100, 23);
            this.lblInvoicePreview.TabIndex = 0;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(0, 0);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(0, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.pnlInvoice, 0, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(18, 398);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1049, 304);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // lblInvoiceTotalValue
            // 
            this.lblInvoiceTotalValue.AutoSize = true;
            this.lblInvoiceTotalValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblInvoiceTotalValue.Location = new System.Drawing.Point(100, 150);
            this.lblInvoiceTotalValue.Name = "lblInvoiceTotalValue";
            this.lblInvoiceTotalValue.Size = new System.Drawing.Size(38, 15);
            this.lblInvoiceTotalValue.TabIndex = 9;
            this.lblInvoiceTotalValue.Text = "₹0.00";
            // 
            // lblInvoiceTotal
            // 
            this.lblInvoiceTotal.AutoSize = true;
            this.lblInvoiceTotal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblInvoiceTotal.Location = new System.Drawing.Point(10, 150);
            this.lblInvoiceTotal.Name = "lblInvoiceTotal";
            this.lblInvoiceTotal.Size = new System.Drawing.Size(88, 15);
            this.lblInvoiceTotal.TabIndex = 8;
            this.lblInvoiceTotal.Text = "Total Amount: ";
            // 
            // lblInvoicePaymentStatusValue
            // 
            this.lblInvoicePaymentStatusValue.AutoSize = true;
            this.lblInvoicePaymentStatusValue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblInvoicePaymentStatusValue.Location = new System.Drawing.Point(100, 110);
            this.lblInvoicePaymentStatusValue.Name = "lblInvoicePaymentStatusValue";
            this.lblInvoicePaymentStatusValue.Size = new System.Drawing.Size(97, 15);
            this.lblInvoicePaymentStatusValue.TabIndex = 7;
            this.lblInvoicePaymentStatusValue.Text = "[Payment Status]";
            // 
            // lblInvoicePaymentStatus
            // 
            this.lblInvoicePaymentStatus.AutoSize = true;
            this.lblInvoicePaymentStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblInvoicePaymentStatus.Location = new System.Drawing.Point(10, 110);
            this.lblInvoicePaymentStatus.Name = "lblInvoicePaymentStatus";
            this.lblInvoicePaymentStatus.Size = new System.Drawing.Size(95, 15);
            this.lblInvoicePaymentStatus.TabIndex = 6;
            this.lblInvoicePaymentStatus.Text = "Payment Status: ";
            // 
            // lblInvoiceBuyerName
            // 
            this.lblInvoiceBuyerName.AutoSize = true;
            this.lblInvoiceBuyerName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblInvoiceBuyerName.Location = new System.Drawing.Point(100, 90);
            this.lblInvoiceBuyerName.Name = "lblInvoiceBuyerName";
            this.lblInvoiceBuyerName.Size = new System.Drawing.Size(87, 15);
            this.lblInvoiceBuyerName.TabIndex = 5;
            this.lblInvoiceBuyerName.Text = "[Farmer Name]";
            // 
            // lblInvoiceBuyer
            // 
            this.lblInvoiceBuyer.AutoSize = true;
            this.lblInvoiceBuyer.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblInvoiceBuyer.Location = new System.Drawing.Point(10, 90);
            this.lblInvoiceBuyer.Name = "lblInvoiceBuyer";
            this.lblInvoiceBuyer.Size = new System.Drawing.Size(50, 15);
            this.lblInvoiceBuyer.TabIndex = 4;
            this.lblInvoiceBuyer.Text = "Farmer: ";
            // 
            // lblInvoiceDateValue
            // 
            this.lblInvoiceDateValue.AutoSize = true;
            this.lblInvoiceDateValue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblInvoiceDateValue.Location = new System.Drawing.Point(100, 70);
            this.lblInvoiceDateValue.Name = "lblInvoiceDateValue";
            this.lblInvoiceDateValue.Size = new System.Drawing.Size(39, 15);
            this.lblInvoiceDateValue.TabIndex = 3;
            this.lblInvoiceDateValue.Text = "[Date]";
            // 
            // lblInvoiceDate
            // 
            this.lblInvoiceDate.AutoSize = true;
            this.lblInvoiceDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblInvoiceDate.Location = new System.Drawing.Point(10, 70);
            this.lblInvoiceDate.Name = "lblInvoiceDate";
            this.lblInvoiceDate.Size = new System.Drawing.Size(37, 15);
            this.lblInvoiceDate.TabIndex = 2;
            this.lblInvoiceDate.Text = "Date: ";
            // 
            // lblInvoiceNumber
            // 
            this.lblInvoiceNumber.AutoSize = true;
            this.lblInvoiceNumber.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblInvoiceNumber.Location = new System.Drawing.Point(10, 50);
            this.lblInvoiceNumber.Name = "lblInvoiceNumber";
            this.lblInvoiceNumber.Size = new System.Drawing.Size(61, 15);
            this.lblInvoiceNumber.TabIndex = 1;
            this.lblInvoiceNumber.Text = "Invoice #: ";
            // 
            // lblInvoiceTitle
            // 
            this.lblInvoiceTitle.AutoSize = true;
            this.lblInvoiceTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblInvoiceTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.lblInvoiceTitle.Location = new System.Drawing.Point(10, 10);
            this.lblInvoiceTitle.Name = "lblInvoiceTitle";
            this.lblInvoiceTitle.Size = new System.Drawing.Size(192, 25);
            this.lblInvoiceTitle.TabIndex = 0;
            this.lblInvoiceTitle.Text = "PURCHASE INVOICE";
            // 
            // BuyPaddy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.panelSalesGrid);
            this.Name = "BuyPaddy";
            this.Padding = new System.Windows.Forms.Padding(15);
            this.Size = new System.Drawing.Size(1085, 709);
            this.pnlHeader.ResumeLayout(false);
            this.pnlInvoice.ResumeLayout(false);
            this.groupBoxInvoice.ResumeLayout(false);
            this.pnlInvoiceButtons.ResumeLayout(false);
            this.panelSalesGrid.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPurchases)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

       

     

        

        private void PopulateInvoicePreview()
        {
            // In a real app, this would populate the invoice with actual data
            // For now, just show some placeholder text
            rtbInvoicePreview.Clear();
            rtbInvoicePreview.AppendText("PURCHASE INVOICE\n\n");
            rtbInvoicePreview.AppendText("Invoice #: INV-" + DateTime.Now.ToString("yyyyMMdd") + "\n");
            rtbInvoicePreview.AppendText("Date: " + DateTime.Now.ToString("dd/MM/yyyy") + "\n\n");

            if (dataGridViewSales.SelectedRows.Count > 0)
            {
                rtbInvoicePreview.AppendText("Farmer: " + dataGridViewSales.SelectedRows[0].Cells["FarmerName"].Value.ToString() + "\n");
                rtbInvoicePreview.AppendText("Quantity: " + dataGridViewSales.SelectedRows[0].Cells["Quantity"].Value.ToString() + " kg\n");
                rtbInvoicePreview.AppendText("Price per kg: ₹" + dataGridViewSales.SelectedRows[0].Cells["Price"].Value.ToString() + "\n");
                rtbInvoicePreview.AppendText("Total Amount: ₹" + dataGridViewSales.SelectedRows[0].Cells["Total"].Value.ToString() + "\n");
                rtbInvoicePreview.AppendText("Payment Status: " + dataGridViewSales.SelectedRows[0].Cells["PaymentStatus"].Value.ToString() + "\n\n");
            }

            rtbInvoicePreview.AppendText("Thank you for your business!");
        }

        

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelBuyerType;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelBuyer;
        private System.Windows.Forms.Panel panelSalesGrid;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelInvoiceButtons;
        private System.Windows.Forms.Panel panelInvoice;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBoxInvoice;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Button btnGenerateInvoice;
        private System.Windows.Forms.Button btnSaveInvoice;
        private System.Windows.Forms.Button btnPrintInvoice;
        private System.Windows.Forms.DataGridView dataGridViewSales;
        private System.Windows.Forms.RichTextBox rtbInvoicePreview;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlInvoiceButtons;
        private System.Windows.Forms.Panel pnlInvoice;
        private System.Windows.Forms.Panel pnlInvoicePreview;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridView dataGridViewPurchases;
        private System.Windows.Forms.Label lblInvoicePreview;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblInvoiceTotalValue;
        private System.Windows.Forms.Label lblInvoiceTotal;
        private System.Windows.Forms.Label lblInvoicePaymentStatusValue;
        private System.Windows.Forms.Label lblInvoicePaymentStatus;
        private System.Windows.Forms.Label lblInvoiceBuyerName;
        private System.Windows.Forms.Label lblInvoiceBuyer;
        private System.Windows.Forms.Label lblInvoiceDateValue;
        private System.Windows.Forms.Label lblInvoiceDate;
        private System.Windows.Forms.Label lblInvoiceNumber;
        private System.Windows.Forms.Label lblInvoiceTitle;
    }
}