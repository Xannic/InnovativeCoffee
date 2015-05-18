using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InovativeCoffeeGUI
{
    class Koffie
    {
        private int _melk = 3;
        private int _suiker = 3;
        private int _sterkte = 3;

        public String Naam { get; set; }
        public int Suiker
        {
            get { return _suiker; }
            set { _suiker = value; }
        }
        public int Melk
        {
            get { return _melk; }
            set { _melk = value; }
        }
        public int Sterkte
        {
            get { return _sterkte; }
            set { _sterkte = value; }
        }
        public String Image { get; set; }
    }
}
