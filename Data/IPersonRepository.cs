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
        List<Address> GetAddressesByPersonId(int personId);
        
        // Other relevant methods.
    }
}
