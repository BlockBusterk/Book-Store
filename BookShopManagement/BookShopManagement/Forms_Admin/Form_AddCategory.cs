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

namespace BookShopManagement.Forms
{
    public partial class Form_AddCategory : Form
    {
        public Form_AddCategory()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            // Add category
            try
            {
                var db = FirebaseHelper.Database;
                string categoryName = txbCategoryName.Text.Trim();

                if (categoryName == "")
                {
                    MessageBox.Show("Field cannot be empty!");
                    return;
                }

                var data = new Category()
                {
                    Name = txbCategoryName.Text.Trim(),
                };

                CollectionReference colref = db.Collection("Category");
                await colref.AddAsync(data);
                MessageBox.Show("Category created success");

                this.Dispose();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Category created failed");
            }
        }
    }
}
