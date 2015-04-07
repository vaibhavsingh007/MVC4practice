using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Base;

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

            for (int i = 0; i < personNames.Count(); i++)
            {
                Persons.Add(new Models.Person
                {
                    FirstName = personNames[i],
                    Age = 20 + i,
                    HomeTown = ((char)(65 + i)).ToString(),
                    LastName = "Anderson"
                }
                    );
            }
        }
    }

    
}
