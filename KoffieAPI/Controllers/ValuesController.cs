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

        public string Get()
        {
           KoffieDBEntities db = new KoffieDBEntities();
           List<Order> orders = db.Order.OrderByDescending(x => x.Id).ToList();
           
            String json = JsonConvert.SerializeObject(orders) ;

            return json;

        }


       


        // POST api/values
      [HttpPost]
        public void Post([FromBody]String KoffieNaam, String Landschap, String Tijd, String Sterkte, String Melk, String Suiker, String DeviceID, String id  )
        {
            //geef de laatst toegevoegde record terug als json
            KoffieDBEntities db = new KoffieDBEntities();
            Order order = new Order();
            order.Id = Convert.ToInt32(id);
            order.KoffieNaam = KoffieNaam;
            order.Landschap = Landschap;
            order.Melk = Convert.ToInt32(Melk);
            order.Sterkte = Convert.ToInt32(Sterkte);
            order.Suiker = Convert.ToInt32(Suiker);
            order.Tijd = DateTime.Now;
            db.SaveChanges();


        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
            KoffieDBEntities db = new KoffieDBEntities();
            Order order = new Order();
            order.KoffieNaam = "test";
            db.Order.Add(order);
            
          
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }

       [HttpGet]
        public String Get(int id)
        {
            KoffieDBEntities db = new KoffieDBEntities();
           var KoffiePerSoortQuery = 
               from order in db.Order 
               orderby order.KoffieNaam
               select order;
 
            foreach(var KoffiePerSoort in KoffiePerSoortQuery ){
                System.Diagnostics.Debug.WriteLine(KoffiePerSoort.KoffieNaam + ", " + KoffiePerSoort.Landschap);

            }


           List<GraphModel> KoffieNaamLijst = new List<GraphModel>();
           //group op koffienaam, tel de groupby bij elkaar op per KoffieNaam en print dit erachter uit
           foreach(var line in db.Order.GroupBy(info => info.KoffieNaam)
                        .Select(group => new { 
                             KoffieNaam = group.Key, 
                             Count = group.Count() 
                        })
                        .OrderBy(x => x.KoffieNaam))
{
    //System.Diagnostics.Debug.WriteLine("{0} {1}", line.KoffieNaam, line.Count);
    GraphModel g = new GraphModel();
    g.Name = line.KoffieNaam;
    g.Value = line.Count;
    KoffieNaamLijst.Add(g);
}   
            String json = JsonConvert.SerializeObject(KoffieNaamLijst) ;
            return json;
             

            //List<Order> BesteldeKoffiePerSoort = db.Order.GroupBy(x => x.KoffieNaam);
           // List<String> CoffeeList = new List<String>();
           //  List<String> LandScapeList = new List<String>();

           
        }
    }
}