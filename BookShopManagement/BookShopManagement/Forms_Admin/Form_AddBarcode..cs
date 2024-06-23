using BarcodeStandard;
using BookShopManagement.Database;
using BookShopManagement.Models;
using Google.Cloud.Firestore;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using static Google.Rpc.Context.AttributeContext.Types;

namespace BookShopManagement.Forms
{
    public partial class Form_AddBarcode : Form
    {
        public string BookId {  get; set; } 
        public Form_AddBarcode(string id)
        {
            BookId = id;
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BarcodeWriter brcode = new BarcodeWriter()
            {
                Format = BarcodeFormat.CODE_128
            };
            pictureBox1.Image = brcode.Write(BookId);
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            // Update new book
            try
            {
                var db = FirebaseHelper.Database;

                string imageUrl = CloudinaryHelper.UploadImageFile(pictureBox1.Image, BookId);

                var data = new Dictionary<string, object>
                {
                    { "Barcode", imageUrl },
                };

                DocumentReference docref = db.Collection("Book").Document(BookId);
                DocumentSnapshot snapshot = await docref.GetSnapshotAsync();
                if (snapshot.Exists)
                {
                    await docref.UpdateAsync(data);
                    MessageBox.Show("Book updated success");
                }
                else
                {
                    MessageBox.Show("Book updated failed");
                }
                this.Dispose();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Book updated failed");
            }
        }
    }
}
