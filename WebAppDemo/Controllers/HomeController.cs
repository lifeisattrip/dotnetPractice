using System;
using System.Linq;
using System.Threading.Tasks;
using csharp_practice.EFTest;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApiDemo.Auth;
using WebApiDemo.MVC;

namespace WebAppDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<TestController> _logger;
        private readonly AppDbContext _context;
        private UserManager<MyIdentityUser> _userManager;
        private SignInManager<MyIdentityUser> _signInManager;

        public HomeController(ILogger<TestController> logger, AppDbContext context,
            UserManager<MyIdentityUser> userManager,
            SignInManager<MyIdentityUser> signInManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        public async Task<object> Login([FromBody] LoginDto model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

            if (result.Succeeded)
            {
                var appUser = _userManager.Users.SingleOrDefault(r => r.Email == model.Email);
                return appUser;
            }

            throw new ApplicationException("INVALID_LOGIN_ATTEMPT");
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

    public class LoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
