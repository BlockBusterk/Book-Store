using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopManagement.Utils
{
    public class VietNameTime
    {
        public static string ConvertToVietnamTime(string iso8601DateTime)
        {
            // Chuyển chuỗi ISO 8601 thành kiểu DateTime
            DateTime utcDateTime = DateTime.ParseExact(iso8601DateTime, "yyyy-MM-ddTHH:mm:ss", null);

            // Tìm thông tin múi giờ của Việt Nam (Asia/Ho_Chi_Minh)
            TimeZoneInfo vietnamTimeZone;
            try
            {
                vietnamTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
            }
            catch (TimeZoneNotFoundException)
            {
                vietnamTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Asia/Ho_Chi_Minh");
            }
            catch (InvalidTimeZoneException)
            {
                vietnamTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Asia/Ho_Chi_Minh");
            }


            // Chuyển đổi thời gian từ UTC sang múi giờ Việt Nam
            DateTime vietnamTime = TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, vietnamTimeZone);

            // Định dạng lại thành chuỗi và trả về
            string formattedVietnamTime = vietnamTime.ToString("yyyy-MM-dd HH:mm:ss");
            return formattedVietnamTime;
        }
    }
}
