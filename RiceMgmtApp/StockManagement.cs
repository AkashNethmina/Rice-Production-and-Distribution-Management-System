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
            switch (currentUserRoleID)
            {
                case 1: // Admin
                 
                    btnAdd.Visible = true;
                    btnEdit.Visible = true;
                    btnDelete.Visible = true;
                    btnExportPDF.Visible = true;
                    break;

                case 2: // Farmer
                    
                    btnAdd.Visible = true;
                    btnEdit.Visible = true;
                    btnDelete.Visible = true;
                    btnExportPDF.Visible = true;
                   
                    break;

                case 3: // Government
                   
                    btnAdd.Visible = false;
                    btnEdit.Visible = false;
                    btnDelete.Visible = false;
                    btnExportPDF.Visible = true;
                    break;

                case 4: // Private Buyer
                    
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

                    if (currentUserRoleID == 2) 
                    {
                        query = @"SELECT S.StockID, U.FullName AS FarmerName, S.CropType, S.Quantity, S.LastUpdated
                                FROM Stock S
                                INNER JOIN Users U ON S.FarmerID = U.UserID
                                WHERE S.FarmerID = @UserID";
                    }
                    else 
                    {
                        query = @"SELECT S.StockID, U.FullName AS FarmerName, S.CropType, S.Quantity, S.LastUpdated
                                FROM Stock S
                                INNER JOIN Users U ON S.FarmerID = U.UserID";
                    }

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (currentUserRoleID == 2) 
                        {
                            cmd.Parameters.AddWithValue("@UserID", currentUserID);
                        }

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridViewStock.DataSource = dt;
                    }
                }

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

            dataGridViewStock.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 10F, FontStyle.Bold);
            dataGridViewStock.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(200, 230, 201);
            dataGridViewStock.ColumnHeadersDefaultCellStyle.ForeColor = Color.DarkGreen;

            if (dataGridViewStock.Columns["LastUpdated"] != null)
            {
                dataGridViewStock.Columns["LastUpdated"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm";
            }

            if (dataGridViewStock.Columns["Quantity"] != null)
            {
                dataGridViewStock.Columns["Quantity"].DefaultCellStyle.Format = "N2";
            }

            dataGridViewStock.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 248, 240);
            dataGridViewStock.DefaultCellStyle.SelectionBackColor = Color.FromArgb(76, 175, 80);
            dataGridViewStock.DefaultCellStyle.SelectionForeColor = Color.White;

           
            if (dataGridViewStock.Columns["FarmerName"] != null)
            {
                dataGridViewStock.Columns["FarmerName"].Visible = currentUserRoleID != 2;
            }
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
            return -1;
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
          
            if (currentUserRoleID != 1 && currentUserRoleID != 2)
            {
                MessageBox.Show("You don't have permission to add stock entries.", "Permission Denied",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            StockEntryForm stockForm = new StockEntryForm(currentUserID, currentUserRoleID, 0); 
            if (stockForm.ShowDialog() == DialogResult.OK)
            {
                LoadStockData(); 
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
            else if (currentUserRoleID != 1)
            {
                MessageBox.Show("You don't have permission to edit stock entries.", "Permission Denied",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

         
            StockEntryForm stockForm = new StockEntryForm(currentUserID, currentUserRoleID, stockId);
            if (stockForm.ShowDialog() == DialogResult.OK)
            {
                LoadStockData();
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
            else if (currentUserRoleID != 1)
            {
                MessageBox.Show("You don't have permission to delete stock entries.", "Permission Denied",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

           
            if (MessageBox.Show("Are you sure you want to delete this stock entry?", "Confirm Delete",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DeleteStock(stockId);
                LoadStockData(); 
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

                   
                    PdfPTable table = new PdfPTable(dataGridViewStock.Columns.Count);
                    table.WidthPercentage = 100;
                    float[] widths = new float[dataGridViewStock.Columns.Count];

                 
                    for (int i = 0; i < dataGridViewStock.Columns.Count; i++)
                    {
                        if (dataGridViewStock.Columns[i].HeaderText.Contains("Name"))
                            widths[i] = 3f; 
                        else if (dataGridViewStock.Columns[i].HeaderText.Contains("Type"))
                            widths[i] = 2f;
                        else if (dataGridViewStock.Columns[i].HeaderText.Contains("Updated"))
                            widths[i] = 2f; 
                        else
                            widths[i] = 1f; 
                    }
                    table.SetWidths(widths);

                  
                    foreach (DataGridViewColumn column in dataGridViewStock.Columns)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText,
                                        FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10)))
                        {
                            BackgroundColor = new BaseColor(200, 230, 201), 
                            HorizontalAlignment = Element.ALIGN_CENTER,
                            Padding = 5
                        };
                        table.AddCell(cell);
                    }

                  
                    foreach (DataGridViewRow row in dataGridViewStock.Rows)
                    {
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            PdfPCell cell = new PdfPCell(new Phrase(row.Cells[i].Value?.ToString() ?? "",
                                            FontFactory.GetFont(FontFactory.HELVETICA, 9)))
                            {
                                Padding = 4
                            };
                            if (i == 0 || i == 3) 
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
    public class StockEntryForm : Form
    {
        private readonly string connectionString = "Server=DESKTOP-O6K3I3U\\SQLEXPRESS;Database=RiceProductionDB2;Integrated Security=True;";
        private int currentUserID;
        private int currentUserRoleID;
        private int stockID; 

      
        private ComboBox cmbCropType;
        private TextBox txtQuantity;
        private ComboBox cmbFarmer; 
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

           
            headerPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = Color.FromArgb(76, 175, 80) 
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
                Visible = (currentUserRoleID == 1) 
            };

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
                Visible = (currentUserRoleID == 1) 
            };

         
            btnSave = new Button
            {
                Text = "Save",
                Location = new Point(160, 250),
                Size = new Size(100, 35),
                DialogResult = DialogResult.OK,
                Font = new System.Drawing.Font("Arial", 10F),
                BackColor = Color.FromArgb(76, 175, 80), 
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
                BackColor = Color.FromArgb(158, 158, 158), 
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnCancel.FlatAppearance.BorderSize = 0;

           
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
           
            txtQuantity.BorderStyle = BorderStyle.FixedSingle;

           
            btnSave.MouseEnter += (s, e) => btnSave.BackColor = Color.FromArgb(56, 142, 60); 
            btnSave.MouseLeave += (s, e) => btnSave.BackColor = Color.FromArgb(76, 175, 80);

            btnCancel.MouseEnter += (s, e) => btnCancel.BackColor = Color.FromArgb(117, 117, 117); 
            btnCancel.MouseLeave += (s, e) => btnCancel.BackColor = Color.FromArgb(158, 158, 158);
        }

        private void LoadFormData()
        {
           
            if (currentUserRoleID == 1)
            {
                LoadFarmersList();
            }

           
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
                                    WHERE RoleID = 2 AND Status = 'Active'"; 
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

         
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query;
                    SqlCommand cmd;

                    if (stockID > 0) 
                    {
                        query = @"UPDATE Stock SET CropType = @CropType, 
                                Quantity = @Quantity, FarmerID = @FarmerID, 
                                LastUpdated = GETDATE() 
                                WHERE StockID = @StockID";
                        cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@StockID", stockID);
                    }
                    else 
                    {
                        query = @"INSERT INTO Stock (CropType, Quantity, FarmerID, LastUpdated) 
                                VALUES (@CropType, @Quantity, @FarmerID, GETDATE())";
                        cmd = new SqlCommand(query, conn);
                    }

                   
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