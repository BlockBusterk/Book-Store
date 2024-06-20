using BookShopManagement.Bill;
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
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Google.Rpc.Context.AttributeContext.Types;

namespace BookShopManagement.UserControls_User
{
    public partial class UC_Cart : UserControl
    {
        public UC_Cart()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UC_Cart_Load(object sender, EventArgs e)
        {
            LoadCart();
        }
        private async void LoadCart()
        {
            dataGridView1.Rows.Clear();
            var db = FirebaseHelper.Database;
            Query cartQue = db.Collection("Cart").Document(Form_Login.currentUserId).Collection("cart");
            QuerySnapshot snap = await cartQue.GetSnapshotAsync();
            foreach (DocumentSnapshot doc in snap)
            {

                if (doc.Exists)
                {
                    
                    Cart cart = doc.ConvertTo<Cart>();
                    DocumentReference bookRef = db.Collection("Book").Document(cart.BookId);
                    DocumentSnapshot bookSnap = await bookRef.GetSnapshotAsync();
                    if(bookSnap.Exists)
                    {
                        Book book = bookSnap.ConvertTo<Book>();
                        dataGridView1.Rows.Add(
                            cart.BookId, 
                            book.BookTitle, 
                            book.Author, 
                            book.Publisher, 
                            cart.Price, 
                            cart.Quantity.ToString(), 
                           (cart.Price * cart.Quantity).ToString());
                    }
                    
                }
            }
            label4.Text = CalculateTotalAmount().ToString();
        }

        private async void dataGridView1_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Remove"].Index && e.RowIndex >= 0)
            {
                // Lấy dữ liệu hàng được nhấn

                var bookid = dataGridView1.Rows[e.RowIndex].Cells["BookId"].Value.ToString();
                var db = FirebaseHelper.Database;
                DocumentReference bookRef = db.Collection("Cart").Document(Form_Login.currentUserId).Collection("cart").Document(bookid);
                
                //Xóa dữ book khỏi cart
                await bookRef.DeleteAsync();
                LoadCart();
            }
            if (e.ColumnIndex == dataGridView1.Columns["Detail"].Index && e.RowIndex >= 0)
            {
                var bookid = dataGridView1.Rows[e.RowIndex].Cells["BookId"].Value.ToString();
                using (Form_Book_Detail fbd = new Form_Book_Detail())
                {
                    fbd.setBookId(bookid);
                    fbd.ShowDialog();
                    LoadCart();
                }
            }
        }
        private async void DeleteFromCart(Cart cart)
        {

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            //Thêm vào Order và xóa khỏi cart
            var db = FirebaseHelper.Database;
            DocumentReference userCartRef = db.Collection("Cart").Document(Form_Login.currentUserId);
            CollectionReference userCartCollection = userCartRef.Collection("cart");
            QuerySnapshot cartSnapshot = await userCartCollection.GetSnapshotAsync();
            if(cartSnapshot.Documents.Count == 0)
            {
                MessageBox.Show("There are nothing in your cart yet!");
                return;
            }
            // check out
             using (Form_Bill fb = new Form_Bill()) // In hóa đơn
             {
                /* foreach (DocumentSnapshot doc in cartSnapshot.Documents)
                 {
                     await doc.Reference.DeleteAsync();
                 }*/
                fb.Total = label4.Text;
                fb.ShowDialog();
                foreach (DocumentSnapshot doc in cartSnapshot.Documents)
                {
                    if (doc.Exists)
                    {
                        Cart cart = doc.ConvertTo<Cart>();

                        // Xóa tài liệu trong cart
                        await doc.Reference.DeleteAsync();

                        // Cập nhật số lượng sách trong Book
                        DocumentReference bookRef = db.Collection("Book").Document(cart.BookId);
                        DocumentSnapshot bookSnapshot = await bookRef.GetSnapshotAsync();
                        if (bookSnapshot.Exists)
                        {
                            Book book = bookSnapshot.ConvertTo<Book>();
                            int newQuantity = book.Quantity - cart.Quantity;
                            if (newQuantity >= 0)
                            {
                                await bookRef.UpdateAsync("Quantity", newQuantity);
                            }
                            else
                            {
                                // Handle case where new quantity would be negative
                                MessageBox.Show($"Not enough stock for book: {book.BookTitle}");
                                return;
                            }
                        }
                    }
                   
                }
                var books = new List<Book>();
                foreach (DocumentSnapshot doc in cartSnapshot.Documents)
                {

                    if (doc.Exists)
                    {
                        Cart cart = doc.ConvertTo<Cart>();

                        books.Add(new Book
                        {
                            BookId = cart.BookId,
                            Quantity = cart.Quantity,
                            SellingPrice = cart.Price,
                        });
                    }
                }
                //Thêm vào collection
                var orderData = new Order()
                {
                    Books = books,
                    CustomerId = Form_Login.currentUserId,
                    TotalPrice = Double.Parse(label4.Text),
                    Quantity = books.Count
                };
                CollectionReference orderCollectionRef = db.Collection("Order");
                await orderCollectionRef.AddAsync(orderData);
                LoadCart();
             }
        }
        private double CalculateTotalAmount()
        {
            double totalAmount = 0;

            // Duyệt qua từng hàng trong DataGridView
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // Kiểm tra xem hàng không phải là hàng mới
                if (!row.IsNewRow)
                {
                    // Lấy giá trị của cột "Amount" trong hàng hiện tại
                    var cellValue = row.Cells["Column_TotalPrice"].Value;

                    // Kiểm tra giá trị không phải là null và có thể chuyển đổi thành số
                    if (cellValue != null && double.TryParse(cellValue.ToString(), out double amount))
                    {
                        totalAmount += amount;
                    }
                }
            }

            return totalAmount;
        }
    }
}
