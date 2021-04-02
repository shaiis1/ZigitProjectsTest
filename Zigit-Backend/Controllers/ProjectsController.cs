using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zigit_Backend.Helpers;
using Zigit_Backend.Interfaces;
using Zigit_Backend.Models;

namespace Zigit_Backend.Controllers
{
    [Route("Projects")]
    [ApiController]
    public class ProjectsController: ControllerBase
    {
        private readonly IProjectsManager _projectsManager;
        private readonly ILoginManager _loginManager;

        #region Constructor
        public ProjectsController(IProjectsManager projectsManager, ILoginManager loginManager)
        {
            _projectsManager = projectsManager;
            _loginManager = loginManager;
        }
        #endregion

        #region Public API Methods

        [HttpGet]
        [Route("GetByID/{id}")]
        [JWTValidation]
        public IActionResult GetByID(Guid id)
        {
            try
            {
                return Ok(_projectsManager.GetByIDAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest($"Bad Request Here {ex.Message}");
            }
        }

        #endregion
    }
}
