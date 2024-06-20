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
        public string BookId { get; set; } = "";
        [FirestoreProperty]
        public string CustomerId { get; set; } = "";
       
       
        [FirestoreProperty]
        public int Quantity { get; set; } = 1; 
        [FirestoreProperty]
        public double TotalPrice { get; set; } = 0;
        [FirestoreProperty]
        public int Price { get; set; } = 0;


    }
}
