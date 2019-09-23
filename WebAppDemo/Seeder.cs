using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using csharp_practice.EFTest;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace WebAppDemo
{


namespace RazorPagesMovie.Models
{
    public static class Seeder
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AppDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<AppDbContext>>()))
            {
                //  context.Database.EnsureCreated();
                //  you can use
                //  the DbContext.Database.Migrate() method to ensure the database is created and
                //  all migrations 
                context.Database.Migrate();
            }
        }
    }
}
}
