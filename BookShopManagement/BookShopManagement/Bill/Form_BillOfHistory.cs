using BookShopManagement.Database;
using BookShopManagement.Models;
using BookShopManagement.Utils;
using Google.Cloud.Firestore;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShopManagement.Bill
{
    public partial class Form_BillOfHistory : Form
    {
        public Form_BillOfHistory()
        {
            InitializeComponent();
        }
        public string BillID { get; set; } = "";
        private async void Form_BillOfHistory_Load(object sender, EventArgs e)
        {

            try
            {
                var db = FirebaseHelper.Database;
                DocumentReference receiptRef = db.Collection("Order").Document(BillID);
                DocumentSnapshot receiptSnapshot = await receiptRef.GetSnapshotAsync();

                if (receiptSnapshot.Exists)
                {
                    // Convert Firestore document to Order object
                    Order order = receiptSnapshot.ConvertTo<Order>();
                    var data = new List<BookShopManagement.Models.Bill>();
                    // Set Report Parameters
                    ReportParameter[] parameters = new ReportParameter[2];
                    parameters[0] = new ReportParameter("InTotal", order.TotalPrice.ToString());
                    parameters[1] = new ReportParameter("DateTime", VietNameTime.ConvertToVietnamTime(order.CreatedDate));
                    reportViewer1.LocalReport.SetParameters(parameters);

                    // Prepare data for the report
                    foreach(Book book in order.Books)
                    {
                        DocumentReference bookRef = db.Collection("Book").Document(book.BookId);
                        DocumentSnapshot bookSnap = await bookRef.GetSnapshotAsync();
                        if (bookSnap.Exists)
                        {
                            Book bookInfo = bookSnap.ConvertTo<Book>();
                            data.Add(new Models.Bill
                            {
                                Title = bookInfo.BookTitle,
                                Author = bookInfo.Author,
                                Publisher = bookInfo.Publisher,
                                Quantity = book.Quantity,
                                Price = book.SellingPrice
                            });
                        }
                    }
                   

                    // Update Report Data Source
                    reportViewer1.LocalReport.DataSources.Clear();
                    reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsBill", data));

                    // Refresh the Report Viewer
                    reportViewer1.RefreshReport();
                }
                else
                {
                    MessageBox.Show("Selected book does not exist in Database.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
    }

