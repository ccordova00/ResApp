using ResApp.Models;
using System;
using System.Linq;

namespace ResApp.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ResAppContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Jobs.Any())
            {
                return;   // DB has been seeded
            }

            var applicant = new Applicant
            {
                FirstName = "Corban",
                LastName = "Cordova",
                PhoneNumber = "505-670-4341",
                Address = "2720 Central SE. Ste. G-435, ABQ, NM 87106",
                Email = "corban@simplequantum.com"
            };
            context.Applicant.Add(applicant);
            context.SaveChanges();

            var reference = new Reference
            {
                Name = "Meredith Baker esq.",
                Title = "Attorney at law",
                PhoneNumber = "212-433-0646",
                ApplicantID = context.Applicant.Single(c => c.FirstName == "Corban").ID
            };
            context.References.Add(reference);
            context.SaveChanges();

            //Online Resources
            var link = new Link
            {
                LinkUrl = "https://www.linkedin.com/in/corban-cordova",
                Description = "LinkedIn",
                ApplicantID = context.Applicant.Single(c => c.FirstName == "Corban").ID
            };
            context.Links.Add(link);
            context.SaveChanges();

            //Certifications
            var certs = new Cert[]
            {
                new Cert{Description="Cisco CCENT",
                    DateAcquired = DateTime.Parse("October 2017"),
                    ApplicantID = context.Applicant.Single(c => c.FirstName == "Corban").ID
                    },
                new Cert{Description="(ISC)^2 CISSP",
                DateAcquired=DateTime.Parse("December 2016"),
                Link = "https://www.youracclaim.com/badges/3aec8761-c65d-408b-91e5-bac25ceb94fb/public_url",
                ApplicantID = context.Applicant.Single(c => c.FirstName == "Corban").ID}
            };
            foreach (Cert c in certs)
            {
                context.Certs.Add(c);
            }
            context.SaveChanges();

            //Jobs
            var jobs = new Job[]
            {
                new Job{StartDate = DateTime.Parse("April 1, 2018"),
                    Company= "Integra Technologies",
                    Title="System Administrator/Network Technician",
                    Info="Integra Technologies specializes in full-turnkey die preparation, packaging, testing and characterization of high reliability semiconductor components and related value-added services for the Aerospace & Defense, Space, Semiconductor and Medical industries. Integra services mission-critical applications where dependability and failure-free performance are paramount.",
                    ApplicantID = context.Applicant.Single(c => c.FirstName == "Corban").ID},
                new Job{StartDate = DateTime.Parse("August 27, 2014"),
                    EndDate = DateTime.Parse("March 1, 2018"),
                    Company= "Haarmeyer Electric",
                    Title="IT. Manager/ PLC programmer/ SCADA technician",
                    Info="Haarmeyer Electric inc. is a family owned electrical company that services and supports the energy industry in the Permian Basin. The company was started in 1985 by Mr. and Mrs. Haarmeyer and has grown since then to be one of the most trusted local companies to support energy production companies in southeastern New Mexico and west Texas. Haarmeyer Electric inc. specializes in custom built electrical and automation systems for oil wells, SWDs, and other field operations both large and small. Initially I was hired on as an Automation Technician and was trained to program PLCs for automation projects. At the same time I trained myself to be network admin and oversee SCADA systems for many of Haarmeyer's clients. I was promoted and held the position of I.T. Manager with duties spanning all of the aforementioned including hiring and managing a growing department, networking and PC support. I was the owner’s go-to for anything I.T. related. ",
                    ApplicantID = context.Applicant.Single(c => c.FirstName == "Corban").ID},
            };
            foreach (Job j in jobs)
            {
                context.Jobs.Add(j);
            }
            context.SaveChanges();

            //Responsibilities
            var responsibilities = new Responsibility[]
            {
                new Responsibility{Description= "Support internal users break/fix requests and tickets",
                    JobID = jobs.Single( c => c.Company == "Integra Technologies").ID},
                new Responsibility{Description= "Install, configure, and manage ESXi, vSphere/vCenter servers",
                    JobID = jobs.Single( c => c.Company == "Integra Technologies").ID},
                new Responsibility{Description= "Manage IT department of team ranging from 2 to 4 people",
                    JobID = jobs.Single( c => c.Company == "Haarmeyer Electric").ID},
                new Responsibility{Description= "Maintenance and development of I.T. infrastructure LAN/WAN and servers",
                    JobID = jobs.Single( c => c.Company == "Haarmeyer Electric").ID},

            };
            foreach (Responsibility r in responsibilities)
            {
                context.Responsibilities.Add(r);
            }
            context.SaveChanges();

            //Categories
            var categories = new Category[]
            {
                new Category{Description ="Programming"},
                new Category{Description ="Networking"}
            };
            foreach (Category c in categories)
            {
                context.Categories.Add(c);
            }
            context.SaveChanges();

            //Skills
            var skills = new Skill[]
            {
                new Skill{Description="Python 2/3 (Django)",
                YearsExp=3,
                CategoryID = categories.Single( c => c.Description == "Programming").ID,
                ApplicantID = context.Applicant.Single(c => c.FirstName == "Corban").ID},
                new Skill{Description="UNIX/Linux (Ubuntu, redhat, slackware, Debian)",
                YearsExp=3,
                CategoryID = categories.Single( c => c.Description == "Networking").ID,
                ApplicantID = context.Applicant.Single(c => c.FirstName == "Corban").ID},
            };
            foreach (Skill s in skills)
            {
                context.Skills.Add(s);
            }
            context.SaveChanges();

            //Education
            var programs = new Education[]
            {
                new Education{Degree="General Studies, A.A.",
                    School="Central New Mexico CC",
                    GPA="3.5",
                    GradDate=DateTime.Parse("May 21, 2013"),
                    ApplicantID = context.Applicant.Single(c => c.FirstName == "Corban").ID
                },
                new Education{Degree="Computer Science, A.S.",
                    School="Sanford Brown College",
                    GPA="3.6",
                    GradDate=DateTime.Parse("Aug. 9, 1999"),
                    ApplicantID = context.Applicant.Single(c => c.FirstName == "Corban").ID
                },
            };
            foreach (Education p in programs)
            {
                context.Educations.Add(p);
            }
            context.SaveChanges();

        }
    }
}