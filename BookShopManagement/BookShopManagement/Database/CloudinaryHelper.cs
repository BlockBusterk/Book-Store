using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopManagement.Database
{
    public class CloudinaryHelper
    {
        private static Cloudinary cloudinary;

        static CloudinaryHelper()
        {
            Account account = new Account(
                "db3qu4bzj", // Cloud name
                "843859726529571",    // API key
                "mGxoFXqty8mhnTmY5axSG5qA0no"  // API secret
            );

            cloudinary = new Cloudinary(account);
        }

        public static string UploadImage(string filePath)
        {
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(filePath)
            };

            var uploadResult = cloudinary.Upload(uploadParams);
            return uploadResult.SecureUrl.ToString();
        }
    }
}
