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
    public class Book
    {
        [FirestoreProperty]
        public string BookId { get; set; } = "";
        [FirestoreProperty]
        public string ImageUrl { get; set; } = "";
        [FirestoreProperty]
        public string BookTitle { get; set; } = "";
        [FirestoreProperty]
        public string Author { get; set; } = "";
        [FirestoreProperty]
        public string Publisher { get; set; } = "";
        [FirestoreProperty]
        public int Quantity { get; set; } = 0;
        [FirestoreProperty]
        public double CostPrice { get; set; } = 0;
        [FirestoreProperty]
        public double SellingPrice { get; set; } = 0;
        [FirestoreProperty]
        public string Category { get; set; } = "";
        [FirestoreProperty]
        public string Barcode { get; set; } = "";

        [FirestoreProperty]
        public string CreatedDate { get; set; } = DateTime.UtcNow.ToString("s", CultureInfo.InvariantCulture);
    }
}
