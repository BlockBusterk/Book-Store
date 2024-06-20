using BookShopManagement.Database;
using BookShopManagement.Models;
using Google.Cloud.Firestore;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShopManagement.Bill
{
    public partial class Form_Bill : Form
    {
        public Form_Bill()
        {
            InitializeComponent();
        }
        public string Total { get; set; } = "";

        private async void Form_Bill_Load(object sender, EventArgs e)
        {
            // Lấy ngày giờ hiện tại theo giờ UTC
            DateTime utcNow = DateTime.UtcNow;

            // Xác định múi giờ Việt Nam (Asia/Ho_Chi_Minh)
            TimeZoneInfo vietnamTimeZone;
            try
            {
                vietnamTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
            }
            catch (TimeZoneNotFoundException)
            {
                vietnamTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Asia/Ho_Chi_Minh");
            }
            catch (InvalidTimeZoneException)
            {
                vietnamTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Asia/Ho_Chi_Minh");
            }

            // Chuyển đổi giờ UTC sang giờ Việt Nam
            DateTime vietnamTime = TimeZoneInfo.ConvertTimeFromUtc(utcNow, vietnamTimeZone);

            // Định dạng ngày giờ
            string formattedUtcNow = utcNow.ToString("yyyy-MM-ddTHH:mm:ssZ");
            string formattedVietnamTime = vietnamTime.ToString("yyyy-MM-dd HH:mm:ss");

            // Hiển thị ngày giờ
            Console.WriteLine("UTC Time: " + formattedUtcNow);
            Console.WriteLine("Vietnam Time: " + formattedVietnamTime);


            ReportParameter[] parameters = new ReportParameter[2];
            parameters[0] = new ReportParameter("InTotal", Total);
            parameters[1] = new ReportParameter("DateTime", formattedVietnamTime);
            reportViewer1.LocalReport.SetParameters(parameters);
            var db = FirebaseHelper.Database;
            Query cartQue = db.Collection("Cart").Document(Form_Login.currentUserId).Collection("cart");
            QuerySnapshot snap = await cartQue.GetSnapshotAsync();

            var data = new List<BookShopManagement.Models.Bill>();
            foreach (DocumentSnapshot doc in snap)
            {

                if (doc.Exists)
                {
                    Cart cart = doc.ConvertTo<Cart>();
                    DocumentReference bookRef = db.Collection("Book").Document(cart.BookId);
                    DocumentSnapshot bookSnap = await bookRef.GetSnapshotAsync();
                    if (bookSnap.Exists)
                    {
                        Book book = bookSnap.ConvertTo<Book>();
                        data.Add(new Models.Bill
                        {
                            Title = book.BookTitle,
                            Author = book.Author,
                            Publisher = book.Publisher,
                            Quantity = cart.Quantity,
                            Price = cart.Price,
                        });
                    }
                       

                }
            }
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsBill", data));

            this.reportViewer1.RefreshReport();
        }
    }
}
