using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookShopManagement.Database;
using Google.Cloud.Firestore;
using BookShopManagement.Models;

namespace BookShopManagement.UserControls
{
    public partial class UC_Home : UserControl
    {
        public UC_Home()
        {
            InitializeComponent();
        }
        Random rand = new Random();

        private void LoadChart()
        {
          

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadChart();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void UC_Home_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private async void LoadData()
        {
            var db = FirebaseHelper.Database;
            double totalRevenue = 0;
            int totalSoldBook = 0;
            CollectionReference collectionUser = db.Collection("UserData");

            // Get all documents in the collection
            QuerySnapshot snapshotUser = await collectionUser.GetSnapshotAsync();

            // Count the number of documents
            
            label7.Text= (snapshotUser.Count - 1).ToString(); //So luong user

            Query queryBook = db.Collection("Order");
            QuerySnapshot snapBook = await queryBook.GetSnapshotAsync();
            foreach(DocumentSnapshot snap in snapBook )
            {
                if(snap.Exists)
                {
                    Order order = snap.ConvertTo<Order>();
                    totalSoldBook += order.Quantity;
                }
            }
            label4.Text= totalSoldBook.ToString(); // So luong sach ban ra

            Query queryRevenue = db.Collection("Order");
            QuerySnapshot snapRevenue = await queryRevenue.GetSnapshotAsync();
            foreach (DocumentSnapshot snap in snapRevenue)
            {
                if (snap.Exists)
                {
                    Order order = snap.ConvertTo<Order>();
                    totalRevenue += order.TotalPrice;
                }
            }
            label5.Text = totalSoldBook.ToString(); // Tong doanh thu

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
