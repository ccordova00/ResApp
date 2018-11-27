using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResApp.Models
{
    public class Skill
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public int YearsExp { get; set; }
        public int? Priority { get; set; }

        public int ApplicantID { get; set; }
        public int CategoryID { get; set; }

        public Applicant Applicant { get; set; }
        public Category Category { get; set; }

    }
}
