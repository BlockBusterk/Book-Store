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
    public class MessageData
    {
        [FirestoreProperty]
        public string MessageId { get; set; } = "";

        [FirestoreProperty]
        public string SenderUserId { get; set; } = "";

        [FirestoreProperty]
        public string ReceiverUserId { get; set; } = "";

        [FirestoreProperty]
        public string MessageText { get; set; } = "";

        [FirestoreProperty]
        public string MessageType { get; set; } = "";

        [FirestoreProperty]
        public string CreatedAt { get; set; } = DateTime.UtcNow.ToString("s", CultureInfo.InvariantCulture);

    }
}
