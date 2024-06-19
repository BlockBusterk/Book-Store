using BookShopManagement.Database;
using BookShopManagement.Models;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BookShopManagement.Forms
{
    public partial class Form_AddNewBook : Form
    {
        public Form_AddNewBook()
        {
            InitializeComponent();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Form_AddNewBook_Load(object sender, EventArgs e)
        {
            LoadCategory();
        }

        private async void LoadCategory()
        {
            try
            {
                List<Category> categories = new List<Category>();
                var db = FirebaseHelper.Database;
                Query qRef = db.Collection("Category");
                QuerySnapshot snap = await qRef.GetSnapshotAsync();

                foreach (DocumentSnapshot docsnap in snap)
                {
                    Category category = docsnap.ConvertTo<Category>();
                    if (docsnap.Exists)
                    {
                        categories.Add(category);
                    }
                }

                cbCategory.DataSource = categories;
                cbCategory.DisplayMember = "Name";
                cbCategory.ValueMember = "Name";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Add new category
            using (Form_AddCategory ac = new Form_AddCategory())
            {
                ac.ShowDialog();
                LoadCategory();
            }
        }


        private async void btnAddNewBook_Click(object sender, EventArgs e)
        {
            // Add new book
            try
            {
                var db = FirebaseHelper.Database;

                int quantity = 0 ;
                int sellingPrice = 0;
                int costPrice = 0;

                string bookTitle = txbBookTitle.Text.Trim();
                string author = txbAuthor.Text.Trim();
                string publisher = txbPublisher.Text.Trim();
              ;
                string imageUrl = CloudinaryHelper.UploadImage(picImage.ImageLocation);

                if (bookTitle == ""
                   || author == ""
                   || publisher == ""
                   || txbQuantity.Text.Trim() == ""
                   || txbSellingPrice.Text.Trim() == ""
                   || txbCostPrice.Text.Trim() == ""
                   || imageUrl == ""
                   )
                {
                    MessageBox.Show("Field cannot be empty!");
                    return;
                }

                if (!int.TryParse(txbQuantity.Text.Trim(), out quantity) 
                    || !int.TryParse(txbSellingPrice.Text.Trim(), out sellingPrice)
                    || !int.TryParse(txbCostPrice.Text.Trim(), out costPrice)
                    )
                {
                    MessageBox.Show("Quantity, Selling Price or Cost Price must be a number!");
                    return;
                }

                DocumentReference docRef = db.Collection("Book").Document();
                string randomBookId = docRef.Id;
                var data = new Book()
                {
                    BookId = randomBookId,
                    Author = author,
                    BookTitle = bookTitle,
                    CostPrice = costPrice,
                    Publisher = publisher,
                    Quantity = quantity,
                    SellingPrice = sellingPrice,
                    Category = cbCategory.SelectedItem.ToString(),
                    ImageUrl = imageUrl,
                };

                //CollectionReference colref = db.Collection("Book");
                //await colref.SetAsync(data);
                await docRef.SetAsync(data);
                MessageBox.Show("Book created success");

                this.Dispose();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Book created failed");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Clear
            txbBookTitle.Text = "";
            txbAuthor.Text = "";
            txbPublisher.Text = "";
            txbQuantity.Text = "";
            txbSellingPrice.Text = "";
            txbCostPrice.Text = "";
        }

        private void picImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                picImage.ImageLocation = openFileDialog.FileName;
            }
        }
    }
}
