using System;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiDemo.MVC
{
    [ApiController]
    [Route("[controller]")]
    public class ErrorHandlerController : Controller
    {
        [AllowAnonymous]
        [HttpGet]
        public Object Get()
        {
            string ExceptionMessage = "Hello";
            var exceptionHandlerPathFeature =
                HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            if (exceptionHandlerPathFeature?.Error is FileNotFoundException)
            {
                ExceptionMessage = "File error thrown";
            }

            if (exceptionHandlerPathFeature?.Path == "/index")
            {
                ExceptionMessage += " from home page";
            }

            return new {code = -1, msg = exceptionHandlerPathFeature.Error.Message + exceptionHandlerPathFeature.Path};
        }
    }
}
