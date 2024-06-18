using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopManagement.Models
{
    [FirestoreData]
    public class Order
    {
        [FirestoreProperty]
        public List<Book> Books { get; set; } = new List<Book>();

        [FirestoreProperty]
        public int  Quantity { get; set; } = 0;
        [FirestoreProperty]
        public string CustomerName { get; set; } = "";
        [FirestoreProperty]
        public string CustomerEmail { get; set; } = "";
       
        [FirestoreProperty]
        public double TotalPrice { get; set; } = 0;
        [FirestoreProperty]
        public string CreatedDate { get; set; } = DateTime.UtcNow.ToString("s", CultureInfo.InvariantCulture);
        [FirestoreProperty]
        public string Status { get; set; } = ""; // Pending, Delivered, Completed

    }
}
