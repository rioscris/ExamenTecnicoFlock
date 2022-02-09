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
    public class LocationsController : ControllerBase
    {
        private readonly ILogger<LocationsController> _logger;
        private readonly IGeoService _geoService;

        public LocationsController(ILogger<LocationsController> logger, IGeoService geoService)
        {
            _logger = logger;
            _geoService = geoService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Devuelve la longitud y latitud del centroide de una provincia a partir del nombre. Ej: 'Santiago del Estero'")]
        public async Task<ActionResult> Get(string province)
        {
            _logger.LogInformation($"Obteniendo datos de la provincia {province}");
            return Ok(await _geoService.GetLocation(province));
        }
    }
}
