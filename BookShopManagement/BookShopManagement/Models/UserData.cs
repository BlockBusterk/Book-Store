using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopManagement.Models
{
    [FirestoreData]
    public class UserData
    {
        [FirestoreProperty]
        public string Name { get; set; }
        [FirestoreProperty]
        public string Email { get; set; }
        [FirestoreProperty]
        public string Phone { get; set; }
        [FirestoreProperty]
        public string Address { get; set; }
        [FirestoreProperty]
        public int Turnover { get; set; } = 0;
        [FirestoreProperty]
        public string CreatedDate { get; set; }
        [FirestoreProperty]
        public string ImageUrl { get; set; }
    }
}
