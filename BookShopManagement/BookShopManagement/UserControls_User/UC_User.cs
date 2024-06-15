using BookShopManagement.Database;
using BookShopManagement.Forms;
using BookShopManagement.Forms_Auth;
using BookShopManagement.Models;
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

namespace BookShopManagement.UserControls_User
{
    public partial class UC_User : UserControl
    {
        private string avatarUrl = "";
        private string selectedFilePath;
        public UC_User()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedFilePath = openFileDialog.FileName;
                pictureBox1.Image = Image.FromFile(selectedFilePath);
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            //Update user data
            try
            {
                // Sign up
                var db = FirebaseHelper.Database;
                string name = txtName.Text.Trim();
                string phone = txtPhone.Text.Trim();
                string address = txtAddress.Text.Trim();
                if (name == "")
                {
                    MessageBox.Show("Field name cannot be empty!");
                    return;
                }


                // var auth = FirebaseAuth.DefaultInstance;

                DocumentReference docRef = db.Collection("UserData").Document(Form_Login.currentUserId);
                DocumentSnapshot snap = await docRef.GetSnapshotAsync();
                
                    if (snap.Exists)
                    {

                    avatarUrl = CloudinaryHelper.UploadImage(selectedFilePath);
                    Dictionary<string, object> data = new Dictionary<string, object>() {
                        {"Name", name },
                        { "Address", address},
                        { "Phone", phone},
                        {"ImageUrl", avatarUrl }
                        
                    };
                        await docRef.UpdateAsync(data);


                        MessageBox.Show("Updated successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        return;
                }
                    else
                    {
                        MessageBox.Show("Email has not been registered yet!");
                        return;
                    }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            using (Form_Change_Password fcp = new Form_Change_Password())
            {
                fcp.ShowDialog();
                
            }
        }

        private void UC_User_Load(object sender, EventArgs e)
        {
            LoadUserData();
        }
        private void LoadUserData()
        {
            var db = FirebaseHelper.Database;
            DocumentReference docRef = db.Collection("UserData").Document(Form_Login.currentUserId);
            UserData user = docRef.GetSnapshotAsync().Result.ConvertTo<UserData>();
            txtName.Text = user.Name;
            txtEmail.Text = user.Email;
            txtAddress.Text = user.Address;
            txtPhone.Text= user.Phone;
            if (user.ImageUrl != string.Empty && user.ImageUrl != null)
            {
                avatarUrl = user.ImageUrl;
                pictureBox1.Load(avatarUrl);
            }
             
           
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ngăn chặn ký tự không hợp lệ
            }
        }
    }
}
