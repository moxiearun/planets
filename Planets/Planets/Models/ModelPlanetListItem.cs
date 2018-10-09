using System;
using System.Collections.Generic;
using System.Text;

namespace Planets.Models
{

    public class Planet
    {
        public string name { set; get; }
        public string rotation_period { set; get; }
        public string orbital_period { set; get; }
        public string diameter { set; get; }
        public string climate { set; get; }
        public string gravity { set; get; }
        public string terrain { set; get; }
        public string surface_water { set; get; }
        public string population { set; get; }
        public string[] residents { set; get; }
        public string[] films { set; get; }
        public string created { set; get; }
        public string edited { set; get; }
        public string url { set; get; }
    }

    public class PlanetResponse
    {
        public int count { set; get; }
        public string next { set; get; }
        public string previous { set; get; }
        public List<Planet> results { set; get; }
    }
}
