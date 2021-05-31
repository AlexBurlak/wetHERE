using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OpenWeatherAPI;


namespace weathere.Controllers
{
    public class WeatherController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly API _client;

        public WeatherController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _client = new API("bed32ed2456be0559f15af6b44c11250");
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GetWeather(string location)
        {
            try
            {
                Query todayWeather = _client.Query(location);
                return View(todayWeather);
            }
            catch
            {
                return NotFound();
            }
        }
    }
}