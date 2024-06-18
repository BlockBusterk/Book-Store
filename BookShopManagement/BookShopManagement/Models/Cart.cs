using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopManagement.Models
{
    [FirestoreData]
    public class Cart
    {
        [FirestoreProperty]
        public string BookTitle { get; set; } = "";
        [FirestoreProperty]
        public string BookPublisher { get; set; } = "";
        [FirestoreProperty]
        public string Author { get; set; } = "";

        [FirestoreProperty]
        public string BookId { get; set; } = "";
        [FirestoreProperty]
        public string CustomerEmail { get; set; } = "";
        [FirestoreProperty]
        public string CustomerName { get; set; } = "";
        [FirestoreProperty]
        public string ImageUrl { get; set; } = "";
        [FirestoreProperty]
        public int Quantity { get; set; } = 1; 
        [FirestoreProperty]
        public int TotalPrice { get; set; } = 0;
        [FirestoreProperty]
        public int Price { get; set; } = 0;


    }
}
