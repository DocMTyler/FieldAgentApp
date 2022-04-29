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

namespace FieldAgent.MVC
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddTransient<IAgencyRepository, AgencyRepository>();
            services.AddTransient<IAgencyAgentRepository, AgencyAgentRepository>();
            services.AddTransient<IAgentRepository, AgentRepository>();
            //services.AddTransient<IAliasRepository, AliasRepository>();
            //services.AddTransient<ILocationRepository, LocationRepository>();
            //services.AddTransient<IMissionRepository, MissionRepository>();
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
