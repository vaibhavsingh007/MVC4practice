using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;

namespace Data
{
    public interface IPersonRepository
    {
        IEnumerable<Person> GetPersons();
        Person GetPersonById(int id);
        
        // Other relevant methods.
    }
}
