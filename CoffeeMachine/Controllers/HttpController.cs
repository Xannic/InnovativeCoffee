using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using CoffeeMachine.Models;
using Newtonsoft.Json;

namespace CoffeeMachine.Controllers
{
    class HttpController
    {
        private String Domain = "http://www.xannic.nl/api/";

        public void PostCoffee(String landscape, String koffieNaam, int tijd)
        {
            using (var wb = new WebClient())
            {
                String url = Domain + "coffee/insertcoffee.php";
                var data = new NameValueCollection();
                data["landscape"]= landscape;
                data["coffee"] = koffieNaam;
                data["time_seconds"] = tijd.ToString();
                data["deviceId"] = ConfigurationSettings.AppSettings["deviceId"];
                var response = wb.UploadValues(url, "POST", data);
            }
        }

        public bool CanWePlay() {
            Order drink;

            try
            {
                // Get the latest order and check if we played the scene.
                String jsonResponse = new WebClient().DownloadString(Domain + "coffee/getlatestcoffee.php");
                drink = JsonConvert.DeserializeObject<Order>(jsonResponse);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);

                return false;
            }
            
            // mysql returning 1 if true and 0 if false
            return (drink.Played == 1);
        }
    }
}
