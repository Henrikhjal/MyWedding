using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace MyWedding.Utility
{
    public class Utility
    {
        public static void setLanguage(HttpRequestBase req)
        {
            string language = "";

            HttpCookie cookie = req.Cookies["_culture"];

            if (cookie == null || cookie.Value == "" || cookie.Value == null)
            {
                language = "sv-SE";
            }
            else
            {
                language = cookie.Value;
                cookie.Expires = DateTime.Now.AddMonths(3);
            }
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(language);
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
        }

        public static double ConvertToDouble(string c)
        {
            if (c == "") return -1;

            c = c.Replace('.', ',');
            // double latitude=  (Convert.ToDouble(c));
            return (Convert.ToDouble(c));  //latitude;
        }

        public static void WriteLog(string Action, string UserName, string city = "", string country = "", double latitude = 0, double longitude = 0)
        {
        //    WeddingContext db = new WeddingContext();

        //    Log log = new Log();
        //    log.UserName = UserName;
        //    log.Time = DateTime.Now;
        //    log.Action = Action;
        //    log.City = city;
        //    log.Country = country;
        //    log.Latitude = latitude;
        //    log.Longitude = longitude;

        //    db.Logs.Add(log);
        //    db.SaveChanges();
        }

        public static string FirstCharToUpper(string input)
        {
            if (String.IsNullOrEmpty(input))
                return "";
            return input.First().ToString().ToUpper() + input.Substring(1);
        }

        public static string RemoveLast(string text, string character)
        {
            if (text.Length < 1) return text;
            return text.Remove(1, 1);
            // return text.Remove(text.ToString().LastIndexOf(character), character.Length);
        }

        private static string GetIPAddress()
        {
            HttpContext context = HttpContext.Current;
            string clientIp = (context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] ?? context.Request.ServerVariables["REMOTE_ADDR"]).Split(',')[0].Trim();


            return clientIp;

            //System.Web.HttpContext context = System.Web.HttpContext.Current;
            ////string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            //string ipAddress = context.Request.ServerVariables["REMOTE_ADDR"];
            //if (!string.IsNullOrEmpty(ipAddress))

            //{
            //    string[] addresses = ipAddress.Split(',');
            //    if (addresses.Length != 0)
            //    {
            //        return addresses[0];
            //    }
            //}

            //return context.Request.ServerVariables["REMOTE_ADDR"];
        }

        public static string FirstAndLastCharToUpper(string input)
        {
            String txt;
            if (String.IsNullOrEmpty(input))
                return "";
            txt = input.First().ToString().ToUpper() + input.Substring(1);


            txt = txt.Remove(txt.Length - 1) + ' ' + txt.Last().ToString().ToUpper();
            return txt;
        }


    }
}