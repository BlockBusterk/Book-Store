﻿using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopManagement.Models
{
    [FirestoreData]
    public class Order
    {
        [FirestoreProperty]
        public string BookTitle { get; set; }
        [FirestoreProperty]
        public string CustomerName { get; set; }
        [FirestoreProperty]
        public string ImageUrl { get; set; }
        [FirestoreProperty]
        public int Quantity { get; set; } = 1;
        [FirestoreProperty]
        public int TotalPrice { get; set; }
        [FirestoreProperty]
        public string CreatedDate { get; set; }
        [FirestoreProperty]
        public string Status { get; set; } // Pending, Delivered, Completed

    }
}