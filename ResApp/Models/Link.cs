using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResApp.Models
{
    public class Link
    {
        //For Online Resources section
        public int ID { get; set; }
        public string LinkUrl { get; set; }
        public string Description { get; set; }

        public int ApplicantID { get; set; }

        public Applicant Applicant { get; set; }

    }
}
