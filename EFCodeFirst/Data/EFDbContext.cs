using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using EFCodeFirst.Models;

namespace EFCodeFirst.Data
{
    public class EFDbContext : DbContext
    {
        public EFDbContext() : base("EFDbContext")
        {
            Database.SetInitializer(new DataInitializer());
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected virtual void InitializeDatabase()
        {
            if (!Database.Exists())
            {
                Database.Initialize(true);
            }
        }

    }
}