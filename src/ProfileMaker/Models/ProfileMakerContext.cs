using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ProfileMaker.Models
{
    public class ProfileMakerContext : IdentityDbContext<ProfileMakerUser>
    {
        public ProfileMakerContext()
        {
            Database.EnsureCreated();
        }

        //Main model
        public DbSet<ProfileUser> ProfileUsers { get; set; }

        //Belongs to ProfileUser
        public DbSet<Education> Educations { get; set; }
        public DbSet<OtherCourse> OtherCourses { get; set; }
        public DbSet<TechniqueArea> TechniqueAreas { get; set; }
        public DbSet<ProjectExperience> ProjectExperiences { get; set; }

        //Belongs to ProjectExperiences
        public DbSet<TechnicalEnvironment> TechnicalEnvironments { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connString = Startup.Configuration["Data:ProfileMakerContextConnection"];

            optionsBuilder.UseSqlServer(connString);

            base.OnConfiguring(optionsBuilder);
        }
    }
}
