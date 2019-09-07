using csharp_practice.EFTest;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApiDemo.Auth;
using WebApiDemo.MVC;

namespace WebApiDemo.Controllers
{
    public class AuthTestController : Controller
    {
        private ILogger<TestController> _logger;
        private AppDbContext _context;
        private UserManager<MyIdentityUser> _userManager;
        private SignInManager<MyIdentityUser> _signInManager;

        public AuthTestController(ILogger<TestController> logger, AppDbContext context,
            UserManager<MyIdentityUser> userManager,
            SignInManager<MyIdentityUser> signInManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }


        [ClaimRequirement(MyClaimTypes.Permission, "CanReadResource")]
        [HttpGet]
        public IActionResult GetResource()
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Register([FromBody] RegisterViewModel registerObj)
        {
            if (ModelState.IsValid)
            {
                MyIdentityUser user = new MyIdentityUser();
                user.UserName = registerObj.UserName;
                user.Email = registerObj.Email;
                user.FullName = registerObj.FullName;
                user.BirthDate = registerObj.BirthDate;

                IdentityResult result = _userManager.CreateAsync(user, registerObj.Password).Result;
                _logger.LogError(result.ToString());
            }
            else
            {
                foreach (var modelStateValue in ModelState.Values)
                {
                    foreach (var modelError in modelStateValue.Errors)
                    {
                        _logger.LogError(modelError.Exception, modelError.ErrorMessage);
                    }
                }
            }

            return Json(true);
        }
    }
}
