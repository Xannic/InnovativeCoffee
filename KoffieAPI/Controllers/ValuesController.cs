using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Linq;
using System.Diagnostics;
using KoffieAPI.Models;

namespace KoffieAPI.Controllers
{
    public class ValuesController : ApiController
    {

        // GET api/values
        //http://www.xannic.nl/api/coffee/insertcoffee.php
        // GET api/values/5
        
        public String GetAllValues()
        {
            InnovativeCoffeeEntities db = new InnovativeCoffeeEntities();
            List<Order> orders = db.Orders.ToList();

            var json = JsonConvert.SerializeObject(orders, Formatting.None,
                new JsonSerializerSettings
                {
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects
                });
            
            return json;

        }

        //api/values/getlatestcoffee zonder extra waarden
        [System.Web.Http.AcceptVerbs("GET")]
        public String GetLatestCoffee()
        {
            InnovativeCoffeeEntities db = new InnovativeCoffeeEntities();
            List<Order> orders = db.Orders.OrderByDescending(x => x.Id).ToList();

            Console.WriteLine(orders);


            var json = JsonConvert.SerializeObject(orders.First(), Formatting.None,
                new JsonSerializerSettings
                {
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects
                });

            return json;
        }

        // api/values/saveorder/landscape$id_string+coffee$id_string+time_seconds$string+device_id$id_string
        [System.Web.Http.AcceptVerbs("POST")]
        public void SaveOrder([FromBody] String landscape, String coffee, String time_seconds, String deviceId)
        {
            InnovativeCoffeeEntities db = new InnovativeCoffeeEntities();

            Order order = new Order();
            order.DrinkId = Convert.ToInt32(coffee);
            order.LandscapeId = Convert.ToInt32(landscape);
            order.Time_Seconds = Convert.ToString(time_seconds);
            order.DeviceId = Convert.ToInt32(deviceId);
            db.SaveChanges();

        }
        
        // POST api/values
        [HttpPost]
        public void Post([FromBody] String Id, String DrinkID, String LandscapeId, String Played  )
        {
            //geef de laatst toegevoegde record terug als json
            InnovativeCoffeeEntities db = new InnovativeCoffeeEntities();
            
            Order order = new Order();
            order.Id = Convert.ToInt32(Id);
            order.DrinkId = Convert.ToInt32(DrinkID);
            order.LandscapeId = Convert.ToInt32(LandscapeId);
            order.Played = Convert.ToBoolean(Played);
            db.SaveChanges();


        }

        public String Get(string id)
        {
            InnovativeCoffeeEntities db = new InnovativeCoffeeEntities();
        //   var KoffiePerSoortQuery = 
         //      from order in db.Orders 
         //      orderby order.KoffieNaam
        //       select order;
 
        //    foreach(var KoffiePerSoort in KoffiePerSoortQuery ){
       //         System.Diagnostics.Debug.WriteLine(KoffiePerSoort.KoffieNaam + ", " + KoffiePerSoort.Landschap);
//
       //     }


           List<GraphModel> KoffieNaamLijst = new List<GraphModel>();
           //group op koffienaam, tel de groupby bij elkaar op per KoffieNaam en print dit erachter uit
         //  foreach(var line in db.Orders.GroupBy(info => info.KoffieNaam)
         //               .Select(group => new { 
         //                   KoffieNaam = group.Key, 
          //                   Count = group.Count() 
          //              })
           //             .OrderBy(x => x.KoffieNaam))
{
    //System.Diagnostics.Debug.WriteLine("{0} {1}", line.KoffieNaam, line.Count);
    GraphModel g = new GraphModel();
  //  g.Name = line.KoffieNaam;
  //  g.Value = line.Count;
  //  KoffieNaamLijst.Add(g);
}

            List<Order> orders = db.Orders.ToList();

            //var json = JsonConvert.SerializeObject(orders);
            var json = JsonConvert.SerializeObject(orders, Formatting.None,
new JsonSerializerSettings
{
    PreserveReferencesHandling = PreserveReferencesHandling.Objects
});

            return json;
       //     String json = JsonConvert.SerializeObject(KoffieNaamLijst) ;
      //      return json;
         

            //List<Order> BesteldeKoffiePerSoort = db.Order.GroupBy(x => x.KoffieNaam);
           // List<String> CoffeeList = new List<String>();
           //  List<String> LandScapeList = new List<String>();

           
        }
    }
}