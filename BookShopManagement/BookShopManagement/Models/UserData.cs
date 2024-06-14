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
    public class UserData
    {
        [FirestoreProperty]
        public string Name { get; set; } = "";
        [FirestoreProperty]
        public string Email { get; set; } = "";
        [FirestoreProperty]
        public string Phone { get; set; } = "";
        [FirestoreProperty]
        public string Address { get; set; } = "";
        [FirestoreProperty]
        public int Sales { get; set; } = 0;
        [FirestoreProperty]
        public string CreatedDate { get; set; } = DateTime.UtcNow.ToString("s", CultureInfo.InvariantCulture);
        [FirestoreProperty]
        public string ImageUrl { get; set; } = "";
    }
}
