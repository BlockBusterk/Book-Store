using BookShopManagement.Database;
using BookShopManagement.Models;
using BookShopManagement.UserControls;
using BookShopManagement.Utils;
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
using static Google.Cloud.Firestore.V1.StructuredAggregationQuery.Types.Aggregation.Types;

namespace BookShopManagement.Forms_User
{
    public partial class Form_Book_Detail_With_Btn : Form
    {
        private string bookId = string.Empty;
        private double sum = 0;
        private int total = 0;
        public void setBookId(string id)
        {
            this.bookId = id;
        }

        public Form_Book_Detail_With_Btn()
        {
            InitializeComponent();
        }

        private void Comment_Click(object sender, EventArgs e)
        {
            Form_Comment_User np = new Form_Comment_User();
            np.BookId = bookId;
            if (np.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Add comment successfully");
                Load_Comment();
            }
        }

        private void Form_Book_Detail_Load(object sender, EventArgs e)
        {
            Load_Book_Detail();
            Load_Comment();
        }
        private async void Load_Book_Detail()
        {
            var db = FirebaseHelper.Database;

          
            DocumentReference bookRef = db.Collection("Book").Document(bookId);
            DocumentSnapshot bookSnap = await bookRef.GetSnapshotAsync();
            if (bookSnap.Exists)
            {

                Book book = bookSnap.ConvertTo<Book>();
                pictureBox1.Load(book.ImageUrl);
                lblBookAuthor.Text = book.Author;
                lblBookTitle.Text = book.BookTitle;
                lblCategory.Text = book.Category;
                lblPublisher.Text = book.Publisher;
            } 
        }

        private async void Load_Comment()
        {
            flowLayoutPanel1.Controls.Clear();
            var db = FirebaseHelper.Database;
            Query commentQue = db.Collection("Comment").Document(bookId).Collection("UserInfo");
            QuerySnapshot snap = await commentQue.GetSnapshotAsync();
            foreach (DocumentSnapshot doc in snap)
            {

                if (doc.Exists)
                {
                    Comment comment = doc.ConvertTo<Comment>();
                    UC_UserComment userControl = new UC_UserComment();
                    DocumentReference userRef = db.Collection("UserData").Document(comment.UserId);
                    DocumentSnapshot userSnap = await userRef.GetSnapshotAsync();
                    if (userSnap.Exists)
                    {
                        UserData user = userSnap.ConvertTo<UserData>();
                        userControl.UserName = user.Name;
                        userControl.Comment = comment.UserComment;
                        userControl.Score = comment.UserScore;
                        userControl.ImageUrl = user.ImageUrl;
                        userControl.Date = VietNameTime.ConvertToVietnamTime(comment.CreatedDate);
                        flowLayoutPanel1.Controls.Add(userControl);
                        flowLayoutPanel1.ScrollControlIntoView(userControl);
                        sum += userControl.Score;
                        total++;
                    }

                }
            }
            lblScore.Text = Math.Round((total == 0 ? 0 : sum / total), 2).ToString();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var db = FirebaseHelper.Database;
            DocumentReference bookRef = db.Collection("Book").Document(bookId);
            DocumentSnapshot bookSnapshot = await bookRef.GetSnapshotAsync();

            if (bookSnapshot.Exists)
            {
                // Convert Firestore document to Book object
                Book selectedBook = bookSnapshot.ConvertTo<Book>();
                selectedBook.BookId = bookId;
                if (selectedBook.Quantity == 0)
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

        private async Task AddToCartF(Book book)
        {
            //Get the amount of the book
            int quantity = int.Parse(lblBookQuantity.Text);
            // Reference to the 'cart' collection in Firestore
            var db = FirebaseHelper.Database;
            DocumentReference cartRef = db.Collection("Cart").Document(Form_Login.currentUserId).Collection("cart").Document(book.BookId);

            // Add the selected book to the 'cart' collection
            Dictionary<string, object> dict = new Dictionary<string, object>()
            {
                { "Quantity", quantity },
                {"CustomerId", Form_Login.currentUserId },
                {"TotalPrice", book.SellingPrice*quantity },
                {"BookId",book.BookId },
                {"Price", book.SellingPrice }
            };

            await cartRef.SetAsync(dict, SetOptions.Overwrite);

        }

        private async void btnMinus_Click(object sender, EventArgs e)
        {

            int quantity = int.Parse(lblBookQuantity.Text);
            var db = FirebaseHelper.Database;
            DocumentReference cartRef = db.Collection("Cart").Document(Form_Login.currentUserId).Collection("cart").Document(bookId);

            DocumentSnapshot docCart = await cartRef.GetSnapshotAsync();

            
                if (quantity - 1 > 0)
                {
                    quantity--;
                    
                  
                    lblBookQuantity.Text = quantity.ToString();
                }
                else
                {
                    MessageBox.Show("The book amount can not be 0!");
                }
            
        }

        private async void btnPlus_Click(object sender, EventArgs e)
        {
            int quantity = int.Parse(lblBookQuantity.Text);
            var db = FirebaseHelper.Database;
            DocumentReference cartRef = db.Collection("Cart").Document(Form_Login.currentUserId).Collection("cart").Document(bookId);
            DocumentReference bookRef = db.Collection("Book").Document(bookId);
            DocumentSnapshot docCart = await cartRef.GetSnapshotAsync();
            DocumentSnapshot docBook = await bookRef.GetSnapshotAsync();
            if (docBook.Exists)
            {
                
                Book book = docBook.ConvertTo<Book>();
                if (quantity + 1 <= book.Quantity)
                {
                    quantity++;
                    
                   
                    lblBookQuantity.Text = quantity.ToString();
                }
                else
                {
                    MessageBox.Show("The book amount in the store not enough for your order!");
                }
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblBookQuantity_Click(object sender, EventArgs e)
        {

        }
    }
}
