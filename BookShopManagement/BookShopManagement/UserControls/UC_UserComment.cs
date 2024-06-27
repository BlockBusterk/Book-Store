using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShopManagement.UserControls
{
    public partial class UC_UserComment : UserControl
    {
        private int score = 0;
        private string comment = "";
        private string userName = "";
        private string date = "";
        private string imageUrl = "";
        public string UserName { get => userName; set { userName = value; lblUserName.Text = value; } }
        public int Score { get => score; set { score = value; lblScore.Text = value.ToString(); } }
        public string Comment { get => comment; set { comment = value; lblUserComment.Text = value; } }
        public string Date { get => date; set { date = value; lblDate.Text = value; } }
        public string ImageUrl { get => imageUrl; set { imageUrl = value;  imgUserAvatar.Load(value); } }
        public UC_UserComment()
        {
            InitializeComponent();
        }

        private void imgUserAvatar_Click(object sender, EventArgs e)
        {

        }
    }
}
