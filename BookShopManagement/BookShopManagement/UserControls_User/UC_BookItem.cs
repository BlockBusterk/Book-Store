using BookShopManagement.Forms_User;
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
    public partial class UC_BookItem : UserControl
    {
        public UC_BookItem()
        {
            InitializeComponent();
        }
        private int quantity = 0;
        private double price = 0;
        private string bookId = "";
        private string bookName = "";
        private string imageUrl = "";
        public string BookId { get => bookId; set { bookId = value; } }
        public string BookName { get => bookName ; set { bookName = value; lblName.Text = value; } }
        public int Quantity { get => quantity; set { quantity = value; lblQuantity.Text = value.ToString(); } }
        public double Price { get => price; set { price = value; lblPrice.Text = value.ToString(); } }
        public string ImageUrl { get => imageUrl; set { imageUrl = value; ptbImage.Load(value); } }
        private void lblDetail_Click(object sender, EventArgs e)
        {
            
            using (Form_Book_Detail_With_Btn fbd = new Form_Book_Detail_With_Btn())
            {
                fbd.setBookId(bookId);
                fbd.ShowDialog();
            }
        }

        private void lblQuantity_Click(object sender, EventArgs e)
        {

        }

        private void UC_BookItem_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.LightGray; // Change to the color you prefer
            foreach (Control control in this.Controls)
            {
                control.BackColor = Color.LightGray;
            }
        }

        private void UC_BookItem_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.White; // Change to the original color
            foreach (Control control in this.Controls)
            {
                control.BackColor = Color.White;
            }
        }
    }
}
