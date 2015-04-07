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

        public IEnumerable<Person> GetPersons()
        {
            return GetDbSet<Person>().AsEnumerable();
        }


        public Person GetPersonById(int id)
        {
            return GetDbSet<Person>().FirstOrDefault(p => p.Id == id);
        }
    }
}
