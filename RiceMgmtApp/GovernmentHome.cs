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
    public partial class GovernmentHome : UserControl
    {
        private readonly string connectionString = "Server=DESKTOP-O6K3I3U\\SQLEXPRESS;Database=RiceProductionDB2;Integrated Security=True;";
        private int currentGovId;
        // Statistics variables
        private int farmerCount = 0;
        private int privateBuyerCount = 0;
        private decimal totalSystemSales = 0;
        private decimal totalSystemStock = 0;
        private decimal totalPendingRequests = 0;
        private decimal totalPurchaseQuantity = 0;

        // Dictionary to store role names and their corresponding counts
        private Dictionary<string, int> roleCounts = new Dictionary<string, int>();

        // Dictionary for crop types and quantities (system-wide)
        private Dictionary<string, decimal> stockByType = new Dictionary<string, decimal>();

        // Dictionary for sales data by month (system-wide)
        private Dictionary<string, decimal> salesByMonth = new Dictionary<string, decimal>();

        // Dictionary for sales data by month (for this buyer)
        private Dictionary<string, decimal> mysalesByMonth = new Dictionary<string, decimal>();

        // Dictionary for crop types and quantities (for this buyer)
        private Dictionary<string, decimal> mystockByType = new Dictionary<string, decimal>();


        public GovernmentHome(int governmentid)
        {
            InitializeComponent();
            this.currentGovId = governmentid;
            // Subscribe to the Load event
            this.Load += GovernmentHome_Load;
        }

        private void GovernmentHome_Load(object sender, EventArgs e)
        {
            // Load all data when the control is loaded
            LoadGovernmentStatistics();
            SetupSalesChart();
            SetupStockChart();
            SetupMySalesChart();
            SetupMyStockChart();
        }

        private void LoadGovernmentStatistics()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Get user counts by role
                    string userQuery = @"
                        SELECT 
                            r.RoleName, 
                            COUNT(u.UserID) as UserCount
                        FROM 
                            Users u
                        JOIN 
                            Roles r ON u.RoleID = r.RoleID
                        GROUP BY 
                            r.RoleName, r.RoleID
                        ORDER BY 
                            r.RoleID";

                    using (SqlCommand command = new SqlCommand(userQuery, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                           
                            while (reader.Read())
                            {
                                string roleName = reader["RoleName"].ToString();
                                int count = Convert.ToInt32(reader["UserCount"]);

                                // Store in dictionary
                                roleCounts[roleName] = count;

                                // Update specific counters
                                switch (roleName)
                                {
                                    
                                    case "Farmer":
                                        farmerCount = count;
                                        break;
                                    case "Private Buyer":
                                        privateBuyerCount = count;
                                        break;
                                }

                              
                            }
                        }
                    }

                    // Get total system sales value
                    //string salesQuery = @"
                    //    SELECT 
                    //        SUM(SalePrice * Quantity) as TotalSales
                    //    FROM 
                    //        Sales";

                    //using (SqlCommand command = new SqlCommand(salesQuery, connection))
                    //{
                    //    object result = command.ExecuteScalar();
                    //    totalSystemSales = result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                    //}

                    // Get total system stock quantity
                    //string stockQuery = @"
                    //    SELECT 
                    //        SUM(Quantity) as TotalStock
                    //    FROM 
                    //        Stock";

                    //using (SqlCommand command = new SqlCommand(stockQuery, connection))
                    //{
                    //    object result = command.ExecuteScalar();
                    //    totalSystemStock = result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                    //}
                    // Get total Sales quantity
                    string purchaseQuantity = @"
                        SELECT 
                            SUM(Quantity) as TotalQuantity
                        FROM 
                            Sales
                        WHERE 
                            BuyerID = @BuyerID";

                    using (SqlCommand command = new SqlCommand(purchaseQuantity, connection))
                    {
                        command.Parameters.AddWithValue("@BuyerID", currentGovId);
                        object result = command.ExecuteScalar();
                        totalPurchaseQuantity = result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                    }

                    // Get total pending requests
                    string requestQuery = @"
                        SELECT 
                            SUM(Quantity) as TotalPendingRequests
                        FROM 
                            RequestPaddy
                        WHERE 
                            BuyerID = @BuyerID AND RequestStatus = 'Pending'";

                    using (SqlCommand command = new SqlCommand(requestQuery, connection))
                    {
                        command.Parameters.AddWithValue("@BuyerID", currentGovId);
                        object result = command.ExecuteScalar();
                        totalPendingRequests = result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                    }
                }

                // Update UI elements
                UpdateGovernmentStatisticsDisplay();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading government statistics: " + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateGovernmentStatisticsDisplay()
        {
            // Update user count controls
         
            lblFarmerCount.Text = farmerCount.ToString();
            lblPrivateBuyerCount.Text = privateBuyerCount.ToString();
            lbltotalPurchaseQuantity.Text = totalPurchaseQuantity.ToString("N2") + " kg";
            lblTotalPendingRequests.Text = totalPendingRequests.ToString("N2") + " kg";
            // Update system statistics (you may need to add these labels to your form)
            // These would replace or supplement the existing labels
            // lblTotalSystemSales.Text = totalSystemSales.ToString("C2"); // Currency format
            // lblTotalSystemStock.Text = totalSystemStock.ToString("N2") + " kg";

        }

        private void SetupSalesChart()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // SQL query to get monthly sales data (system-wide)
                    string query = @"
                        SELECT 
                            FORMAT(SaleDate, 'yyyy-MM') as Month,
                            SUM(SalePrice * Quantity) as TotalSales
                        FROM 
                            Sales
                        GROUP BY 
                            FORMAT(SaleDate, 'yyyy-MM')
                        ORDER BY 
                            Month";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
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
                chartSales.Titles.Add(new Title("System-wide Monthly Sales", Docking.Top, new System.Drawing.Font("Arial", 12, FontStyle.Bold), Color.Black));

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

                    // SQL query to get stock data by crop type (system-wide)
                    string query = @"
                        SELECT 
                            CropType,
                            SUM(Quantity) as TotalQuantity
                        FROM 
                            Stock
                        GROUP BY 
                            CropType
                        ORDER BY 
                            TotalQuantity DESC";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
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
                chartStock.Titles.Add(new Title("System-wide Stock by Crop Type", Docking.Top, new System.Drawing.Font("Arial", 12, FontStyle.Bold), Color.Black));

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


        private void SetupMySalesChart()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    // SQL query to get monthly sales data for specific buyer
                    string query = @"
                SELECT 
                    FORMAT(SaleDate, 'yyyy-MM') as Month,
                    SUM(SalePrice * Quantity) as TotalSales
                FROM 
                    Sales
                WHERE 
                    BuyerID = @BuyerID
                GROUP BY 
                    FORMAT(SaleDate, 'yyyy-MM')
                ORDER BY 
                    Month";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add the parameter here, inside the method
                        command.Parameters.AddWithValue("@BuyerID", currentGovId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string month = reader["Month"].ToString();
                                decimal totalSales = Convert.ToDecimal(reader["TotalSales"]);
                                mysalesByMonth[month] = totalSales;
                            }
                        }
                    }
                }

                // Configure the Sales Chart
                mychartSales.Series.Clear();
                mychartSales.ChartAreas.Clear();

                // Specify the full namespace for ChartArea to resolve ambiguity
                System.Windows.Forms.DataVisualization.Charting.ChartArea salesChartArea =
                    new System.Windows.Forms.DataVisualization.Charting.ChartArea("SalesChartArea");
                mychartSales.ChartAreas.Add(salesChartArea);

                // Specify the full namespace for Series to avoid ambiguity
                System.Windows.Forms.DataVisualization.Charting.Series salesSeries =
                    new System.Windows.Forms.DataVisualization.Charting.Series("Sales");
                salesSeries.ChartType = SeriesChartType.Column;

                foreach (var entry in mysalesByMonth
                    )
                {
                    salesSeries.Points.AddXY(entry.Key, entry.Value);
                }

                mychartSales.Series.Add(salesSeries);
                mychartSales.Titles.Add(new Title("Monthly Sales for Current Buyer", Docking.Top,
                    new System.Drawing.Font("Arial", 12, FontStyle.Bold), Color.Black));

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
        private void SetupMyStockChart()
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
                            Sales
                        WHERE 
                            BuyerID = @BuyerID
                        GROUP BY 
                            CropType
                        ORDER BY 
                            TotalQuantity DESC";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@BuyerID", currentGovId);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string cropType = reader["CropType"].ToString();
                                decimal quantity = Convert.ToDecimal(reader["TotalQuantity"]);

                                mystockByType[cropType] = quantity;
                            }
                        }
                    }
                }

                // Configure the Stock Chart
                mychartStock.Series.Clear();
                mychartStock.ChartAreas.Clear();
                mychartStock.Legends.Clear();
                mychartStock.Titles.Clear();

                // Specify the full namespace for ChartArea to resolve ambiguity
                System.Windows.Forms.DataVisualization.Charting.ChartArea stockChartArea =
                    new System.Windows.Forms.DataVisualization.Charting.ChartArea("StockChartArea");
                mychartStock.ChartAreas.Add(stockChartArea);

                // Inside SetupStockChart method
                System.Windows.Forms.DataVisualization.Charting.Series stockSeries =
                    new System.Windows.Forms.DataVisualization.Charting.Series("Stock");

                stockSeries.ChartType = SeriesChartType.Pie;

                foreach (var entry in mystockByType)
                {
                    DataPoint point = new DataPoint();
                    point.SetValueXY(entry.Key, entry.Value);
                    point.LegendText = entry.Key;
                    // Show percentage in the pie chart
                    point.Label = "#PERCENT{P0}";
                    stockSeries.Points.Add(point);
                }

                mychartStock.Series.Add(stockSeries);
                mychartStock.Titles.Add(new Title("My Current Stock by Crop Type", Docking.Top, new System.Drawing.Font("Arial", 12, FontStyle.Bold), Color.Black));

                // Specify the full namespace for Legend to resolve ambiguity
                System.Windows.Forms.DataVisualization.Charting.Legend stockLegend =
                    new System.Windows.Forms.DataVisualization.Charting.Legend("StockLegend");
                mychartStock.Legends.Add(stockLegend);
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
      

        // Button click handler for the refresh button
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // Reset counters and dictionaries
            
           
            farmerCount = 0;
            privateBuyerCount = 0;
            totalSystemSales = 0;
            totalSystemStock = 0;
            totalPendingRequests = 0;
            roleCounts.Clear();
            stockByType.Clear();
            mystockByType.Clear();
            salesByMonth.Clear();
            mysalesByMonth.Clear();

            // Clear chart titles
            chartSales.Titles.Clear();
            chartStock.Titles.Clear();

            // Reload all data
            LoadGovernmentStatistics();
            SetupSalesChart();
            SetupStockChart();
            SetupMySalesChart();
            SetupMyStockChart();

            MessageBox.Show("Dashboard data has been refreshed.", "Refresh Complete",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Add method to refresh data (can be called from outside if needed)
        public void RefreshDashboard()
        {
            // Reset counters and dictionaries
            
            farmerCount = 0;
            privateBuyerCount = 0;
            totalSystemSales = 0;
            totalSystemStock = 0;
            totalPendingRequests = 0;
            roleCounts.Clear();
            stockByType.Clear();
            mystockByType.Clear();
            mysalesByMonth.Clear();
            salesByMonth.Clear();

            // Reload all data
            LoadGovernmentStatistics();
            SetupSalesChart();
            SetupStockChart();
            SetupMySalesChart();
            SetupMyStockChart();
        }

    }
}