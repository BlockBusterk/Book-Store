using BookShopManagement.Database;
using BookShopManagement.Models;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShopManagement.UserControls_User
{
    public partial class UC_CartItem : UserControl
    {
        private int quantity = 0;
        private double price = 0;
        private double sellPrice = 0;  
        private string bookId = "";
        private string bookName = "";
        private string imageUrl = "";
        public string BookId { get => bookId; set { bookId = value; } }
        public string BookName { get => bookName; set { bookName = value; lblTitle.Text = value; } }
        public int Quantity { get => quantity; set { quantity = value; lblBookQuantity.Text = value.ToString(); } }
        public double Price { get => price; set { price = value; lblPrice.Text = value.ToString(); } }
        public double SellPrice { get => sellPrice; set { sellPrice = value; lblSellPrice.Text = value.ToString(); } }
        public string ImageUrl { get => imageUrl; set { imageUrl = value; pictureBox1.Load(value); } }
        public UC_CartItem()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var db = FirebaseHelper.Database;
            DocumentReference bookRef = db.Collection("Cart").Document(Form_Login.currentUserId).Collection("cart").Document(BookId);

            //Xóa dữ book khỏi cart
            await bookRef.DeleteAsync();

            Control current = this.Parent;

            //load Cart từ control cha

            while (current != null)
            {
                if (current is UC_Cart ucCart)
                {
                    ucCart.LoadCart();
                    return; // Found UC_Cart, exit the method
                }
                current = current.Parent;
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
            if (docCart.Exists && docBook.Exists)
            {
                Cart cart = docCart.ConvertTo<Cart>();
                Book book = docBook.ConvertTo<Book>();
                if (quantity + 1 <= book.Quantity)
                {
                    quantity++;
                    cart.Quantity = quantity;
                    Dictionary<string, object> data = new Dictionary<string, object>() {
                        {"Quantity", cart.Quantity}
                    };
                    await cartRef.UpdateAsync(data);
                    lblBookQuantity.Text = cart.Quantity.ToString();
                }
                else
                {
                    MessageBox.Show("The book amount in the store not enough for your order!");
                }
            }
        }

        private async void btnMinus_Click(object sender, EventArgs e)
        {
            int quantity = int.Parse(lblBookQuantity.Text);
            var db = FirebaseHelper.Database;
            DocumentReference cartRef = db.Collection("Cart").Document(Form_Login.currentUserId).Collection("cart").Document(bookId);

            DocumentSnapshot docCart = await cartRef.GetSnapshotAsync();

            if (docCart.Exists)
            {
                Cart cart = docCart.ConvertTo<Cart>();

                if (quantity - 1 > 0)
                {
                    quantity--;
                    cart.Quantity = quantity;
                    Dictionary<string, object> data = new Dictionary<string, object>() {
                        {"Quantity", cart.Quantity}
                    };
                    await cartRef.UpdateAsync(data);
                    lblBookQuantity.Text = cart.Quantity.ToString();
                }
                else
                {
                    MessageBox.Show("The book amount can not be 0!");
                }
            }
        }
    }
}
