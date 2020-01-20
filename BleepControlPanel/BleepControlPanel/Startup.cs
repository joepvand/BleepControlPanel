using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using BleepControlPanel.Areas.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using BleepControlPanel.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BleepControlPanel.Models;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace BleepControlPanel
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


            services.Configure<IdentityOptions>(options =>
            {
                // Default Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                
            });

            services.AddIdentity<IdentityUser, IdentityRole>(config => { config.SignIn.RequireConfirmedEmail = false; })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultUI()
                .AddDefaultTokenProviders();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("AzureConnection")));

//            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
//                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddRazorPages();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider services)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
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
                endpoints.MapControllers();
                endpoints.MapRazorPages();

            });
            

            CreateRoles(services).Wait();
        }

        //This method adds the users
        private async Task CreateRoles(IServiceProvider serviceProvider)
        {
            //adding custom roles
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            string[] roleNames = { "Admin", "Manager", "Member" };
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                //creating the roles and seeding them to the database
                var roleExist = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            //creating a super user who could maintain the web app
            var poweruser = new IdentityUser
            {
                UserName = Configuration.GetSection("UserSettings")["UserEmail"],
                Email = Configuration.GetSection("UserSettings")["UserEmail"]
            };

            string UserPassword = Configuration.GetSection("UserSettings")["UserPassword"];
            var _user = await UserManager.FindByEmailAsync(Configuration.GetSection("UserSettings")["UserEmail"]);

            if(_user == null)
            {
                var createPowerUser = await UserManager.CreateAsync(poweruser, UserPassword);
                if (createPowerUser.Succeeded)
                {
                    //here we tie the new user to the "Admin" role 
                    await UserManager.AddToRoleAsync(poweruser, "Admin");

                }
            }
        }
    }
}
