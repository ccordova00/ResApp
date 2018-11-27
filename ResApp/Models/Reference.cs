using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResApp.Models
{
    public class Reference
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string PhoneNumber { get; set; }
        public string Company { get; set; }

        public int ApplicantID { get; set; }

        public Applicant Applicant { get; set; }
    }
}
