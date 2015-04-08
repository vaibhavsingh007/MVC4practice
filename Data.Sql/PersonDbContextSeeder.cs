using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Base;
using Models;

namespace Data.Sql
{
    public partial class PersonDbContext : ISeedDatabase
    {
        public void Seed()
        {
            CreateSomePersonsAndCountries();
        }

        private void CreateSomePersonsAndCountries()
        {
            string[] personNames = new string[] { "James", "Adams", "Jill", "Mark" };
            string[] personCountries = new string[] { "USA", "India", "UK", "Denmark" };
            Person newPerson = null;

            for (int i = 0; i < personNames.Count(); i++)
            {
                newPerson = new Person
                {
                    FirstName = personNames[i],
                    Age = 20 + i,
                    HomeTown = ((char)(65 + i)).ToString(),
                    LastName = "Anderson",
                    Addresses = new List<Address>()
                };

                AddAddresses(newPerson);
                Persons.Add(newPerson);
            }
        }

        private void AddAddresses(Person person)
        {
            // A randomized seeder logic that dynamically adds different number
            //..of addresses for a person.
            Random random = new Random();
            int addressCount = random.Next(1, 4);

            for (int num = 1; num <= addressCount; num++)
            {
                person.Addresses.Add(new Address
                {
                    Street = "Street " + num,
                    City = "City " + num,
                    State = "State " + num
                    //ZipCode = 100 + num
                });
            }
        }
    }

    
}
