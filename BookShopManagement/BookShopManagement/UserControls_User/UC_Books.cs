using BookShopManagement.Database;
using BookShopManagement.Forms;
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
                dataGridView1.Rows.Add(
                    book.BookId,
                    book.BookTitle, 
                    book.Author, 
                    book.Publisher, 
                    book.Quantity.ToString(), 
                    book.SellingPrice.ToString(), 
                    book.Category);
            }
       
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            string selectedGenre = comboBox2.SelectedItem.ToString();

            List<Book> books;
            if (selectedGenre == "All")
            {
                dataGridView1.Rows.Clear();
                books = await GetAllBooksAsync();
            }
            else
            {
                dataGridView1.Rows.Clear();
                books = await GetBooksByGenreAsync(selectedGenre);
            }

            foreach (Book book in books)
            {
                dataGridView1.Rows.Add(
                    book.BookId, 
                    book.BookTitle, 
                    book.Author, 
                    book.Publisher, 
                    book.Quantity.ToString(), 
                    book.SellingPrice.ToString(), 
                    book.Category);
            }
        }

        public async Task<List<string>> GetGenresFromFirestoreAsync()
        {
            var db = FirebaseHelper.Database;
            CollectionReference booksRef = db.Collection("Category");
            QuerySnapshot snapshot = await booksRef.GetSnapshotAsync();

            HashSet<string> genres = new HashSet<string>(); // Sử dụng HashSet để loại bỏ thể loại trùng lặp

            foreach (DocumentSnapshot document in snapshot.Documents)
            {
                if (document.Exists)
                {
                    string genre = document.GetValue<string>("Name");
                    if (!string.IsNullOrEmpty(genre))
                    {
                        genres.Add(genre);
                    }
                }
            }

            List<string> genreList = new List<string>(genres);
            genreList.Insert(0, "All"); // Thêm "All" vào đầu danh sách

            return genreList;
        }

        public async Task<List<Book>> GetBooksByGenreAsync(string genre)
        {
            var db = FirebaseHelper.Database;
            CollectionReference booksRef = db.Collection("Book");
            QuerySnapshot snapshot = await booksRef.WhereEqualTo("Category", genre).GetSnapshotAsync();

            List<Book> books = new List<Book>();

            foreach (DocumentSnapshot document in snapshot.Documents)
            {
                if (document.Exists)
                {
                    Book book = document.ConvertTo<Book>();
                    books.Add(book);
                }
            }

            return books;
        }

        public async Task<List<Book>> GetAllBooksAsync()
        {
            var db = FirebaseHelper.Database;
            CollectionReference booksRef = db.Collection("Book");
            QuerySnapshot snapshot = await booksRef.GetSnapshotAsync();

            List<Book> books = new List<Book>();

            foreach (DocumentSnapshot document in snapshot.Documents)
            {
                if (document.Exists)
                {
                    Book book = document.ConvertTo<Book>();
                    books.Add(book);
                }
            }

            return books;
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
                    dataGridView1.Rows.Add(
                        book.BookId,
                        book.BookTitle, 
                        book.Author, 
                        book.Publisher, 
                        book.Quantity.ToString(),
                        book.SellingPrice.ToString(),
                        book.Category
                    );
                }
            }

        }
        private async void LoadGenres()
        {
            List<string> genres = await GetGenresFromFirestoreAsync();
            comboBox2.DataSource = genres;
        }

        private void UC_Books_Load(object sender, EventArgs e)
        {
            LoadGenres();
            //LoadBooks();
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
                    if(selectedBook.Quantity == 0)
                    {
                        MessageBox.Show($"'{selectedBook.BookTitle}' out of stock! We are sorry");
                        return;
                    }
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
                { "Quantity", 1 },
                {"CustomerId", Form_Login.currentUserId },
                {"TotalPrice", book.SellingPrice },
                {"BookId",book.BookId },
                {"Price", book.SellingPrice }
            };
           
                await cartRef.SetAsync(dict, SetOptions.Overwrite);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAddNewBooks_Click(object sender, EventArgs e)
        {
            using (Form_ScanBarcode fbd = new Form_ScanBarcode())
            {
                fbd.ShowDialog();
            }
        }
    }
}
