using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Covid.Models
{
    public class Records
    {
        //  public Guid Id { get; set; }
       // [Key]
        //Guid ID = Guid.NewGuid();
        public IList<Dataset> records { get; set; }
    }
}
