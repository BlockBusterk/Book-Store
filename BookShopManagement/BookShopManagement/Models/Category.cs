﻿using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopManagement.Models
{
    [FirestoreData]
    public class Category
    {
        [FirestoreProperty]
        public string Name { get; set; } = "";
    }
}