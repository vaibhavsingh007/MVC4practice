using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Models;
using Data.Base;
using Data.Sql.Initializers;

namespace Data.Sql.Base
{
    public class RepositoryInitializer : IRepositoryInitializer
    {
        private IUnitOfWork unitOfWork;

        public RepositoryInitializer(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException("unitOfWork");
            }

            this.unitOfWork = unitOfWork;

            //Database.DefaultConnectionFactory = new SqlCeConnectionFactory("System.Data.SqlClient");
            Database.DefaultConnectionFactory = new SqlCeConnectionFactory("System.Data.SqlServerCe.4.0");

            // Sets the default database initialization code for working with Sql Server Compact databases
            Database.SetInitializer(new DropCreateIfModelChangesSqlCeInitializer<PersonDbContext>());
        }

        protected PersonDbContext Context
        {
            get { return (PersonDbContext)this.unitOfWork; }
        }

        public void Initialize()
        {
            this.Context.Set<Address>().ToList().Count();
        }
    }
}
