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

            LoadBookList();
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
                        book.Barcode
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

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
