using Aplicacion.Modelos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface IGeoService
    {
        Task<Location> GetLocation(string provinceName);
    }
}
