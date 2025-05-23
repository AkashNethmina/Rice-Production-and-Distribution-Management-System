using System.Windows.Forms;
using System;

namespace RiceMgmtApp
{
    partial class RequestPaddy
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>


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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.formPanel = new System.Windows.Forms.Panel();
            this.formFieldsPanel = new System.Windows.Forms.Panel();
            this.pricePanel = new System.Windows.Forms.Panel();
            this.quantityPanel = new System.Windows.Forms.Panel();
            this.btnSubmitRequest = new System.Windows.Forms.Button();
            this.availableQtyPanel = new System.Windows.Forms.Panel();
            this.txtRequestPrice = new System.Windows.Forms.TextBox();
            this.lblRequestPrice = new System.Windows.Forms.Label();
            this.stockPanel = new System.Windows.Forms.Panel();
            this.lblRequestQty = new System.Windows.Forms.Label();
            this.txtRequestQty = new System.Windows.Forms.TextBox();
            this.cmbStock = new System.Windows.Forms.ComboBox();
            this.lblStock = new System.Windows.Forms.Label();
            this.farmerPanel = new System.Windows.Forms.Panel();
            this.lblAvailableQtyValue = new System.Windows.Forms.Label();
            this.cmbFarmers = new System.Windows.Forms.ComboBox();
            this.lblAvailableQty = new System.Windows.Forms.Label();
            this.lblFarmer = new System.Windows.Forms.Label();
            this.formHeaderPanel = new System.Windows.Forms.Panel();
            this.btnReview = new System.Windows.Forms.Button();
            this.btnReject = new System.Windows.Forms.Button();
            this.btnApprove = new System.Windows.Forms.Button();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.requestsPanel = new System.Windows.Forms.Panel();
            this.dgvRequests = new System.Windows.Forms.DataGridView();
            this.requestsHeaderPanel = new System.Windows.Forms.Panel();
            this.lblRequestsTitle = new System.Windows.Forms.Label();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.lblMainTitle = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            this.contentPanel.SuspendLayout();
            this.formPanel.SuspendLayout();
            this.formFieldsPanel.SuspendLayout();
            this.quantityPanel.SuspendLayout();
            this.availableQtyPanel.SuspendLayout();
            this.stockPanel.SuspendLayout();
            this.farmerPanel.SuspendLayout();
            this.formHeaderPanel.SuspendLayout();
            this.requestsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequests)).BeginInit();
            this.requestsHeaderPanel.SuspendLayout();
            this.headerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.AutoScroll = true;
            this.mainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.mainPanel.Controls.Add(this.contentPanel);
            this.mainPanel.Controls.Add(this.headerPanel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Padding = new System.Windows.Forms.Padding(20);
            this.mainPanel.Size = new System.Drawing.Size(1085, 795);
            this.mainPanel.TabIndex = 0;
            // 
            // contentPanel
            // 
            this.contentPanel.Controls.Add(this.formPanel);
            this.contentPanel.Controls.Add(this.requestsPanel);
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(20, 90);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(1045, 685);
            this.contentPanel.TabIndex = 1;
            // 
            // formPanel
            // 
            this.formPanel.BackColor = System.Drawing.Color.White;
            this.formPanel.Controls.Add(this.formFieldsPanel);
            this.formPanel.Controls.Add(this.formHeaderPanel);
            this.formPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.formPanel.Location = new System.Drawing.Point(0, 261);
            this.formPanel.Name = "formPanel";
            this.formPanel.Padding = new System.Windows.Forms.Padding(25);
            this.formPanel.Size = new System.Drawing.Size(1045, 424);
            this.formPanel.TabIndex = 0;
            // 
            // formFieldsPanel
            // 
            this.formFieldsPanel.Controls.Add(this.pricePanel);
            this.formFieldsPanel.Controls.Add(this.quantityPanel);
            this.formFieldsPanel.Controls.Add(this.availableQtyPanel);
            this.formFieldsPanel.Controls.Add(this.stockPanel);
            this.formFieldsPanel.Controls.Add(this.farmerPanel);
            this.formFieldsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formFieldsPanel.Location = new System.Drawing.Point(25, 92);
            this.formFieldsPanel.Name = "formFieldsPanel";
            this.formFieldsPanel.Size = new System.Drawing.Size(995, 307);
            this.formFieldsPanel.TabIndex = 1;
            // 
            // pricePanel
            // 
            this.pricePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.pricePanel.Location = new System.Drawing.Point(0, 198);
            this.pricePanel.Name = "pricePanel";
            this.pricePanel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 15);
            this.pricePanel.Size = new System.Drawing.Size(995, 10);
            this.pricePanel.TabIndex = 4;
            // 
            // quantityPanel
            // 
            this.quantityPanel.Controls.Add(this.btnSubmitRequest);
            this.quantityPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.quantityPanel.Location = new System.Drawing.Point(0, 141);
            this.quantityPanel.Name = "quantityPanel";
            this.quantityPanel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 15);
            this.quantityPanel.Size = new System.Drawing.Size(995, 57);
            this.quantityPanel.TabIndex = 3;
            // 
            // btnSubmitRequest
            // 
            this.btnSubmitRequest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnSubmitRequest.FlatAppearance.BorderSize = 0;
            this.btnSubmitRequest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmitRequest.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnSubmitRequest.ForeColor = System.Drawing.Color.White;
            this.btnSubmitRequest.Location = new System.Drawing.Point(6, 6);
            this.btnSubmitRequest.Name = "btnSubmitRequest";
            this.btnSubmitRequest.Size = new System.Drawing.Size(200, 45);
            this.btnSubmitRequest.TabIndex = 0;
            this.btnSubmitRequest.Text = "Submit Request";
            this.btnSubmitRequest.UseVisualStyleBackColor = false;
            this.btnSubmitRequest.Click += new System.EventHandler(this.btnSubmitRequest_Click);
            // 
            // availableQtyPanel
            // 
            this.availableQtyPanel.Controls.Add(this.txtRequestPrice);
            this.availableQtyPanel.Controls.Add(this.lblRequestPrice);
            this.availableQtyPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.availableQtyPanel.Location = new System.Drawing.Point(0, 96);
            this.availableQtyPanel.Name = "availableQtyPanel";
            this.availableQtyPanel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 15);
            this.availableQtyPanel.Size = new System.Drawing.Size(995, 45);
            this.availableQtyPanel.TabIndex = 2;
            // 
            // txtRequestPrice
            // 
            this.txtRequestPrice.BackColor = System.Drawing.Color.White;
            this.txtRequestPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRequestPrice.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtRequestPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.txtRequestPrice.Location = new System.Drawing.Point(200, 8);
            this.txtRequestPrice.Name = "txtRequestPrice";
            this.txtRequestPrice.Size = new System.Drawing.Size(250, 27);
            this.txtRequestPrice.TabIndex = 1;
            this.txtRequestPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRequestPrice_KeyPress);
            // 
            // lblRequestPrice
            // 
            this.lblRequestPrice.AutoSize = true;
            this.lblRequestPrice.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblRequestPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblRequestPrice.Location = new System.Drawing.Point(2, 15);
            this.lblRequestPrice.Name = "lblRequestPrice";
            this.lblRequestPrice.Size = new System.Drawing.Size(149, 20);
            this.lblRequestPrice.TabIndex = 0;
            this.lblRequestPrice.Text = "Offer Price per Unit:";
            // 
            // stockPanel
            // 
            this.stockPanel.Controls.Add(this.lblRequestQty);
            this.stockPanel.Controls.Add(this.txtRequestQty);
            this.stockPanel.Controls.Add(this.cmbStock);
            this.stockPanel.Controls.Add(this.lblStock);
            this.stockPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.stockPanel.Location = new System.Drawing.Point(0, 50);
            this.stockPanel.Name = "stockPanel";
            this.stockPanel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 15);
            this.stockPanel.Size = new System.Drawing.Size(995, 46);
            this.stockPanel.TabIndex = 1;
            // 
            // lblRequestQty
            // 
            this.lblRequestQty.AutoSize = true;
            this.lblRequestQty.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblRequestQty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblRequestQty.Location = new System.Drawing.Point(593, 11);
            this.lblRequestQty.Name = "lblRequestQty";
            this.lblRequestQty.Size = new System.Drawing.Size(135, 20);
            this.lblRequestQty.TabIndex = 0;
            this.lblRequestQty.Text = "Request Quantity:";
            // 
            // txtRequestQty
            // 
            this.txtRequestQty.BackColor = System.Drawing.Color.White;
            this.txtRequestQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRequestQty.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtRequestQty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.txtRequestQty.Location = new System.Drawing.Point(734, 9);
            this.txtRequestQty.Name = "txtRequestQty";
            this.txtRequestQty.Size = new System.Drawing.Size(250, 27);
            this.txtRequestQty.TabIndex = 1;
            this.txtRequestQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRequestQty_KeyPress);
            // 
            // cmbStock
            // 
            this.cmbStock.BackColor = System.Drawing.Color.White;
            this.cmbStock.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStock.Enabled = false;
            this.cmbStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbStock.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbStock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.cmbStock.FormattingEnabled = true;
            this.cmbStock.Location = new System.Drawing.Point(200, 8);
            this.cmbStock.Name = "cmbStock";
            this.cmbStock.Size = new System.Drawing.Size(350, 28);
            this.cmbStock.TabIndex = 1;
            this.cmbStock.SelectedIndexChanged += new System.EventHandler(this.cmbStock_SelectedIndexChanged);
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblStock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblStock.Location = new System.Drawing.Point(3, 8);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(97, 20);
            this.lblStock.TabIndex = 0;
            this.lblStock.Text = "Select Stock:";
            // 
            // farmerPanel
            // 
            this.farmerPanel.Controls.Add(this.lblAvailableQtyValue);
            this.farmerPanel.Controls.Add(this.cmbFarmers);
            this.farmerPanel.Controls.Add(this.lblAvailableQty);
            this.farmerPanel.Controls.Add(this.lblFarmer);
            this.farmerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.farmerPanel.Location = new System.Drawing.Point(0, 0);
            this.farmerPanel.Name = "farmerPanel";
            this.farmerPanel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 15);
            this.farmerPanel.Size = new System.Drawing.Size(995, 50);
            this.farmerPanel.TabIndex = 0;
            // 
            // lblAvailableQtyValue
            // 
            this.lblAvailableQtyValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAvailableQtyValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.lblAvailableQtyValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAvailableQtyValue.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblAvailableQtyValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblAvailableQtyValue.Location = new System.Drawing.Point(734, 12);
            this.lblAvailableQtyValue.Name = "lblAvailableQtyValue";
            this.lblAvailableQtyValue.Size = new System.Drawing.Size(250, 27);
            this.lblAvailableQtyValue.TabIndex = 1;
            this.lblAvailableQtyValue.Text = "0.00";
            this.lblAvailableQtyValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbFarmers
            // 
            this.cmbFarmers.BackColor = System.Drawing.Color.White;
            this.cmbFarmers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFarmers.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbFarmers.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbFarmers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.cmbFarmers.FormattingEnabled = true;
            this.cmbFarmers.Location = new System.Drawing.Point(200, 12);
            this.cmbFarmers.Name = "cmbFarmers";
            this.cmbFarmers.Size = new System.Drawing.Size(350, 28);
            this.cmbFarmers.TabIndex = 1;
            this.cmbFarmers.SelectedIndexChanged += new System.EventHandler(this.cmbFarmers_SelectedIndexChanged);
            // 
            // lblAvailableQty
            // 
            this.lblAvailableQty.AutoSize = true;
            this.lblAvailableQty.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblAvailableQty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblAvailableQty.Location = new System.Drawing.Point(586, 15);
            this.lblAvailableQty.Name = "lblAvailableQty";
            this.lblAvailableQty.Size = new System.Drawing.Size(142, 20);
            this.lblAvailableQty.TabIndex = 0;
            this.lblAvailableQty.Text = "Available Quantity:";
            // 
            // lblFarmer
            // 
            this.lblFarmer.AutoSize = true;
            this.lblFarmer.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblFarmer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblFarmer.Location = new System.Drawing.Point(3, 15);
            this.lblFarmer.Name = "lblFarmer";
            this.lblFarmer.Size = new System.Drawing.Size(109, 20);
            this.lblFarmer.TabIndex = 0;
            this.lblFarmer.Text = "Select Farmer:";
            // 
            // formHeaderPanel
            // 
            this.formHeaderPanel.Controls.Add(this.btnReview);
            this.formHeaderPanel.Controls.Add(this.btnReject);
            this.formHeaderPanel.Controls.Add(this.btnApprove);
            this.formHeaderPanel.Controls.Add(this.lblFormTitle);
            this.formHeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.formHeaderPanel.Location = new System.Drawing.Point(25, 25);
            this.formHeaderPanel.Name = "formHeaderPanel";
            this.formHeaderPanel.Size = new System.Drawing.Size(995, 67);
            this.formHeaderPanel.TabIndex = 0;
            // 
            // btnReview
            // 
            this.btnReview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnReview.FlatAppearance.BorderSize = 0;
            this.btnReview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReview.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnReview.ForeColor = System.Drawing.Color.White;
            this.btnReview.Location = new System.Drawing.Point(6, 7);
            this.btnReview.Name = "btnReview";
            this.btnReview.Size = new System.Drawing.Size(200, 43);
            this.btnReview.TabIndex = 3;
            this.btnReview.Text = "Under Review";
            this.btnReview.UseVisualStyleBackColor = false;
            this.btnReview.Click += new System.EventHandler(this.btnReview_Click);
            // 
            // btnReject
            // 
            this.btnReject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnReject.Enabled = false;
            this.btnReject.FlatAppearance.BorderSize = 0;
            this.btnReject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReject.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnReject.ForeColor = System.Drawing.Color.White;
            this.btnReject.Location = new System.Drawing.Point(415, 7);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(180, 43);
            this.btnReject.TabIndex = 2;
            this.btnReject.Text = "Reject Request";
            this.btnReject.UseVisualStyleBackColor = false;
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            // 
            // btnApprove
            // 
            this.btnApprove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnApprove.Enabled = false;
            this.btnApprove.FlatAppearance.BorderSize = 0;
            this.btnApprove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApprove.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnApprove.ForeColor = System.Drawing.Color.White;
            this.btnApprove.Location = new System.Drawing.Point(212, 7);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(200, 43);
            this.btnApprove.TabIndex = 1;
            this.btnApprove.Text = "Approve Request";
            this.btnApprove.UseVisualStyleBackColor = false;
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.AutoSize = true;
            this.lblFormTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblFormTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblFormTitle.Location = new System.Drawing.Point(3, 20);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(155, 30);
            this.lblFormTitle.TabIndex = 0;
            this.lblFormTitle.Text = "Request Form";
            // 
            // requestsPanel
            // 
            this.requestsPanel.BackColor = System.Drawing.Color.White;
            this.requestsPanel.Controls.Add(this.dgvRequests);
            this.requestsPanel.Controls.Add(this.requestsHeaderPanel);
            this.requestsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.requestsPanel.Location = new System.Drawing.Point(0, 0);
            this.requestsPanel.Name = "requestsPanel";
            this.requestsPanel.Padding = new System.Windows.Forms.Padding(25);
            this.requestsPanel.Size = new System.Drawing.Size(1045, 261);
            this.requestsPanel.TabIndex = 1;
            // 
            // dgvRequests
            // 
            this.dgvRequests.AllowUserToAddRows = false;
            this.dgvRequests.AllowUserToDeleteRows = false;
            this.dgvRequests.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRequests.BackgroundColor = System.Drawing.Color.White;
            this.dgvRequests.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRequests.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRequests.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvRequests.ColumnHeadersHeight = 45;
            this.dgvRequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRequests.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvRequests.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRequests.EnableHeadersVisualStyles = false;
            this.dgvRequests.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.dgvRequests.Location = new System.Drawing.Point(25, 70);
            this.dgvRequests.MultiSelect = false;
            this.dgvRequests.Name = "dgvRequests";
            this.dgvRequests.ReadOnly = true;
            this.dgvRequests.RowHeadersVisible = false;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvRequests.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvRequests.RowTemplate.Height = 40;
            this.dgvRequests.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRequests.Size = new System.Drawing.Size(995, 166);
            this.dgvRequests.TabIndex = 1;
            this.dgvRequests.SelectionChanged += new System.EventHandler(this.dgvRequests_SelectionChanged);
            // 
            // requestsHeaderPanel
            // 
            this.requestsHeaderPanel.Controls.Add(this.lblRequestsTitle);
            this.requestsHeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.requestsHeaderPanel.Location = new System.Drawing.Point(25, 25);
            this.requestsHeaderPanel.Name = "requestsHeaderPanel";
            this.requestsHeaderPanel.Size = new System.Drawing.Size(995, 45);
            this.requestsHeaderPanel.TabIndex = 0;
            // 
            // lblRequestsTitle
            // 
            this.lblRequestsTitle.AutoSize = true;
            this.lblRequestsTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblRequestsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblRequestsTitle.Location = new System.Drawing.Point(3, 12);
            this.lblRequestsTitle.Name = "lblRequestsTitle";
            this.lblRequestsTitle.Size = new System.Drawing.Size(177, 30);
            this.lblRequestsTitle.TabIndex = 0;
            this.lblRequestsTitle.Text = "Paddy Requests";
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.headerPanel.Controls.Add(this.lblMainTitle);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(20, 20);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Padding = new System.Windows.Forms.Padding(25, 20, 25, 20);
            this.headerPanel.Size = new System.Drawing.Size(1045, 70);
            this.headerPanel.TabIndex = 0;
            // 
            // lblMainTitle
            // 
            this.lblMainTitle.AutoSize = true;
            this.lblMainTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblMainTitle.ForeColor = System.Drawing.Color.White;
            this.lblMainTitle.Location = new System.Drawing.Point(25, 20);
            this.lblMainTitle.Name = "lblMainTitle";
            this.lblMainTitle.Size = new System.Drawing.Size(269, 32);
            this.lblMainTitle.TabIndex = 0;
            this.lblMainTitle.Text = "Paddy Request System";
            // 
            // RequestPaddy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.mainPanel);
            this.Name = "RequestPaddy";
            this.Size = new System.Drawing.Size(1085, 795);
            this.Load += new System.EventHandler(this.RequestPaddy_Load);
            this.mainPanel.ResumeLayout(false);
            this.contentPanel.ResumeLayout(false);
            this.formPanel.ResumeLayout(false);
            this.formFieldsPanel.ResumeLayout(false);
            this.quantityPanel.ResumeLayout(false);
            this.availableQtyPanel.ResumeLayout(false);
            this.availableQtyPanel.PerformLayout();
            this.stockPanel.ResumeLayout(false);
            this.stockPanel.PerformLayout();
            this.farmerPanel.ResumeLayout(false);
            this.farmerPanel.PerformLayout();
            this.formHeaderPanel.ResumeLayout(false);
            this.formHeaderPanel.PerformLayout();
            this.requestsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequests)).EndInit();
            this.requestsHeaderPanel.ResumeLayout(false);
            this.requestsHeaderPanel.PerformLayout();
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.Panel requestsPanel;
        private System.Windows.Forms.DataGridView dgvRequests;
        private System.Windows.Forms.Panel requestsHeaderPanel;
        private System.Windows.Forms.Label lblRequestsTitle;
        private System.Windows.Forms.Panel formPanel;
        private System.Windows.Forms.Button btnReject;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.Panel formHeaderPanel;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label lblMainTitle;
        private System.ComponentModel.IContainer components = null;
        private Panel formFieldsPanel;
        private Panel pricePanel;
        private Panel quantityPanel;
        private Button btnSubmitRequest;
        private Panel availableQtyPanel;
        private TextBox txtRequestPrice;
        private Label lblRequestPrice;
        private Panel stockPanel;
        private Label lblRequestQty;
        private TextBox txtRequestQty;
        private ComboBox cmbStock;
        private Label lblStock;
        private Panel farmerPanel;
        private Label lblAvailableQtyValue;
        private ComboBox cmbFarmers;
        private Label lblAvailableQty;
        private Label lblFarmer;
        private Button btnReview;
    }
}

       