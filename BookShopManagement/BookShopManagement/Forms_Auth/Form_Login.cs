using BookShopManagement.Database;
using BookShopManagement.Forms;
using BookShopManagement.Forms_Auth;
using BookShopManagement.Forms_User;
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

namespace BookShopManagement
{
    public partial class Form_Login : Form
    {
        public static UserData currentUser { get; set; }
        public static string currentUserId { get; set; }
        public Form_Login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            // Login
            try
            {
                var db = FirebaseHelper.Database;
                string email = txbEmail.Text.Trim();
                string password = txbPassword.Text;

                if (password == "" || email == "")
                {
                    MessageBox.Show("Field cannot be empty!");
                    return;
                }

                var userCredentials = await FirebaseHelper.FirebaseAuth.SignInWithEmailAndPasswordAsync(email, password);
                var Id = userCredentials is null ? null : userCredentials.User.Uid;
                DocumentReference docRef = db.Collection("UserData").Document(Id);
                currentUser = docRef.GetSnapshotAsync().Result.ConvertTo<UserData>();
                currentUserId = Id;

                if (currentUser.Email == "admin@gmail.com")
                {
                    using (Form_Dashboard fd = new Form_Dashboard())
                    {
                        fd.ShowDialog();
                    }
                }
                else
                {
                    using (Form_DashBoard_User fd = new Form_DashBoard_User())
                    {
                        fd.ShowDialog();
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Wrong email or password");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Sign up
            using (Form_Sign_Up fsu = new Form_Sign_Up())
            {
                fsu.ShowDialog();
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            using (Form_Password_Recovery fpr = new Form_Password_Recovery())
            {
                fpr.ShowDialog();
            }
        }
    }
}
