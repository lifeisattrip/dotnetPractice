using System;
using Microsoft.AspNetCore.Identity;

namespace WebApiDemo.Auth
{
    public class MyIdentityUser : IdentityUser
    {
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
