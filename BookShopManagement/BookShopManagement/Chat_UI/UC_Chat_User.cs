using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookShopManagement.Database;
using Google.Cloud.Firestore;
using BookShopManagement.Models;
using System.Globalization;
using System.Windows.Forms.DataVisualization.Charting;

namespace BookShopManagement.UserControls
{
    public partial class UC_Chat_User : UserControl
    {
        public UC_Chat_User()
        {
            InitializeComponent();
        }

        private async void UC_Home_Load(object sender, EventArgs e)
        {
          
            LoadData();
        }

        private async void LoadData()
        {
         

        }
    }
}
