using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ResApp.Models
{
    public class Applicant
    {
        public int ID { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }

        public ICollection<Cert> Certs { get; set; }
        public ICollection<Education> Educations { get; set; }
        public ICollection<Job> Jobs { get; set; }
        public ICollection<Skill> Skills { get; set; }
        public ICollection<Link> Links { get; set; }
        public ICollection<Reference> References { get; set; }
    }
}
