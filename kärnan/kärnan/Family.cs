using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace kärnan
{
    public class Family
    {
        public int familyID { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string birth { get; set; }

        public string familyName
        {
            get
            {
                return name + " " + surname();

            }
        }

    }
}