using Aplicacion.Modelos;
using Domain;
using Domain.Entities;
using Infrastructure.Helpers;
using Microsoft.Extensions.Configuration;
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
        private IConfiguration _configuration;
        public GeoService(GeoAPIContext context, IHttpClientFactory clientFactory, IConfiguration configuration)
        {
            _context = context;
            _clientFactory = clientFactory;
            _configuration = configuration;
        }
        
        public async Task<Location> GetLocation(string provinceName)
        {
            var apiUrl = _configuration.GetSection("PublicUrls").GetSection("APIProvincias").Value;
            ProvinceData provinceData = await _clientFactory.GetRequest<ProvinceData>(apiUrl, $"nombre={provinceName}");
            return provinceData.provincias.First().centroide;
        }
    }
}
