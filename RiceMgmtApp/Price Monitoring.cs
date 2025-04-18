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
            // Data Grid View for price monitoring
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
            
            // Region ComboBox
            cmbRegion = new ComboBox();
            cmbRegion.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRegion.Width = 200;
            cmbRegion.SelectedIndexChanged += new EventHandler(cmbRegion_SelectedIndexChanged);
            
            // Set threshold input
            numThreshold = new NumericUpDown();
            numThreshold.DecimalPlaces = 2;
            numThreshold.Minimum = 0;
            numThreshold.Maximum = 1000;
            numThreshold.Value = 5; // Default threshold of 5
            numThreshold.Width = 100;
            
            // Buttons
            btnRefresh = new Button();
            btnRefresh.Text = "Refresh Data";
            btnRefresh.Click += new EventHandler(btnRefresh_Click);
            
            btnSetPrice = new Button();
            btnSetPrice.Text = "Set Government Price";
            btnSetPrice.Click += new EventHandler(btnSetPrice_Click);
            
            // Alert Panel
            pnlAlerts = new Panel();
            pnlAlerts.BorderStyle = BorderStyle.FixedSingle;
            pnlAlerts.AutoScroll = true;
            pnlAlerts.Height = 150;
            
            // Layout
            TableLayoutPanel mainLayout = new TableLayoutPanel();
            mainLayout.Dock = DockStyle.Fill;
            mainLayout.RowCount = 4;
            mainLayout.ColumnCount = 1;
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 70F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
            
            // Control panel for filters and buttons
            FlowLayoutPanel controlPanel = new FlowLayoutPanel();
            controlPanel.FlowDirection = FlowDirection.LeftToRight;
            controlPanel.Dock = DockStyle.Fill;
            controlPanel.Padding = new Padding(5);
            
            // Add region label and combo
            Label lblRegion = new Label();
            lblRegion.Text = "Region:";
            lblRegion.AutoSize = true;
            lblRegion.Padding = new Padding(0, 5, 0, 0);
            
            controlPanel.Controls.Add(lblRegion);
            controlPanel.Controls.Add(cmbRegion);
            
            // Add threshold controls (only visible for admin/government)
            Label lblThreshold = new Label();
            lblThreshold.Text = "Alert Threshold:";
            lblThreshold.AutoSize = true;
            lblThreshold.Padding = new Padding(20, 5, 0, 0);
            
            controlPanel.Controls.Add(lblThreshold);
            controlPanel.Controls.Add(numThreshold);
            controlPanel.Controls.Add(btnRefresh);
            
            // Add set price button (only visible for admin/government)
            if (currentUserRoleID == 1 || currentUserRoleID == 3) // Admin or Government
            {
                controlPanel.Controls.Add(btnSetPrice);
            }
            
            // Alert section label
            Label lblAlerts = new Label();
            lblAlerts.Text = "Price Alerts";
            lblAlerts.Font = new Font(lblAlerts.Font, FontStyle.Bold);
            lblAlerts.Dock = DockStyle.Fill;
            lblAlerts.TextAlign = ContentAlignment.MiddleLeft;
            
            // Add controls to main layout
            mainLayout.Controls.Add(controlPanel, 0, 0);
            mainLayout.Controls.Add(dataGridViewPrices, 0, 1);
            mainLayout.Controls.Add(lblAlerts, 0, 2);
            mainLayout.Controls.Add(pnlAlerts, 0, 3);
            
            this.Controls.Add(mainLayout);
        }

        private void Price_Monitoring_Load(object sender, EventArgs e)
        {
            // Load regions into combo box
            LoadRegions();
            
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

        private void LoadRegions()
        {
            try
            {
                using (connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT DISTINCT Region FROM PriceMonitoring ORDER BY Region";
                    
                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    
                    cmbRegion.Items.Clear();
                    cmbRegion.Items.Add("All Regions");
                    
                    while (reader.Read())
                    {
                        cmbRegion.Items.Add(reader["Region"].ToString());
                    }
                    
                    // Select "All Regions" by default
                    cmbRegion.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading regions: " + ex.Message, "Database Error", 
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
                    string query = "SELECT PriceID, Region, AvgPrice, GovernmentPrice, " +
                                  "PriceDeviation, CreatedAt FROM PriceMonitoring ";
                    
                    // Apply region filter if specific region selected
                    if (cmbRegion.SelectedIndex > 0) // Not "All Regions"
                    {
                        query += "WHERE Region = @Region ";
                        
                    }
                    
                    query += "ORDER BY CreatedAt DESC";
                    
                    SqlCommand cmd = new SqlCommand(query, connection);
                    
                    // Add parameter if filtering by region
                    if (cmbRegion.SelectedIndex > 0)
                    {
                        cmd.Parameters.AddWithValue("@Region", cmbRegion.SelectedItem.ToString());
                    }
                    
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    
                    dataGridViewPrices.DataSource = dataTable;
                    
                    // Format columns
                    if (dataGridViewPrices.Columns.Contains("PriceID"))
                        dataGridViewPrices.Columns["PriceID"].Visible = false;
                    
                    if (dataGridViewPrices.Columns.Contains("AvgPrice"))
                        dataGridViewPrices.Columns["AvgPrice"].HeaderText = "Average Price";
                    
                    if (dataGridViewPrices.Columns.Contains("GovernmentPrice"))
                        dataGridViewPrices.Columns["GovernmentPrice"].HeaderText = "Government Price";
                    
                    if (dataGridViewPrices.Columns.Contains("PriceDeviation"))
                    {
                        dataGridViewPrices.Columns["PriceDeviation"].HeaderText = "Price Deviation";
                        dataGridViewPrices.Columns["PriceDeviation"].DefaultCellStyle.Format = "N2";
                    }
                    
                    if (dataGridViewPrices.Columns.Contains("CreatedAt"))
                        dataGridViewPrices.Columns["CreatedAt"].HeaderText = "Date";
                    
                    // Color code based on deviation
                    foreach (DataGridViewRow row in dataGridViewPrices.Rows)
                    {
                        if (row.Cells["PriceDeviation"].Value != DBNull.Value)
                        {
                            decimal deviation = Convert.ToDecimal(row.Cells["PriceDeviation"].Value);
                            decimal threshold = numThreshold.Value;
                            
                            if (Math.Abs(deviation) > threshold)
                            {
                                row.DefaultCellStyle.BackColor = (deviation > 0) ? 
                                    Color.LightCoral : Color.LightBlue;
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
                    
                    string query = "SELECT Region, AvgPrice, GovernmentPrice, PriceDeviation, CreatedAt " +
                                  "FROM PriceMonitoring " +
                                  "WHERE ABS(PriceDeviation) > @Threshold ";
                    
                    // Apply region filter if specific region selected
                    if (cmbRegion.SelectedIndex > 0)
                    {
                        query += "AND Region = @Region ";
                    }
                    
                    query += "ORDER BY CreatedAt DESC";
                    
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@Threshold", threshold);
                    
                    // Add parameter if filtering by region
                    if (cmbRegion.SelectedIndex > 0)
                    {
                        cmd.Parameters.AddWithValue("@Region", cmbRegion.SelectedItem.ToString());
                    }
                    
                    SqlDataReader reader = cmd.ExecuteReader();
                    
                    int yPos = 10;
                    
                    while (reader.Read())
                    {
                        string region = reader["Region"].ToString();
                        decimal avgPrice = Convert.ToDecimal(reader["AvgPrice"]);
                        decimal govPrice = Convert.ToDecimal(reader["GovernmentPrice"]);
                        decimal deviation = Convert.ToDecimal(reader["PriceDeviation"]);
                        DateTime createdAt = Convert.ToDateTime(reader["CreatedAt"]);
                        
                        // Create alert label
                        Label lblAlert = new Label();
                        lblAlert.AutoSize = false;
                        lblAlert.Width = pnlAlerts.Width - 25;
                        lblAlert.Height = 40;
                        lblAlert.Location = new Point(10, yPos);
                        lblAlert.BorderStyle = BorderStyle.FixedSingle;
                        lblAlert.Padding = new Padding(5);
                        
                        string alertType = deviation > 0 ? "HIGH" : "LOW";
                        Color alertColor = deviation > 0 ? Color.LightCoral : Color.LightBlue;
                        
                        lblAlert.Text = $"ALERT [{alertType}]: {region} - Avg Price: {avgPrice:C2} vs Gov Price: {govPrice:C2} " +
                                       $"(Deviation: {deviation:C2}) - {createdAt:yyyy-MM-dd HH:mm}";
                        lblAlert.BackColor = alertColor;
                        
                        pnlAlerts.Controls.Add(lblAlert);
                        yPos += 45;
                    }
                    
                    // If no alerts
                    if (yPos == 10)
                    {
                        Label lblNoAlert = new Label();
                        lblNoAlert.AutoSize = true;
                        lblNoAlert.Location = new Point(10, yPos);
                        lblNoAlert.Text = "No price alerts with current threshold.";
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

        private void cmbRegion_SelectedIndexChanged(object sender, EventArgs e)
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
            
            // Get selected region from user
            string selectedRegion = "";
            if (cmbRegion.SelectedIndex > 0)
            {
                selectedRegion = cmbRegion.SelectedItem.ToString();
            }
            else
            {
                // Show region selection form/dialog
                using (var form = new RegionSelectionForm())
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        selectedRegion = form.SelectedRegion;
                    }
                    else
                    {
                        return; // User cancelled
                    }
                }
            }
            
            // Get new price from user
            decimal newPrice = 0;
            using (var priceForm = new SetPriceForm(selectedRegion))
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
                    
                    // First check if there's already a price monitoring record for this region today
                    string checkQuery = "SELECT PriceID, AvgPrice FROM PriceMonitoring " +
                                       "WHERE Region = @Region AND CONVERT(date, CreatedAt) = CONVERT(date, GETDATE())";
                    
                    SqlCommand checkCmd = new SqlCommand(checkQuery, connection);
                    checkCmd.Parameters.AddWithValue("@Region", selectedRegion);
                    
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
                        decimal avgPrice = GetCurrentAveragePrice(selectedRegion);
                        
                        // Insert new record
                        string insertQuery = "INSERT INTO PriceMonitoring (Region, AvgPrice, GovernmentPrice) " +
                                           "VALUES (@Region, @AvgPrice, @GovPrice)";
                        
                        SqlCommand insertCmd = new SqlCommand(insertQuery, connection);
                        insertCmd.Parameters.AddWithValue("@Region", selectedRegion);
                        insertCmd.Parameters.AddWithValue("@AvgPrice", avgPrice);
                        insertCmd.Parameters.AddWithValue("@GovPrice", newPrice);
                        
                        insertCmd.ExecuteNonQuery();
                    }
                    
                    MessageBox.Show($"Government price for {selectedRegion} has been set to {newPrice:C2}",
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

        private decimal GetCurrentAveragePrice(string region)
        {
            // Implement logic to get current average price from another table or source
            // This is a placeholder method - you would connect to your sales data here
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    
                    // This query should be adapted to your actual data structure
                    string query = "SELECT AVG(Price) FROM DailySalesData WHERE Region = @Region " +
                                  "AND SaleDate = CONVERT(date, GETDATE())";
                    
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Region", region);
                    
                    object result = cmd.ExecuteScalar();
                    
                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToDecimal(result);
                    }
                    else
                    {
                        // If no sales data, use the latest known average price
                        string fallbackQuery = "SELECT TOP 1 AvgPrice FROM PriceMonitoring " +
                                             "WHERE Region = @Region ORDER BY CreatedAt DESC";
                        
                        SqlCommand fallbackCmd = new SqlCommand(fallbackQuery, conn);
                        fallbackCmd.Parameters.AddWithValue("@Region", region);
                        
                        object fallbackResult = fallbackCmd.ExecuteScalar();
                        
                        if (fallbackResult != null && fallbackResult != DBNull.Value)
                        {
                            return Convert.ToDecimal(fallbackResult);
                        }
                    }
                }
            }
            catch (Exception)
            {
                // Log error if needed
            }
            
            // Default fallback price if no data is available
            return 0;
        }

        // Helper Forms for Price Setting

        // Region Selection Form
        private class RegionSelectionForm : Form
        {
            private ComboBox cmbRegions;
            private Button btnOK;
            private Button btnCancel;
            
            public string SelectedRegion { get; private set; }
            
            public RegionSelectionForm()
            {
                this.Text = "Select Region";
                this.Size = new Size(300, 150);
                this.FormBorderStyle = FormBorderStyle.FixedDialog;
                this.MaximizeBox = false;
                this.MinimizeBox = false;
                this.StartPosition = FormStartPosition.CenterParent;
                
                Label lblPrompt = new Label();
                lblPrompt.Text = "Select a region:";
                lblPrompt.Location = new Point(20, 20);
                lblPrompt.AutoSize = true;
                
                cmbRegions = new ComboBox();
                cmbRegions.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbRegions.Location = new Point(20, 50);
                cmbRegions.Width = 240;
                
                btnOK = new Button();
                btnOK.Text = "OK";
                btnOK.DialogResult = DialogResult.OK;
                btnOK.Location = new Point(95, 80);
                
                btnCancel = new Button();
                btnCancel.Text = "Cancel";
                btnCancel.DialogResult = DialogResult.Cancel;
                btnCancel.Location = new Point(180, 80);
                
                this.Controls.Add(lblPrompt);
                this.Controls.Add(cmbRegions);
                this.Controls.Add(btnOK);
                this.Controls.Add(btnCancel);
                
                this.AcceptButton = btnOK;
                this.CancelButton = btnCancel;
                
                // Load regions
                LoadRegions();
                
                this.FormClosing += (s, e) => {
                    if (this.DialogResult == DialogResult.OK)
                    {
                        if (cmbRegions.SelectedIndex < 0)
                        {
                            MessageBox.Show("Please select a region.", "Selection Required", 
                                           MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            e.Cancel = true;
                            return;
                        }
                        
                        SelectedRegion = cmbRegions.SelectedItem.ToString();
                    }
                };
            }
            
            private void LoadRegions()
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection("Your_Connection_String_Here"))
                    {
                        conn.Open();
                        string query = "SELECT DISTINCT Region FROM PriceMonitoring ORDER BY Region";
                        
                        SqlCommand cmd = new SqlCommand(query, conn);
                        SqlDataReader reader = cmd.ExecuteReader();
                        
                        cmbRegions.Items.Clear();
                        
                        while (reader.Read())
                        {
                            cmbRegions.Items.Add(reader["Region"].ToString());
                        }
                        
                        if (cmbRegions.Items.Count > 0)
                            cmbRegions.SelectedIndex = 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading regions: " + ex.Message, "Database Error", 
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Price Setting Form
        private class SetPriceForm : Form
        {
            private NumericUpDown numPrice;
            private Button btnOK;
            private Button btnCancel;
            
            public decimal NewPrice { get; private set; }
            
            public SetPriceForm(string region)
            {
                this.Text = "Set Government Price";
                this.Size = new Size(320, 180);
                this.FormBorderStyle = FormBorderStyle.FixedDialog;
                this.MaximizeBox = false;
                this.MinimizeBox = false;
                this.StartPosition = FormStartPosition.CenterParent;
                
                Label lblPrompt = new Label();
                lblPrompt.Text = $"Set new government price for {region}:";
                lblPrompt.Location = new Point(20, 20);
                lblPrompt.AutoSize = true;
                
                numPrice = new NumericUpDown();
                numPrice.DecimalPlaces = 2;
                numPrice.Minimum = 0;
                numPrice.Maximum = 10000;
                numPrice.Value = GetCurrentPrice(region);
                numPrice.Increment = 0.5M;
                numPrice.Location = new Point(20, 50);
                numPrice.Width = 120;
                
                Label lblCurrency = new Label();
                lblCurrency.Text = "PHP"; // Or your currency
                lblCurrency.Location = new Point(150, 52);
                lblCurrency.AutoSize = true;
                
                btnOK = new Button();
                btnOK.Text = "Set Price";
                btnOK.DialogResult = DialogResult.OK;
                btnOK.Location = new Point(115, 90);
                
                btnCancel = new Button();
                btnCancel.Text = "Cancel";
                btnCancel.DialogResult = DialogResult.Cancel;
                btnCancel.Location = new Point(200, 90);
                
                this.Controls.Add(lblPrompt);
                this.Controls.Add(numPrice);
                this.Controls.Add(lblCurrency);
                this.Controls.Add(btnOK);
                this.Controls.Add(btnCancel);
                
                this.AcceptButton = btnOK;
                this.CancelButton = btnCancel;
                
                this.FormClosing += (s, e) => {
                    if (this.DialogResult == DialogResult.OK)
                    {
                        NewPrice = numPrice.Value;
                    }
                };
            }
            
            private decimal GetCurrentPrice(string region)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection("Your_Connection_String_Here"))
                    {
                        conn.Open();
                        string query = "SELECT TOP 1 GovernmentPrice FROM PriceMonitoring " +
                                      "WHERE Region = @Region ORDER BY CreatedAt DESC";
                        
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@Region", region);
                        
                        object result = cmd.ExecuteScalar();
                        
                        if (result != null && result != DBNull.Value)
                        {
                            return Convert.ToDecimal(result);
                        }
                    }
                }
                catch (Exception)
                {
                    // Log error if needed
                }
                
                return 0; // Default price
            }
        }

       
        

        
    }
}
