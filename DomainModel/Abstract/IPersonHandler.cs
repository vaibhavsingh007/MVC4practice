using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;

namespace DomainModel.Abstract
{
    public interface IPersonHandler
    {
        IEnumerable<Person> GetAllPersons();
        Person GetPersonById(int id);
        List<Address> GetPersonAddresses(int personId);
    }
}
