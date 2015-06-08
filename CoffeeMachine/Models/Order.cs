﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoffeeAnalytics.Models
{
    public class Order
    {
        public int Id { get; set; }
        public String Coffee { get; set; }
        public String Landscape { get; set; }
        //public DateTime Date { get; set; }
        public int DeviceId { get; set; }
        public int Played { get; set; }
    }
}