using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace kärnan
{
    public class journalClass
    {
        public int journalID { get; set; }
        public int MyProperty { get; set; }
        public DateTime date { get; set; }
        public string journal { get; set; }
        public string incident { get; set; }

        public string journalDateIncident
        {
            get
            {
                return date + " " + journal + " " + incident;

            }
        }
    }
}