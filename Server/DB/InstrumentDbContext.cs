using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using P8.Server.Controllers;
using P8.Shared;
namespace P8.Server.DB
{
    public class InstrumentDbContext : DbContext
    {
        public InstrumentDbContext(DbContextOptions<InstrumentDbContext> options) : base(options)
        {
        }

        public DbSet<Instrument> Instruments { get; set; }
        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }
    }
}