using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookShopManagement.Database;
using Google.Cloud.Firestore;
using BookShopManagement.Models;
using System.Globalization;
using System.Windows.Forms.DataVisualization.Charting;

namespace BookShopManagement.UserControls
{
    public partial class UC_Home : UserControl
    {
        public UC_Home()
        {
            InitializeComponent();
        }
        Random rand = new Random();

        private void LoadChart()
        {
          

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadChart();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private async void UC_Home_Load(object sender, EventArgs e)
        {
            int currentYear = DateTime.UtcNow.Year; // Lấy năm hiện tại
            List<Order> orders = await GetOrdersForYearAsync(currentYear); // Lấy danh sách đơn hàng của năm hiện tại
            List<MonthlyRevenue> monthlyRevenues = CalculateMonthlyRevenue(orders, currentYear); // Tính toán tổng doanh thu theo tháng

            ConfigureChart(monthlyRevenues); // Hiển thị dữ liệu trên biểu đồ
            LoadData();
        }
        private async void LoadData()
        {
            var db = FirebaseHelper.Database;
            double totalRevenue = 0;
            int totalSoldBook = 0;
            CollectionReference collectionUser = db.Collection("UserData");

            // Get all documents in the collection
            QuerySnapshot snapshotUser = await collectionUser.GetSnapshotAsync();

            // Count the number of documents
            
            label7.Text= (snapshotUser.Count - 1).ToString(); //So luong user

            Query queryBook = db.Collection("Order");
            QuerySnapshot snapBook = await queryBook.GetSnapshotAsync();
            foreach(DocumentSnapshot snap in snapBook )
            {
                if(snap.Exists)
                {
                    Order order = snap.ConvertTo<Order>();
                    totalSoldBook += order.Quantity;
                }
            }
            label4.Text= totalSoldBook.ToString(); // So luong sach ban ra

            Query queryRevenue = db.Collection("Order");
            QuerySnapshot snapRevenue = await queryRevenue.GetSnapshotAsync();
            foreach (DocumentSnapshot snap in snapRevenue)
            {
                if (snap.Exists)
                {
                    Order order = snap.ConvertTo<Order>();
                    totalRevenue += order.TotalPrice;
                }
            }
            label5.Text = totalRevenue.ToString(); // Tong doanh thu

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        public async Task<List<Order>> GetOrdersForYearAsync(int year)
        {
            var db = FirebaseHelper.Database;
            CollectionReference orderCollectionRef = db.Collection("Order");

            // Lọc các đơn hàng trong năm được chỉ định
            QuerySnapshot snapshot = await orderCollectionRef
                .WhereGreaterThanOrEqualTo("CreatedDate", new DateTime(year, 1, 1).ToString("s"))
                .WhereLessThanOrEqualTo("CreatedDate", new DateTime(year, 12, 31).ToString("s"))
                .GetSnapshotAsync();

            List<Order> orders = snapshot.Documents.Select(doc => doc.ConvertTo<Order>()).ToList();

            return orders;
        }
        public List<MonthlyRevenue> CalculateMonthlyRevenue(List<Order> orders, int year)
        {
            // Khởi tạo danh sách các đối tượng MonthlyRevenue
            List<MonthlyRevenue> monthlyRevenues = new List<MonthlyRevenue>();

            // Lặp qua từng tháng trong năm
            for (int month = 1; month <= 12; month++)
            {
                // Lấy các đơn hàng của tháng hiện tại
                var ordersInMonth = orders.Where(order =>
                {
                    DateTime orderDate = DateTime.ParseExact(order.CreatedDate, "s", null);
                    return orderDate.Year == year && orderDate.Month == month;
                });

                // Tính tổng doanh thu của tháng hiện tại
                decimal totalRevenue = (decimal)ordersInMonth.Sum(order => order.TotalPrice);

                // Thêm vào danh sách MonthlyRevenue
                monthlyRevenues.Add(new MonthlyRevenue
                {
                    Month = month,
                    Year = year,
                    TotalRevenue = totalRevenue
                });
            }

            return monthlyRevenues;
        }
        private void ConfigureChart(List<MonthlyRevenue> monthlyRevenues)
        {
            chart1.Series.Clear();

            // Tạo một Series mới cho biểu đồ cột
            Series series = new Series("TotalRevenuePerMonth");
            series.ChartType = SeriesChartType.Column; // Loại biểu đồ cột
            chart1.Series.Add(series);

            // Thêm dữ liệu từ danh sách monthlyRevenues vào Series
            foreach (var revenue in monthlyRevenues)
            {
                series.Points.AddXY($"{CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(revenue.Month)} {revenue.Year}", revenue.TotalRevenue);
            }

            // Đặt tên trục X và Y
            chart1.ChartAreas[0].AxisX.Title = "Month";
            chart1.ChartAreas[0].AxisY.Title = "Total Revenue";

            // Điều chỉnh giao diện và định dạng biểu đồ (nếu cần)
            // Ví dụ: đặt lại cỡ chữ, màu sắc, ...

            // Cập nhật biểu đồ
            chart1.Invalidate();
        }




    }
}
