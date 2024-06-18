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
                Query historyQue = db.Collection("Order").WhereEqualTo("CustomerEmail", Form_Login.currentUserEmail);
                QuerySnapshot snap = await historyQue.GetSnapshotAsync();

                totalOrders = snap.Count; // Số lượng đơn hàng

                // Tính toán số trang dựa trên số lượng đơn hàng và số dòng trên mỗi trang
                int totalPages = (int)Math.Ceiling((double)totalOrders / pageSize);

                // Kiểm tra và cập nhật trang hiện tại nếu nó vượt quá tổng số trang
                if (currentPage > totalPages)
                {
                    currentPage = totalPages;
                }

                // Tính toán chỉ số bắt đầu và kết thúc của dữ liệu cần hiển thị cho trang hiện tại
                int startIndex = (currentPage - 1) * pageSize;
                int endIndex = Math.Min(startIndex + pageSize - 1, totalOrders - 1);

                // Xóa dữ liệu hiện tại của DataGridView
                dataGridView1.Rows.Clear();

                // Lặp qua từng đơn hàng trong phạm vi trang hiện tại
                for (int i = startIndex; i <= endIndex; i++)
                {
                    DocumentSnapshot doc = snap.Documents[i];
                    if (doc.Exists)
                    {
                        Order order = doc.ConvertTo<Order>();
                        List<Book> books = order.Books;
                        string date = VietNameTime.ConvertToVietnamTime(order.CreatedDate);

                        // Thêm từng sách của đơn hàng vào DataGridView
                        foreach (Book book in books)
                        {
                            dataGridView1.Rows.Add(book.BookTitle, book.Author, book.Publisher, book.Quantity.ToString(), (book.SellingPrice * book.Quantity).ToString(), date);
                        }
                    }
                }

                // Cập nhật lại thông tin về trang và tổng số trang (nếu cần)
                lblCurrentPage.Text = currentPage.ToString();
                lblTotalPages.Text = totalPages.ToString();
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
