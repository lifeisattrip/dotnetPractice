using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using csharp_practice.EFTest;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApiDemo.MVC
{
    // 会覆盖上层路由  ApiBaseController里面的
    [Route("api/v1/[controller]/[action]")]
    public class TestController : ApiBaseController
    {
        private readonly ILogger<TestController> _logger;
        private readonly AppDbContext _context;

        public TestController(ILogger<TestController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public PagedResult<SysUser> Index()
        {
            PagedResult<SysUser> pagedResult = _context.SysUsers.OrderByDescending(u => u.Id).GetPaged(1, 10);

            return pagedResult;
        }

        [HttpGet]
        public Object Test(int id)
        {
            PagedResult<SysUser> pagedResult = _context.SysUsers.OrderByDescending(u => u.Id).GetPaged(2, 10);

            return new {Page = pagedResult, Param = id};
        }

        [HttpGet]
        public Object Exception()
        {
            int a = 100 - 50 - 50;
            int i = 10 / a;
            return i;
        }
    }
}
