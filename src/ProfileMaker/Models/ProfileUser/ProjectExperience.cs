using System;
using System.Collections.Generic;

//Belongs to ProfileUser
namespace ProfileMaker.Models
{
    public class ProjectExperience
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime StopDate { get; set; }
        public string Summary { get; set; }
        public ICollection<TechnicalEnvironment> TechnicalEnvironments { get; set; }
        public int Order { get; set; }
    }
}