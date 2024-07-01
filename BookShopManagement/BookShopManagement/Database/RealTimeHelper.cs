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
using FireSharp.Response;
using FireSharp.EventStreaming;

namespace BookShopManagement.Database
{
    public class RealTimeHelper
    {
        private readonly IFirebaseConfig config;
        private readonly IFirebaseClient client;

        public RealTimeHelper(string apiKey, string authSecret, string databaseUrl)
        {
            config = new FirebaseConfig
            {
                AuthSecret = "cMUy8pXn96Xt4kt0IOpw5K5Rm1nAbNfbIDHRDYU7",
                BasePath = "https://bookstorecsapp-default-rtdb.asia-southeast1.firebasedatabase.app/",
            };
            client = new FirebaseClient(config);
        }

        public async Task<FirebaseResponse> GetAsync(string path)
        {
            return await client.GetAsync(path);
        }

        public async Task<bool> SetAsync(string path, object data)
        {
            FirebaseResponse response = await client.SetAsync(path, data);
            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }

        public async Task<EventStreamResponse> OnAsync(string path, ValueAddedEventHandler callback)
        {
            return await client.OnAsync(path, callback);
        }

    }
}
