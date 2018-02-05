using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Sovellus.Model.Entities;

namespace Sovellus.Data
{
    public class SovellusContext : DbContext
    {
        public DbSet<Alue> Alueet { get; set; }
        public DbSet<Arviointi> Arvioinnit { get; set; }
        public DbSet<Kaupunki> Kaupungit { get; set; }
        public DbSet<Ravintola> Ravintolat { get; set; }
        public DbSet<RavintolaTyyppi> RavintolaTyypit { get; set; }
        public DbSet<Uutinen> Uutiset { get; set; }

        public SovellusContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            foreach (var relationship in modelBuilder.Model) {
                .GetEntityTypes()
                    .SelectMany
            }
        }
    }
}
