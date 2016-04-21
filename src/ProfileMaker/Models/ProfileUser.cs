using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileMaker.Models
{
    public class ProfileUser
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserImage { get; set; }
        public string CopanyName { get; set; }
        public string Address { get; set; }
        public int PostNumber { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string Summary { get; set; }

        public List<String> OtherCourses { get; set; }
        public List<String> TechniqueAreas { get; set; }

        public ICollection<Education> Educations { get; set; }
        public ICollection<ProjectExperiences> ProjectExperienceses { get; set; }
    }
}
