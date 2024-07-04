using BookShopManagement.Models;
using BookShopManagement.UserControls;
using Guna.UI2.WinForms;
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
    public partial class IconForm : Form
    {
        private string anxiousIconUrl = "https://res.cloudinary.com/db3qu4bzj/image/upload/v1720109515/mdacfhxn7ekf79hndopg.png";
        private string disapointedIconUrl = "https://res.cloudinary.com/db3qu4bzj/image/upload/v1720109516/wx1b441b17pzyvlxaks2.png";
        private string neutralIconUrl = "https://res.cloudinary.com/db3qu4bzj/image/upload/v1720109517/l227bova9tbawze2nq76.png";
        private string smilingIconUrl = "https://res.cloudinary.com/db3qu4bzj/image/upload/v1720109518/acffhh3tpaaxvddv7obh.png";

        public IconForm()
        {
            InitializeComponent();
            initIcon();
            initIcon2();
            initIcon3();
            initIcon4();
        }

        // Application.StartupPath + “/resources/myfilename.wav”;

        public UC_Chat_Admin uC_Chat_Admin { get; set; }
        public UC_Chat_User uC_Chat_User { get; set; }
        public void initIcon()
        {
            var pictureBox = new Guna2PictureBox();
            pictureBox.Size = new Size(50, 50);
            pictureBox.Load(anxiousIconUrl); pictureBox.ImageLocation = anxiousIconUrl;
            //pictureBox.ImageLocation = "D:\\repository\\BaiTap_CS\\TH01_ChapApp\\image\\anxious-face-with-sweat.png";
            pictureBox.Click += sendBtn_Click;
            iconLayout.Controls.Add(pictureBox);
        }

        public void initIcon2()
        {
            var pictureBox = new Guna2PictureBox();
            pictureBox.Size = new Size(50, 50);
            pictureBox.Load(disapointedIconUrl);

            pictureBox.ImageLocation = disapointedIconUrl;
            //pictureBox.ImageLocation = "D:\\repository\\BaiTap_CS\\TH01_ChapApp\\image\\disappointed-face.png";
            pictureBox.Click += sendBtn_Click;
            iconLayout.Controls.Add(pictureBox);
        }

        public void initIcon3()
        {
            var pictureBox = new Guna2PictureBox();
            pictureBox.Size = new Size(50, 50);
            pictureBox.Load(neutralIconUrl);
            pictureBox.ImageLocation = neutralIconUrl;

            // pictureBox.ImageLocation = "D:\\repository\\BaiTap_CS\\TH01_ChapApp\\image\\neutral-face.png";
            pictureBox.Click += sendBtn_Click;
            iconLayout.Controls.Add(pictureBox);

        }
        public void initIcon4()
        {
            var pictureBox = new Guna2PictureBox();
            pictureBox.Size = new Size(50, 50);
            pictureBox.Load(smilingIconUrl);
            pictureBox.ImageLocation = smilingIconUrl;

            //  pictureBox.ImageLocation = "D:\\repository\\BaiTap_CS\\TH01_ChapApp\\image\\slightly-smiling-face.png";
            pictureBox.Click += sendBtn_Click;
            iconLayout.Controls.Add(pictureBox);

        }
        private void sendBtn_Click(object sender, EventArgs e)
        {

            if (uC_Chat_Admin != null)
            {
                Guna2PictureBox pictureBox = (Guna2PictureBox)sender;
                MessageData message = new MessageData();
                message.SenderUserId = Form_Login.currentUser.Email;
                message.ReceiverUserId = UC_Chat_Admin.currentChatUser.Email;
                message.MessageId = "0";
                message.MessageText = pictureBox.ImageLocation;
                message.CreatedAt = DateTime.Now.ToString();
                message.MessageType = "METADATA";

                uC_Chat_Admin.CreateMessage(message);

                uC_Chat_Admin.refresh();
            }

            if (uC_Chat_User != null)
            {
                Guna2PictureBox pictureBox = (Guna2PictureBox)sender;
                MessageData message = new MessageData();
                message.SenderUserId = Form_Login.currentUser.Email;
                message.ReceiverUserId = UC_Chat_User.currentChatUser.Email;
                message.MessageId = "1";
                message.MessageText = pictureBox.ImageLocation;
                message.CreatedAt = DateTime.Now.ToString();
                message.MessageType = "METADATA";

                uC_Chat_User.CreateMessage(message);
            }

            this.Dispose();
        }
    }

}
