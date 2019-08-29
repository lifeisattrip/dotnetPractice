using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using csharp_practice.EFTest;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApiDemo.MVC
{
    [ApiController]
    public class WeatherForecastController : ApiBaseController
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly AppDbContext _context;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IEnumerable<SysUser> Get()
        {
            List<SysUser> list = _context.SysUsers.Where(u => u.UserName.Contains("3")).ToList();
            return list;
        }
    }
}
