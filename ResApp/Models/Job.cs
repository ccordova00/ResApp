using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ResApp.Models
{
    public class Job
    {
        public int ID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM}", ApplyFormatInEditMode = true)]
        public DateTime? EndDate { get; set; }
        public string Company { get; set; }
        public string Title { get; set; }
        public string Info { get; set; }

        public int ApplicantID { get; set; }

        public Applicant Applicant { get; set; }
        public ICollection<Responsibility> Responsibilities { get; set; }
    }
}
