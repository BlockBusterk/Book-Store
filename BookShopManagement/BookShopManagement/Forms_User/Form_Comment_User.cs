using BookShopManagement.Database;
using BookShopManagement.Models;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Google.Rpc.Context.AttributeContext.Types;

namespace BookShopManagement.Forms_User
{
    public partial class Form_Comment_User : Form
    {
        public Form_Comment_User()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
        }
        int MaxCharacters = 170;
        int score = 0;
        public string BookId { get; set; } = string.Empty;
        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Length > MaxCharacters)
            {
                // Cắt bớt phần dư thừa
                richTextBox1.Text = richTextBox1.Text.Substring(0, MaxCharacters);
                // Đặt lại vị trí con trỏ để tránh lỗi con trỏ bị di chuyển sai
                richTextBox1.SelectionStart = MaxCharacters;
                // Hiển thị thông báo
                MessageBox.Show("Can comment maximum of " + MaxCharacters + " characters.");
            }
            else
            {
                // Xóa thông báo khi số ký tự hợp lệ
               
            }
        }

        
        private void ResetStar()
        {
            starBtn1.Image = Image.FromFile("E:\\Year4HK2\\C#\\ThucHanh2\\2849817_favorite_star_favorites_favourite_multimedia_icon.png");
            starBtn2.Image = Image.FromFile("E:\\Year4HK2\\C#\\ThucHanh2\\2849817_favorite_star_favorites_favourite_multimedia_icon.png");
            starBtn3.Image = Image.FromFile("E:\\Year4HK2\\C#\\ThucHanh2\\2849817_favorite_star_favorites_favourite_multimedia_icon.png");
            starBtn4.Image = Image.FromFile("E:\\Year4HK2\\C#\\ThucHanh2\\2849817_favorite_star_favorites_favourite_multimedia_icon.png");
            starBtn5.Image = Image.FromFile("E:\\Year4HK2\\C#\\ThucHanh2\\2849817_favorite_star_favorites_favourite_multimedia_icon.png");

        }

        


        private async void btnSend_Click(object sender, EventArgs e)
        {
            if (score == 0)
            {
                MessageBox.Show("Please give us a score at least");
                return;
            }
            try
            {
                var db = FirebaseHelper.Database;
                DocumentReference comRef = db.Collection("Comment").Document(BookId).Collection("UserInfo").Document(Form_Login.currentUserId);

                var data = new Comment()
                {
                    UserName = Form_Login.currentUserName,
                    UserComment = richTextBox1.Text,
                    ImageUrl = Form_Login.currentUser.ImageUrl,
                    UserScore = score,
                };

                await comRef.SetAsync(data, SetOptions.Overwrite);
                this.DialogResult = DialogResult.OK;
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void starBtn5_Click_1(object sender, EventArgs e)
        {
            ResetStar();
            score = 5;
            starBtn1.Image = Image.FromFile("E:\\Year4HK2\\C#\\ThucHanh2\\285661_star_icon.png");
            starBtn2.Image = Image.FromFile("E:\\Year4HK2\\C#\\ThucHanh2\\285661_star_icon.png");
            starBtn3.Image = Image.FromFile("E:\\Year4HK2\\C#\\ThucHanh2\\285661_star_icon.png");
            starBtn4.Image = Image.FromFile("E:\\Year4HK2\\C#\\ThucHanh2\\285661_star_icon.png");
            starBtn5.Image = Image.FromFile("E:\\Year4HK2\\C#\\ThucHanh2\\285661_star_icon.png");
        }

        private void starBtn4_Click_1(object sender, EventArgs e)
        {
            ResetStar();
            score = 4;
            starBtn1.Image = Image.FromFile("E:\\Year4HK2\\C#\\ThucHanh2\\285661_star_icon.png");
            starBtn2.Image = Image.FromFile("E:\\Year4HK2\\C#\\ThucHanh2\\285661_star_icon.png");
            starBtn3.Image = Image.FromFile("E:\\Year4HK2\\C#\\ThucHanh2\\285661_star_icon.png");
            starBtn4.Image = Image.FromFile("E:\\Year4HK2\\C#\\ThucHanh2\\285661_star_icon.png");
        }

        private void starBtn3_Click_1(object sender, EventArgs e)
        {

            ResetStar();
            score = 3;
            starBtn1.Image = Image.FromFile("E:\\Year4HK2\\C#\\ThucHanh2\\285661_star_icon.png");
            starBtn2.Image = Image.FromFile("E:\\Year4HK2\\C#\\ThucHanh2\\285661_star_icon.png");
            starBtn3.Image = Image.FromFile("E:\\Year4HK2\\C#\\ThucHanh2\\285661_star_icon.png");
        }

        private void starBtn2_Click_1(object sender, EventArgs e)
        {
            ResetStar();
            score = 2;
            starBtn1.Image = Image.FromFile("E:\\Year4HK2\\C#\\ThucHanh2\\285661_star_icon.png");
            starBtn2.Image = Image.FromFile("E:\\Year4HK2\\C#\\ThucHanh2\\285661_star_icon.png");
        }

        private void starBtn1_Click_1(object sender, EventArgs e)
        {
            ResetStar();
            score = 1;
            starBtn1.Image = Image.FromFile("E:\\Year4HK2\\C#\\ThucHanh2\\285661_star_icon.png");
        }
    }
}
