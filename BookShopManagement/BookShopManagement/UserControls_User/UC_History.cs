using BookShopManagement.Database;
using BookShopManagement.Models;
using BookShopManagement.Utils;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShopManagement.UserControls_User
{
    public partial class UC_History : UserControl
    {
        private int pageSize = 10;
        // Biến để lưu trữ trang hiện tại
        private int currentPage = 1;
        // Tổng số đơn hàng
        private int totalOrders = 0;
        public UC_History()
        {
            InitializeComponent();
        }

        private async void UC_History_Load(object sender, EventArgs e)
        {
           Load_History();
        }
        private async void Load_History()
        {
            try
            {
                var db = FirebaseHelper.Database;
                Query historyQue = db.Collection("Order").WhereEqualTo("CustomerId", Form_Login.currentUserId);
                QuerySnapshot historySnap = await historyQue.GetSnapshotAsync();
                List<Order> orders = new List<Order>();

                foreach (DocumentSnapshot doc in historySnap.Documents)
                {
                    if (doc.Exists)
                    {
                        Order order = doc.ConvertTo<Order>();
                       
                        foreach (Book book in order.Books)
                        {
                            DocumentReference bookRef = db.Collection("Book").Document(book.BookId);
                            DocumentSnapshot bookSnapshot = await bookRef.GetSnapshotAsync();
                            if(bookSnapshot.Exists)
                            {
                            Book bookInfo = bookSnapshot.ConvertTo<Book>();

                             dataGridView1.Rows.Add(
                             bookInfo.BookTitle,
                             bookInfo.Author,
                             bookInfo.Publisher,
                             book.Quantity.ToString(),
                             (book.Quantity * book.SellingPrice).ToString(),
                             VietNameTime.ConvertToVietnamTime(order.CreatedDate)
                               );
                            }
                           
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading history: " + ex.Message);
            }
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            currentPage++;
            Load_History();
        }

        private void btnPreviousPage_Click(object sender, EventArgs e)
        {
            currentPage--;
            Load_History();
        }
    }
}
