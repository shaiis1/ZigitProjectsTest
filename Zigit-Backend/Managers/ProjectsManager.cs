using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zigit_Backend.Interfaces;
using Zigit_Backend.Models;

namespace Zigit_Backend.Managers
{
    public class ProjectsManager : IProjectsManager
    {
        private readonly IProjectsDal _projectsDal;
        private readonly ILoginManager _loginManager;

        #region Constructor
        public ProjectsManager(IProjectsDal projectsDal, ILoginManager loginManager)
        {
            _projectsDal = projectsDal;
            _loginManager = loginManager;
        }
        #endregion

        #region Public Methods

        public List<ProjectsModel> GetByIDAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("ID is not valid.");

            return  _projectsDal.GetByIDAsync(id);
        }

        #endregion
    }
}
