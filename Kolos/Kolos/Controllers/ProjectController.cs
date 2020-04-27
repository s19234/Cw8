using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Kolos.Services;

namespace Kolos.Controllers
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private IProjectDbService _dbService;

        public ProjectController(IProjectDbService _dbService)
        {
            this._dbService = _dbService;
        }

        [HttpPost("{id}")]
        public IActionResult GetProject([FromRoute] int id)
        {
            var result = _dbService.GetProject(id);
            if (result == null)
                return NotFound("Project was not found on this server");
            return Ok(result);
        }
    }
}