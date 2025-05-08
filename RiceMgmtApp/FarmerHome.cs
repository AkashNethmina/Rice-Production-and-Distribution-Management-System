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
using System.Windows.Forms.DataVisualization.Charting;
using Microsoft.Office.Interop.Excel;

namespace RiceMgmtApp
{
    public partial class FarmerHome : UserControl
    {
        private readonly string connectionString = "Server=DESKTOP-O6K3I3U\\SQLEXPRESS;Database=RiceProductionDB2;Integrated Security=True;";
        private int currentFarmerId; // To store the current logged-in farmer's ID
        private decimal totalFieldSize = 0; // Total field size for the farmer
        private decimal totalStockQuantity = 0; // Total stock quantity for the farmer
        private decimal totalsalesQuantity = 0;

        // Dictionary for crop types and quantities
        private Dictionary<string, decimal> stockByType = new Dictionary<string, decimal>();

        // Dictionary for sales data by month
        private Dictionary<string, decimal> salesByMonth = new Dictionary<string, decimal>();

        public FarmerHome(int farmerId)
        {
            InitializeComponent();
            this.currentFarmerId = farmerId;
            // Subscribe to the Load event
            this.Load += FarmerHome_Load;
        }

        private void FarmerHome_Load(object sender, EventArgs e)
        {
            // Load all data when the control is loaded
            LoadFarmerStatistics();
            SetupSalesChart();
            SetupStockChart();
        }

        private void LoadFarmerStatistics()
        {
            try
            {
                int completedSalesCount = 0; // Declare the variable here

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Get total field size
                    string fieldQuery = @"
                        SELECT 
                            SUM(FieldSize) as TotalFieldSize
                        FROM 
                            Fields
                        WHERE 
                            FarmerID = @FarmerId";

                    using (SqlCommand command = new SqlCommand(fieldQuery, connection))
                    {
                        command.Parameters.AddWithValue("@FarmerId", currentFarmerId);
                        object result = command.ExecuteScalar();
                        totalFieldSize = result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                    }

                    // Get total stock quantity
                    string stockQuery = @"
                        SELECT 
                            SUM(Quantity) as TotalQuantity
                        FROM 
                            Stock
                        WHERE 
                            FarmerID = @FarmerId";

                    using (SqlCommand command = new SqlCommand(stockQuery, connection))
                    {
                        command.Parameters.AddWithValue("@FarmerId", currentFarmerId);
                        object result = command.ExecuteScalar();
                        totalStockQuantity = result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                    }

                    // Get completed sales count
                    string salesQuery = @"
                        SELECT 
                            SUM(Quantity) as TotalQuantity
                        FROM 
                            Sales
                        WHERE 
                            FarmerID = @FarmerId ";

                    using (SqlCommand command = new SqlCommand(salesQuery, connection))
                    {
                        command.Parameters.AddWithValue("@FarmerId", currentFarmerId);
                        object result = command.ExecuteScalar();
                        totalsalesQuantity = result != DBNull.Value ? Convert.ToDecimal(result) : 0;

                    }
                }

                // Update UI elements
                UpdateFarmerStatisticsDisplay();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading farmer statistics: " + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateFarmerStatisticsDisplay()
        {
            // Update your UI controls with the farmer's data
            lblTotalFieldSize.Text = totalFieldSize.ToString("N2") + " Acres";
            lblTotalStock.Text = totalStockQuantity.ToString("N2") + " kg";
            lblTotalSales.Text = totalsalesQuantity.ToString("N2") + " Kg";

            // Note: You'll need to add these labels to your form design
            // and remove the previous user count labels
        }

        private void SetupSalesChart()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // SQL query to get monthly sales data for this farmer only
                    string query = @"
                        SELECT 
                            FORMAT(SaleDate, 'yyyy-MM') as Month,
                            SUM(SalePrice * Quantity) as TotalSales
                        FROM 
                            Sales
                        WHERE
                            FarmerID = @FarmerId
                        GROUP BY 
                            FORMAT(SaleDate, 'yyyy-MM')
                        ORDER BY 
                            Month";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FarmerId", currentFarmerId);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string month = reader["Month"].ToString();
                                decimal totalSales = Convert.ToDecimal(reader["TotalSales"]);

