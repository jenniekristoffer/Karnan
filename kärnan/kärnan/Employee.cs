using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace kärnan
{
    public class Employee
    {
        public int employeeid { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string initials { get; set; }

        public string nameInitials
        {
            get
            {
                return initials;

            }
        }
    }
}