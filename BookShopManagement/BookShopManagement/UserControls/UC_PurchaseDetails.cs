using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookShopManagement.Forms;
using Google.Cloud.Firestore;
using BookShopManagement.Database;
using BookShopManagement.Models;
using System.Web.UI.WebControls;

namespace BookShopManagement.UserControls
{
    public partial class UC_PurchaseDetails : UserControl
    {
        public UC_PurchaseDetails()
        {
            InitializeComponent();
            
            //LoadBookList();
        }

        private async void LoadBookList()
        {
            dataGridView.Rows.Clear();
            var db = FirebaseHelper.Database;
            Query query = db.Collection("Book");
            QuerySnapshot snapshots = await query.GetSnapshotAsync();

            foreach (DocumentSnapshot snapshot in snapshots.Documents) {
                Book book = snapshot.ConvertTo<Book>();
                if (snapshot.Exists)
                {
                    dataGridView.Rows.Add(
                        snapshot.Id,
                        book.BookTitle,
                        book.Author,
                        book.Publisher,
                        book.Quantity,
                        book.CostPrice,
                        book.SellingPrice,
                        book.Category
                   );
                }
            }

        }
        private void btnAddNewBooks_Click(object sender, EventArgs e)
        {
            using (Form_AddNewBook abn = new Form_AddNewBook())
            {
                abn.ShowDialog();
                LoadBookList();
            }
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Exclude header row
            {
                // Assuming the ID is in the first column (index 0)
                String id = dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                // Use the 'id' value as needed (e.g., display it, perform an action, etc.)
                // ...
                using (Form_EditDeleteBook form = new Form_EditDeleteBook(id))
                {
                    form.ShowDialog();
                    LoadBookList();
                }
            }
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


            dataGridView.Rows.Clear();
            // Loại bỏ các bản sao dựa trên BookId
            books = books.GroupBy(b => b.BookId).Select(g => g.First()).ToList();

            books = books.Where(b => b.Publisher.ToLower().Contains(keyword) ||
                                     b.BookTitle.ToLower().Contains(keyword) ||
                                     b.Author.ToLower().Contains(keyword)).ToList();
            foreach (Book book in books)
            {
                dataGridView.Rows.Add(
                    book.BookId,
                    book.BookTitle,
                    book.Author,
                    book.Publisher,
                    book.Quantity.ToString(),
                    book.CostPrice.ToString(),
                    book.SellingPrice.ToString(),
                    book.Category);
            }
        }
        private async void LoadBooks()
        {
            dataGridView.Rows.Clear();
            var db = FirebaseHelper.Database;
            Query bookQue = db.Collection("Book");
            QuerySnapshot snap = await bookQue.GetSnapshotAsync();
            foreach (DocumentSnapshot doc in snap)
            {
                if (doc.Exists)
                {
                    Book book = doc.ConvertTo<Book>();
                    book.BookId = doc.Id;
                    dataGridView.Rows.Add(
                        book.BookId,
                        book.BookTitle,
                        book.Author,
                        book.Publisher,
                        book.Quantity.ToString(),
                        book.CostPrice.ToString(),  
                        book.SellingPrice.ToString(),
                        book.Category);
                }
            }

        }

        private async void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedGenre = comboBox2.SelectedItem.ToString();

            List<Book> books;
            if (selectedGenre == "All")
            {
                dataGridView.Rows.Clear();
                books = await GetAllBooksAsync();
            }
            else
            {
                dataGridView.Rows.Clear();
                books = await GetBooksByGenreAsync(selectedGenre);
            }

            foreach (Book book in books)
            {
                dataGridView.Rows.Add(
                    book.BookId,
                    book.BookTitle,
                    book.Author,
                    book.Publisher,
                    book.Quantity.ToString(),
                    book.CostPrice.ToString(),
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

        private void UC_PurchaseDetails_Load(object sender, EventArgs e)
        {
            LoadGenres();
           // LoadBooks();
        }
        private async void LoadGenres()
        {
            List<string> genres = await GetGenresFromFirestoreAsync();
            comboBox2.DataSource = genres;
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
