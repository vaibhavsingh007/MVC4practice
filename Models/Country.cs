using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Person> VisitedBy { get; set; }
    }
}
