using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB;
using MongoDB.Driver;

namespace BjertorpAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class PostController : ControllerBase
    {
        MongoClient dbClient = new MongoClient("mongodb+srv://BjertorpAdmin:Freak219@cluster0.whre4.mongodb.net/myFirstDatabase?retryWrites=true&w=majority");
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public PostController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Object> Get()
        {
            var dbList = dbClient.ListDatabases().ToList();
            foreach (var db in dbList)
            {
              Console.WriteLine(db);
            }
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}