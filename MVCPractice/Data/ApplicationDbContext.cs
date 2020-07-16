using MVCPractice.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCPractice.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base(@"Data Source=L2010217\SQLEXPRESS;Initial Catalog=MVCPracticedb;Integrated Security=True")
        {
        }
        public DbSet<Person> Persons { get; set; }
    }
}