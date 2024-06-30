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
    public partial class UC_ReceiverMetaData : UserControl
    {
        public UC_ReceiverMetaData()
        {
            InitializeComponent();
        }

        public void setProp(string imageUrl, string metadataurl, string time)
        {
            pictureBoxAvaSender.ImageLocation = imageUrl;
            pictureBoxView.ImageLocation = metadataurl;
            lbTimeString.Text = time;
        }

        private void pictureBoxView_Click(object sender, EventArgs e)
        {
            ViewMetaDataForm form = new ViewMetaDataForm();
            form.setPic(pictureBoxView.ImageLocation);
            form.ShowDialog();
        }
    }
}
