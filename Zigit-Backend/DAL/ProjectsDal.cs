using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zigit_Backend.DbContent;
using Zigit_Backend.Interfaces;
using Zigit_Backend.Models;

namespace Zigit_Backend.DAL
{
    public class ProjectsDal : IProjectsDal
    {
        private readonly ZigitContext _zigitContext;
        #region Constructor
        public ProjectsDal(ZigitContext zigitContext)
        {
            _zigitContext = zigitContext;
        }

        #endregion

        #region Public Methods
        public List<ProjectsModel> GetByIDAsync(Guid id)
        {
            return  _zigitContext.Projects.Where(e => e.UserID == id).ToList();
        }
        #endregion
    }
}
