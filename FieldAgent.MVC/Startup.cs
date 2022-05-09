using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FieldAgent.Core.Interfaces.DAL;
using FieldAgent.DAL.Repositories;
using FieldAgent.DAL;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace FieldAgent.MVC
{
    public class Startup
    {
        private const string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
              .AddJwtBearer(options =>
              {
                  options.TokenValidationParameters = new TokenValidationParameters
                  {
                      ValidateIssuer = true,
                      ValidateAudience = true,
                      ValidateLifetime = true,
                      ValidateIssuerSigningKey = true,

                      ValidIssuer = "http://localhost:2000",
                      ValidAudience = "http://localhost:2000",
                      IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("KeyForSignInSecret@1234"))
                  };
                  services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
              });
            
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                    policy =>
                    {
                        policy.AllowAnyHeader();
                        policy.WithOrigins("*", "http://localhost:3002");
                        policy.AllowAnyMethod();
                    });
            });

            services.AddControllers();
            services.AddTransient<IAgencyRepository, AgencyRepository>();
            services.AddTransient<IAgencyAgentRepository, AgencyAgentRepository>();
            services.AddTransient<IAgentRepository, AgentRepository>();
            services.AddTransient<IAliasRepository, AliasRepository>();
            //services.AddTransient<ILocationRepository, LocationRepository>();
            services.AddTransient<IMissionRepository, MissionRepository>();
            //services.AddTransient<ISecurityClearanceRepository, SecurityClearanceRepository>();
            //services.AddTransient<IReportsRepository, ReportsRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();
            
            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
