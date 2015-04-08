using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

namespace Mvc4Architecture.Models
{
    public class PersonTdVM
    {
        public Person Person { get; set; }

        public string AddressTitleString { get; set; }

        public int AddressCount { get; set; }
    }
}