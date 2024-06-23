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
    public class Comment
    {
        [FirestoreProperty]
        public string UserComment { get; set; } = "";
        [FirestoreProperty]
        public string UserId { get; set; } = "";

        [FirestoreProperty]
        public int UserScore { get; set; } = 0;
        [FirestoreProperty]
        public string ImageUrl { get; set; } = "";
        [FirestoreProperty]
        public string CreatedDate { get; set; } = DateTime.UtcNow.ToString("s", CultureInfo.InvariantCulture);
    }
}
