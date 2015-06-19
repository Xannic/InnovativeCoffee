using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace CoffeApi2.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
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

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}