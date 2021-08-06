using Academy.TestWeek4.Core;
using Academy.TestWeek4.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Academy.TestWeek4.EF
{
    public class GestioneContext : DbContext
    {
        public DbSet<Cliente> Clienti { get; set; }
        public DbSet<Ordine> Ordini { get; set; }

        public GestioneContext() : base()
        {

        }

        public GestioneContext(DbContextOptions<GestioneContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                string connectionString = "Server=.;Database=GestioneOrdini;Trusted_Connection=True;";
                options.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Ordine>(new OrdineConfiguration());
            modelBuilder.ApplyConfiguration<Cliente>(new ClienteConfiguration());
        }
    }
}
