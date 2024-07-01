using BookShopManagement.Models;
using BookShopManagement.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShopManagement.Chat_UI
{
    public partial class UC_UserListItem : UserControl
    {
        public UC_UserListItem()
        {
            InitializeComponent();
        }

        public UC_Chat_Admin uC_Chat_Admin { get; set; }

        public UserData user { get; set; }
        public void setProp(string name, string imageUrl, string mess, string timeDisplay, string messCount)
        {
            lbName.Text = name;
            if (imageUrl != null && imageUrl != "")
            {
                pictureBoxAvatar.ImageLocation = imageUrl;
            }
            lbLastMessage.Text = mess;
            lbTime.Text = timeDisplay;
            lbNumberMessage.Text = messCount;
        }

        private void itemPanel_Click(object sender, EventArgs e)
        {
            UC_Chat_Admin.currentChatUser = user;

            uC_Chat_Admin.SearchMessages();
            uC_Chat_Admin.setCurrentUserChat(user.ImageUrl, user.Name);
        }

    }
}
