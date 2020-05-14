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
       // public DbSet<Records> Records { get; set; }

        public CovidContext()
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=entityframework;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
        public Records SeedLargData()
        {
            var data = new Records();
            using (var wc = new WebClient())
            {
                var json = wc.DownloadString("https://opendata.ecdc.europa.eu/covid19/casedistribution/json/");
                data = JsonConvert.DeserializeObject<Records>(json, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }
            return data;
        }
   // protected override void Seed()
    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           // modelBuilder.Entity<Records>().HasNoKey();
            //modelBuilder.Entity<Records>().HasData(SeedLargData());

        
            var wc = new WebClient();
            var json = wc.DownloadString("https://opendata.ecdc.europa.eu/covid19/casedistribution/json/");

            var data = JsonConvert.DeserializeObject<Records>(json, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
            uint iterator = 1;
            foreach (var d in data.records)
            {
                
                Dataset dataset = new Dataset() {
                ID=iterator,
                DataRep = d.DataRep,
                day = d.day,
                month = d.month,
                year=d.year,
                cases=d.cases,
                deaths=d.deaths,
                countriesAndTerritories=d.countriesAndTerritories,
                geoId=d.geoId,
                countryterritoryCode=d.countryterritoryCode,
                popData2018=d.popData2018,
                ContinentExp=d.ContinentExp,
                newCases=d.newCases,
                
            };
                ++iterator;
                modelBuilder.Entity<Dataset>().HasData(dataset);
            };
           // modelBuilder.Entity<Records>().HasNoKey();
            
           // modelBuilder.Entity<Records>().HasData(new Records() = data);
           // modelBuilder.Entity<Dataset>().HasData(data);
            


        }

    }
}
