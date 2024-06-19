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
using BookShopManagement.Models;
using Google.Cloud.Firestore;

namespace BookShopManagement.UserControls
{
    public partial class UC_ViewSales : UserControl
    {
        public UC_ViewSales()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UC_ViewSales_Load(object sender, EventArgs e)
        {
            LoadRevenue();
        }
        private async void LoadRevenue()
        {
            dataGridView1.Rows.Clear();
            List<BookSalesSummary> summaries = await CalculateBookSalesSummaryAsync();
            var sortedSummaries = summaries.OrderByDescending(summary => summary.TotalQuantitySold).ToList();
            foreach (var summary in sortedSummaries)
            {
                dataGridView1.Rows.Add(
                    summary.BookId,
                    summary.BookTitle,
                    summary.Author,
                    summary.Publisher,
                    summary.Category,
                    summary.TotalQuantitySold,
                    summary.TotalRevenue

               );
            }
           
        }
        public async Task<Dictionary<string, Book>> GetBooksDetailsAsync(List<string> bookIds)
        {
            var db = FirebaseHelper.Database;
            CollectionReference booksCollection = db.Collection("Book");

            var booksDetails = new Dictionary<string, Book>();

            foreach (string bookId in bookIds)
            {
                DocumentSnapshot bookDoc = await booksCollection.Document(bookId).GetSnapshotAsync();
                if (bookDoc.Exists)
                {
                    Book book = bookDoc.ConvertTo<Book>();
                    booksDetails[bookId] = book;
                }
            }

            return booksDetails;
        }
        public async Task<List<BookSalesSummary>> CalculateBookSalesSummaryAsync()
        {
            var db = FirebaseHelper.Database;
            CollectionReference orderCollection = db.Collection("Order");
            QuerySnapshot orderSnapshot = await orderCollection.GetSnapshotAsync();

            var bookSalesSummaries = new Dictionary<string, BookSalesSummary>();

            foreach (DocumentSnapshot orderDoc in orderSnapshot.Documents)
            {
                if (orderDoc.Exists)
                {
                    Order order = orderDoc.ConvertTo<Order>();

                    foreach (Book book in order.Books)
                    {
                        if (bookSalesSummaries.ContainsKey(book.BookId))
                        {
                            bookSalesSummaries[book.BookId].TotalQuantitySold += book.Quantity;
                            bookSalesSummaries[book.BookId].TotalRevenue += book.Quantity * book.SellingPrice;
                        }
                        else
                        {
                            bookSalesSummaries[book.BookId] = new BookSalesSummary
                            {
                                BookId = book.BookId,
                                BookTitle = book.BookTitle,
                                TotalQuantitySold = book.Quantity,
                                TotalRevenue = book.Quantity * book.SellingPrice
                            };
                        }
                    }
                }
            }

            // Lấy danh sách BookId từ summaries
            var bookIds = bookSalesSummaries.Keys.ToList();

            // Lấy thông tin chi tiết của các sách từ collection Books
            var booksDetails = await GetBooksDetailsAsync(bookIds);

            // Bổ sung thông tin chi tiết vào summaries
            foreach (var summary in bookSalesSummaries.Values)
            {
                if (booksDetails.ContainsKey(summary.BookId))
                {
                    var bookDetail = booksDetails[summary.BookId];
                    summary.Author = bookDetail.Author;
                    summary.Publisher = bookDetail.Publisher;
                    summary.Category= bookDetail.Category;
                }
            }

            return bookSalesSummaries.Values.ToList();
        }

    }
}
