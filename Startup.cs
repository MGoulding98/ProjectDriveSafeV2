using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProjectDriveSafeV2.Data;
using ProjectDriveSafeV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.ML.OnnxRuntime;

namespace ProjectDriveSafeV2
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
                // This lambda determines whether user consent for non-essential 
                // cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                // requires using Microsoft.AspNetCore.Http;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<RDSContext>(options =>
            {
                string connection = Environment.GetEnvironmentVariable("CrashesDBConnection");
                options.UseMySql(connection);
            });

            // Identity context files
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                string connection = Environment.GetEnvironmentVariable("IdentityConnection");
                options.UseMySql(connection);
            });

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            // Modified password options
            services.Configure<IdentityOptions>(options =>
            {
                // Default Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 10;
                options.Password.RequiredUniqueChars = 1;
            });

            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddScoped<ICollisionRepository, EFCollisionRepository>();

            services.AddSingleton<InferenceSession>(
                new InferenceSession("wwwroot/best_model.onnx")
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add(
                    "content-security-policy",
                    "default-src 'self'; " +
                    "script-src 'self' 'unsafe-inline'; " +
                    "script-src-elem 'self' 'unsafe-inline' 'unsafe-eval' 'https://public.tableau.com/javascripts/api/viz_v1.js'; " +
                    "style-src 'unsafe-inline'; " +
                    "style-src-elem 'self' 'unsafe-inline'; " +
                    "img-src 'self'");

                await next();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("countypage", "{county}/{pageNum}", new { Controller = "Home", action = "ViewCrashes" });

                endpoints.MapControllerRoute("county", "{county}", new { Controller = "Home", action="ViewCrashes", pageNum = 1 });

                //endpoints.MapControllerRoute(
                //    name: "Paging",
                //    pattern: "{pageNum}",
                //    new { Controller = "Home", action="ViewCrashes"});

                endpoints.MapRazorPages();

                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
