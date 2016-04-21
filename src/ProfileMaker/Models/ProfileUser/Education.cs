using System;

namespace ProfileMaker.Models
{
    public class Education
    {
        public int Id { get; set; }
        public string SchoolName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime StopDate { get; set; }
        public int Order { get; set; }
    }
}