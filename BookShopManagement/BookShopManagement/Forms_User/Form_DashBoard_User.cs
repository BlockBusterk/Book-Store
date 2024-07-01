using BookShopManagement.UserControls;
using BookShopManagement.UserControls_User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShopManagement.Forms_User
{
    public partial class Form_DashBoard_User : Form
    {
        public Form_DashBoard_User()
        {
            InitializeComponent();
        }

        private void Form_DashBoard_User_Load(object sender, EventArgs e)
        {
            UC_Books ucb = new UC_Books();
            AddControlsToPanel(ucb);
        }

        private void btnSaleBooks_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnSaleBooks);
            UC_Books ucb = new UC_Books();
            AddControlsToPanel(ucb);

        }
        private void AddControlsToPanel(Control c)
        {
            c.Dock = DockStyle.Fill;
            panelControls.Controls.Clear();
            panelControls.Controls.Add(c);
        }
        private void timerTime_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            //labelTime.Text = dt.ToString("HH:MM:ss");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            moveSidePanel(button1);
            UC_Cart ucc = new UC_Cart();
            AddControlsToPanel(ucc);
        }
        private void moveSidePanel(Control btn)
        {
            panelSide.Top = btn.Top;
            panelSide.Height = btn.Height;
        }
      

        private void btnHistory_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnHistory);
            UC_History uch = new UC_History();
            AddControlsToPanel(uch);
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnUser);
            UC_User ucb = new UC_User();
            AddControlsToPanel(ucb);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Handle the "Yes" button click
                // Do something here
                this.Dispose();
            }
            else
            {
                // Handle the "No" button click
                // Do something else here
            }
        
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnChat);
            UC_Chat_User ucb = new UC_Chat_User();
            AddControlsToPanel(ucb);
        }
    }
}
