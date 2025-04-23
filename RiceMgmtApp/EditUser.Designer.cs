namespace RiceMgmtApp
{
    partial class EditUser
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
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtContact = new System.Windows.Forms.TextBox();
            this.comboRole = new System.Windows.Forms.ComboBox();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.comboStatus = new System.Windows.Forms.ComboBox();
            this.usersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.riceProductionDB2DataSet = new RiceMgmtApp.RiceProductionDB2DataSet();
            this.usersTableAdapter = new RiceMgmtApp.RiceProductionDB2DataSetTableAdapters.UsersTableAdapter();
            this.btnSave = new System.Windows.Forms.Button();
            this.riceProductionDB2DataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnCancel = new System.Windows.Forms.Button();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.panelForm = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblFullName = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblUsername = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblContact = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblEmail = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblRole = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.panelButtons = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.usersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riceProductionDB2DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riceProductionDB2DataSetBindingSource)).BeginInit();
            this.panelHeader.SuspendLayout();
            this.panelForm.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtUsername
            // 
            this.txtUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUsername.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtUsername.Location = new System.Drawing.Point(8, 30);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(286, 25);
            this.txtUsername.TabIndex = 14;
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmail.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtEmail.Location = new System.Drawing.Point(8, 30);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(279, 25);
            this.txtEmail.TabIndex = 15;
            // 
            // txtContact
            // 
            this.txtContact.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContact.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtContact.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtContact.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtContact.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtContact.Location = new System.Drawing.Point(8, 30);
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new System.Drawing.Size(286, 25);
            this.txtContact.TabIndex = 16;
            // 
            // comboRole
            // 
            this.comboRole.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboRole.BackColor = System.Drawing.Color.WhiteSmoke;
            this.comboRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboRole.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboRole.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboRole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.comboRole.FormattingEnabled = true;
            this.comboRole.Location = new System.Drawing.Point(8, 30);
            this.comboRole.Name = "comboRole";
            this.comboRole.Size = new System.Drawing.Size(279, 25);
            this.comboRole.TabIndex = 17;
            // 
            // txtFullName
            // 
            this.txtFullName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFullName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFullName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFullName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtFullName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtFullName.Location = new System.Drawing.Point(8, 30);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(286, 25);
            this.txtFullName.TabIndex = 19;
            // 
            // comboStatus
            // 
            this.comboStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboStatus.BackColor = System.Drawing.Color.WhiteSmoke;
            this.comboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.comboStatus.FormattingEnabled = true;
            this.comboStatus.Location = new System.Drawing.Point(8, 30);
            this.comboStatus.Name = "comboStatus";
            this.comboStatus.Size = new System.Drawing.Size(279, 25);
            this.comboStatus.TabIndex = 26;
            this.comboStatus.SelectedIndexChanged += new System.EventHandler(this.comboStatus_SelectedIndexChanged);
            // 
            // usersBindingSource
            // 
            this.usersBindingSource.DataMember = "Users";
            this.usersBindingSource.DataSource = this.riceProductionDB2DataSet;
            // 
            // riceProductionDB2DataSet
            // 
            this.riceProductionDB2DataSet.DataSetName = "RiceProductionDB2DataSet";
            this.riceProductionDB2DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // usersTableAdapter
            // 
            this.usersTableAdapter.ClearBeforeFill = true;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(356, 13);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 35);
            this.btnSave.TabIndex = 27;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // riceProductionDB2DataSetBindingSource
            // 
            this.riceProductionDB2DataSetBindingSource.DataSource = this.riceProductionDB2DataSet;
            this.riceProductionDB2DataSetBindingSource.Position = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(500, 13);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 35);
            this.btnCancel.TabIndex = 28;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.panelHeader.Controls.Add(this.lblHeader);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(700, 60);
            this.panelHeader.TabIndex = 30;
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(20, 15);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(100, 30);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Edit User";
            // 
            // panelForm
            // 
            this.panelForm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelForm.BackColor = System.Drawing.Color.White;
            this.panelForm.ColumnCount = 2;
            this.panelForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelForm.Controls.Add(this.panel1, 0, 0);
            this.panelForm.Controls.Add(this.panel2, 0, 1);
            this.panelForm.Controls.Add(this.panel3, 0, 2);
            this.panelForm.Controls.Add(this.panel4, 1, 0);
            this.panelForm.Controls.Add(this.panel5, 1, 1);
            this.panelForm.Controls.Add(this.panel6, 1, 2);
            this.panelForm.Location = new System.Drawing.Point(40, 80);
            this.panelForm.Name = "panelForm";
            this.panelForm.Padding = new System.Windows.Forms.Padding(10);
            this.panelForm.RowCount = 3;
            this.panelForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.panelForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.panelForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.panelForm.Size = new System.Drawing.Size(630, 240);
            this.panelForm.TabIndex = 31;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblFullName);
            this.panel1.Controls.Add(this.txtFullName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(299, 67);
            this.panel1.TabIndex = 0;
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFullName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblFullName.Location = new System.Drawing.Point(5, 8);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(69, 17);
            this.lblFullName.TabIndex = 20;
            this.lblFullName.Text = "Full Name";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblUsername);
            this.panel2.Controls.Add(this.txtUsername);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(13, 86);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(299, 67);
            this.panel2.TabIndex = 1;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblUsername.Location = new System.Drawing.Point(5, 8);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(69, 17);
            this.lblUsername.TabIndex = 21;
            this.lblUsername.Text = "Username";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblContact);
            this.panel3.Controls.Add(this.txtContact);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(13, 159);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(299, 68);
            this.panel3.TabIndex = 2;
            // 
            // lblContact
            // 
            this.lblContact.AutoSize = true;
            this.lblContact.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContact.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblContact.Location = new System.Drawing.Point(5, 8);
            this.lblContact.Name = "lblContact";
            this.lblContact.Size = new System.Drawing.Size(109, 17);
            this.lblContact.TabIndex = 22;
            this.lblContact.Text = "Contact Number";
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.lblEmail);
            this.panel4.Controls.Add(this.txtEmail);
            this.panel4.Location = new System.Drawing.Point(318, 13);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(299, 67);
            this.panel4.TabIndex = 3;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblEmail.Location = new System.Drawing.Point(5, 8);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(93, 17);
            this.lblEmail.TabIndex = 23;
            this.lblEmail.Text = "Email Address";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.lblRole);
            this.panel5.Controls.Add(this.comboRole);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(318, 86);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(299, 67);
            this.panel5.TabIndex = 4;
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblRole.Location = new System.Drawing.Point(5, 8);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(34, 17);
            this.lblRole.TabIndex = 25;
            this.lblRole.Text = "Role";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.lblStatus);
            this.panel6.Controls.Add(this.comboStatus);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(318, 159);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(299, 68);
            this.panel6.TabIndex = 5;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblStatus.Location = new System.Drawing.Point(5, 8);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(46, 17);
            this.lblStatus.TabIndex = 29;
            this.lblStatus.Text = "Status";
            // 
            // panelButtons
            // 
            this.panelButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelButtons.Controls.Add(this.btnSave);
            this.panelButtons.Controls.Add(this.btnCancel);
            this.panelButtons.Location = new System.Drawing.Point(40, 330);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(630, 60);
            this.panelButtons.TabIndex = 32;
            // 
            // EditUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.panelForm);
            this.Controls.Add(this.panelHeader);
            this.Name = "EditUser";
            this.Size = new System.Drawing.Size(700, 420);
            this.Load += new System.EventHandler(this.EditUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.usersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riceProductionDB2DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riceProductionDB2DataSetBindingSource)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelForm.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtContact;
        private System.Windows.Forms.ComboBox comboRole;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.ComboBox comboStatus;
        private System.Windows.Forms.BindingSource usersBindingSource;
        private RiceProductionDB2DataSet riceProductionDB2DataSet;
        private RiceProductionDB2DataSetTableAdapters.UsersTableAdapter usersTableAdapter;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.BindingSource riceProductionDB2DataSetBindingSource;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.TableLayoutPanel panelForm;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblContact;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Panel panelButtons;
    }
}