using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Firebase.Auth.Providers;
using Firebase.Auth;
using FirebaseAdmin;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Firestore;
using System.Drawing;


namespace BookShopManagement.Database
{

    public static class FirebaseHelper
    {
        static string config = @"
        {
          ""type"": ""service_account"",
          ""project_id"": ""bookstorecsapp"",
          ""private_key_id"": ""68e656d595fecc72642091ee10e51d60237ccbb5"",
          ""private_key"": ""-----BEGIN PRIVATE KEY-----\nMIIEvQIBADANBgkqhkiG9w0BAQEFAASCBKcwggSjAgEAAoIBAQCXE+Cd1mTTfeHH\nMQKhyG2T7xZ0fAeAon+B+3GcskWjKXBpQgxn5HXp8lq7z+9xK0rxYAQT+razP2Zh\nLAICd0BzV/rvlWdnwaJnLTpJMof6vxZhxRADt0LOjHVz8SH6/0fQqiQasyiuGK36\nXxeU1jgz7qm9f9SQ1ZM7yHD5bQJa+bu1ZDnF9MZ5wi7pfbshwxRmRveaTatrsCT7\n1SwxQPSzph+/TNr59GgvzzziPUkPx3NmAC/Sux//6nnl3bDOOQ+Uhm8+6N4e/3x0\nLCGbCEEjqOD4NjBekQnvzffVlWTssdcEHTbPgvnQDLjnSzuNwGcU2kIhnbIHyKPH\nfMggv/erAgMBAAECggEADgLb7Ad8JlkgXVbgRZzO/M9Jp9fw4i8v4CAvszadWrp3\nIGvttpzripzdaVmpfTdkpeoftrKjyw/wMMbiENR6d7gLH7kdc/PzWdpJ84vqLIkY\nTEz4ZT/TxFAmfHA6lIqkYGfHHWrMNQk46WV0TGtpnvddaqO2VRBZrUuzno5Lj6BB\nG5SpJ0Qe8GNC6F/fQwgg4y4gS4msrdS8xoO7qdivQIOMiM5KE1RXjZqMxVX+CcyN\neGZXLYM3PSgVdRvTFnxPysP42vwbe8vxzWNIYyU4uuOG04maV/Nh32q9amkSqUyd\nhYmjGq9er89jcVVgSEOfgcHbQY5+9/HibUySXH0FEQKBgQDGhNqZC9PHwxX2EDum\nPu5pRuhmx9r0lGQPS3VX8uKSLsiU86ZWdhXniiRD83kYeuokw3QYA4VO3405BhQ4\n0s3K7cEJ11fjStr1lTjycoQ6+Mfg/QYEfRlW6vUHbjYTVu7P2w+l6VxBdOz5xElR\nQjH2V7PcsXIV9MiqB/R/6wkTZQKBgQDC0nQILLk0b6bGuKAFxPOr6Oinfw20FPvy\n2IjYeSb+ek1IO3vwsWyo1MCwqTzYZJIyiyMQ0uZuzgH/Xu7HJyn4yqqf01nItgJt\nX/UMA0yELulZ/K+2jkBySlFy7LNtc8KSe+UFN+02Pg8DwrBN9tEVHR/IcVwxaPih\nlcrYNmoVzwKBgHYM8uEoA1w7Sof0x0PpEGVSYUkdd7sRsx7VRIZ0TP+ZCnZpHXU0\n63mw0DgIRO6lyS7re9H75f4tOhG657OSyAXwtGZhxEXJccOwZRjnuHJJFrNYQ4fP\nzI2/Us6EX2vIumKoZfnHd7EFExbD/sVvk75mEPMgIjOkSN+zs1WOMutxAoGAYNnG\nnRm+qHao7jlyM+wJRvjuT/Y1lcSoy70hqpvv6qpaKQKJRsqtPfEmKay4dsrocwAA\nWqi9rW/0RkOnaJHrp6b406N6CvGQm1cMtwAc1cmMcBPSNmrZVvfjLcLGIC9gFvpI\njCOVZVXMmQ38H4YHwvtLhZX1QwrwL0QMJxhF/LkCgYEAi4m2yX3ikiE01YYWO4H9\nckehrp5q8GcnkcgG6TR186TuskAFF4AUiLonSFcsM9w1MK0VCbuf5EfgUlTpt+vh\nXrYuBcanO5w91TnpRs38gYncZIP/RnkwTdeRpPfOMiqVnZR9fjQGPNakGSxV90Wt\nkW3wSZINiwjpBLJamp8UMnI=\n-----END PRIVATE KEY-----\n"",
          ""client_email"": ""firebase-adminsdk-vw2kc@bookstorecsapp.iam.gserviceaccount.com"",
          ""client_id"": ""108760733908936181852"",
          ""auth_uri"": ""https://accounts.google.com/o/oauth2/auth"",
          ""token_uri"": ""https://oauth2.googleapis.com/token"",
          ""auth_provider_x509_cert_url"": ""https://www.googleapis.com/oauth2/v1/certs"",
          ""client_x509_cert_url"": ""https://www.googleapis.com/robot/v1/metadata/x509/firebase-adminsdk-vw2kc%40bookstorecsapp.iam.gserviceaccount.com"",
          ""universe_domain"": ""googleapis.com""
        }";

        static string filePath = "";
        public static FirestoreDb Database { get; private set; }
        public static FirebaseAuthClient FirebaseAuth { get; private set; }
        public static void SetEnviromentVariable()
        {
            filePath = Path.Combine(Path.GetTempPath(), Path.GetFileNameWithoutExtension(Path.GetRandomFileName())) + ".json";
            File.WriteAllText(filePath, config);
            File.SetAttributes(filePath, FileAttributes.Hidden);

            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filePath);
            FirebaseApp.Create(new AppOptions
            {
                Credential = GoogleCredential.FromFile(filePath),
            });
            Database = FirestoreDb.Create("bookstorecsapp");
            FirebaseAuth = new FirebaseAuthClient(new FirebaseAuthConfig
            {
                ApiKey= "AIzaSyCNxrLj4Z1NtZVvVrQR39IPj_JVV_fJcfE",
                AuthDomain = $"bookstorecsapp.firebaseapp.com",
                Providers = new FirebaseAuthProvider[]
                {
                    new EmailProvider(),
                    new GoogleProvider()
                }
            });

            File.Delete(filePath);
        }
    }
}
