using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace kärnan
{
    public class Unit
    {
        public int unitid { get; set; }
        public string name { get; set; }
        //public string color { get; set; }
        //public DateTime date { get; set; }
        //public string journal { get; set; }
        //public string incident { get; set; }

        public string unitName
        {
            get
            {
                return name;

            }
        }
    }
}