using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResApp.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string Description { get; set; }

        public ICollection<Skill> Skills { get; set; }

    }
}