                                salesByMonth[month] = totalSales;
                            }
                        }
                    }
                }

                // Configure the Sales Chart
                chartSales.Series.Clear();
                chartSales.ChartAreas.Clear();

                // Specify the full namespace for ChartArea to resolve ambiguity
                System.Windows.Forms.DataVisualization.Charting.ChartArea salesChartArea =
                    new System.Windows.Forms.DataVisualization.Charting.ChartArea("SalesChartArea");
                chartSales.ChartAreas.Add(salesChartArea);

                // Specify the full namespace for Series to avoid ambiguity
                System.Windows.Forms.DataVisualization.Charting.Series salesSeries =
                    new System.Windows.Forms.DataVisualization.Charting.Series("Sales");

                salesSeries.ChartType = SeriesChartType.Column;

                foreach (var entry in salesByMonth)
                {
                    salesSeries.Points.AddXY(entry.Key, entry.Value);
                }

                chartSales.Series.Add(salesSeries);
                chartSales.Titles.Add(new Title("My Monthly Sales", Docking.Top, new System.Drawing.Font("Arial", 12, FontStyle.Bold), Color.Black));

                // Set chart appearance
                salesChartArea.AxisX.MajorGrid.LineColor = Color.LightGray;
                salesChartArea.AxisY.MajorGrid.LineColor = Color.LightGray;
                salesChartArea.AxisX.LabelStyle.Font = new System.Drawing.Font("Arial", 9);
                salesChartArea.AxisY.LabelStyle.Font = new System.Drawing.Font("Arial", 9);

                // Add formatting to make the chart more readable
                salesChartArea.AxisX.LabelStyle.Angle = -45;
                salesChartArea.AxisX.LabelStyle.IsStaggered = false;
                salesChartArea.AxisX.MajorGrid.Enabled = false;

                // Set bar color
                salesSeries.Color = Color.FromArgb(52, 152, 219);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading sales chart: " + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupStockChart()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // SQL query to get stock data by crop type for this farmer only
                    string query = @"
                        SELECT 
                            CropType,
                            SUM(Quantity) as TotalQuantity
                        FROM 
                            Stock
                        WHERE 
                            FarmerID = @FarmerId
                        GROUP BY 
                            CropType
                        ORDER BY 
                            TotalQuantity DESC";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FarmerId", currentFarmerId);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string cropType = reader["CropType"].ToString();
                                decimal quantity = Convert.ToDecimal(reader["TotalQuantity"]);

                                stockByType[cropType] = quantity;
                            }
                        }
                    }
                }

                // Configure the Stock Chart
                chartStock.Series.Clear();
                chartStock.ChartAreas.Clear();
                chartStock.Legends.Clear();
                chartStock.Titles.Clear();

                // Specify the full namespace for ChartArea to resolve ambiguity
                System.Windows.Forms.DataVisualization.Charting.ChartArea stockChartArea =
                    new System.Windows.Forms.DataVisualization.Charting.ChartArea("StockChartArea");
                chartStock.ChartAreas.Add(stockChartArea);

                // Inside SetupStockChart method
                System.Windows.Forms.DataVisualization.Charting.Series stockSeries =
                    new System.Windows.Forms.DataVisualization.Charting.Series("Stock");

                stockSeries.ChartType = SeriesChartType.Pie;

                foreach (var entry in stockByType)
                {
                    DataPoint point = new DataPoint();
                    point.SetValueXY(entry.Key, entry.Value);
                    point.LegendText = entry.Key;
                    // Show percentage in the pie chart
                    point.Label = "#PERCENT{P0}";
                    stockSeries.Points.Add(point);
                }

                chartStock.Series.Add(stockSeries);
                chartStock.Titles.Add(new Title("My Current Stock by Crop Type", Docking.Top, new System.Drawing.Font("Arial", 12, FontStyle.Bold), Color.Black));

                // Specify the full namespace for Legend to resolve ambiguity
                System.Windows.Forms.DataVisualization.Charting.Legend stockLegend =
                    new System.Windows.Forms.DataVisualization.Charting.Legend("StockLegend");
                chartStock.Legends.Add(stockLegend);
                stockSeries.Legend = "StockLegend";

                // Add custom colors
                stockSeries.Palette = ChartColorPalette.BrightPastel;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading stock chart: " + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Add method to get field details (total acreage by zone)
        private void LoadFieldsByZone()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // SQL query to get fields by zone
                    string query = @"
                        SELECT 
                            Zone,
                            SUM(FieldSize) as TotalSize
                        FROM 
                            Fields
                        WHERE 
                            FarmerID = @FarmerId
                        GROUP BY 
                            Zone
                        ORDER BY 
                            TotalSize DESC";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FarmerId", currentFarmerId);

                        // Explicitly specify the namespace for DataTable to resolve ambiguity
                        System.Data.DataTable dt = new System.Data.DataTable();
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dt);
                        }

                        // If you have a DataGridView for fields
                        // dgvFieldsByZone.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading field data: " + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Button click handler for the refresh button
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // Reset counters and dictionaries
            totalFieldSize = 0;
            totalStockQuantity = 0;
            totalsalesQuantity = 0;
            stockByType.Clear();
            salesByMonth.Clear();

            // Clear chart titles
            chartSales.Titles.Clear();
            chartStock.Titles.Clear();

            // Reload all data
            LoadFarmerStatistics();
            SetupSalesChart();
            SetupStockChart();
            LoadFieldsByZone();

            MessageBox.Show("Dashboard data has been refreshed.", "Refresh Complete",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Add method to refresh data (can be called from outside if needed)
        public void RefreshDashboard()
        {
            // Reset counters and dictionaries
            totalFieldSize = 0;
            totalStockQuantity = 0;
            totalsalesQuantity = 0;
            stockByType.Clear();
            salesByMonth.Clear();

            // Reload all data
            LoadFarmerStatistics();
            SetupSalesChart();
            SetupStockChart();
            LoadFieldsByZone();
        }

        // Add method to analyze crop performance
        public void AnalyzeCropPerformance()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // SQL query to get sales performance by crop type
                    string query = @"
                        SELECT 
                            CropType,
                            SUM(Quantity) as TotalQuantitySold,
                            SUM(SalePrice * Quantity) as TotalRevenue,
                            AVG(SalePrice) as AveragePrice
                        FROM 
                            Sales
                        WHERE 
                            FarmerID = @FarmerId
                        GROUP BY 
                            CropType
                        ORDER BY 
                            TotalRevenue DESC";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FarmerId", currentFarmerId);

                        // If you have a DataGridView for crop performance
                        // DataTable dt = new DataTable();
                        // using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        // {
                        //     adapter.Fill(dt);
                        // }
                        // dgvCropPerformance.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error analyzing crop performance: " + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panelStats_Paint(object sender, PaintEventArgs e)
        {
            // You can add any custom painting if needed
        }
    }
}