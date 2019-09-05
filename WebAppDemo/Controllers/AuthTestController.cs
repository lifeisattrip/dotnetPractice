using Microsoft.AspNetCore.Mvc;
using WebApiDemo.Auth;

namespace WebApiDemo.Controllers
{
    [Route("authTest")]
    public class AuthTestController : Controller
    {
        [ClaimRequirement(MyClaimTypes.Permission, "CanReadResource")]
        [HttpGet]
        public IActionResult GetResource()
        {
            return Ok();
        }
    }
}
