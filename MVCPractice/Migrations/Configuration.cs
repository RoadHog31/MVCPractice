namespace MVCPractice.Migrations
{
    using MVCPractice.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MVCPractice.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MVCPractice.Data.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            var personSeeded = new List<Person>
            {
                new Person { FirstName = "Stephen", LastName = "Pino", Age = 41, IsActive = true },
                new Person { FirstName = "Troy", LastName = "Bayliss", Age = 35, IsActive = true },
                new Person { FirstName = "Valentino", LastName = "Rossi", Age = 42, IsActive = true },
                new Person { FirstName = "Abhimanyu K Vatsa", LastName = "Bokaro", Age = 30, IsActive = true },
                new Person { FirstName = "Tess", LastName = "Bokaro", Age = 25, IsActive = true }
            };
            personSeeded.ForEach(p => context.Persons.Add(p));
            context.SaveChanges();
        }
    }
}
