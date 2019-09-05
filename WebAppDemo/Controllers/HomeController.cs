using System;
using System.Linq;
using csharp_practice.EFTest;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApiDemo.MVC;

namespace WebAppDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<TestController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<TestController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        PagedResult<SysUser> TestSortPageData()
        {
            PagedResult<SysUser> pagedResult = _context.SysUsers.OrderByDescending(u => u.Id).GetPaged(1, 10);
            return pagedResult;
        }

        [HttpGet]
        public Object Index()
        {
            return TestSortPageData();
        }
    }
}
