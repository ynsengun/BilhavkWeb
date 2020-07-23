using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BilhavkWeb.Models
{
    public class DataContext:DbContext
    {
        public DataContext():base("db")
        {
            Database.SetInitializer(new DataInitializer());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Day> Days { get; set; }
        public DbSet<Participant> Participants { get; set; }

    }
}