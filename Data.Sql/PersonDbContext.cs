using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Models;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Base;

namespace Data.Sql
{
    public partial class PersonDbContext : DbContext, IUnitOfWork
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            SetupPersonEntity(modelBuilder);
            SetupCountryEntity(modelBuilder);
        }

        private static void SetupPersonEntity(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasKey(p => p.Id);
            modelBuilder.Entity<Person>().Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Person>().Property(p => p.FirstName).IsRequired();
            modelBuilder.Entity<Person>().Property(p => p.LastName).IsRequired();
            modelBuilder.Entity<Person>().Property(p => p.HomeTown).IsRequired();

            modelBuilder.Entity<Person>().HasMany(p => p.VisitedCountries).WithMany(c => c.VisitedBy);
        }

        private static void SetupCountryEntity(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasKey(p => p.Id);
            modelBuilder.Entity<Country>().Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Country>().Property(p => p.Name).IsRequired();
        }

        public DbSet<Person> Persons { get; set; }

        public DbSet<Country> Countries { get; set; }
        
        public new void SaveChanges()
        {
            base.SaveChanges();
        }
    }
}
