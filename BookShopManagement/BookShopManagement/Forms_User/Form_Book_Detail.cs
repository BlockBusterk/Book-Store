﻿using BookShopManagement.Database;
using BookShopManagement.Models;
using BookShopManagement.UserControls;
using BookShopManagement.Utils;
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
using static Google.Cloud.Firestore.V1.StructuredAggregationQuery.Types.Aggregation.Types;

namespace BookShopManagement.Forms_User
{
    public partial class Form_Book_Detail : Form
    {
        private string bookId = string.Empty;
        private double sum = 0;
        private int total = 0;
        public void setBookId(string id)
        {
            this.bookId = id;
        }
       
        public Form_Book_Detail()
        {
            InitializeComponent();
        }

        private void Comment_Click(object sender, EventArgs e)
        {
            Form_Comment_User np = new Form_Comment_User();
            np.BookId= bookId;
            if (np.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Add comment successfully");
                Load_Comment();
            }
        }

        private async void Form_Book_Detail_Load(object sender, EventArgs e)
        {
           Load_Book_Detail();
            Load_Comment();
        }
        private async void Load_Book_Detail()
        {
            var db = FirebaseHelper.Database;
            
            DocumentReference bookRef = db.Collection("Cart").Document(Form_Login.currentUserId).Collection("cart").Document(bookId);
            DocumentSnapshot doc = await bookRef.GetSnapshotAsync();
            DocumentReference categoryRef = db.Collection("Book").Document(bookId);
            DocumentSnapshot categorySnap = await categoryRef.GetSnapshotAsync();
            if (doc.Exists && categorySnap.Exists)
            {
                Cart cart = doc.ConvertTo<Cart>();
                Book book = categorySnap.ConvertTo<Book>();
                lblBookAuthor.Text = cart.Author;
                lblBookQuantity.Text = cart.Quantity.ToString();
                lblBookTitle.Text = cart.BookTitle;
                lblCategory.Text = book.Category;
            }
        }

        private async void Load_Comment()
        {
            var db = FirebaseHelper.Database;
            Query cartQue = db.Collection("Comment").Document(bookId).Collection("UserInfo");
            QuerySnapshot snap = await cartQue.GetSnapshotAsync();
            foreach (DocumentSnapshot doc in snap)
            {

                if (doc.Exists)
                {
                    Comment comment = doc.ConvertTo<Comment>();
                    UC_UserComment userControl = new UC_UserComment();
                    userControl.UserName = comment.UserName;
                    userControl.Comment = comment.UserComment;
                    userControl.Score = comment.UserScore;
                    userControl.ImageUrl = comment.ImageUrl;
                    userControl.Date = VietNameTime.ConvertToVietnamTime(comment.CreatedDate);
                    flowLayoutPanel1.Controls.Add(userControl);
                    flowLayoutPanel1.ScrollControlIntoView(userControl);
                    sum += userControl.Score;
                    total++;
                }
            }
            lblScore.Text = Math.Round((total == 0 ? 0 : sum / total), 2).ToString();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
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
                if (quantity + 1<= book.Quantity)
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