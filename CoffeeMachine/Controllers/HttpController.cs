using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using CoffeeAnalytics.Models;
using Newtonsoft.Json;

namespace InovativeCoffeeGUI
{
    class HttpController
    {
        private String Domain = "http://www.xannic.nl/api/";

        public void PostCoffee(String Gebied, String KoffieNaam, int tijd)
        {
            using (var wb = new WebClient())
            {
                String url = Domain + "coffee/insertcoffee.php";
                var data = new NameValueCollection();
                data["landscape"]= Gebied;
                data["coffee"] = KoffieNaam;
                data["time_seconds"] = tijd.ToString();
                data["deviceId"] = ConfigurationSettings.AppSettings["deviceId"];
                var response = wb.UploadValues(url, "POST", data);
            }
        }

        public bool CanWePlay() {
            // Get the latest coffee order and check if we played the scene.
            String JsonResponse = new WebClient().DownloadString(Domain + "coffee/getlatestcoffee.php");
            Order Koffie = JsonConvert.DeserializeObject<Order>(JsonResponse);
            //mysql bool = 0 if false or 1 if true
            return (Koffie.Played == 1);
           
        }
    }
}
