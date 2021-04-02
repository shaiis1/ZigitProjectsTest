using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zigit_Backend.DAL;
using Zigit_Backend.DbContent;
using Zigit_Backend.Helpers;
using Zigit_Backend.Interfaces;
using Zigit_Backend.Managers;

namespace Zigit_Backend
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

            AddScopes(services);
            AddCorsPolicy(services, "CorsPolicy");

            // Add DbContext
            services.AddDbContext<ZigitContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ZigitContext")));

            // Camle Cast Handle.
            services.AddControllers().AddJsonOptions(options => { options.JsonSerializerOptions.PropertyNamingPolicy = null; });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseCors("CorsPolicy");
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

        #region Private Methods
        private void AddCorsPolicy(IServiceCollection services, string name)
        {
            services.AddCors(o => o.AddPolicy(name, builder =>
            {
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            }));
        }

        private void AddScopes(IServiceCollection services)
        {
            services.AddScoped<IProjectsDal, ProjectsDal>();
            services.AddScoped<IProjectsManager, ProjectsManager>();

            services.AddScoped<ILoginDal, LoginDal>();
            services.AddScoped<ILoginManager, LoginManager>();

            services.AddScoped<IAuthenticationHelper, AuthenticationHelper>();
        }
        #endregion
    }
}
