using BookShopManagement.Database;
using BookShopManagement.Models;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShopManagement.Forms_Auth
{
    public partial class Form_Password_Recovery : Form
    {
        public static UserData currentUser { get; set; }
        public Form_Password_Recovery()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose(); 
        }

        private async void btnRecover_Click(object sender, EventArgs e)
        {
            try
            {
                // Sign up
                var db = FirebaseHelper.Database;
                string email = txbEmail.Text.Trim();
               
                if ( email == "" )
                {
                    MessageBox.Show("Field cannot be empty!");
                    return;
                }


                // var auth = FirebaseAuth.DefaultInstance;

                Query queryRef = db.Collection("UserData").WhereEqualTo("Email", email);
                QuerySnapshot snap = await queryRef.GetSnapshotAsync();
                foreach ( DocumentSnapshot doc in snap.Documents )
                {
                    if (doc.Exists)
                    {
                        await FirebaseHelper.FirebaseAuth.ResetEmailPasswordAsync(email);
                        MessageBox.Show("An email has been sent to reset your password. Please check your mailbox!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                      
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Email has not been registered yet!");
                        return;
                    }
                }
                this.Dispose();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }
    }
}
