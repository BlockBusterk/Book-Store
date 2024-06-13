using BookShopManagement.Forms_User;
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
    public partial class UC_Detail_User : UserControl
    {
        public UC_Detail_User()
        {
            InitializeComponent();
        }

        private void Comment_Click(object sender, EventArgs e)
        {
            Form_Comment_User np = new Form_Comment_User();
            if (np.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Add comment successfully");
                LoadComment();
            }
        }
        
        private void LoadComment()
        {

        }
    }
}
