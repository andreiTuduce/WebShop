using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Manager;
using Microsoft.AspNetCore.Mvc;
using WebShopClient.Controllers.Models;

namespace WebShopClient.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private readonly CustomerManager customerManager = new CustomerManager();

        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> WeatherForecasts()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }

        [HttpPost("[action]")]
        public void CreateCustomer([FromBody] Customer customer)
        {

            Core.Model.Customer customerCore = new Core.Model.Customer
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Username = customer.Username,
                Password = customer.Password
            };

            customerManager.CreateCustomer(customerCore);
        }

        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF
            {
                get
                {
                    return 32 + (int)(TemperatureC / 0.5556);
                }
            }
        }
    }
}
