using Microsoft.AspNetCore.Identity;

namespace WebApiDemo.Auth
{
    public class MyIdentityRole:IdentityRole
    {
        public string Description { get; set; }
    }
}
