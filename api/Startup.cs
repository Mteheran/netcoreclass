using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DBContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Microsoft.EntityFrameworkCore.Proxies;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.OData.Edm;
using Microsoft.AspNet.OData.Builder;
using shared.Models;

namespace api
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
           services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            //services.AddDbContext<StoreContext>(p=>
            //p.UseLazyLoadingProxies(false).UseInMemoryDatabase("DBStore"));

            // using Microsoft.EntityFrameworkCore;
            services.AddDbContext<StoreContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddOData();

            services.AddCors();

            services.AddMvc(options => { options.EnableEndpointRouting = false; }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0).AddNewtonsoftJson();

            services.AddResponseCaching();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseResponseCaching();

            app.UseCors(options => 
            {
                options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
            });

            app.UseAuthorization();

            app.UseMvc(routebuilder => 
            {
                routebuilder.Count().Filter().OrderBy().Expand().Select().MaxTop(null);
                routebuilder.MapODataServiceRoute("odata", "odata", GetDemModel());
                routebuilder.EnableDependencyInjection();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        IEdmModel GetDemModel()
        {
            var odataBuilder = new ODataConventionModelBuilder();
            odataBuilder.EntitySet<Category>("Categories");
            odataBuilder.EntitySet<User>("Users");
            odataBuilder.EntitySet<UserType>("UserTypes");

            return odataBuilder.GetEdmModel();
        }

    }
}
