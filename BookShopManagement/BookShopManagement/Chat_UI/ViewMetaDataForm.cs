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
    public partial class ViewMetaDataForm : Form
    {
        public ViewMetaDataForm()
        {
            InitializeComponent();
        }
        public void setPic(string pic)
        {
            pictureBoxView.ImageLocation = pic;
        }
    }
}
