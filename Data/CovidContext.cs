using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Covid.Models;

namespace Covid.Data
{
    public class CovidContext : DbContext
    {
        public DbSet<Dataset> Datas { get; set; }
        public DbSet<Records> Records { get; set; }

        public CovidContext()
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
