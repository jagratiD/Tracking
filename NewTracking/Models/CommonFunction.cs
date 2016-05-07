using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewTracking.Models;

namespace NewTracking.Models
{

    public class CommonFunction
    {
        public static string EncodeToBase64(string toEncode)
        {
            byte[] toEncodeAsBytes
                  = System.Text.ASCIIEncoding.ASCII.GetBytes(toEncode);
            string returnValue
                  = System.Convert.ToBase64String(toEncodeAsBytes);
            return returnValue;
        }

        public static string DecodeFromBase64(string encodedData)
        {
            byte[] encodedDataAsBytes
                = System.Convert.FromBase64String(encodedData);
            string returnValue =
               System.Text.ASCIIEncoding.ASCII.GetString(encodedDataAsBytes);
            return returnValue;
        }

        public static List<SelectListItem> GetPaymentType()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            items.Insert(0, (new SelectListItem { Text = "Cash", Value = "Cash" }));
            items.Insert(1, (new SelectListItem { Text = "Cheque", Value = "Cheque" }));

            return items;
        }

        public static List<SelectListItem> GetEventType()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            items.Insert(0, (new SelectListItem { Text = "PICKUP", Value = "PICKUP" }));
            items.Insert(1, (new SelectListItem { Text = "DELIVERY", Value = "DELIVERY", Selected = true }));

            return items;
        }

        public static DateTime GetDateTime()
        {
            DateTime indianStd = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, "India Standard Time");
            return indianStd;
        }

        public static string GetUserCity(int UserID)
        {
            LogisureEntities1 context = new LogisureEntities1();

            var str = String.Empty;
            var City = context.DB_CustomUserProfile.Where(x => x.UserID == UserID).Select(x => x.CityOfOperation).FirstOrDefault();
         //   var CityList = City.Split(',').Select(x => int.Parse(x)).ToList();
            return City;
        }

    }

    public class BasicInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FullAddress { get; set; }
    }

    

}