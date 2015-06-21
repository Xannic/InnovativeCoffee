using System;
using System.Collections.Specialized;
using System.Configuration;
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
            // Get the latest coffee order and check if we played the scene.
            Console.WriteLine("Start canplay" + System.DateTime.Now);
            
            String jsonResponse = new WebClient().DownloadString(Domain + "coffee/getlatestcoffee.php");
            Console.WriteLine("Middle canplay" + System.DateTime.Now);
            
            Order koffie = JsonConvert.DeserializeObject<Order>(jsonResponse);
            Console.WriteLine("Stop canplay" + System.DateTime.Now);
            
            //mysql bool = 0 if false or 1 if true
            return (koffie.Played == 1);
           
        }
    }
}
