using EasyData.Services;
using MailSender.Models;
using MailSender.Service;
using MailSender.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using EasyData.Services;
using System;

namespace MailSender
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<MailSender.Models.AppContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


            services.AddIdentity<User, IdentityRole>(optins =>
            {
                optins.Password.RequireDigit = false;
                optins.Password.RequireLowercase = false;
                optins.Password.RequireNonAlphanumeric = false;
                optins.Password.RequiredLength = 6;

                optins.User.RequireUniqueEmail = false;
                optins.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                optins.SignIn.RequireConfirmedEmail = false;
            })
                  .AddEntityFrameworkStores<MailSender.Models.AppContext>()
                  .AddDefaultTokenProviders();

            services.AddTransient<IMailService, MailService>();
            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));            
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");

                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints => {
                endpoints.MapEasyData(options => {
                    options.UseDbContext<MailSender.Models.AppContext>();
                });
                endpoints.MapControllers();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

           
        }
    }
}
