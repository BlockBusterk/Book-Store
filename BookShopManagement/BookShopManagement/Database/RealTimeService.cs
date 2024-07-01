using Firebase.Auth.Providers;
using Firebase.Auth;
using FirebaseAdmin.Auth;
using FirebaseAdmin;
using FireSharp.Config;
using FireSharp.Interfaces;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FireSharp;
using System.Windows.Forms;

namespace BookShopManagement.Database
{
    public static class RealTimeService
    {
        static IFirebaseConfig ifc = new FirebaseConfig()
        {
            AuthSecret= "cMUy8pXn96Xt4kt0IOpw5K5Rm1nAbNfbIDHRDYU7",
            BasePath = "https://bookstorecsapp-default-rtdb.asia-southeast1.firebasedatabase.app/",
        };

        public static IFirebaseClient client { get; set; }
        public static void SetEnviromentVariable()
        {
           try
            {
                client = new FirebaseClient(ifc);
            }
            catch
            {
                MessageBox.Show("There was a problem in your internet.");
            }
        }

    }
}
