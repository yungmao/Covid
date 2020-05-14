using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid.Models
{
    public class Records
    {
        public Guid Id { get; set; }
        public ICollection<Dataset> records { get; set; }
    }
}
