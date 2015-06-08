using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoffeeAnalytics.Models
{
    public class Orders
    {
        public List<Order> items{get; set;}
        public List<ChartData> CoffeeChartInfo { get; set; }
    }
}