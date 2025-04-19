using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RiceMgmtApp
{
    public partial class Price_Monitoring : UserControl
    {
        private SqlConnection connection;
        private readonly string connectionString = "Server=DESKTOP-O6K3I3U\\SQLEXPRESS;Database=RiceProductionDB2;Integrated Security=True;";
        private int currentUserRoleID;
        private Timer refreshTimer;

        // UI Controls
        //private DataGridView dataGridViewPrices;
        //private ComboBox cmbCropType;
        //private NumericUpDown numThreshold;
        //private Button btnRefresh;
        //private Button btnSetPrice;
        //private Panel pnlAlerts;

        public Price_Monitoring(int userRoleID)
        {
            InitializeComponent();
            this.currentUserRoleID = userRoleID;

            // Initialize UI components that weren't in the designer
            InitializeCustomComponents();

            // Set up refresh timer (update every 5 minutes)
            refreshTimer = new Timer();
            refreshTimer.Interval = 300000; // 5 minutes
            refreshTimer.Tick += new EventHandler(RefreshData);
            refreshTimer.Start();
        }

        private void InitializeCustomComponents()
        {
            // Main container with proper padding
            TableLayoutPanel mainLayout = new TableLayoutPanel();
            mainLayout.Dock = DockStyle.Fill;
            mainLayout.RowCount = 4;
            mainLayout.ColumnCount = 1;
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 65F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 35F));
            mainLayout.Padding = new Padding(15);
            mainLayout.BackColor = Color.FromArgb(245, 247, 250);

            // Data Grid View for price monitoring with modern styling
            dataGridViewPrices = new DataGridView();
            dataGridViewPrices.Dock = DockStyle.Fill;
            dataGridViewPrices.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewPrices.AllowUserToAddRows = false;
            dataGridViewPrices.AllowUserToDeleteRows = false;
            dataGridViewPrices.ReadOnly = true;
            dataGridViewPrices.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewPrices.MultiSelect = false;
            dataGridViewPrices.RowHeadersVisible = false;
            dataGridViewPrices.BackgroundColor = Color.White;
            dataGridViewPrices.BorderStyle = BorderStyle.None;
            dataGridViewPrices.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewPrices.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewPrices.EnableHeadersVisualStyles = false;
            dataGridViewPrices.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(37, 150, 190);
            dataGridViewPrices.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewPrices.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewPrices.ColumnHeadersHeight = 40;
            dataGridViewPrices.RowTemplate.Height = 35;
            dataGridViewPrices.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dataGridViewPrices.DefaultCellStyle.SelectionBackColor = Color.FromArgb(87, 200, 240);
            dataGridViewPrices.DefaultCellStyle.Font = new Font("Segoe UI", 9F);

            // CropType ComboBox with modern styling
            cmbCropType = new ComboBox();
            cmbCropType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCropType.Width = 200;
            cmbCropType.Font = new Font("Segoe UI", 9F);
            cmbCropType.SelectedIndexChanged += new EventHandler(cmbCropType_SelectedIndexChanged);

            // Set threshold input with modern styling
            numThreshold = new NumericUpDown();
            numThreshold.DecimalPlaces = 2;
            numThreshold.Minimum = 0;
            numThreshold.Maximum = 1000;
            numThreshold.Value = 5; // Default threshold of 5
            numThreshold.Width = 100;
            numThreshold.Font = new Font("Segoe UI", 9F);

            // Buttons with modern styling
            btnRefresh = new Button();
            btnRefresh.Text = "Refresh Data";
            btnRefresh.Width = 110;
            btnRefresh.Height = 32;
            btnRefresh.BackColor = Color.FromArgb(37, 150, 190);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.Font = new Font("Segoe UI", 9F);
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.Click += new EventHandler(btnRefresh_Click);

            btnSetPrice = new Button();
            btnSetPrice.Text = "Set Government Price";
            btnSetPrice.Width = 150;
            btnSetPrice.Height = 32;
            btnSetPrice.BackColor = Color.FromArgb(37, 150, 190);
            btnSetPrice.ForeColor = Color.White;
            btnSetPrice.FlatStyle = FlatStyle.Flat;
            btnSetPrice.FlatAppearance.BorderSize = 0;
            btnSetPrice.Font = new Font("Segoe UI", 9F);
            btnSetPrice.Cursor = Cursors.Hand;
            btnSetPrice.Click += new EventHandler(btnSetPrice_Click);

            // Alert Panel with modern styling
            pnlAlerts = new Panel();
            pnlAlerts.BorderStyle = BorderStyle.None;
            pnlAlerts.AutoScroll = true;
            pnlAlerts.BackColor = Color.White;

            // Control panel for filters and buttons with modern styling
            FlowLayoutPanel controlPanel = new FlowLayoutPanel();
            controlPanel.FlowDirection = FlowDirection.LeftToRight;
            controlPanel.Dock = DockStyle.Fill;
            controlPanel.Padding = new Padding(0, 5, 0, 5);

            // Add crop type label and combo
            Label lblCropType = new Label();
            lblCropType.Text = "Crop Type:";
            lblCropType.AutoSize = true;
            lblCropType.Padding = new Padding(0, 8, 0, 0);
            lblCropType.Font = new Font("Segoe UI", 9F);

            controlPanel.Controls.Add(lblCropType);
            controlPanel.Controls.Add(cmbCropType);

            // Add threshold controls (only visible for admin/government)
            Label lblThreshold = new Label();
            lblThreshold.Text = "Alert Threshold:";
            lblThreshold.AutoSize = true;
            lblThreshold.Padding = new Padding(20, 8, 0, 0);
            lblThreshold.Font = new Font("Segoe UI", 9F);

            controlPanel.Controls.Add(lblThreshold);
            controlPanel.Controls.Add(numThreshold);

            // Add spacing before buttons
            Panel spacer = new Panel();
            spacer.Width = 15;
            spacer.Height = 1;
            controlPanel.Controls.Add(spacer);

            controlPanel.Controls.Add(btnRefresh);

            // Add set price button (only visible for admin/government)
            if (currentUserRoleID == 1 || currentUserRoleID == 3) // Admin or Government
            {
                // Add small spacing between buttons
                Panel btnSpacer = new Panel();
                btnSpacer.Width = 10;
                btnSpacer.Height = 1;
                controlPanel.Controls.Add(btnSpacer);

                controlPanel.Controls.Add(btnSetPrice);
            }

            // Alert section label with modern styling
            Label lblAlerts = new Label();
            lblAlerts.Text = "Price Alerts";
            lblAlerts.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblAlerts.Dock = DockStyle.Fill;
            lblAlerts.TextAlign = ContentAlignment.MiddleLeft;
            lblAlerts.ForeColor = Color.FromArgb(50, 50, 50);

            // Add controls to main layout
            mainLayout.Controls.Add(controlPanel, 0, 0);
            mainLayout.Controls.Add(dataGridViewPrices, 0, 1);
            mainLayout.Controls.Add(lblAlerts, 0, 2);
            mainLayout.Controls.Add(pnlAlerts, 0, 3);

            this.Controls.Add(mainLayout);

            // Subscribe to form load event
            this.Load += new EventHandler(Price_Monitoring_Load);
        }

        private void Price_Monitoring_Load(object sender, EventArgs e)
        {
            // Load crop types into combo box
            LoadCropTypes();

            // Load initial data
            LoadPriceData();

            // Update alerts
            UpdateAlerts();

            // Set visibility based on role
            SetControlsByRole();
        }

        private void SetControlsByRole()
        {
            bool isAdminOrGovernment = (currentUserRoleID == 1 || currentUserRoleID == 3);

            btnSetPrice.Visible = isAdminOrGovernment;
            numThreshold.Enabled = isAdminOrGovernment;

            // Farmers and private buyers can only view data
            if (currentUserRoleID == 2 || currentUserRoleID == 4)
            {
                // Hide buttons or panels that allow data modification
                btnSetPrice.Visible = false;
            }
        }

        private void LoadCropTypes()
        {
            try
            {
                using (connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT DISTINCT CropType FROM PriceMonitoring ORDER BY CropType";

                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlDataReader reader = cmd.ExecuteReader();

                    cmbCropType.Items.Clear();
                    cmbCropType.Items.Add("All Crop Types");

                    while (reader.Read())
                    {
                        cmbCropType.Items.Add(reader["CropType"].ToString());
                    }

                    // Select "All Crop Types" by default
                    cmbCropType.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading crop types: " + ex.Message, "Database Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPriceData()
        {
            try
            {
                using (connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT PriceID, CropType, AvgPrice, GovernmentPrice, " +
                                  "PriceDeviation, CreatedAt FROM PriceMonitoring ";

                    // Apply crop type filter if specific crop type selected
                    if (cmbCropType.SelectedIndex > 0) // Not "All Crop Types"
                    {
                        query += "WHERE CropType = @CropType ";
                    }

                    query += "ORDER BY CreatedAt DESC";

                    SqlCommand cmd = new SqlCommand(query, connection);

                    // Add parameter if filtering by crop type
                    if (cmbCropType.SelectedIndex > 0)
                    {
                        cmd.Parameters.AddWithValue("@CropType", cmbCropType.SelectedItem.ToString());
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridViewPrices.DataSource = dataTable;

                    // Format columns
                    if (dataGridViewPrices.Columns.Contains("PriceID"))
                        dataGridViewPrices.Columns["PriceID"].Visible = false;

                    if (dataGridViewPrices.Columns.Contains("CropType"))
                        dataGridViewPrices.Columns["CropType"].HeaderText = "Crop Type";

                    if (dataGridViewPrices.Columns.Contains("AvgPrice"))
                    {
                        dataGridViewPrices.Columns["AvgPrice"].HeaderText = "Average Price";
                        dataGridViewPrices.Columns["AvgPrice"].DefaultCellStyle.Format = "Rs. #,##0.00";

                    }

                    if (dataGridViewPrices.Columns.Contains("GovernmentPrice"))
                    {
                        dataGridViewPrices.Columns["GovernmentPrice"].HeaderText = "Government Price";
                        dataGridViewPrices.Columns["GovernmentPrice"].DefaultCellStyle.Format = "Rs. #,##0.00";
                    }

                    if (dataGridViewPrices.Columns.Contains("PriceDeviation"))
                    {
                        dataGridViewPrices.Columns["PriceDeviation"].HeaderText = "Price Deviation";
                        dataGridViewPrices.Columns["PriceDeviation"].DefaultCellStyle.Format = "Rs. #,##0.00";
                    }

                    if (dataGridViewPrices.Columns.Contains("CreatedAt"))
                    {
                        dataGridViewPrices.Columns["CreatedAt"].HeaderText = "Date";
                        dataGridViewPrices.Columns["CreatedAt"].DefaultCellStyle.Format = "dd-MMM-yyyy HH:mm";
                    }

                    // Color code based on deviation
                    foreach (DataGridViewRow row in dataGridViewPrices.Rows)
                    {
                        if (row.Cells["PriceDeviation"].Value != DBNull.Value)
                        {
                            decimal deviation = Convert.ToDecimal(row.Cells["PriceDeviation"].Value);
                            decimal threshold = numThreshold.Value;

                            if (Math.Abs(deviation) > threshold)
                            {
                                if (deviation > 0)
                                {
                                    // High price - light red
                                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 235, 235);
                                    row.DefaultCellStyle.ForeColor = Color.FromArgb(180, 0, 0);
                                }
                                else
                                {
                                    // Low price - light blue
                                    row.DefaultCellStyle.BackColor = Color.FromArgb(235, 245, 255);
                                    row.DefaultCellStyle.ForeColor = Color.FromArgb(0, 0, 180);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading price data: " + ex.Message, "Database Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateAlerts()
        {
            // Clear current alerts
            pnlAlerts.Controls.Clear();

            try
            {
                using (connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    decimal threshold = numThreshold.Value;

                    string query = "SELECT CropType, AvgPrice, GovernmentPrice, PriceDeviation, CreatedAt " +
                                  "FROM PriceMonitoring " +
                                  "WHERE ABS(PriceDeviation) > @Threshold ";

                    // Apply crop type filter if specific crop type selected
                    if (cmbCropType.SelectedIndex > 0)
                    {
                        query += "AND CropType = @CropType ";
                    }

                    query += "ORDER BY CreatedAt DESC";

                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@Threshold", threshold);

                    // Add parameter if filtering by crop type
                    if (cmbCropType.SelectedIndex > 0)
                    {
                        cmd.Parameters.AddWithValue("@CropType", cmbCropType.SelectedItem.ToString());
                    }

                    SqlDataReader reader = cmd.ExecuteReader();

                    int yPos = 10;

                    while (reader.Read())
                    {
                        string cropType = reader["CropType"].ToString();
                        decimal avgPrice = Convert.ToDecimal(reader["AvgPrice"]);
                        decimal govPrice = Convert.ToDecimal(reader["GovernmentPrice"]);
                        decimal deviation = Convert.ToDecimal(reader["PriceDeviation"]);
                        DateTime createdAt = Convert.ToDateTime(reader["CreatedAt"]);

                        // Create alert panel with modern styling
                        Panel alertPanel = new Panel();
                        alertPanel.Width = pnlAlerts.Width - 25;
                        alertPanel.Height = 65;
                        alertPanel.Location = new Point(10, yPos);
                        alertPanel.Padding = new Padding(10);

                        bool isHighAlert = deviation > 0;
                        string alertType = isHighAlert ? "HIGH PRICE" : "LOW PRICE";

                        // Set alert panel color based on alert type
                        if (isHighAlert)
                        {
                            alertPanel.BackColor = Color.FromArgb(255, 240, 240);
                            alertPanel.BorderStyle = BorderStyle.None;
                        }
                        else
                        {
                            alertPanel.BackColor = Color.FromArgb(240, 245, 255);
                            alertPanel.BorderStyle = BorderStyle.None;
                        }

                        // Alert header (Crop Type and Alert Type)
                        Label lblAlertHeader = new Label();
                        lblAlertHeader.AutoSize = true;
                        lblAlertHeader.Location = new Point(10, 10);
                        lblAlertHeader.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                        lblAlertHeader.Text = $"{cropType} - {alertType}";
                        lblAlertHeader.ForeColor = isHighAlert ? Color.FromArgb(200, 0, 0) : Color.FromArgb(0, 0, 200);

                        // Alert details
                        Label lblAlertDetails = new Label();
                        lblAlertDetails.AutoSize = true;
                        lblAlertDetails.Location = new Point(10, 32);
                        lblAlertDetails.Font = new Font("Segoe UI", 9F);
                        lblAlertDetails.Text = $"Avg: ₱{avgPrice:N2} | Gov: ₱{govPrice:N2} | Deviation: ₱{deviation:N2} | {createdAt:dd-MMM-yyyy HH:mm}";
                        lblAlertDetails.ForeColor = Color.FromArgb(70, 70, 70);

                        alertPanel.Controls.Add(lblAlertHeader);
                        alertPanel.Controls.Add(lblAlertDetails);
                        pnlAlerts.Controls.Add(alertPanel);

                        yPos += 75; // Add spacing between alerts
                    }

                    // If no alerts
                    if (yPos == 10)
                    {
                        Label lblNoAlert = new Label();
                        lblNoAlert.AutoSize = true;
                        lblNoAlert.Location = new Point(10, 15);
                        lblNoAlert.Text = "No price alerts with current threshold.";
                        lblNoAlert.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
                        lblNoAlert.ForeColor = Color.FromArgb(100, 100, 100);
                        pnlAlerts.Controls.Add(lblNoAlert);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating alerts: " + ex.Message, "Database Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshData(object sender, EventArgs e)
        {
            LoadPriceData();
            UpdateAlerts();
        }

        private void cmbCropType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPriceData();
            UpdateAlerts();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadPriceData();
            UpdateAlerts();
        }

        private void btnSetPrice_Click(object sender, EventArgs e)
        {
            // Only allow admin or government to set prices
            if (currentUserRoleID != 1 && currentUserRoleID != 3)
            {
                MessageBox.Show("You don't have permission to set government prices.",
                               "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get selected crop type from user
            string selectedCropType = "";
            if (cmbCropType.SelectedIndex > 0)
            {
                selectedCropType = cmbCropType.SelectedItem.ToString();
            }
            else
            {
                // Show crop type selection form/dialog
                using (var form = new CropTypeSelectionForm(connectionString))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        selectedCropType = form.SelectedCropType;
                    }
                    else
                    {
                        return; // User cancelled
                    }
                }
            }

            // Get new price from user
            decimal newPrice = 0;
            using (var priceForm = new SetPriceForm(selectedCropType, connectionString))
            {
                if (priceForm.ShowDialog() == DialogResult.OK)
                {
                    newPrice = priceForm.NewPrice;
                }
                else
                {
                    return; // User cancelled
                }
            }

            // Update government price in database
            try
            {
                using (connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // First check if there's already a price monitoring record for this crop type today
                    string checkQuery = "SELECT PriceID, AvgPrice FROM PriceMonitoring " +
                                       "WHERE CropType = @CropType AND CONVERT(date, CreatedAt) = CONVERT(date, GETDATE())";

                    SqlCommand checkCmd = new SqlCommand(checkQuery, connection);
                    checkCmd.Parameters.AddWithValue("@CropType", selectedCropType);

                    object existingId = checkCmd.ExecuteScalar();

                    if (existingId != null)
                    {
                        // Update existing record
                        string updateQuery = "UPDATE PriceMonitoring SET GovernmentPrice = @GovPrice " +
                                           "WHERE PriceID = @PriceID";

                        SqlCommand updateCmd = new SqlCommand(updateQuery, connection);
                        updateCmd.Parameters.AddWithValue("@GovPrice", newPrice);
                        updateCmd.Parameters.AddWithValue("@PriceID", existingId);

                        updateCmd.ExecuteNonQuery();
                    }
                    else
                    {
                        // No record for today, get average price data or use some default
                        decimal avgPrice = GetCurrentAveragePrice(selectedCropType);

                        // Insert new record
                        string insertQuery = "INSERT INTO PriceMonitoring (CropType, AvgPrice, GovernmentPrice) " +
                                           "VALUES (@CropType, @AvgPrice, @GovPrice)";

                        SqlCommand insertCmd = new SqlCommand(insertQuery, connection);
                        insertCmd.Parameters.AddWithValue("@CropType", selectedCropType);
                        insertCmd.Parameters.AddWithValue("@AvgPrice", avgPrice);
                        insertCmd.Parameters.AddWithValue("@GovPrice", newPrice);

                        insertCmd.ExecuteNonQuery();
                    }

                    MessageBox.Show($"Government price for {selectedCropType} has been set to ₱{newPrice:N2}",
                                   "Price Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Refresh data
                    LoadPriceData();
                    UpdateAlerts();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error setting price: " + ex.Message, "Database Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private decimal GetCurrentAveragePrice(string cropType)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // This query should be adapted to your actual data structure
                    string query = "SELECT AVG(Price) FROM DailySalesData WHERE CropType = @CropType " +
                                  "AND SaleDate = CONVERT(date, GETDATE())";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@CropType", cropType);

                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToDecimal(result);
                    }
                    else
                    {
                        // If no sales data, use the latest known average price
                        string fallbackQuery = "SELECT TOP 1 AvgPrice FROM PriceMonitoring " +
                                             "WHERE CropType = @CropType ORDER BY CreatedAt DESC";

                        SqlCommand fallbackCmd = new SqlCommand(fallbackQuery, conn);
                        fallbackCmd.Parameters.AddWithValue("@CropType", cropType);

                        object fallbackResult = fallbackCmd.ExecuteScalar();

                        if (fallbackResult != null && fallbackResult != DBNull.Value)
                        {
                            return Convert.ToDecimal(fallbackResult);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log error if needed
                Console.WriteLine("Error getting average price: " + ex.Message);
            }

            // Default fallback price if no data is available
            return 0;
        }
    }

    // Helper Forms for Price Setting

    // Crop Type Selection Form with modern styling
    public class CropTypeSelectionForm : Form
    {
        private ComboBox cmbCropTypes;
        private Button btnOK;
        private Button btnCancel;
        private string connectionString;

        public string SelectedCropType { get; private set; }

        public CropTypeSelectionForm(string connectionString)
        {
            this.connectionString = connectionString;
            this.Text = "Select Crop Type";
            this.Size = new Size(340, 180);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.White;

            Label lblPrompt = new Label();
            lblPrompt.Text = "Select a crop type:";
            lblPrompt.Location = new Point(20, 20);
            lblPrompt.AutoSize = true;
            lblPrompt.Font = new Font("Segoe UI", 9F);

            cmbCropTypes = new ComboBox();
            cmbCropTypes.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCropTypes.Location = new Point(20, 50);
            cmbCropTypes.Width = 280;
            cmbCropTypes.Font = new Font("Segoe UI", 9F);

            btnOK = new Button();
            btnOK.Text = "OK";
            btnOK.DialogResult = DialogResult.OK;
            btnOK.Location = new Point(130, 90);
            btnOK.Width = 80;
            btnOK.Height = 30;
            btnOK.BackColor = Color.FromArgb(37, 150, 190);
            btnOK.ForeColor = Color.White;
            btnOK.FlatStyle = FlatStyle.Flat;
            btnOK.FlatAppearance.BorderSize = 0;
            btnOK.Font = new Font("Segoe UI", 9F);

            btnCancel = new Button();
            btnCancel.Text = "Cancel";
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(220, 90);
            btnCancel.Width = 80;
            btnCancel.Height = 30;
            btnCancel.BackColor = Color.FromArgb(240, 240, 240);
            btnCancel.ForeColor = Color.Black;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Font = new Font("Segoe UI", 9F);

            this.Controls.Add(lblPrompt);
            this.Controls.Add(cmbCropTypes);
            this.Controls.Add(btnOK);
            this.Controls.Add(btnCancel);

            this.AcceptButton = btnOK;
            this.CancelButton = btnCancel;

            // Load crop types
            LoadCropTypes();

            this.FormClosing += (s, e) =>
            {
                if (this.DialogResult == DialogResult.OK)
                {
                    if (cmbCropTypes.SelectedIndex < 0)
                    {
                        MessageBox.Show("Please select a crop type.", "Selection Required",
                                       MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        e.Cancel = true;
                        return;
                    }

                    SelectedCropType = cmbCropTypes.SelectedItem.ToString();
                }
            };
        }

        private void LoadCropTypes()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT DISTINCT CropType FROM PriceMonitoring ORDER BY CropType";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    cmbCropTypes.Items.Clear();

                    while (reader.Read())
                    {
                        cmbCropTypes.Items.Add(reader["CropType"].ToString());
                    }

                    if (cmbCropTypes.Items.Count > 0)
                        cmbCropTypes.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading crop types: " + ex.Message, "Database Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    // Price Setting Form with modern styling
    public class SetPriceForm : Form
    {
        private NumericUpDown numPrice;
        private Button btnOK;
        private Button btnCancel;
        private string connectionString;

        public decimal NewPrice { get; private set; }

        public SetPriceForm(string cropType, string connectionString)
        {
            this.connectionString = connectionString;
            this.Text = "Set Government Price";
            this.Size = new Size(340, 200);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.White;

            Label lblHeader = new Label();
            lblHeader.Text = "Government Price Setting";
            lblHeader.Location = new Point(20, 15);
            lblHeader.AutoSize = true;
            lblHeader.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblHeader.ForeColor = Color.FromArgb(37, 150, 190);

            Label lblPrompt = new Label();
            lblPrompt.Text = $"Set new government price for {cropType}:";
            lblPrompt.Location = new Point(20, 45);
            lblPrompt.AutoSize = true;
            lblPrompt.Font = new Font("Segoe UI", 9F);

            numPrice = new NumericUpDown();
            numPrice.DecimalPlaces = 2;
            numPrice.Minimum = 0;
            numPrice.Maximum = 10000;
            numPrice.Value = GetCurrentPrice(cropType);
            numPrice.Increment = 0.5M;
            numPrice.Location = new Point(20, 75);
            numPrice.Width = 140;
            numPrice.Font = new Font("Segoe UI", 10F);
            numPrice.BorderStyle = BorderStyle.FixedSingle;

            Label lblCurrency = new Label();
            lblCurrency.Text = "LKR"; // Or your currency
            lblCurrency.Location = new Point(170, 77);
            lblCurrency.AutoSize = true;
            lblCurrency.Font = new Font("Segoe UI", 10F);

            btnOK = new Button();
            btnOK.Text = "Set Price";
            btnOK.DialogResult = DialogResult.OK;
            btnOK.Location = new Point(130, 120);
            btnOK.Width = 90;
            btnOK.Height = 32;
            btnOK.BackColor = Color.FromArgb(37, 150, 190);
            btnOK.ForeColor = Color.White;
            btnOK.FlatStyle = FlatStyle.Flat;
            btnOK.FlatAppearance.BorderSize = 0;
            btnOK.Font = new Font("Segoe UI", 9F);

            btnCancel = new Button();
            btnCancel.Text = "Cancel";
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(230, 120);
            btnCancel.Width = 80;
            btnCancel.Height = 32;
            btnCancel.BackColor = Color.FromArgb(240, 240, 240);
            btnCancel.ForeColor = Color.Black;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Font = new Font("Segoe UI", 9F);

            this.Controls.Add(lblHeader);
            this.Controls.Add(lblPrompt);
            this.Controls.Add(numPrice);
            this.Controls.Add(lblCurrency);
            this.Controls.Add(btnOK);
            this.Controls.Add(btnCancel);

            this.AcceptButton = btnOK;
            this.CancelButton = btnCancel;

            this.FormClosing += (s, e) =>
            {
                if (this.DialogResult == DialogResult.OK)
                {
                    NewPrice = numPrice.Value;
                }
            };
        }

        private decimal GetCurrentPrice(string cropType)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT TOP 1 GovernmentPrice FROM PriceMonitoring " +
                                  "WHERE CropType = @CropType ORDER BY CreatedAt DESC";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@CropType", cropType);

                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToDecimal(result);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving current price: " + ex.Message, "Database Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return 0; // Default price
        }
    }
}