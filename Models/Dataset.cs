using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Covid.Models
{
    public class Dataset
    {
        // public Guid ID { get; set; }
       // [Key]
       // Guid ID = Guid.NewGuid();
        public string DataRep { get; set; }
        public uint day { get; set; }
        public uint month { get; set; }
        public uint year { get; set; }
        public int cases { get; set; }
        public int deaths { get; set; }
        public string countriesAndTerritories { get; set; }
        public string geoId { get; set; }
        public string countryterritoryCode { get; set; }
        public ulong? popData2018 { get; set; }
        public string ContinentExp { get; set; }
        public string newCases { get; set; }
    }

}

