using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;
using System.Configuration;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace RiceMgmtApp
{
    public partial class Cultivation : UserControl
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["RiceMgmtApp.Properties.Settings.RiceProductionDB2ConnectionString"].ConnectionString;
        private int editingCultivationId = 0;
        private bool isEditMode = false;

        public Cultivation()
        {
            InitializeComponent();
            InitializeCustomComponents();
        }

        #region UI Initialization & Data Loading

        private void InitializeCustomComponents()
        {
            // Initialize panels
            pnlList = new Panel();
            pnlEntry = new Panel();

            // Initialize components for data entry
            lblFarmer = new Label();
            cboFarmers = new ComboBox();
            lblField = new Label();
            cboFields = new ComboBox();
       
            lblYear = new Label();
            numYear = new NumericUpDown();
            lblAcres = new Label();
            numAcres = new NumericUpDown();
            lblExpectedYield = new Label();
            numExpectedYield = new NumericUpDown();
            lblActualYield = new Label();
            numActualYield = new NumericUpDown();
            lblCropLoss = new Label();
            numCropLoss = new NumericUpDown();
            btnSave = new Button();
            btnCancel = new Button();

            // Configure entry panel
            pnlEntry.Dock = DockStyle.Fill;
            pnlEntry.Visible = false;
            pnlEntry.Padding = new Padding(20);

            // Configure list panel
            pnlList.Dock = DockStyle.Fill;
            pnlList.Visible = true;

            // Configure controls
            lblFarmer.Text = "Farmer:";
            lblFarmer.AutoSize = true;
            lblField.Text = "Field:";
            lblField.AutoSize = true;
       
            lblYear.Text = "Year:";
            lblYear.AutoSize = true;
            lblAcres.Text = "Acres Cultivated:";
            lblAcres.AutoSize = true;
            lblExpectedYield.Text = "Expected Yield:";
            lblExpectedYield.AutoSize = true;
            lblActualYield.Text = "Actual Yield:";
            lblActualYield.AutoSize = true;
            lblCropLoss.Text = "Crop Loss:";
            lblCropLoss.AutoSize = true;

            // Configure numeric inputs
            numYear.Minimum = 2000;
            numYear.Maximum = 2100;
            numYear.Value = DateTime.Now.Year;

            numAcres.DecimalPlaces = 2;
            numAcres.Minimum = 0.01M;
            numAcres.Maximum = 1000M;
            numAcres.Increment = 0.1M;

            numExpectedYield.DecimalPlaces = 2;
            numExpectedYield.Minimum = 0M;
            numExpectedYield.Maximum = 10000M;

            numActualYield.DecimalPlaces = 2;
            numActualYield.Minimum = 0M;
            numActualYield.Maximum = 10000M;

            numCropLoss.DecimalPlaces = 2;
            numCropLoss.Minimum = 0M;
            numCropLoss.Maximum = 10000M;

            // Configure buttons
            btnSave.Text = "Save";
            btnSave.BackColor = Color.ForestGreen;
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Click += new EventHandler(btnSave_Click);

            btnCancel.Text = "Cancel";
            btnCancel.BackColor = Color.Gray;
            btnCancel.ForeColor = Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Click += new EventHandler(btnCancel_Click);

            // Set up combobox event handlers
            cboFarmers.SelectedIndexChanged += new EventHandler(cboFarmers_SelectedIndexChanged);

            // Layout
            pnlEntry.SuspendLayout();
            TableLayoutPanel tblEntry = new TableLayoutPanel();
            tblEntry.Dock = DockStyle.Fill;
            tblEntry.ColumnCount = 2;
            tblEntry.RowCount = 9;
            tblEntry.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tblEntry.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));

            for (int i = 0; i < 9; i++)
            {
                tblEntry.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            }

            tblEntry.Controls.Add(lblFarmer, 0, 0);
            tblEntry.Controls.Add(cboFarmers, 1, 0);
            tblEntry.Controls.Add(lblField, 0, 1);
            tblEntry.Controls.Add(cboFields, 1, 1);
        
            tblEntry.Controls.Add(lblYear, 0, 3);
            tblEntry.Controls.Add(numYear, 1, 3);
            tblEntry.Controls.Add(lblAcres, 0, 4);
            tblEntry.Controls.Add(numAcres, 1, 4);
            tblEntry.Controls.Add(lblExpectedYield, 0, 5);
            tblEntry.Controls.Add(numExpectedYield, 1, 5);
            tblEntry.Controls.Add(lblActualYield, 0, 6);
            tblEntry.Controls.Add(numActualYield, 1, 6);
            tblEntry.Controls.Add(lblCropLoss, 0, 7);
            tblEntry.Controls.Add(numCropLoss, 1, 7);

            FlowLayoutPanel flpButtons = new FlowLayoutPanel();
            flpButtons.FlowDirection = FlowDirection.RightToLeft;
            flpButtons.Dock = DockStyle.Fill;
            flpButtons.Controls.Add(btnCancel);
            flpButtons.Controls.Add(btnSave);
            tblEntry.Controls.Add(flpButtons, 1, 8);

            pnlEntry.Controls.Add(tblEntry);
            pnlEntry.ResumeLayout();

            // Add the panels to the user control
            this.Controls.Add(pnlEntry);
            this.Controls.Add(pnlList);
        }

        private void Cultivation_Load(object sender, EventArgs e)
        {
            LoadCultivationData();
            StyleCultivationGrid();
        }

        private void LoadCultivationData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT c.CultivationID, c.FarmerID, u.FullName AS FarmerName, " +
                               "c.FieldID, c.Year, c.AcresCultivated, " +
                               "c.ExpectedYield, c.ActualYield, c.CropLoss, c.CreatedAt " +
                               "FROM Cultivation c " +
                               "INNER JOIN Users u ON c.FarmerID = u.UserID " +
                               "ORDER BY c.CreatedAt DESC";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dgvCultivation.DataSource = table;
            }
        }

        private void LoadFarmers()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT UserID, FullName FROM Users 
                                 WHERE RoleID = 2 AND Status = 'Active' ORDER BY FullName"; // RoleID 2 = Farmer
                
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);

                cboFarmers.DataSource = table;
                cboFarmers.DisplayMember = "FullName";
                cboFarmers.ValueMember = "UserID";
            }
        }

        private void LoadFieldsByFarmer(int farmerId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT FieldID, CONCAT('Field #', FieldID, ' - ', LocationCoordinates, ' (', FieldSize, ' acres)') AS FieldInfo " +
                              "FROM Fields WHERE FarmerID = @FarmerID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FarmerID", farmerId);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);

                cboFields.DataSource = table;
                cboFields.DisplayMember = "FieldInfo";
                cboFields.ValueMember = "FieldID";
            }
        }

        private void StyleCultivationGrid()
        {
            dgvCultivation.EnableHeadersVisualStyles = false;
            dgvCultivation.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dgvCultivation.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvCultivation.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
            dgvCultivation.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvCultivation.DefaultCellStyle.BackColor = Color.White;
            dgvCultivation.DefaultCellStyle.ForeColor = Color.Black;
            dgvCultivation.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10);
            dgvCultivation.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCultivation.DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue;
            dgvCultivation.DefaultCellStyle.SelectionForeColor = Color.Black;

            dgvCultivation.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dgvCultivation.RowTemplate.Height = 28;
            dgvCultivation.GridColor = Color.LightGray;
            dgvCultivation.BorderStyle = BorderStyle.Fixed3D;
            dgvCultivation.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvCultivation.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCultivation.MultiSelect = false;
            dgvCultivation.AllowUserToAddRows = false;
            dgvCultivation.ReadOnly = true;
        }

        #endregion

        #region Button Click Events

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCultivation.CurrentRow != null)
            {
                int id = Convert.ToInt32(dgvCultivation.CurrentRow.Cells["CultivationID"].Value);
                DialogResult confirm = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("DELETE FROM Cultivation WHERE CultivationID = @id", conn);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                    LoadCultivationData();
                    MessageBox.Show("Record deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please select a record to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "PDF files (*.pdf)|*.pdf",
                FileName = "Cultivation_Report.pdf"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Document doc = new Document(PageSize.A4.Rotate());
                    PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                    doc.Open();

                    // Add title
                    Paragraph title = new Paragraph("Rice Cultivation Report")
                    {
                        Alignment = Element.ALIGN_CENTER,
                        SpacingAfter = 20f
                    };
                    title.Font.SetStyle(iTextSharp.text.Font.BOLD);
                    title.Font.Size = 18;
                    doc.Add(title);

                    // Add date
                    Paragraph dateText = new Paragraph($"Generated on: {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}")
                    {
                        Alignment = Element.ALIGN_RIGHT,
                        SpacingAfter = 20f
                    };
                    doc.Add(dateText);

                    PdfPTable pdfTable = new PdfPTable(dgvCultivation.Columns.Count);
                    pdfTable.WidthPercentage = 100;
                    float[] widths = new float[dgvCultivation.Columns.Count];
                    for (int i = 0; i < dgvCultivation.Columns.Count; i++)
                    {
                        widths[i] = 4f;
                    }
                    pdfTable.SetWidths(widths);

                    // Add headers
                    foreach (DataGridViewColumn column in dgvCultivation.Columns)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText))
                        {
                            BackgroundColor = new BaseColor(0, 0, 128), // Navy 
                            HorizontalAlignment = Element.ALIGN_CENTER,
                            VerticalAlignment = Element.ALIGN_MIDDLE,
                            Padding = 5
                        };
                        cell.PaddingTop = 8f;
                        cell.PaddingBottom = 8f;
                        cell.PaddingLeft = 4f;
                        cell.PaddingRight = 4f;

                        // Set text color to white
                        iTextSharp.text.Font font = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.BOLD, BaseColor.WHITE);
                        cell.Phrase = new Phrase(column.HeaderText, font);

                        pdfTable.AddCell(cell);
                    }

                    // Add data rows
                    foreach (DataGridViewRow row in dgvCultivation.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                PdfPCell pdfCell = new PdfPCell(new Phrase(cell.Value?.ToString() ?? ""))
                                {
                                    HorizontalAlignment = Element.ALIGN_CENTER,
                                    VerticalAlignment = Element.ALIGN_MIDDLE,
                                    Padding = 5
                                };
                                pdfTable.AddCell(pdfCell);
                            }
                        }
                    }

                    doc.Add(pdfTable);
                    doc.Close();

                    MessageBox.Show("Exported to PDF successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Open the PDF file
                    System.Diagnostics.Process.Start(sfd.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error exporting PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Set to Add mode
            isEditMode = false;
            editingCultivationId = 0;

            // Clear form inputs
            ClearEntryForm();

            // Load farmers
            LoadFarmers();

            // Show entry panel
            pnlList.Visible = false;
            pnlEntry.Visible = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvCultivation.CurrentRow != null)
            {
                // Set to Edit mode
                isEditMode = true;
                editingCultivationId = Convert.ToInt32(dgvCultivation.CurrentRow.Cells["CultivationID"].Value);

                // Load farmers
                LoadFarmers();
                
                // Populate form data after loading farmers
                PopulateEntryFormForEdit();

                // Show entry panel
                pnlList.Visible = false;
                pnlEntry.Visible = true;
            }
            else
            {
                MessageBox.Show("Please select a record to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                if (isEditMode)
                {
                    UpdateCultivationRecord();
                }
                else
                {
                    CreateCultivationRecord();
                }

                // Return to list view
                pnlEntry.Visible = false;
                pnlList.Visible = true;
                LoadCultivationData();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Return to list view without saving
            pnlEntry.Visible = false;
            pnlList.Visible = true;
        }

        #endregion

        #region Helper Methods

        private void PopulateEntryFormForEdit()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT c.FarmerID, c.FieldID, c.Year, c.AcresCultivated, " +
                               "c.ExpectedYield, c.ActualYield, c.CropLoss " +
                               "FROM Cultivation c WHERE c.CultivationID = @CultivationID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CultivationID", editingCultivationId);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    int farmerId = Convert.ToInt32(reader["FarmerID"]);
                    
                    // Close reader before making another database call
                    reader.Close();
                    
                    // Load fields for this farmer
                    LoadFieldsByFarmer(farmerId);
                    
                    // Set the farmer value
                    cboFarmers.SelectedValue = farmerId;
                    
                    // Re-query to get all data
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@CultivationID", editingCultivationId);
                    reader = cmd.ExecuteReader();
                    
                    if (reader.Read())
                    {
                        // Set field value
                        int fieldId = Convert.ToInt32(reader["FieldID"]);
                        cboFields.SelectedValue = fieldId;

                        // Set other field values
                        numYear.Value = Convert.ToDecimal(reader["Year"]);
                        numAcres.Value = Convert.ToDecimal(reader["AcresCultivated"]);
                        numExpectedYield.Value = Convert.ToDecimal(reader["ExpectedYield"]);

                        // Handle nullable fields
                        if (!reader.IsDBNull(reader.GetOrdinal("ActualYield")))
                            numActualYield.Value = Convert.ToDecimal(reader["ActualYield"]);
                        else
                            numActualYield.Value = 0;

                        if (!reader.IsDBNull(reader.GetOrdinal("CropLoss")))
                            numCropLoss.Value = Convert.ToDecimal(reader["CropLoss"]);
                        else
                            numCropLoss.Value = 0;
                    }
                }
                reader.Close();
            }
        }

        private void ClearEntryForm()
        {
            if (cboFarmers.Items.Count > 0)
                cboFarmers.SelectedIndex = 0;
            if (cboFields.Items.Count > 0)
                cboFields.SelectedIndex = 0;

            numYear.Value = DateTime.Now.Year;
            numAcres.Value = numAcres.Minimum;
            numExpectedYield.Value = 0;
            numActualYield.Value = 0;
            numCropLoss.Value = 0;
        }

        private bool ValidateForm()
        {
            if (cboFarmers.SelectedValue == null)
            {
                MessageBox.Show("Please select a farmer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cboFields.SelectedValue == null)
            {
                MessageBox.Show("Please select a field.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (numAcres.Value <= 0)
            {
                MessageBox.Show("Acres cultivated must be greater than zero.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void CreateCultivationRecord()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO Cultivation (FarmerID, FieldID, Year, AcresCultivated, " +
                                  "ExpectedYield, ActualYield, CropLoss) " +
                                  "VALUES (@FarmerID, @FieldID, @Year, @AcresCultivated, " +
                                  "@ExpectedYield, @ActualYield, @CropLoss)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@FarmerID", cboFarmers.SelectedValue);
                    cmd.Parameters.AddWithValue("@FieldID", cboFields.SelectedValue);
                
                    cmd.Parameters.AddWithValue("@Year", (int)numYear.Value);
                    cmd.Parameters.AddWithValue("@AcresCultivated", numAcres.Value);
                    cmd.Parameters.AddWithValue("@ExpectedYield", numExpectedYield.Value);

                    // Handle nullable fields
                    if (numActualYield.Value > 0)
                        cmd.Parameters.AddWithValue("@ActualYield", numActualYield.Value);
                    else
                        cmd.Parameters.AddWithValue("@ActualYield", DBNull.Value);

                    if (numCropLoss.Value > 0)
                        cmd.Parameters.AddWithValue("@CropLoss", numCropLoss.Value);
                    else
                        cmd.Parameters.AddWithValue("@CropLoss", DBNull.Value);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Cultivation record added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding cultivation record: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateCultivationRecord()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE Cultivation SET FarmerID = @FarmerID, FieldID = @FieldID, " +
                                  "Year = @Year, AcresCultivated = @AcresCultivated, " +
                                  "ExpectedYield = @ExpectedYield, ActualYield = @ActualYield, " +
                                  "CropLoss = @CropLoss " +
                                  "WHERE CultivationID = @CultivationID";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@CultivationID", editingCultivationId);
                    cmd.Parameters.AddWithValue("@FarmerID", cboFarmers.SelectedValue);
                    cmd.Parameters.AddWithValue("@FieldID", cboFields.SelectedValue);
                  
                    cmd.Parameters.AddWithValue("@Year", (int)numYear.Value);
                    cmd.Parameters.AddWithValue("@AcresCultivated", numAcres.Value);
                    cmd.Parameters.AddWithValue("@ExpectedYield", numExpectedYield.Value);

                    // Handle nullable fields
                    if (numActualYield.Value > 0)
                        cmd.Parameters.AddWithValue("@ActualYield", numActualYield.Value);
                    else
                        cmd.Parameters.AddWithValue("@ActualYield", DBNull.Value);

                    if (numCropLoss.Value > 0)
                        cmd.Parameters.AddWithValue("@CropLoss", numCropLoss.Value);
                    else
                        cmd.Parameters.AddWithValue("@CropLoss", DBNull.Value);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Cultivation record updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating cultivation record: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Event Handlers

        private void cboFarmers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboFarmers.SelectedValue != null)
            {
                try
                {
                    int farmerId = Convert.ToInt32(cboFarmers.SelectedValue);
                    LoadFieldsByFarmer(farmerId);
                }
                catch (Exception ex)
                {
                    // Handle conversion error if needed
                    Console.WriteLine("Error converting farmer ID: " + ex.Message);
                }
            }
        }

        #endregion

        #region Designer Variables

        private Panel pnlList;
        private Panel pnlEntry;

        private Label lblFarmer;
        private ComboBox cboFarmers;
        private Label lblField;
        private ComboBox cboFields;
     
        private Label lblYear;
        private NumericUpDown numYear;
        private Label lblAcres;
        private NumericUpDown numAcres;
        private Label lblExpectedYield;
        private NumericUpDown numExpectedYield;
        private Label lblActualYield;
        private NumericUpDown numActualYield;
        private Label lblCropLoss;
        private NumericUpDown numCropLoss;
        private Button btnSave;
        private Button btnCancel;

        #endregion
    }
}