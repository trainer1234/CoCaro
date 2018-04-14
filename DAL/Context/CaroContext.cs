using CoCaro.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCaro.DAL.Context
{
    public class CaroContext : DbContext
    {
        public CaroContext()
        {

        }

        public DbSet<Move> Moves { get; set; }
        public DbSet<Game> Games { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("COCARO");
        }
    }
}
