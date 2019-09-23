using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using csharp_practice.EFTest;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WebApiDemo.Auth;

namespace WebAppDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddDbContext<AppDbContext>(opt =>
                    opt.UseSqlite(Configuration.GetConnectionString("SQLite"))
//                opt.UseMySQL(Configuration.GetConnectionString("Database"))
            );


            services.AddDefaultIdentity<MyIdentityUser>()
                .AddEntityFrameworkStores<AppDbContext>();

            services.AddMvc(
                options =>
                {
//                    options.MaxModelValidationErrors = 50;
//                    options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(
//                        (_) => "该项内容不能为空！"
//                    );
                }
            ).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = $"/Test/ErrorCode";
                options.LogoutPath = $"/Test/ErrorCode";
                options.AccessDeniedPath = $"/Test/ErrorCode";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
                app.UseExceptionHandler("/ErrorHandler");
            }

//            web    api
//            app.UseHttpsRedirection();
//            app.UseMvc();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();


            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}
