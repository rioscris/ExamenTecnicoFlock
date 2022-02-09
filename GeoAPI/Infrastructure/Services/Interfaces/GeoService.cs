using Aplicacion.Modelos;
using Domain;
using Domain.Entities;
using Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Interfaces
{
    public class GeoService : IGeoService
    {
        private GeoAPIContext _context;
        private IHttpClientFactory _clientFactory;
        public GeoService(GeoAPIContext context, IHttpClientFactory clientFactory)
        {
            _context = context;
            _clientFactory = clientFactory;
        }
        
        public async Task<Location> GetLocation(string provinceName)
        {
            ProvinceData provinceData = await _clientFactory.GetRequest<ProvinceData>("https://apis.datos.gob.ar/georef/api/provincias", $"nombre={provinceName}");
            return provinceData.provincias.First().centroide;
        }
    }
}
