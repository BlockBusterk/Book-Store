using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System;
using System.Collections.Generic;
using System.Drawing;
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

        public static string UploadImageFile(System.Drawing.Image image, string fileName)
        {
            using (var stream = new System.IO.MemoryStream())
            {
                image.Save(stream, System.Drawing.Imaging.ImageFormat.Png); // Save the image to the stream
                stream.Seek(0, System.IO.SeekOrigin.Begin); // Reset the stream position

                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(fileName + ".png", stream) // Provide a filename
                };

                var uploadResult = cloudinary.Upload(uploadParams);
                // Handle the upload result as needed (e.g., save the URL to a database or display it to the user)
                return uploadResult.SecureUrl.ToString();
            }
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
