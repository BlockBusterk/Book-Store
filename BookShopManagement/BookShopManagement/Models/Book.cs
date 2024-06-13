﻿using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopManagement.Models
{

    [FirestoreData]
    public class Book
    {
        [FirestoreProperty]
        public string ImageUrl { get; set; }
        [FirestoreProperty]
        public string BookTitle { get; set; }
        [FirestoreProperty]
        public string Author { get; set; }
        [FirestoreProperty]
        public string Publisher { get; set; }
        [FirestoreProperty]
        public int Quantity { get; set; }
        [FirestoreProperty]
        public int CostPrice { get; set; }
        [FirestoreProperty]
        public int SellingPrice { get; set; }
        [FirestoreProperty]
        public string Category { get; set; }
        [FirestoreProperty]
        public string Barcode { get; set; }
        [FirestoreProperty]
        public string CreatedDate { get; set; }
    }
}
