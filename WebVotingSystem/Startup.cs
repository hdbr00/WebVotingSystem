using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebVotingSystem.Models;
using WebVotingSystem.DataAccess.Data;
using WebVotingSystem.DataAccess.Repositorio;
using WebVotingSystem.DataAccess.Repositorio.IRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;
using WebVotingSystem.Utility;
using NETCore.MailKit.Extensions;
using NETCore.MailKit.Infrastructure.Internal;

namespace WebVotingSystem
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
            services.AddScoped<IControlador, Controlador>();
            services.AddMvc();
            services.AddRazorPages();
            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            //Add MailKit
            services.AddMailKit(optionBuilder =>
            {
                optionBuilder.UseMailKit(new MailKitOptions()
                {
                    //get options from secrets.json
                    Server = Configuration["EmailConfiguration:Server"],
                    Port = Convert.ToInt32(Configuration["EmailConfiguration:Port"]),
                    SenderName = Configuration["EmailConfiguration:SenderName"],
                    SenderEmail = Configuration["EmailConfiguration:SenderEmail"],

                    // can be optional with no authentication 
                    Account = Configuration["EmailConfiguration:Account"],
                    Password = Configuration["EmailConfiguration:Password"],
                    // enable ssl or tls
                    Security = true
                });
            });

            services.AddTransient<IEmailSender, EmailSender>();

            services.AddAuthentication().AddFacebook
             (
               options =>
               {
                   options.AppId = Configuration["Authentication:Facebook:AppId"];
                   options.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
               }
             );

            services.ConfigureApplicationCookie(options => { options.LoginPath = "/Identity/Account/Login"; options.LogoutPath = "/Identity/Account/Logout"; options.AccessDeniedPath = "/Identity/Account/AccessDenied"; });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
