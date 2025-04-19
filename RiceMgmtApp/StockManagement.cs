using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace RiceMgmtApp
{
    public partial class StockManagement : UserControl
    {
        private readonly string connectionString = "Server=DESKTOP-O6K3I3U\\SQLEXPRESS;Database=RiceProductionDB2;Integrated Security=True;";
        private int currentUserID;
        private int currentUserRoleID;

        public StockManagement(int userID, int roleID)
        {
            InitializeComponent();
            currentUserID = userID;
            currentUserRoleID = roleID;
            ConfigureBasedOnRole();
        }

        private void StockManagement_Load(object sender, EventArgs e)
        {
            LoadStockData();
        }

        private void ConfigureBasedOnRole()
        {
            // Configure buttons and interface based on role
            switch (currentUserRoleID)
            {
                case 1: // Admin
                    // Full access - enable all controls
                    btnAdd.Visible = true;
                    btnEdit.Visible = true;
                    btnDelete.Visible = true;
                    btnExportPDF.Visible = true;
                    break;

                case 2: // Farmer
                    // Can only view own stock and add/edit/delete own records
                    btnAdd.Visible = true;
                    btnEdit.Visible = true;
                    btnDelete.Visible = true;
                    btnExportPDF.Visible = true;
                    // Filter will be applied in LoadStockData
                    break;

                case 3: // Government
                    // View only access
                    btnAdd.Visible = false;
                    btnEdit.Visible = false;
                    btnDelete.Visible = false;
                    btnExportPDF.Visible = true;
                    break;

                case 4: // Private Buyer
                    // No access - this should be handled at navigation level
                    // But in case they somehow access this control:
                    MessageBox.Show("You do not have permission to access Stock Management.",
                                   "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Enabled = false;
                    break;
            }
        }

        private void LoadStockData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query;

                    if (currentUserRoleID == 2) // Farmer - show only own stock
                    {
                        query = @"SELECT S.StockID, U.FullName AS FarmerName, S.CropType, S.Quantity, S.LastUpdated
                                FROM Stock S
                                INNER JOIN Users U ON S.FarmerID = U.UserID
                                WHERE S.FarmerID = @UserID";
                    }
                    else // Admin or Government - show all
                    {
                        query = @"SELECT S.StockID, U.FullName AS FarmerName, S.CropType, S.Quantity, S.LastUpdated
                                FROM Stock S
                                INNER JOIN Users U ON S.FarmerID = U.UserID";
                    }

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (currentUserRoleID == 2) // Add parameter for farmer filter
                        {
                            cmd.Parameters.AddWithValue("@UserID", currentUserID);
                        }

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridViewStock.DataSource = dt;
                    }
                }

                // Format the DataGridView for better readability
                FormatDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading stock data: " + ex.Message, "Database Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatDataGridView()
        {
            dataGridViewStock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewStock.AllowUserToAddRows = false;
            dataGridViewStock.AllowUserToDeleteRows = false;
            dataGridViewStock.ReadOnly = true;
            dataGridViewStock.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Style header row
            dataGridViewStock.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 10F, FontStyle.Bold);
            dataGridViewStock.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(200, 230, 201); // Light green for rice theme
            dataGridViewStock.ColumnHeadersDefaultCellStyle.ForeColor = Color.DarkGreen;

            // Format datetime column
            if (dataGridViewStock.Columns["LastUpdated"] != null)
            {
                dataGridViewStock.Columns["LastUpdated"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm";
            }

            // Format quantity with 2 decimal places
            if (dataGridViewStock.Columns["Quantity"] != null)
            {
                dataGridViewStock.Columns["Quantity"].DefaultCellStyle.Format = "N2";
            }

            // Alternate row colors for better readability
            dataGridViewStock.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 248, 240); // Very light green
            dataGridViewStock.DefaultCellStyle.SelectionBackColor = Color.FromArgb(76, 175, 80); // Material Green
            dataGridViewStock.DefaultCellStyle.SelectionForeColor = Color.White;
        }

        private int GetFarmerIdByStockId(int stockId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT FarmerID FROM Stock WHERE StockID = @StockID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@StockID", stockId);
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            return Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving farmer information: " + ex.Message, "Database Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return -1; // Invalid ID
        }

        private void DeleteStock(int stockId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM Stock WHERE StockID = @StockID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@StockID", stockId);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Stock entry deleted successfully.", "Delete Successful",
                                           MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete stock entry.", "Delete Failed",
                                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting stock entry: " + ex.Message, "Database Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Check if current user is allowed to add stock
            if (currentUserRoleID != 1 && currentUserRoleID != 2) // Only Admin and Farmer can add
            {
                MessageBox.Show("You don't have permission to add stock entries.", "Permission Denied",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Open a form to add new stock
            StockEntryForm stockForm = new StockEntryForm(currentUserID, currentUserRoleID, 0); // 0 means new entry
            if (stockForm.ShowDialog() == DialogResult.OK)
            {
                LoadStockData(); // Refresh data after adding
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewStock.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a record to edit.", "No Selection",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int stockId = Convert.ToInt32(dataGridViewStock.SelectedRows[0].Cells["StockID"].Value);

            // For farmers, verify they own this stock before allowing edit
            if (currentUserRoleID == 2)
            {
                int farmerId = GetFarmerIdByStockId(stockId);
                if (farmerId != currentUserID)
                {
                    MessageBox.Show("You can only edit your own stock entries.", "Permission Denied",
                                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else if (currentUserRoleID != 1) // Not an admin
            {
                MessageBox.Show("You don't have permission to edit stock entries.", "Permission Denied",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Open edit form
            StockEntryForm stockForm = new StockEntryForm(currentUserID, currentUserRoleID, stockId);
            if (stockForm.ShowDialog() == DialogResult.OK)
            {
                LoadStockData(); // Refresh data after editing
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewStock.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a record to delete.", "No Selection",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int stockId = Convert.ToInt32(dataGridViewStock.SelectedRows[0].Cells["StockID"].Value);

            // For farmers, verify they own this stock before allowing delete
            if (currentUserRoleID == 2)
            {
                int farmerId = GetFarmerIdByStockId(stockId);
                if (farmerId != currentUserID)
                {
                    MessageBox.Show("You can only delete your own stock entries.", "Permission Denied",
                                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else if (currentUserRoleID != 1) // Not an admin
            {
                MessageBox.Show("You don't have permission to delete stock entries.", "Permission Denied",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Confirm deletion
            if (MessageBox.Show("Are you sure you want to delete this stock entry?", "Confirm Delete",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DeleteStock(stockId);
                LoadStockData(); // Refresh data after deleting
            }
        }

        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            if (dataGridViewStock.Rows.Count == 0)
            {
                MessageBox.Show("No data to export.", "Export Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "PDF files (*.pdf)|*.pdf",
                FileName = "StockReport.pdf"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Document doc = new Document(PageSize.A4, 10, 10, 10, 10);
                try
                {
                    PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                    doc.Open();

                    // Add title and timestamp
                    Paragraph title = new Paragraph("Rice Stock Report",
                                     FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18))
                    {
                        Alignment = Element.ALIGN_CENTER,
                        SpacingAfter = 10f
                    };
                    doc.Add(title);

                    Paragraph timestamp = new Paragraph($"Generated: {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}",
                                         FontFactory.GetFont(FontFactory.HELVETICA, 10))
                    {
                        Alignment = Element.ALIGN_CENTER,
                        SpacingAfter = 20f
                    };
                    doc.Add(timestamp);

                    // Create table
                    PdfPTable table = new PdfPTable(dataGridViewStock.Columns.Count);
                    table.WidthPercentage = 100;
                    float[] widths = new float[dataGridViewStock.Columns.Count];

                    // Customize column widths
                    for (int i = 0; i < dataGridViewStock.Columns.Count; i++)
                    {
                        if (dataGridViewStock.Columns[i].HeaderText.Contains("Name"))
                            widths[i] = 3f; // Name columns wider
                        else if (dataGridViewStock.Columns[i].HeaderText.Contains("Type"))
                            widths[i] = 2f; // Type columns medium
                        else if (dataGridViewStock.Columns[i].HeaderText.Contains("Updated"))
                            widths[i] = 2f; // Date columns medium
                        else
                            widths[i] = 1f; // Default width
                    }
                    table.SetWidths(widths);

                    // Add headers
                    foreach (DataGridViewColumn column in dataGridViewStock.Columns)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText,
                                        FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10)))
                        {
                            BackgroundColor = new BaseColor(200, 230, 201), // Match the UI green theme
                            HorizontalAlignment = Element.ALIGN_CENTER,
                            Padding = 5
                        };
                        table.AddCell(cell);
                    }

                    // Add data rows
                    foreach (DataGridViewRow row in dataGridViewStock.Rows)
                    {
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            PdfPCell cell = new PdfPCell(new Phrase(row.Cells[i].Value?.ToString() ?? "",
                                            FontFactory.GetFont(FontFactory.HELVETICA, 9)))
                            {
                                Padding = 4
                            };

                            // Center ID and quantity columns
                            if (i == 0 || i == 3) // StockID or Quantity column
                                cell.HorizontalAlignment = Element.ALIGN_CENTER;

                            table.AddCell(cell);
                        }
                    }
                    doc.Add(table);

                    MessageBox.Show("PDF exported successfully!", "Export Complete",
                                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error generating PDF: " + ex.Message, "Export Error",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    doc.Close();
                }
            }
        }
    }

    // This is the dialog form for adding/editing stock entries
    public class StockEntryForm : Form
    {
        private readonly string connectionString = "Server=DESKTOP-O6K3I3U\\SQLEXPRESS;Database=RiceProductionDB2;Integrated Security=True;";
        private int currentUserID;
        private int currentUserRoleID;
        private int stockID; // 0 for new entry, >0 for editing existing

        // Form controls
        private ComboBox cmbCropType;
        private TextBox txtQuantity;
        private ComboBox cmbFarmer; // For admin to select farmer
        private Button btnSave;
        private Button btnCancel;
        private Label lblCropType;
        private Label lblQuantity;
        private Label lblFarmer;
        private Panel headerPanel;
        private Label lblHeader;

        public StockEntryForm(int userID, int roleID, int stockId)
        {
            currentUserID = userID;
            currentUserRoleID = roleID;
            stockID = stockId;

            InitializeComponent();
            StyleControls();
            LoadFormData();
        }

        private void InitializeComponent()
        {
            this.Text = stockID > 0 ? "Edit Stock Entry" : "Add New Stock Entry";
            this.Size = new Size(450, 350);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.White;

            // Header panel
            headerPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = Color.FromArgb(76, 175, 80) // Material Green
            };

            lblHeader = new Label
            {
                Text = stockID > 0 ? "Edit Stock Entry" : "Add New Stock Entry",
                ForeColor = Color.White,
                Font = new System.Drawing.Font("Arial", 14F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };

            headerPanel.Controls.Add(lblHeader);

            // Create labels with improved styling
            lblCropType = new Label
            {
                Text = "Crop Type:",
                Location = new Point(40, 90),
                Size = new Size(120, 25),
                Font = new System.Drawing.Font("Arial", 10F)
            };

            lblQuantity = new Label
            {
                Text = "Quantity (kg):",
                Location = new Point(40, 140),
                Size = new Size(120, 25),
                Font = new System.Drawing.Font("Arial", 10F)
            };

            lblFarmer = new Label
            {
                Text = "Farmer:",
                Location = new Point(40, 190),
                Size = new Size(120, 25),
                Font = new System.Drawing.Font("Arial", 10F),
                Visible = (currentUserRoleID == 1) // Only visible to Admin
            };

            // Create input controls with improved styling
            cmbCropType = new ComboBox
            {
                Location = new Point(160, 90),
                Size = new Size(240, 25),
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new System.Drawing.Font("Arial", 10F)
            };
            cmbCropType.Items.AddRange(new object[] {
                "Red Nadu", "White Nadu", "White Samba", "Red Samba",
                "Keeri Samba", "Red Raw Rice", "White Raw Rice"
            });

            txtQuantity = new TextBox
            {
                Location = new Point(160, 140),
                Size = new Size(240, 25),
                Font = new System.Drawing.Font("Arial", 10F)
            };

            cmbFarmer = new ComboBox
            {
                Location = new Point(160, 190),
                Size = new Size(240, 25),
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new System.Drawing.Font("Arial", 10F),
                Visible = (currentUserRoleID == 1) // Only visible to Admin
            };

            // Create buttons with improved styling
            btnSave = new Button
            {
                Text = "Save",
                Location = new Point(160, 250),
                Size = new Size(100, 35),
                DialogResult = DialogResult.OK,
                Font = new System.Drawing.Font("Arial", 10F),
                BackColor = Color.FromArgb(76, 175, 80), // Green
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Click += BtnSave_Click;

            btnCancel = new Button
            {
                Text = "Cancel",
                Location = new Point(280, 250),
                Size = new Size(100, 35),
                DialogResult = DialogResult.Cancel,
                Font = new System.Drawing.Font("Arial", 10F),
                BackColor = Color.FromArgb(158, 158, 158), // Gray
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnCancel.FlatAppearance.BorderSize = 0;

            // Add controls to form
            this.Controls.Add(headerPanel);
            this.Controls.Add(lblCropType);
            this.Controls.Add(cmbCropType);
            this.Controls.Add(lblQuantity);
            this.Controls.Add(txtQuantity);
            this.Controls.Add(lblFarmer);
            this.Controls.Add(cmbFarmer);
            this.Controls.Add(btnSave);
            this.Controls.Add(btnCancel);

            this.AcceptButton = btnSave;
            this.CancelButton = btnCancel;
        }

        private void StyleControls()
        {
            // Additional styling for input controls
            txtQuantity.BorderStyle = BorderStyle.FixedSingle;

            // Add event handlers for visual feedback
            btnSave.MouseEnter += (s, e) => btnSave.BackColor = Color.FromArgb(56, 142, 60); // Darker green on hover
            btnSave.MouseLeave += (s, e) => btnSave.BackColor = Color.FromArgb(76, 175, 80);

            btnCancel.MouseEnter += (s, e) => btnCancel.BackColor = Color.FromArgb(117, 117, 117); // Darker gray on hover
            btnCancel.MouseLeave += (s, e) => btnCancel.BackColor = Color.FromArgb(158, 158, 158);
        }

        private void LoadFormData()
        {
            // If admin, load farmer list
            if (currentUserRoleID == 1)
            {
                LoadFarmersList();
            }

            // If editing existing record, load its data
            if (stockID > 0)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = @"SELECT S.CropType, S.Quantity, S.FarmerID 
                                        FROM Stock S WHERE S.StockID = @StockID";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@StockID", stockID);
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    cmbCropType.Text = reader["CropType"].ToString();
                                    txtQuantity.Text = reader["Quantity"].ToString();

                                    if (currentUserRoleID == 1) // Admin
                                    {
                                        int farmerId = Convert.ToInt32(reader["FarmerID"]);
                                        // Select the farmer in dropdown
                                        foreach (DataRowView item in cmbFarmer.Items)
                                        {
                                            if (Convert.ToInt32(item["UserID"]) == farmerId)
                                            {
                                                cmbFarmer.SelectedItem = item;
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading stock data: " + ex.Message, "Database Error",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
        }

        private void LoadFarmersList()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"SELECT UserID, FullName FROM Users 
                                    WHERE RoleID = 2 AND Status = 'Active'"; // RoleID 2 = Farmer
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    cmbFarmer.DataSource = dt;
                    cmbFarmer.DisplayMember = "FullName";
                    cmbFarmer.ValueMember = "UserID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading farmers list: " + ex.Message, "Database Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(cmbCropType.Text))
            {
                MessageBox.Show("Please select a crop type.", "Validation Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtQuantity.Text) ||
                !decimal.TryParse(txtQuantity.Text, out decimal quantity) ||
                quantity <= 0)
            {
                MessageBox.Show("Please enter a valid quantity (numeric value greater than zero).",
                              "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int farmerID;
            if (currentUserRoleID == 1) // Admin
            {
                if (cmbFarmer.SelectedValue == null)
                {
                    MessageBox.Show("Please select a farmer.", "Validation Error",
                                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                farmerID = Convert.ToInt32(cmbFarmer.SelectedValue);
            }
            else // Farmer
            {
                farmerID = currentUserID;
            }

            // Save to database
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query;
                    SqlCommand cmd;

                    if (stockID > 0) // Update existing record
                    {
                        query = @"UPDATE Stock SET CropType = @CropType, 
                                Quantity = @Quantity, FarmerID = @FarmerID, 
                                LastUpdated = GETDATE() 
                                WHERE StockID = @StockID";
                        cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@StockID", stockID);
                    }
                    else // Insert new record
                    {
                        query = @"INSERT INTO Stock (CropType, Quantity, FarmerID, LastUpdated) 
                                VALUES (@CropType, @Quantity, @FarmerID, GETDATE())";
                        cmd = new SqlCommand(query, conn);
                    }

                    // Add common parameters
                    cmd.Parameters.AddWithValue("@CropType", cmbCropType.Text);
                    cmd.Parameters.AddWithValue("@Quantity", quantity);
                    cmd.Parameters.AddWithValue("@FarmerID", farmerID);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Stock information saved successfully!", "Save Successful",
                                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Failed to save stock information.", "Save Failed",
                                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving stock information: " + ex.Message, "Database Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
            }
        }
    }
}