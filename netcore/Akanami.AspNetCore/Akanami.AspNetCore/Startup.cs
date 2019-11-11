using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Akanami.AspNetCore.AkaIdentity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Akanami.AspNetCore.Configurations;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Akanami.AspNetCore
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
            services.AddControllers();




            //var jwtSection = this.Configuration.GetSection("Jwt");

            //JwtOptions jwtOptions = new JwtOptions();
            //jwtSection.Bind(jwtOptions);

            //var jwtOptionsBuilder = services.AddOptions<JwtOptions>("Jwt");

            var jwtSection = this.Configuration.GetSection("Jwt");
            JwtOptions jwtOptions = new JwtOptions();

            jwtSection.Bind(jwtOptions);

            services.AddSingleton<JwtOptions>(jwtOptions);


            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateIssuerSigningKey = true,
                            ValidIssuer = jwtOptions.Issuer,
                            ValidAudience = jwtOptions.Audience,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SecurityKey)),
                            ClockSkew = TimeSpan.Zero
                        };

                        options.Events = new JwtBearerEvents()
                        {
                            OnMessageReceived = async (MessageReceivedContext context) =>
                            {
                                var c = context;
                            }
                        };

                        //options.Events.OnMessageReceived += async (context) =>
                        //{
                        //    await Task.CompletedTask;
                        //};
                    });

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                var connectionString = this.Configuration.GetConnectionString("Default");
                options.UseSqlServer(connectionString);
            });

            
            services.AddAutoMapper(this.GetType().Assembly);

            services.AddIdentityCore<ApplicationUser>()
                    .AddEntityFrameworkStores<ApplicationDbContext>()
                    .AddRoles<ApplicationRole>()
                    .AddRoleManager<ApplicationRoleManager>()
                    .AddUserStore<ApplicationUserStore>()
                    .AddRoleStore<ApplicationRoleStore>()
                    .AddUserManager<ApplicationUserManager>()
                    .AddSignInManager<ApplicationSignInManager>();

            services.AddHttpContextAccessor();

            //services.TryAddScoped<IUserValidator<ApplicationUser>, UserValidator<ApplicationUser>>();
            //services.TryAddScoped<IPasswordValidator<ApplicationUser>, PasswordValidator<ApplicationUser>>();
            //services.TryAddScoped<IPasswordHasher<ApplicationUser>, PasswordHasher<ApplicationUser>>();
            services.TryAddScoped<ILookupNormalizer, UpperInvariantLookupNormalizer>();
            services.TryAddScoped<IRoleValidator<ApplicationRole>, RoleValidator<ApplicationRole>>();
            // No interface for the error describer so we can add errors without rev'ing the interface
            //services.TryAddScoped<IdentityErrorDescriber>();
            services.TryAddScoped<ISecurityStampValidator, SecurityStampValidator<ApplicationUser>>();
            services.TryAddScoped<ITwoFactorSecurityStampValidator, TwoFactorSecurityStampValidator<ApplicationUser>>();
            //services.TryAddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, UserClaimsPrincipalFactory<ApplicationUser, ApplicationRole>>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseAuthentication();
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
