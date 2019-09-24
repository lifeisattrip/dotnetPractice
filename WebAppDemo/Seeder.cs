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

                    if (context.SysRes.Any())
                    {
                        return;
                    }
                    context.SysRes.AddRange(
                        new SysRes
                        {
                            Id=1,
                            ResName="resName1",
                            GmtCreate= DateTime.Now
                        },
                        new SysRes
                        {
                            Id=2,
                            ResName="resName3",
                            GmtCreate= DateTime.Now
                        },
                        new SysRes
                        {
                            Id=3,
                            ResName="resName中文",
                            GmtCreate= DateTime.Now
                        }
                    );
                    context.SaveChanges();
            }
        }
    }
}
}
