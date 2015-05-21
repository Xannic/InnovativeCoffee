﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace InovativeCoffeeGUI
{
    class HttpController
    {
        private String Domain = "http://www.xannic.nl/api/";

        public void PostKoffie(String Gebied, String KoffieNaam, int tijd)
        {
            using (var wb = new WebClient())
            {
                String url = Domain + "api/coffee/insertcoffee.php";
                var data = new NameValueCollection();
                data["landscape"]= Gebied;
                data["coffee"] = KoffieNaam;
                data["time_seconds"] = tijd.ToString();
                var response = wb.UploadValues(url, "POST", data);
            }
        }
    }
}
