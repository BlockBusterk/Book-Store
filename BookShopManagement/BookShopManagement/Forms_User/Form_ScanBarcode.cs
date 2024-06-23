using AForge.Video.DirectShow;
using BookShopManagement.Database;
using BookShopManagement.Forms_User;
using BookShopManagement.Models;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BookShopManagement.Forms
{
    public partial class Form_ScanBarcode : Form
    {
        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice videoCaptureDevice;

        public Form_ScanBarcode()
        {
            InitializeComponent();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Form_AddNewBook_Load(object sender, EventArgs e)
        {
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo device in filterInfoCollection)
            {
                cbCamera.Items.Add(device.Name);
            }
            cbCamera.SelectedIndex = 0;

        }

        private void btnAddNewBook_Click(object sender, EventArgs e)
        {
            videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[cbCamera.SelectedIndex].MonikerString);
            videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
            videoCaptureDevice.Start();
        }

        private void VideoCaptureDevice_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            BarcodeReader reader = new BarcodeReader();
            var result = reader.Decode(bitmap);
            if (result != null)
            {
                txbBarcode.Invoke(new MethodInvoker(async delegate ()
                {
                    // var bookid = "9eJd9H8v25VYK5dsInut";
                    var bookid = result.ToString();
                    txbBarcode.Text = bookid;

                    var db = FirebaseHelper.Database;
                    DocumentReference bookRef = db.Collection("Book").Document(bookid);
                    DocumentSnapshot bookSnap = await bookRef.GetSnapshotAsync();
                    if (bookSnap.Exists)
                    {
                        Book book = bookSnap.ConvertTo<Book>();
                        using (Form_Book_Detail_With_Btn fbd = new Form_Book_Detail_With_Btn())
                        {
                            fbd.setBookId(bookid);
                            fbd.ShowDialog();
                        }
                    } else
                    {
                        MessageBox.Show("Cannot find this book! Scan again");
                    }


                }));
            }
            picImage.Image = bitmap;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (videoCaptureDevice != null)
            {
                if (videoCaptureDevice.IsRunning)
                {
                    videoCaptureDevice.Stop();
                }
            }
            this.Dispose();
        }

        private void Form_ScanBarcode_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (videoCaptureDevice != null)
            {
                if (videoCaptureDevice.IsRunning)
                {
                    videoCaptureDevice.Stop();
                }
            }
        }
    }
}
