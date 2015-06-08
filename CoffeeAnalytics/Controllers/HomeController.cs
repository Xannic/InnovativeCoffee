using CoffeeAnalytics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using Newtonsoft.Json;
using System.Web.Script.Serialization;

namespace CoffeeAnalytics.Controllers
{
    public class HomeController : Controller
    {
        String Domain = "http://www.xannic.nl/api";
        Orders OrdersModel;
        public ActionResult Index()
        {
            OrdersModel = FetchOrdersFromJson();
            List<String> CoffeeList = new List<String>();
            List<String> LandScapeList = new List<String>();

            for (int i = 0; i < OrdersModel.items.Count; i++ )
            {
                if (!CoffeeList.Contains(OrdersModel.items[i].Coffee)) {
                    CoffeeList.Add(OrdersModel.items[i].Coffee);
                }
                if (!LandScapeList.Contains(OrdersModel.items[i].Landscape))
                {
                    LandScapeList.Add(OrdersModel.items[i].Landscape);
                }
            }
            List<ChartData> data = new List<ChartData>();
            for (int i = 0; i < CoffeeList.Count; i++ )
            {
                int CountCoffee = 0;
                for (int j = 0; j < OrdersModel.items.Count; j++) {
                    if (CoffeeList[i].Equals(OrdersModel.items[j].Coffee)) {
                        CountCoffee++;
                    }
                }
                ChartData d = new ChartData();
                d.CoffeeName = CoffeeList[i];
                d.Number = CountCoffee;
                data.Add(d);
            }

            OrdersModel.CoffeeChartInfo = data;
            return View(OrdersModel);
        }

        private Orders FetchOrdersFromJson()
        {
            String JsonResponse = new WebClient().DownloadString(Domain + "/coffee/getalldata.php");
            Orders OrdersModel = JsonConvert.DeserializeObject<Orders>(JsonResponse);
            return OrdersModel;
        }

        public ActionResult About()
        {
            OrdersModel = FetchOrdersFromJson();
            var jsonSerialiser = new JavaScriptSerializer();
            var json = jsonSerialiser.Serialize(OrdersModel.items);
            return View((object)json);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}