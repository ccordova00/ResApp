using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResApp.Models
{
    public class Responsibility
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public int JobID { get; set; }

        public Job Job { get; set; }

    }
}
