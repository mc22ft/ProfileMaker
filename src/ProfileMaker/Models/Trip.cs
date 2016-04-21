using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileMaker.Models
{
    public class Trip
    {
        public int id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public string UserName { get; set; }
        public ICollection<Stop> Stops { get; set; }
    }
}
