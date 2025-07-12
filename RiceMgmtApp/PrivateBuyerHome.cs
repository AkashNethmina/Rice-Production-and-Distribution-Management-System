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
    public partial class PrivateBuyerHome : UserControl
    {
        private readonly string connectionString = "Server=DESKTOP-O6K3I3U\\SQLEXPRESS;Database=RiceProductionDB2;Integrated Security=True;";
        private int currentBuyerId; 
        private decimal totalPurchaseQuantity = 0; 
        private decimal totalStockQuantity = 0; 
        private decimal totalrequestQuantity = 0;

        
        private Dictionary<string, decimal> stockByType = new Dictionary<string, decimal>();

        private Dictionary<string, decimal> salesByMonth = new Dictionary<string, decimal>();

        public PrivateBuyerHome(int buyerid)
        {
            InitializeComponent();
            this.currentBuyerId = buyerid;
           
            this.Load += PrivateBuyerHome_Load;
        }

        private void PrivateBuyerHome_Load(object sender, EventArgs e)
        {
           
            LoadBuyerStatistics();
            SetupSalesChart();
            SetupStockChart();
        }

        private void LoadBuyerStatistics()
        {
            try
            {
                int completedSalesCount = 0; 

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                  
                    string purchaseQuantity = @"
                        SELECT 
                            SUM(Quantity) as TotalQuantity
                        FROM 
                            Sales
                        WHERE 
                            BuyerID = @BuyerID";

                    using (SqlCommand command = new SqlCommand(purchaseQuantity, connection))
                    {
                        command.Parameters.AddWithValue("@BuyerID", currentBuyerId);
                        object result = command.ExecuteScalar();
                        totalPurchaseQuantity = result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                    }

                    
                    string requestQuantity = @"
                        SELECT 
                            SUM(Quantity) as TotalQuantity
                        FROM 
                            RequestPaddy
                        WHERE 
                            BuyerID = @BuyerID AND RequestStatus = 'Pending'";

                    using (SqlCommand command = new SqlCommand(requestQuantity, connection))
                    {
                        command.Parameters.AddWithValue("@BuyerID", currentBuyerId);
                        object result = command.ExecuteScalar();
                        totalrequestQuantity = result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                    }

                }

               
                UpdateBuyerStatisticsDisplay();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading buyer statistics: " + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateBuyerStatisticsDisplay()
        {
           
            lbltotalPurchaseQuantity.Text = totalPurchaseQuantity.ToString("N2") + " kg";
            lblTotalrequest.Text = totalrequestQuantity.ToString("N2") + " Kg";

            
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
                        WHERE
                            BuyerID = @BuyerID
                        GROUP BY 
                            FORMAT(SaleDate, 'yyyy-MM')
                        ORDER BY 
                            Month";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@BuyerID", currentBuyerId);
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
                chartSales.Titles.Add(new Title("My Monthly Sales", Docking.Top, new System.Drawing.Font("Arial", 12, FontStyle.Bold), Color.Black));

                
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
                            Sales
                        WHERE 
                            BuyerID = @BuyerID
                        GROUP BY 
                            CropType
                        ORDER BY 
                            TotalQuantity DESC";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@BuyerID", currentBuyerId);
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
                chartStock.Titles.Add(new Title("My Current Stock by Crop Type", Docking.Top, new System.Drawing.Font("Arial", 12, FontStyle.Bold), Color.Black));

               
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

       
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            
            totalPurchaseQuantity = 0;
            totalStockQuantity = 0;
            totalrequestQuantity = 0;
            stockByType.Clear();
            salesByMonth.Clear();

            
            chartSales.Titles.Clear();
            chartStock.Titles.Clear();

            LoadBuyerStatistics();
            SetupSalesChart();
            SetupStockChart();

            MessageBox.Show("Dashboard data has been refreshed.", "Refresh Complete",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        
        public void RefreshDashboard()
        {
           
            totalPurchaseQuantity = 0;
            totalStockQuantity = 0;
            totalrequestQuantity = 0;
            stockByType.Clear();
            salesByMonth.Clear();

           
            LoadBuyerStatistics();
            SetupSalesChart();
            SetupStockChart();
         
        }

      
    }
}