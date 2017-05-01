using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SonOfCod.Models;

namespace SonOfCod
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; set; }
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json");
            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddEntityFramework()
                .AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            var context = app.ApplicationServices.GetService<ApplicationDbContext>();
            AddTestData(context);

            app.UseStaticFiles();
            app.UseIdentity();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Admin}/{action=Index}/{id?}");
            });

            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context1) =>
            {
                await context1.Response.WriteAsync("Hello World!");
            });
        }

        private static void AddTestData(ApplicationDbContext context)
        {
            var seedMarketingContent = new Models.MarketingPageContent
            {
                Title = "Our Products",
                Tagline = "The key to good seafood is freshness!",
                Introduction = "Being a vertically integrated company allows Pacific Seafood to receive, process and deliver seafood quickly and efficiently. With plants stretching the Pacific Coastline from Alaska to Mexico, we have access to a wide variety of species and offer you a diverse selection of product types and forms.",
                ImageLink = "https://static01.nyt.com/images/2015/12/29/dining/29salmon-21/29salmon-21-superJumbo.jpg"
            };
            context.MarketingPageContents.Add(seedMarketingContent);
            context.SaveChanges();
        }
    }
}
