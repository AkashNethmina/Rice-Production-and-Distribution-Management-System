using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Configuration;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace RiceMgmtApp
{
    public partial class Fields : UserControl
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["RiceMgmtApp.Properties.Settings.RiceProductionDB2ConnectionString"].ConnectionString;
        private int currentUserId;
        private int currentUserRoleId;
        private DataTable originalDataTable;
        private bool isSearching = false;

        public Fields(int userId, int roleId)
        {
            if (roleId == 4) 
            {
                MessageBox.Show("Access denied. You are not authorized to view field data.", "Access Denied",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Dispose();
                return;
            }

            InitializeComponent();
            currentUserId = userId;
            currentUserRoleId = roleId;

            btnAddField.Visible = currentUserRoleId == 2; 
            cboFilter.SelectedIndex = 0; 

            this.SizeChanged += Fields_SizeChanged;
            this.Resize += Fields_Resize;

            LoadFields();
        }
        private void Fields_SizeChanged(object sender, EventArgs e)
        {
            ResizeUI();
        }

        private void Fields_Resize(object sender, EventArgs e)
        {
            ResizeUI();
        }

        private void ResizeUI()
        {
            if (this.Width < 700)
            {
                cboFilter.Width = 100;
                btnExportPDF.Text = "PDF";
                lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 14, FontStyle.Bold);
                lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 14, FontStyle.Bold);
            }
            else
            {
                cboFilter.Width = 150;
                btnExportPDF.Text = "📋 PDF";
                lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 16, FontStyle.Bold);
            }
        }

        private void LoadFields()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query;

                    if (currentUserRoleId == 2) // Farmer
                    {
                        query = @"
                    SELECT 
                        F.FieldID, 
                        FA.FullName AS FarmerName,
                        F.FarmerID, 
                        F.LocationCoordinates, 
                        F.FieldSize, 
                        F.SoilCondition, 
                        F.Zone, 
                        F.SeasonType, 
                        F.CreatedAt
                    FROM Fields F
                    JOIN Users FA ON F.FarmerID = FA.UserID
                    WHERE FA.UserID = @UserID";
                    }
                    else if (currentUserRoleId == 1 || currentUserRoleId == 3)
                    {
                        query = @"
                    SELECT 
                        F.FieldID, 
                        FA.FullName AS FarmerName,
                        F.FarmerID, 
                        F.LocationCoordinates, 
                        F.FieldSize, 
                        F.SoilCondition, 
                        F.Zone, 
                        F.SeasonType, 
                        F.CreatedAt
                    FROM Fields F
                    JOIN Users FA ON F.FarmerID = FA.UserID";
                    }
                    else
                    {
                        UpdateStatus("No data available.");
                        return;
                    }

                    SqlCommand cmd = new SqlCommand(query, con);
                    if (currentUserRoleId == 2)
                    {
                        cmd.Parameters.AddWithValue("@UserID", currentUserId);
                    }

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    originalDataTable = dt.Copy();

                    SetupDataGridView(dt);
                    UpdateStatus($"{dt.Rows.Count} record(s) found.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading fields: {ex.Message}", "Database Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    UpdateStatus("Error loading data.");
                }
            }
        }

        private void SetupDataGridView(DataTable dt)
        {
            dgvFields.DataSource = dt;

            dgvFields.Columns["FieldID"].HeaderText = "ID";

            if (currentUserRoleId == 2)
            {
                dgvFields.Columns["FarmerName"].Visible = false;
            }
            else
            {
                dgvFields.Columns["FarmerName"].HeaderText = "Farmer Name";
                dgvFields.Columns["FarmerName"].Visible = true;
            }

            dgvFields.Columns["FarmerID"].Visible = false;
            dgvFields.Columns["LocationCoordinates"].HeaderText = "Location";
            dgvFields.Columns["FieldSize"].HeaderText = "Size (Acres)";
            dgvFields.Columns["SoilCondition"].HeaderText = "Soil Condition";
            dgvFields.Columns["Zone"].HeaderText = "Zone";
            dgvFields.Columns["SeasonType"].HeaderText = "Season Type";
            dgvFields.Columns["CreatedAt"].HeaderText = "Created At";
            dgvFields.Columns["CreatedAt"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";

            if (dgvFields.Columns["Edit"] != null) dgvFields.Columns.Remove("Edit");
            if (dgvFields.Columns["Delete"] != null) dgvFields.Columns.Remove("Delete");

            if (currentUserRoleId == 1 || currentUserRoleId == 2)
            {
                DataGridViewImageColumn editColumn = new DataGridViewImageColumn();
                editColumn.Name = "Edit";
                editColumn.HeaderText = "";
                editColumn.Image = Properties.Resources.edit_icon;
                editColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
                editColumn.Width = 50;
                editColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvFields.Columns.Add(editColumn);

                DataGridViewImageColumn deleteColumn = new DataGridViewImageColumn();
                deleteColumn.Name = "Delete";
                deleteColumn.HeaderText = "";
                deleteColumn.Image = Properties.Resources.delete_icon;
                deleteColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
                deleteColumn.Width = 50;
                deleteColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvFields.Columns.Add(deleteColumn);
            }

            if (dgvFields.Columns["FieldID"] != null)
                dgvFields.Columns["FieldID"].Width = 60;

            if (dgvFields.Columns["FieldSize"] != null)
                dgvFields.Columns["FieldSize"].Width = 80;
        }

        private void dgvFields_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int fieldID = Convert.ToInt32(dgvFields.Rows[e.RowIndex].Cells["FieldID"].Value);
                int farmerID = Convert.ToInt32(dgvFields.Rows[e.RowIndex].Cells["FarmerID"].Value);
                string columnName = dgvFields.Columns[e.ColumnIndex].Name;

                if (columnName == "Edit")
                {
                    if (currentUserRoleId == 1 || (currentUserRoleId == 2 && farmerID == currentUserId))
                    {
                        EditField(fieldID);
                    }
                    else
                    {
                        MessageBox.Show("You do not have permission to edit this field.", "Access Denied",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                if (columnName == "Delete")
                {
                    if (currentUserRoleId == 1 || (currentUserRoleId == 2 && farmerID == currentUserId))
                    {
                        DialogResult result = MessageBox.Show("Are you sure you want to delete this field?",
                            "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            DeleteField(fieldID);
                            LoadFields();
                        }
                    }
                    else
                    {
                        MessageBox.Show("You do not have permission to delete this field.", "Access Denied",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }
        private void UpdateStatus(string message)
        {
            lblStatus.Text = message;
        }

        private void EditField(int fieldID)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT * FROM Fields WHERE FieldID = @FieldID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@FieldID", fieldID);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string currentLocation = reader["LocationCoordinates"].ToString();
                    decimal currentSize = Convert.ToDecimal(reader["FieldSize"]);
                    string currentSoilCondition = reader["SoilCondition"].ToString();
                    string currentZone = reader["Zone"].ToString();
                    string currentSeasonType = reader["SeasonType"].ToString();

                    reader.Close();

                    Form editForm = new Form();
                    editForm.Text = "Edit Field";
                    editForm.Size = new Size(550, 500);
                    editForm.StartPosition = FormStartPosition.CenterParent;
                    editForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                    editForm.MaximizeBox = false;
                    editForm.MinimizeBox = false;
                    editForm.BackColor = Color.FromArgb(245, 246, 250);

                    Panel headerPanel = new Panel();
                    headerPanel.Dock = DockStyle.Top;
                    headerPanel.Height = 70;
                    headerPanel.BackColor = Color.FromArgb(30, 136, 229);

                    Label lblFormTitle = new Label();
                    lblFormTitle.Text = "Edit Field Details";
                    lblFormTitle.ForeColor = Color.White;
                    lblFormTitle.Font = new System.Drawing.Font("Segoe UI", 16, FontStyle.Bold);
                    lblFormTitle.AutoSize = false;
                    lblFormTitle.Size = new Size(editForm.Width, 70);
                    lblFormTitle.TextAlign = ContentAlignment.MiddleCenter;
                    headerPanel.Controls.Add(lblFormTitle);

                    Panel contentPanel = new Panel();
                    contentPanel.Dock = DockStyle.Fill;
                    contentPanel.Padding = new Padding(30, 25, 30, 20);
                    contentPanel.BackColor = Color.FromArgb(245, 246, 250);

                    TableLayoutPanel formLayout = new TableLayoutPanel();
                    formLayout.Dock = DockStyle.Top;
                    formLayout.ColumnCount = 2;
                    formLayout.RowCount = 5;
                    formLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35));
                    formLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65));
                    formLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60));
                    formLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60));
                    formLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60));
                    formLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60));
                    formLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60));
                    formLayout.AutoSize = true;

                    Label lblLocation = CreateFormLabel("Location Coordinates");
                    TextBox txtLocation = CreateFormTextBox(currentLocation);
                    formLayout.Controls.Add(lblLocation, 0, 0);
                    formLayout.Controls.Add(txtLocation, 1, 0);

                    Label lblSize = CreateFormLabel("Field Size (Acres)");
                    TextBox txtSize = CreateFormTextBox(currentSize.ToString());
                    formLayout.Controls.Add(lblSize, 0, 1);
                    formLayout.Controls.Add(txtSize, 1, 1);

                    Label lblSoil = CreateFormLabel("Soil Condition");
                    ComboBox cboSoil = CreateFormComboBox(new string[] {
                "Alluvial Soils",
                "Reddish Brown Earth",
                "Low Humic Gley",
                "Grumusols (Black Clay)",
                "Red-Yellow Podzolic"
            }, currentSoilCondition);
                    formLayout.Controls.Add(lblSoil, 0, 2);
                    formLayout.Controls.Add(cboSoil, 1, 2);

                    Label lblZone = CreateFormLabel("Zone");
                    ComboBox cboZone = CreateFormComboBox(new string[] {
                "Lowlands",
                "Dry Zone",
                "Low-lying areas",
                "Central/North",
                "Wet Zone"
            }, currentZone);
                    formLayout.Controls.Add(lblZone, 0, 3);
                    formLayout.Controls.Add(cboZone, 1, 3);

                    Label lblSeason = CreateFormLabel("Season Type");
                    ComboBox cboSeason = CreateFormComboBox(new string[] { "Yala", "Maha" }, currentSeasonType);
                    formLayout.Controls.Add(lblSeason, 0, 4);
                    formLayout.Controls.Add(cboSeason, 1, 4);

                    FlowLayoutPanel buttonPanel = new FlowLayoutPanel();
                    buttonPanel.Dock = DockStyle.Bottom;
                    buttonPanel.Height = 70;
                    buttonPanel.FlowDirection = FlowDirection.RightToLeft;
                    buttonPanel.Padding = new Padding(0, 15, 0, 0);

                    Button btnCancel = CreateButton("Cancel", Color.FromArgb(120, 120, 120), Color.White);
                    btnCancel.DialogResult = DialogResult.Cancel;
                    buttonPanel.Controls.Add(btnCancel);

                    Button btnOK = CreateButton("Update Field", Color.FromArgb(76, 175, 80), Color.White);
                    btnOK.DialogResult = DialogResult.OK;
                    buttonPanel.Controls.Add(btnOK);

                    contentPanel.Controls.Add(buttonPanel);
                    contentPanel.Controls.Add(formLayout);

                    editForm.Controls.Add(contentPanel);
                    editForm.Controls.Add(headerPanel);

                    editForm.AcceptButton = btnOK;
                    editForm.CancelButton = btnCancel;

                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        if (decimal.TryParse(txtSize.Text, out decimal newSize))
                        {
                            string updateQuery = @"UPDATE Fields 
                                          SET LocationCoordinates=@Loc, 
                                              FieldSize=@Size,
                                              SoilCondition=@Soil,
                                              Zone=@Zone,
                                              SeasonType=@Season
                                          WHERE FieldID=@FieldID";

                            SqlCommand updateCmd = new SqlCommand(updateQuery, con);
                            updateCmd.Parameters.AddWithValue("@Loc", txtLocation.Text);
                            updateCmd.Parameters.AddWithValue("@Size", newSize);
                            updateCmd.Parameters.AddWithValue("@Soil", cboSoil.Text);
                            updateCmd.Parameters.AddWithValue("@Zone", cboZone.Text);
                            updateCmd.Parameters.AddWithValue("@Season", cboSeason.Text);
                            updateCmd.Parameters.AddWithValue("@FieldID", fieldID);
                            updateCmd.ExecuteNonQuery();

                            LoadFields();
                        }
                        else
                        {
                            MessageBox.Show("Invalid size input!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }

        private void DeleteField(int fieldID)
        {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();


                    string deleteField = "DELETE FROM Fields WHERE FieldID = @FieldID";
                    SqlCommand cmd2 = new SqlCommand(deleteField, con);
                    cmd2.Parameters.AddWithValue("@FieldID", fieldID);
                    cmd2.ExecuteNonQuery();

                    LoadFields();
                }
        }

        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            if (dgvFields.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = "Fields_Report.pdf";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Document doc = new Document(PageSize.A4);
                        PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                        doc.Open();

                     
                        Paragraph title = new Paragraph("Fields Management Report",
                            new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 18, iTextSharp.text.Font.BOLD));
                        title.Alignment = Element.ALIGN_CENTER;
                        title.SpacingAfter = 20f;
                        doc.Add(title);

                 
                        Paragraph date = new Paragraph(
    new Phrase($"Generated on: {DateTime.Now.ToString("dd MMMM yyyy HH:mm")}",
    new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.NORMAL)));
                        date.Alignment = Element.ALIGN_RIGHT;
                        date.SpacingAfter = 20f;
                        doc.Add(date);

                        PdfPTable pdfTable = new PdfPTable(dgvFields.Columns.Count - 3); 
                        pdfTable.WidthPercentage = 100;

                     
                        BaseFont baseFont = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
         
                        iTextSharp.text.Font headerFont = new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.BOLD, new iTextSharp.text.BaseColor(255, 255, 255));

                        foreach (DataGridViewColumn column in dgvFields.Columns)
                        {
                            if (column.Name != "Edit" && column.Name != "Delete" && column.Name != "FarmerID" && column.Visible)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.BOLD, new iTextSharp.text.BaseColor(255, 255, 255))));
                                cell.BackgroundColor = new BaseColor(30, 136, 229);
                                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                                cell.Padding = 8;
                                pdfTable.AddCell(cell);
                            }
                        }

                        iTextSharp.text.Font contentFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9);
                        BaseColor lightBlue = new BaseColor(240, 248, 255);
                        BaseColor white = new BaseColor(255, 255, 255);
                        bool useAltColor = false;

                        foreach (DataGridViewRow row in dgvFields.Rows)
                        {
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                if (dgvFields.Columns[cell.ColumnIndex].Name != "Edit" &&
                                    dgvFields.Columns[cell.ColumnIndex].Name != "Delete" &&
                                    dgvFields.Columns[cell.ColumnIndex].Name != "FarmerID" &&
                                    dgvFields.Columns[cell.ColumnIndex].Visible)
                                {
                                    PdfPCell pdfCell = new PdfPCell(new Phrase(cell.Value?.ToString() ?? string.Empty, new iTextSharp.text.Font(contentFont)));
                                    pdfCell.BackgroundColor = useAltColor ? lightBlue : white;
                                    pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
                                    pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                                    pdfCell.Padding = 6;
                                    pdfTable.AddCell(pdfCell);
                                }
                            }
                            useAltColor = !useAltColor;
                        }

                        doc.Add(pdfTable);

                        Paragraph footer = new Paragraph(
    new Phrase("This report was generated by Field Management System",
    new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.ITALIC)));
                        footer.Alignment = Element.ALIGN_CENTER;
                        footer.SpacingBefore = 30f;
                        doc.Add(footer);

                        doc.Close();
                        MessageBox.Show("PDF report has been successfully exported.", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("No data to export!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAddField_Click(object sender, EventArgs e)
        {
            Form addForm = new Form();
            addForm.Text = "Add New Field";
            addForm.Size = new Size(550, 500);
            addForm.StartPosition = FormStartPosition.CenterParent;
            addForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            addForm.MaximizeBox = false;
            addForm.MinimizeBox = false;
            addForm.BackColor = Color.FromArgb(245, 246, 250);

            Panel headerPanel = new Panel();
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Height = 70;
            headerPanel.BackColor = Color.FromArgb(33, 150, 243);

            Label lblFormTitle = new Label();
            lblFormTitle.Text = "Add New Field";
            lblFormTitle.ForeColor = Color.White;
            lblFormTitle.Font = new System.Drawing.Font("Segoe UI", 16, FontStyle.Bold);
            lblFormTitle.AutoSize = false;
            lblFormTitle.Size = new Size(addForm.Width, 70);
            lblFormTitle.TextAlign = ContentAlignment.MiddleCenter;
            headerPanel.Controls.Add(lblFormTitle);

            Panel contentPanel = new Panel();
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.Padding = new Padding(30, 25, 30, 20);
            contentPanel.BackColor = Color.FromArgb(245, 246, 250);

            TableLayoutPanel formLayout = new TableLayoutPanel();
            formLayout.Dock = DockStyle.Top;
            formLayout.ColumnCount = 2;
            formLayout.RowCount = 5;
            formLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35));
            formLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65));
            formLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60));
            formLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60));
            formLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60));
            formLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60));
            formLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60));
            formLayout.AutoSize = true;

            Label lblLocation = CreateFormLabel("Location Coordinates");
            TextBox txtLocation = CreateFormTextBox();
            formLayout.Controls.Add(lblLocation, 0, 0);
            formLayout.Controls.Add(txtLocation, 1, 0);

            Label lblSize = CreateFormLabel("Field Size (Acres)");
            TextBox txtSize = CreateFormTextBox();
            formLayout.Controls.Add(lblSize, 0, 1);
            formLayout.Controls.Add(txtSize, 1, 1);

            Label lblSoil = CreateFormLabel("Soil Condition");
            ComboBox cboSoil = CreateFormComboBox(new string[] {
        "Alluvial Soils",
        "Reddish Brown Earth",
        "Low Humic Gley",
        "Grumusols (Black Clay)",
        "Red-Yellow Podzolic"
    });
            formLayout.Controls.Add(lblSoil, 0, 2);
            formLayout.Controls.Add(cboSoil, 1, 2);

            Label lblZone = CreateFormLabel("Zone");
            ComboBox cboZone = CreateFormComboBox(new string[] {
        "Lowlands",
        "Dry Zone",
        "Low-lying areas",
        "Central/North",
        "Wet Zone"
    });
            formLayout.Controls.Add(lblZone, 0, 3);
            formLayout.Controls.Add(cboZone, 1, 3);

            Label lblSeason = CreateFormLabel("Season Type");
            ComboBox cboSeason = CreateFormComboBox(new string[] { "Yala", "Maha" });
            formLayout.Controls.Add(lblSeason, 0, 4);
            formLayout.Controls.Add(cboSeason, 1, 4);

            FlowLayoutPanel buttonPanel = new FlowLayoutPanel();
            buttonPanel.Dock = DockStyle.Bottom;
            buttonPanel.Height = 70;
            buttonPanel.FlowDirection = FlowDirection.RightToLeft;
            buttonPanel.Padding = new Padding(0, 15, 0, 0);

            Button btnCancel = CreateButton("Cancel", Color.FromArgb(120, 120, 120), Color.White);
            btnCancel.DialogResult = DialogResult.Cancel;
            buttonPanel.Controls.Add(btnCancel);

            Button btnOK = CreateButton("Add Field", Color.FromArgb(76, 175, 80), Color.White);
            btnOK.DialogResult = DialogResult.OK;
            buttonPanel.Controls.Add(btnOK);

            contentPanel.Controls.Add(buttonPanel);
            contentPanel.Controls.Add(formLayout);

            addForm.Controls.Add(contentPanel);
            addForm.Controls.Add(headerPanel);

            addForm.AcceptButton = btnOK;
            addForm.CancelButton = btnCancel;

            if (addForm.ShowDialog() == DialogResult.OK)
            {
                if (decimal.TryParse(txtSize.Text, out decimal size))
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        con.Open();
                        string insertQuery = @"INSERT INTO Fields (FarmerID, LocationCoordinates,
                                                   FieldSize, SoilCondition, Zone, SeasonType, CreatedAt)
                                VALUES (@FarmerID, @Loc, @Size, @Soil, @Zone, @Season, GETDATE())";
                        SqlCommand cmd = new SqlCommand(insertQuery, con);
                        cmd.Parameters.AddWithValue("@FarmerID", currentUserId);
                        cmd.Parameters.AddWithValue("@Loc", txtLocation.Text);
                        cmd.Parameters.AddWithValue("@Size", size);
                        cmd.Parameters.AddWithValue("@Soil", cboSoil.Text);
                        cmd.Parameters.AddWithValue("@Zone", cboZone.Text);
                        cmd.Parameters.AddWithValue("@Season", cboSeason.Text);

                        cmd.ExecuteNonQuery();
                        LoadFields();

                        MessageBox.Show("Field added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {

                    MessageBox.Show("Invalid size input!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private Label CreateFormLabel(string text)
        {
            Label label = new Label();
            label.Text = text;
            label.Dock = DockStyle.Fill;
            label.Font = new System.Drawing.Font("Segoe UI", 10);
            label.TextAlign = ContentAlignment.MiddleLeft;
            label.ForeColor = Color.FromArgb(60, 60, 60);
            return label;
        }

        private TextBox CreateFormTextBox(string initialValue = "")
        {
            TextBox textBox = new TextBox();
            textBox.Dock = DockStyle.Fill;
            textBox.Font = new System.Drawing.Font("Segoe UI", 10);
            textBox.Margin = new Padding(0, 10, 0, 10);
            textBox.Text = initialValue;
            textBox.BorderStyle = BorderStyle.FixedSingle;
            textBox.BackColor = Color.White;
            return textBox;
        }

        private ComboBox CreateFormComboBox(string[] items, string selectedItem = "")
        {
            ComboBox comboBox = new ComboBox();
            comboBox.Dock = DockStyle.Fill;
            comboBox.Font = new System.Drawing.Font("Segoe UI", 10);
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox.Margin = new Padding(0, 10, 0, 10);
            comboBox.BackColor = Color.White;
            comboBox.FlatStyle = FlatStyle.Flat;
            comboBox.Items.AddRange(items);

            if (!string.IsNullOrEmpty(selectedItem))
                comboBox.Text = selectedItem;
            else if (items.Length > 0)
                comboBox.SelectedIndex = 0;

            return comboBox;
        }

        private Button CreateButton(string text, Color backColor, Color foreColor)
        {
            Button button = new Button();
            button.Text = text;
            button.Size = new Size(120, 40);
            button.Margin = new Padding(10, 0, 0, 0);
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.BackColor = backColor;
            button.ForeColor = foreColor;
            button.Font = new System.Drawing.Font("Segoe UI", 10);
            button.Cursor = Cursors.Hand;
            return button;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            isSearching = true;
            ApplyFilters();
        }

        private void cboFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            if (originalDataTable == null || originalDataTable.Rows.Count == 0)
                return;

            try
            {
                DataTable filteredData = originalDataTable.Copy();
                string zoneFilter = cboFilter.SelectedItem.ToString();

                DataView dv = filteredData.DefaultView;

                if (zoneFilter != "All Zones")
                {
                    dv.RowFilter = $"Zone = '{zoneFilter}'";
                }

                SetupDataGridView(dv.ToTable());

                UpdateStatus($"{dv.Count} record(s) found");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error filtering data: {ex.Message}", "Filter Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (isSearching)
                {
                    cboFilter.SelectedIndex = 0;
                    isSearching = false;
                    SetupDataGridView(originalDataTable);
                }
            }
        }
    }
}