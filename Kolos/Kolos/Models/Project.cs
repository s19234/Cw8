using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolos.Models
{
    public class Project
    {
        public int IdTeam { get; set; }
        public string Name { get; set; }
        public DateTime Deadline { get; set; }
        public List<Task> Tasks { get; set; }

    }
}
