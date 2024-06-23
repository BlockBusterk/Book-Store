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
using BookShopManagement.Database;
using BookShopManagement.Models;
using Google.Cloud.Firestore;
using BookShopManagement.Utils;

namespace BookShopManagement.UserControls
{
    public partial class UC_Customer : UserControl
    {
        public UC_Customer()
        {
            InitializeComponent();
            btnAddNewBooks.Visible = false;
        }

        private void btnAddNewBooks_Click(object sender, EventArgs e)
        {
            using (Form_AddNewBook abn = new Form_AddNewBook())
            {
                abn.ShowDialog();
            }
        }
        private async void LoadUsers()
        {
            dataGridView1.Rows.Clear();
            var db = FirebaseHelper.Database;
            Query userQue = db.Collection("UserData");
            QuerySnapshot snap = await userQue.GetSnapshotAsync();
            foreach (DocumentSnapshot doc in snap)
            {
                if (doc.Exists)
                {
                    UserData user = doc.ConvertTo<UserData>();
                    if (user.Email == "admin@gmail.com")
                        continue;
                    user.UserId = doc.Id;
                    dataGridView1.Rows.Add(
                    user.UserId,
                    user.Name,
                    user.Email,
                    user.Phone,
                    user.Address,
                    VietNameTime.ConvertToVietnamTime(user.CreatedDate)
                    );
                }
            }

        }

        private async void textBox7_TextChanged(object sender, EventArgs e)
        {
            string keyword = textBox7.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                LoadUsers();
                return;
            }

            var db = FirebaseHelper.Database;
            CollectionReference usersRef = db.Collection("UserData");
            Query emailQuery = usersRef.WhereLessThanOrEqualTo("Email", keyword + '\uf8ff');
            Query nameQuery = usersRef.WhereLessThanOrEqualTo("Name", keyword + '\uf8ff');
            Query addressQuery = usersRef.WhereLessThanOrEqualTo("Address", keyword + '\uf8ff');

            // Get results from all three queries
            QuerySnapshot emailSnapshot = await emailQuery.GetSnapshotAsync();
            QuerySnapshot nameSnapshot = await nameQuery.GetSnapshotAsync();
            QuerySnapshot addressSnapshot = await addressQuery.GetSnapshotAsync();

            //Combine results into a single list, removing duplicates
            List<UserData> users = new List<UserData>();
            users.AddRange(emailSnapshot.Documents.Select(doc =>
            {
                UserData user = doc.ConvertTo<UserData>();
                user.UserId = doc.Id;  // Lấy ID của tài liệu và gán cho BookId
                return user;
            }));

            users.AddRange(nameSnapshot.Documents.Select(doc =>
            {
                UserData user = doc.ConvertTo<UserData>();
                user.UserId = doc.Id;  // Lấy ID của tài liệu và gán cho BookId
                return user;
            }));
            users.AddRange(addressSnapshot.Documents.Select(doc =>
            {
                UserData user = doc.ConvertTo<UserData>();
                user.UserId = doc.Id;  // Lấy ID của tài liệu và gán cho BookId
                return user;
            })); 


            dataGridView1.Rows.Clear();
            // Loại bỏ các bản sao dựa trên BookId
            users = users.GroupBy(u => u.UserId).Select(g => g.First()).ToList();

            users = users.Where(u => u.Email.ToLower().Contains(keyword)   ||
                                     u.Name.ToLower().Contains(keyword) ||
                                     u.Address.ToLower().Contains(keyword) ).ToList();
            foreach (UserData user in users)
            {
                if (user.Email == "admin@gmail.com")
                    continue;
                dataGridView1.Rows.Add(
                    user.UserId,
                    user.Name,
                    user.Email,
                    user.Phone,
                    user.Address,
                    VietNameTime.ConvertToVietnamTime(user.CreatedDate)   
                  );
            }
        }

        private void UC_Customer_Load(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
