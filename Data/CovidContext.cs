using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Covid.Models;
using System.Net;
using Newtonsoft.Json;

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
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=entityframework;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           var wc = new WebClient()
           var json = wc.DownloadString("https://opendata.ecdc.europa.eu/covid19/casedistribution/json/");
            var data = JsonConvert.DeserializeObject<Records>(json, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
            var jsonStateList = MyAppResources.StateXml;
            var states = JsonConvert.DeserializeObject<List<State>>(jsonStateList);
            modelBuilder.Entity<State>().HasData(states);
        }

    }
}
