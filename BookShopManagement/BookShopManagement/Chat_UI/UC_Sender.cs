using BookShopManagement.Models;
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
    public partial class UC_Sender : UserControl
    {
        public UserData senderUser { get; set; }
        public void setProp(string imageUrl, string message, string time)
        {
            pictureBoxAvaSender.ImageLocation = imageUrl;
            richMessage.Text = message;
            lbTimeString.Text = time;
            // message.CreatedAt.ToShortTimeString()
            // .ToShortTimeString() + " " + message.CreatedAt.ToShortDateString()
        }

        public UC_Sender()
        {
            InitializeComponent();
        }
    }
}
