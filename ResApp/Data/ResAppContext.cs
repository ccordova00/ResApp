using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ResApp.Models;

namespace ResApp.Data
{
    public class ResAppContext : DbContext
    {
        public ResAppContext(DbContextOptions<ResAppContext> options)
            : base(options)
        {
        }

        //public DbSet<PhonesMvc.Models.Phone> Phone { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cert> Certs { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Responsibility> Responsibilities { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<Reference> References { get; set; }
        public DbSet<Applicant> Applicants { get; set; }

        // This is unnecessary but it demonstrates how to override the default 
        // table names
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<Cert>().ToTable("Cert");
            modelBuilder.Entity<Education>().ToTable("Education");
            modelBuilder.Entity<Job>().ToTable("Job");
            modelBuilder.Entity<Responsibility>().ToTable("Responsibility");
            modelBuilder.Entity<Skill>().ToTable("Skill");
        }

        // This is unnecessary but it demonstrates how to override the default 
        // table names
        public DbSet<ResApp.Models.Reference> Reference { get; set; }

        // This is unnecessary but it demonstrates how to override the default 
        // table names
        public DbSet<ResApp.Models.Applicant> Applicant { get; set; }

    }
}
