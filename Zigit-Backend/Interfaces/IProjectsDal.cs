using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zigit_Backend.Models;

namespace Zigit_Backend.Interfaces
{
    public interface IProjectsDal
    {
        List<ProjectsModel> GetByIDAsync(Guid id);
    }
}
