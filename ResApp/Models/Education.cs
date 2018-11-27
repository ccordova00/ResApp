using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ResApp.Models
{
    public class Education
    {
        public int ID { get; set; }
        public string Degree { get; set; }
        public string School { get; set; }
        public string GPA { get; set; }
        public int ApplicantID { get; set; }

        public Applicant Applicant { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM}", ApplyFormatInEditMode = true)]
        public DateTime GradDate { get; set; }

    }
}
