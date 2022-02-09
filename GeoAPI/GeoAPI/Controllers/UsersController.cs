using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUsersService _usersService;

        public UsersController(ILogger<UsersController> logger, IUsersService usersService)
        {
            _logger = logger;
            _usersService = usersService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Retorna la lista completa de usuarios")]
        public ActionResult Get()
        {
            return Ok(_usersService.GetUsers());
        }
        [HttpPost]
        [SwaggerOperation(Summary = "Recibe un usuario y lo guarda en el sistema")]
        public ActionResult SaveUser([FromBody]User user)
        {
            return Ok(_usersService.SaveUser(user));
        }
    }
}
