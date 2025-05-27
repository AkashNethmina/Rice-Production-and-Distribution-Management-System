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
        private int farmerCount = 0;
        private int privateBuyerCount = 0;
        private decimal totalSystemSales = 0;
        private decimal totalSystemStock = 0;
        private decimal totalPendingRequests = 0;
        private decimal totalPurchaseQuantity = 0;

       
        private Dictionary<string, int> roleCounts = new Dictionary<string, int>();

 
        private Dictionary<string, decimal> stockByType = new Dictionary<string, decimal>();


        private Dictionary<string, decimal> salesByMonth = new Dictionary<string, decimal>();


        private Dictionary<string, decimal> mysalesByMonth = new Dictionary<string, decimal>();

      
        private Dictionary<string, decimal> mystockByType = new Dictionary<string, decimal>();


        public GovernmentHome(int governmentid)
        {
            InitializeComponent();
            this.currentGovId = governmentid;
            this.Load += GovernmentHome_Load;
        }

        

        private void LoadGovernmentStatistics()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

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

                                roleCounts[roleName] = count;

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
            
            lblFarmerCount.Text = farmerCount.ToString();
            lblPrivateBuyerCount.Text = privateBuyerCount.ToString();
            lbltotalPurchaseQuantity.Text = totalPurchaseQuantity.ToString("N2") + " kg";
            lblTotalPendingRequests.Text = totalPendingRequests.ToString("N2") + " kg";

        }

        private void SetupSalesChart()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

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

                chartSales.Series.Clear();
                chartSales.ChartAreas.Clear();

                System.Windows.Forms.DataVisualization.Charting.ChartArea salesChartArea =
                    new System.Windows.Forms.DataVisualization.Charting.ChartArea("SalesChartArea");
                chartSales.ChartAreas.Add(salesChartArea);

                System.Windows.Forms.DataVisualization.Charting.Series salesSeries =
                    new System.Windows.Forms.DataVisualization.Charting.Series("Sales");

                salesSeries.ChartType = SeriesChartType.Column;

                foreach (var entry in salesByMonth)
                {
                    salesSeries.Points.AddXY(entry.Key, entry.Value);
                }

                chartSales.Series.Add(salesSeries);
                chartSales.Titles.Add(new Title("System-wide Monthly Sales", Docking.Top, new System.Drawing.Font("Arial", 12, FontStyle.Bold), Color.Black));

                salesChartArea.AxisX.MajorGrid.LineColor = Color.LightGray;
                salesChartArea.AxisY.MajorGrid.LineColor = Color.LightGray;
                salesChartArea.AxisX.LabelStyle.Font = new System.Drawing.Font("Arial", 9);
                salesChartArea.AxisY.LabelStyle.Font = new System.Drawing.Font("Arial", 9);

                salesChartArea.AxisX.LabelStyle.Angle = -45;
                salesChartArea.AxisX.LabelStyle.IsStaggered = false;
                salesChartArea.AxisX.MajorGrid.Enabled = false;

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

                chartStock.Series.Clear();
                chartStock.ChartAreas.Clear();
                chartStock.Legends.Clear();
                chartStock.Titles.Clear();

                System.Windows.Forms.DataVisualization.Charting.ChartArea stockChartArea =
                    new System.Windows.Forms.DataVisualization.Charting.ChartArea("StockChartArea");
                chartStock.ChartAreas.Add(stockChartArea);

                System.Windows.Forms.DataVisualization.Charting.Series stockSeries =
                    new System.Windows.Forms.DataVisualization.Charting.Series("Stock");

                stockSeries.ChartType = SeriesChartType.Pie;

                foreach (var entry in stockByType)
                {
                    DataPoint point = new DataPoint();
                    point.SetValueXY(entry.Key, entry.Value);
                    point.LegendText = entry.Key;
                    point.Label = "#PERCENT{P0}";
                    stockSeries.Points.Add(point);
                }

                chartStock.Series.Add(stockSeries);
                chartStock.Titles.Add(new Title("System-wide Stock by Crop Type", Docking.Top, new System.Drawing.Font("Arial", 12, FontStyle.Bold), Color.Black));

                System.Windows.Forms.DataVisualization.Charting.Legend stockLegend =
                    new System.Windows.Forms.DataVisualization.Charting.Legend("StockLegend");
                chartStock.Legends.Add(stockLegend);
                stockSeries.Legend = "StockLegend";

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

                mychartSales.Series.Clear();
                mychartSales.ChartAreas.Clear();

                System.Windows.Forms.DataVisualization.Charting.ChartArea salesChartArea =
                    new System.Windows.Forms.DataVisualization.Charting.ChartArea("SalesChartArea");
                mychartSales.ChartAreas.Add(salesChartArea);

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

                salesChartArea.AxisX.MajorGrid.LineColor = Color.LightGray;
                salesChartArea.AxisY.MajorGrid.LineColor = Color.LightGray;
                salesChartArea.AxisX.LabelStyle.Font = new System.Drawing.Font("Arial", 9);
                salesChartArea.AxisY.LabelStyle.Font = new System.Drawing.Font("Arial", 9);

                salesChartArea.AxisX.LabelStyle.Angle = -45;
                salesChartArea.AxisX.LabelStyle.IsStaggered = false;
                salesChartArea.AxisX.MajorGrid.Enabled = false;

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

                mychartStock.Series.Clear();
                mychartStock.ChartAreas.Clear();
                mychartStock.Legends.Clear();
                mychartStock.Titles.Clear();

                System.Windows.Forms.DataVisualization.Charting.ChartArea stockChartArea =
                    new System.Windows.Forms.DataVisualization.Charting.ChartArea("StockChartArea");
                mychartStock.ChartAreas.Add(stockChartArea);

                System.Windows.Forms.DataVisualization.Charting.Series stockSeries =
                    new System.Windows.Forms.DataVisualization.Charting.Series("Stock");

                stockSeries.ChartType = SeriesChartType.Pie;

                foreach (var entry in mystockByType)
                {
                    DataPoint point = new DataPoint();
                    point.SetValueXY(entry.Key, entry.Value);
                    point.LegendText = entry.Key;

                    point.Label = "#PERCENT{P0}";
                    stockSeries.Points.Add(point);
                }

                mychartStock.Series.Add(stockSeries);
                mychartStock.Titles.Add(new Title("My Current Stock by Crop Type", Docking.Top, new System.Drawing.Font("Arial", 12, FontStyle.Bold), Color.Black));

               
                System.Windows.Forms.DataVisualization.Charting.Legend stockLegend =
                    new System.Windows.Forms.DataVisualization.Charting.Legend("StockLegend");
                mychartStock.Legends.Add(stockLegend);
                stockSeries.Legend = "StockLegend";

                stockSeries.Palette = ChartColorPalette.BrightPastel;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading stock chart: " + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
      

        private void btnRefresh_Click(object sender, EventArgs e)
        {
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

            chartSales.Titles.Clear();
            chartStock.Titles.Clear();

            LoadGovernmentStatistics();
            SetupSalesChart();
            SetupStockChart();
            SetupMySalesChart();
            SetupMyStockChart();

            MessageBox.Show("Dashboard data has been refreshed.", "Refresh Complete",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void RefreshDashboard()
        {
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

            LoadGovernmentStatistics();
            SetupSalesChart();
            SetupStockChart();
            SetupMySalesChart();
            SetupMyStockChart();
        }

        private void GovernmentHome_Load(object sender, EventArgs e)
        {
            LoadGovernmentStatistics();
            SetupSalesChart();
            SetupStockChart();
            SetupMySalesChart();
            SetupMyStockChart();
        }
    }
}