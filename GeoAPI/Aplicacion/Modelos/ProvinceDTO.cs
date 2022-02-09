using System;
using System.Collections.Generic;

namespace Aplicacion.Modelos
{
    public class Location
    {
        public double lat { get; set; }
        public double lon { get; set; }
    }
    public class ProvinceName
    {
        public string nombre { get; set; }
    }
    public class Province
    {
        public Location centroide { get; set; }
        public string id { get; set; }
        public string nombre { get; set; }
    }
    public class ProvinceData
    {
        public int cantidad { get; set; }
        public int inicio { get; set; }
        public ProvinceName parametros { get; set; }
        public List<Province> provincias { get; set; }
        public int total { get; set; }
    }
}
