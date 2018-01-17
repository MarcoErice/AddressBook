using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AddressBook.Data;
using AddressBook.Models;
using AddressBook.Services;
using AddressBook.Interfaces;
using System.Globalization;
using Microsoft.AspNetCore.Localization;

namespace AddressBook
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
            
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseInMemoryDatabase(Configuration.GetConnectionString("DefaultConnection")));
            //options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            iTimeProvider myFakeTimeProvider = new FakeTimeProvider();
            myFakeTimeProvider.Now = DateTime.Now;            
            services.AddSingleton<iTimeProvider>(myFakeTimeProvider);

            //services.AddLocalization(options => options.ResourcesPath = "");
            services.AddLocalization();
            services.AddMvc();
                //.AddViewLocalization()
                //.AddDataAnnotationsLocalization();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ApplicationDbContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.Use((request, next) =>
            {
                var es = new CultureInfo("es-CL");
                System.Threading.Thread.CurrentThread.CurrentCulture = es;
                System.Threading.Thread.CurrentThread.CurrentUICulture = es;
                return next();
            });
            //app.Use((stx, next) =>
            //{
            //    var cultureQuery = stx.Request.Query["culture"];
            //    if (!string.IsNullOrWhiteSpace(cultureQuery))
            //    {
            //        var culture = new CultureInfo(cultureQuery);
            //        CultureInfo.CurrentCulture = culture;
            //        CultureInfo.CurrentUICulture = culture;
            //    }
            //    else
            //    {
            //        var culture = new CultureInfo("sv-SE");
            //        CultureInfo.CurrentCulture = culture;
            //        CultureInfo.CurrentUICulture = culture;
            //    }
            //    return next();
            //});
            //List<CultureInfo> supportedCultures = new List<CultureInfo>
            //{
            //    new CultureInfo("en-US"),
            //    new CultureInfo("es-CL"),
            //    new CultureInfo("es"),
            //    new CultureInfo("sv")                
            //};

            //app.UseRequestLocalization(new RequestLocalizationOptions
            //{
            //    DefaultRequestCulture = new RequestCulture("es-CL"),
            //    SupportedCultures = supportedCultures,
            //    SupportedUICultures = supportedCultures
            //});

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}/{slug?}");
            });

            SeedData.Initialize(context);
        }
    }
}
