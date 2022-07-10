using System.Globalization;
using System.Net;

namespace AssetTrackingMVC.Models
{
    public class Asset
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }   
        public string Model { get; set; }
        public DateTime PurchaseDate { get; set; }
        public double Price { get; set; }

        public Office? Office { get; set; }
        public int OfficeId { get; set; } // Foreing Key


        /* Returns a bootstrap table class value, depending on the age of the asset. */
        public static string GetColor(Asset asset)
        {
            var today = DateTime.Now;
            var years = today.Year - asset.PurchaseDate.Year;
            var months = today.Month - asset.PurchaseDate.Month;
            var days = today.Day - asset.PurchaseDate.Day;
            if (years == 3)
            {
                if ((months == -3 && days > 0) || months > -3)
                {
                    return "table-danger"; // less than three months from 3 years old
                }

                else if ((months == -6 && days > 0) || months > -6)
                {
                    return "table-warning"; // less than six months from 3 years old
                }
            }
            else if (years > 3) { return "table-info"; } // more than 3 years old
            return "table-light"; // more than six months left before asset is 3 years old
        }

        //Gets todays rates from floatrates.com
        //Returns the price of the asset in local currency
        public static double LocalPriceToday(Asset asset)
        {
            if (asset.Price == null) { return 0; }
            double localPrice = asset.Price;
            if (asset.Office.Currency == "USD") { return asset.Price; }
            double rate;
            WebRequest request = WebRequest.Create("http://www.floatrates.com/daily/usd.json");
            request.Credentials = CredentialCache.DefaultCredentials;
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            string sRateBegin = "Euro\",\"rate\":";
            string sRateEnd = ",";
            if (asset.Office.Currency == "SEK")
            {
                sRateBegin = "Swedish Krona\",\"rate\":";
                sRateEnd = ",";
            }
            if (asset.Office.Currency == "DKK")
            {
                sRateBegin = "Danish Krone\",\"rate\":";
                sRateEnd = ",";
            }
            string sRate = responseFromServer.Substring(responseFromServer.IndexOf(sRateBegin) + sRateBegin.Length);
            sRate = sRate.Substring(0, sRate.IndexOf(sRateEnd));
            if (double.TryParse(sRate, NumberStyles.Number, CultureInfo.CreateSpecificCulture("en-US"), out rate)) { localPrice = asset.Price * rate; }
            else { throw new Exception("Couldn't parse exchange rate, string to double."); }
            reader.Close();
            response.Close();
            localPrice = Math.Round(localPrice,0);
            return localPrice;
        }
    }
}
