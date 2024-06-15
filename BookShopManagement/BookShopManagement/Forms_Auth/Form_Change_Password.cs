using BookShopManagement.Database;
using BookShopManagement.Utils;
using FirebaseAdmin.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Bunifu.UI.WinForms.Helpers.Transitions.Transition;
using static Google.Rpc.Context.AttributeContext.Types;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;


namespace BookShopManagement.Forms_Auth
{
    public partial class Form_Change_Password : Form
    {
        private FirebaseAuth auth;
        public Form_Change_Password()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Clear info
            txbNewPassword.Text= string.Empty;
            txt_ConfirmNewPass.Text= string.Empty;
        }

        private async void btnAddNewBook_Click(object sender, EventArgs e)
        {

            // Kiểm tra độ dài mật khẩu
            if (txbNewPassword.Text.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters long.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra xác nhận mật khẩu
            if (txbNewPassword.Text != txt_ConfirmNewPass.Text)
            {
                MessageBox.Show("Passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //update new pass
            string newPassword = txbNewPassword.Text;


            if (Form_Login.currentUserId != null)
            {
                try
                {
                    // Cập nhật mật khẩu mới cho người dùng
                    UserRecordArgs args = new UserRecordArgs()
                    {
                        Uid = Form_Login.currentUserId,
                        Password = newPassword
                    };

                    UserRecord userRecord = await FirebaseAuth.DefaultInstance.UpdateUserAsync(args);
                    MessageBox.Show("Password updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Dispose();
                }
                catch (FirebaseAuthException ex)
                {
                    MessageBox.Show($"Error updating password: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("User not logged in.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form_Change_Password_Load(object sender, EventArgs e)
        {

        }
    }
}
