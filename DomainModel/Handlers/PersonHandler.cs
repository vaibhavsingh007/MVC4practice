using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomainModel.Abstract;
using Data;
using Models;

namespace DomainModel.Handlers
{
    public class PersonHandler: IPersonHandler
    {
        private IPersonRepository _personRepo;

        public PersonHandler(IPersonRepository personRepo)
        {
            _personRepo = personRepo;
        }

        public IEnumerable<Person> GetAllPersons()
        {
            IEnumerable<Person> retval = null;

            retval = _personRepo.GetPersons();
            return retval;
        }

        public Person GetPersonById(int id)
        {
            Person retval = null;
            retval = _personRepo.GetPersonById(id);
            return retval;
        }
    }
}
