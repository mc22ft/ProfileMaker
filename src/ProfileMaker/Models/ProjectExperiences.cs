using System;
using System.Collections.Generic;

namespace ProfileMaker.Models
{
    public class ProjectExperiences
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
       
        public DateTime StartDate { get; set; }
        public DateTime StopDate { get; set; }
        public string Summary { get; set; }
        public List<String> TechnicalEnvironment { get; set; }
    }
}