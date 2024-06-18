using BookShopManagement.Database;
using BookShopManagement.Forms_User;
using BookShopManagement.Models;
using Google.Cloud.Firestore;
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

namespace BookShopManagement.UserControls_User
{
    public partial class UC_Books : UserControl
    {
        private string filter = string.Empty;
        public UC_Books()
        {
            InitializeComponent();
        }

        private async void textBox7_TextChanged(object sender, EventArgs e)
        {
            string keyword = textBox7.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                LoadBooks();
                return;
            }
            var db = FirebaseHelper.Database;
            CollectionReference booksRef = db.Collection("Book");
            Query publisherQuery = booksRef.WhereLessThanOrEqualTo("Publisher", keyword + '\uf8ff');
            Query titleQuery = booksRef.WhereLessThanOrEqualTo("Title", keyword + '\uf8ff');
            Query authorQuery = booksRef.WhereLessThanOrEqualTo("Author", keyword + '\uf8ff');

            // Get results from all three queries
            QuerySnapshot publisherSnapshot = await publisherQuery.GetSnapshotAsync();
            QuerySnapshot titleSnapshot = await titleQuery.GetSnapshotAsync();
            QuerySnapshot authorSnapshot = await authorQuery.GetSnapshotAsync();

            // Combine results into a single list, removing duplicates
            List<Book> books = new List<Book>();
            books.AddRange(publisherSnapshot.Documents.Select(doc =>
            {
                Book book = doc.ConvertTo<Book>();
                book.BookId = doc.Id;  // Lấy ID của tài liệu và gán cho BookId
                return book;
            }));
            books.AddRange(titleSnapshot.Documents.Select(doc =>
            {
                Book book = doc.ConvertTo<Book>();
                book.BookId = doc.Id;
                return book;
            }));
            books.AddRange(authorSnapshot.Documents.Select(doc =>
            {
                Book book = doc.ConvertTo<Book>();
                book.BookId = doc.Id;
                return book;
            }));


            dataGridView1.Rows.Clear();
            // Loại bỏ các bản sao dựa trên BookId
            books = books.GroupBy(b => b.BookId).Select(g => g.First()).ToList();

            books = books.Where(b => b.Publisher.ToLower().Contains(keyword) ||
                                     b.BookTitle.ToLower().Contains(keyword) ||
                                     b.Author.ToLower().Contains(keyword)).ToList();
            foreach (Book book in books)
            {
                dataGridView1.Rows.Add(book.BookId,book.BookTitle, book.Author, book.Publisher, book.Quantity.ToString(), book.SellingPrice.ToString(), book.Barcode);
            }
       
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            filter = comboBox2.Text;
        }

        private async void LoadBooks()
        {
            dataGridView1.Rows.Clear();
            var db = FirebaseHelper.Database;
            Query bookQue = db.Collection("Book");
            QuerySnapshot snap = await bookQue.GetSnapshotAsync();
            foreach(DocumentSnapshot doc in snap)
            {
                
                if(doc.Exists)
                {
                    Book book = doc.ConvertTo<Book>();
                    book.BookId = doc.Id;
                    dataGridView1.Rows.Add(book.BookId,book.BookTitle, book.Author, book.Publisher, book.Quantity.ToString(),book.SellingPrice.ToString(),book.Barcode);
                }
            }

        }

        private void UC_Books_Load(object sender, EventArgs e)
        {
            LoadBooks();
        }

        private async void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["AddToCart"].Index && e.RowIndex >= 0)
            {
                // Lấy dữ liệu hàng được nhấn
               
                var bookid = dataGridView1.Rows[e.RowIndex].Cells["BookId"].Value.ToString();
                var db = FirebaseHelper.Database;
                DocumentReference bookRef = db.Collection("Book").Document(bookid);
                DocumentSnapshot bookSnapshot = await bookRef.GetSnapshotAsync();

                if (bookSnapshot.Exists)
                {
                    // Convert Firestore document to Book object
                    Book selectedBook = bookSnapshot.ConvertTo<Book>();
                    selectedBook.BookId = bookid;
                    // Add the book to the cart collection
                    await AddToCartF(selectedBook);

                    // Optionally, provide feedback to the user
                    MessageBox.Show($"Added '{selectedBook.BookTitle}' to cart!");
                }
                else
                {
                    MessageBox.Show("Selected book does not exist in Database.");
                }

            }
            
        }
        private async Task AddToCartF(Book book)
        {
            // Reference to the 'cart' collection in Firestore
            var db = FirebaseHelper.Database;
            DocumentReference cartRef = db.Collection("Cart").Document(Form_Login.currentUserId).Collection("cart").Document(book.BookId);

            // Add the selected book to the 'cart' collection
            Dictionary<string, object> dict = new Dictionary<string, object>()
            {
                { "BookTitle",book.BookTitle  },
                { "Quantity", 1 },
                {"CustomerName", Form_Login.currentUserName },
                {"CustomerEmail", Form_Login.currentUserEmail },
                {"BookPublisher", book.Publisher },
                {"TotalPrice", book.SellingPrice },
                {"Author", book.Author },
                {"BookId",book.BookId },
                {"Price", book.SellingPrice }
            };
           
                await cartRef.SetAsync(dict, SetOptions.Overwrite);

        }
    }
}
