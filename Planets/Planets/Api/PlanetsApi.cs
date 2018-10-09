using Newtonsoft.Json;
using Planets.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Planets.Api
{
    class PlanetsApi
    {

        public const String BASE_URL = "https://swapi.co/api/planets/";

        public static async Task<PlanetResponse> GetPlanestList(string url)
        {
            HttpClient RestClient = new HttpClient();
            try
            {
                HttpResponseMessage response = await RestClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var JsonResponse = await response.Content.ReadAsStringAsync();
                    PlanetResponse PlanetResponse = JsonConvert.DeserializeObject<PlanetResponse>(JsonResponse);
                    return PlanetResponse;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
