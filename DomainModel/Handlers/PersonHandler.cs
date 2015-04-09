using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomainModel.Abstract;
using Data;
using Models;
using ExceptionFacade;

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

            try
            {
                retval = _personRepo.GetPersons();
            }
            catch (Exception e)
            {
                ExceptionHandlers.LogException(e, Constants.ErrorLogFolderPath, true);
            }
            return retval;
        }

        public Person GetPersonById(int id)
        {
            Person retval = null;
            
            try
            {
                retval = _personRepo.GetPersonById(id);
            }
            catch (Exception e)
            {
                ExceptionHandlers.LogException(e, Constants.ErrorLogFolderPath, true);
            }
            return retval;
        }


        public List<Address> GetPersonAddresses(int personId)
        {
            List<Address> retval = null;

            try
            {
                retval = _personRepo.GetAddressesByPersonId(personId);
            }
            catch (Exception e)
            {
                ExceptionHandlers.LogException(e, Constants.ErrorLogFolderPath, true);
            }

            return retval;
        }
    }
}
