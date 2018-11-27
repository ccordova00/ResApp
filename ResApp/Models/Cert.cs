using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ResApp.Models
{
    public class Cert
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public DateTime DateAcquired { get; set; }
        public DateTime? DateExpired { get; set; }
        public string Link { get; set; }

        [Display(Name = "Applicant")]
        public int ApplicantID { get; set; }

        public Applicant Applicant { get; set; }

    }
}
