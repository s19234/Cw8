using Kolos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolos.Services
{
    public interface IProjectDbService
    {
        public Project GetProject(int id);
        public void AddProject();
    }
}
