using ProfileMaker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileMaker.ViewModels
{
    public class ProfileUserViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserImage { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public int PostNumber { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        //[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")] TIPS!
        public DateTime Date { get; set; } = DateTime.Now;
        public string Summary { get; set; }

        public IEnumerable<OtherCourse> OtherCourses { get; set; }
        //public ICollection<TechniqueArea> TechniqueAreas { get; set; }

        //public ICollection<Education> Educations { get; set; }
        //public ICollection<ProjectExperience> ProjectExperiences { get; set; }
    }
}
