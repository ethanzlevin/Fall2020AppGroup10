using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Fall2020AppGroup10.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

namespace Fall2020AppGroup10.Controllers
{
    public class NBAAPIController : Controller
    {
        public string GetStatisticsData()
        {
            var client = new RestClient("https://api-nba-v1.p.rapidapi.com/teams/confName/east");
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-key", "fdfed50160mshc31568e2d648abcp15c35djsn4c40ccb7ace6");
            request.AddHeader("x-rapidapi-host", "api-nba-v1.p.rapidapi.com");
            IRestResponse response = client.Execute(request);

            //ist<Team> data = JsonConvert.DeserializeObject<List<Team>>(response.Content);
            return response.Content;
        }
    }
}
