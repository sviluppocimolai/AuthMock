using AuthMock.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;

namespace AuthMock.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class ProjectsController : ControllerBase
    {

        [HttpGet]
        [Route("")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(List<Project>), (int)HttpStatusCode.OK)]
        public IActionResult Get()
        {
            var res = new List<Project>()
            {
                new Project { Code = 2021001, Description = "Pleyel" },
                new Project { Code = 2021002, Description = "Roland Garros" },
                new Project { Code = 2021001, Description = "Pleyel" }
            };

            return Ok(res);
        }
    }
}