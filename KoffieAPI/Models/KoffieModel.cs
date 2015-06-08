using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KoffieAPI.Models
{
    public class KoffieModel
    {
        public int ID { get; set; }
        public String KoffieNaam { get; set; }
        public String Landschap { get; set; }
        public String Tijd { get; set; }
        public int Sterkte { get; set; }
        public int Suiker { get; set; }

        public int Melk { get; set;}
        public int DeviceID { get; set; }
    }
}