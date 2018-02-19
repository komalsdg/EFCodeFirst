using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EFCodeFirst.Models;

namespace EFCodeFirst.Data
{
    public class DataInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<EFDbContext>
    {
        protected override void Seed(EFDbContext context)
        {
            base.Seed(context);

            var clients = new List<Client>
            {
                new Client{ClientName="Client1"},
                new Client{ ClientName="Client2"},
                new Client{ClientName="Client3"}
            };

            clients.ForEach(c => context.Clients.Add(c));
            context.SaveChanges();
        }
    }
}