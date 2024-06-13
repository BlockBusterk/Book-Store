using BookShopManagement.Database;
using BookShopManagement.Forms;
using BookShopManagement.Forms_User;
using BookShopManagement.Models;
using Firebase.Auth;
using Firebase.Auth.Providers;
using FirebaseAdmin.Auth;
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
    public partial class Form_Sign_Up : Form
    {
        public Form_Sign_Up()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            try
            {
                // Sign up
                var db = FirebaseHelper.Database;
                string email = txbEmail.Text.Trim();
                string password = txbPassword.Text;
                string rePassword = txbRePassword.Text;

                if (password != rePassword)
                {
                    MessageBox.Show("Password and re enter password incorrect!");
                    return;
                }

                // var auth = FirebaseAuth.DefaultInstance;
                var userCredentials = await FirebaseHelper.FirebaseAuth.CreateUserWithEmailAndPasswordAsync(email, password);
                var Id = userCredentials is null ? null :  userCredentials.User.Uid;

                var data = new UserData() { Email = email, };

                DocumentReference docRef = db.Collection("UserData").Document(Id);
                await docRef.SetAsync(data);
                MessageBox.Show("Account created success");

                this.Dispose();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Email already exists");
            }
        }
    }
}
