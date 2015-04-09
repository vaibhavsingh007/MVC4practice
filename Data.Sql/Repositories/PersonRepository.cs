using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Sql.Base;
using Models;
using Data.Base;

namespace Data.Sql.Repositories
{
    public class PersonRepository : BaseRepository, IPersonRepository
    {
        public PersonRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        /// <summary>
        /// Eager loads Addresses.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Person> GetPersons()
        {
            List<Person> retval = null;
            List<Address> unproxiedAddresses = null;

            var persons = GetDbSet<Person>().AsEnumerable();

            retval = new List<Person>();
            unproxiedAddresses = new List<Address>();

            foreach (var person in persons)
            {
                var unproxiedPerson = UnProxy<Person>(person);
                foreach (var address in person.Addresses)
                {
                    unproxiedAddresses.Add(UnProxy<Address>(address));
                }

                unproxiedPerson.Addresses = unproxiedAddresses.ToList();
                retval.Add(unproxiedPerson);

                unproxiedAddresses.Clear();
            }

            return retval;
        }


        public Person GetPersonById(int id)
        {
            return GetDbSet<Person>().FirstOrDefault(p => p.Id == id);
        }

        public List<Address> GetAddressesByPersonId(int personId)
        {
            List<Address> retval = new List<Address>();

            // Unproxying required.
            foreach (var address in GetPersonById(personId).Addresses)
            {
                retval.Add(UnProxy<Address>(address));
            }

            return retval;

        }
    }
}
