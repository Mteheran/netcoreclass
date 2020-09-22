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
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using System.Reflection;
using System.IO;

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
           services.AddControllers(options=> {
                options.EnableEndpointRouting = false;
                var policy = new AuthorizationPolicyBuilder()
                                        .RequireAuthenticatedUser()
                                        .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
           }
           );

            //services.AddDbContext<StoreContext>(p=>
            //p.UseLazyLoadingProxies(false).UseInMemoryDatabase("DBStore"));

            // using Microsoft.EntityFrameworkCore;
            services.AddDbContext<StoreContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddCors(options => 
            {
                options.DefaultPolicyName = "default";

                options.AddPolicy("default",
                builder => {
                    builder.AllowAnyHeader().WithMethods("GET", "POST");
                });

                options.AddPolicy("category",
                builder => {
                    builder.AllowAnyHeader().WithMethods("GET", "POST", "PUT")
                        .WithOrigins("http://127.0.0.1:5500");
                });
            });

            var key = Encoding.ASCII.GetBytes(Configuration.GetValue<string>("SecretKey"));

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options => {

                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateLifetime =  true,
                        ValidIssuer = "",
                        ValidAudience = "",
                        ValidateAudience = false,
                        ValidateIssuer = false,
                        ValidateIssuerSigningKey= true
                    };
            });  

            services.AddMvc(options => { 
                options.EnableEndpointRouting = false; 
            }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0).AddNewtonsoftJson();

            services.AddResponseCaching();

            //services.AddOData(); 

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Web API",
                    Description = "Class demo",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Shayne Boyer",
                        Email = string.Empty,
                        Url = new Uri("https://twitter.com/spboyer"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under LICX",
                        Url = new Uri("https://example.com/license"),
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });    
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "api netcore");
            });

            app.UseRouting();

            app.UseResponseCaching();

            app.UseCors("default");

            app.UseAuthentication();

            app.UseAuthorization();

            //app.UseMvc(routeBuilder =>
            //{
            //    routeBuilder.Expand().Select().OrderBy().Filter();
            //    routeBuilder.EnableDependencyInjection();
            //    routeBuilder.MapODataServiceRoute("odata", "odata", GetEdmModel());
            //});


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        IEdmModel GetEdmModel()
        {
            var odataBuilder = new ODataConventionModelBuilder();
            odataBuilder.EntitySet<Category>("Categories");
            odataBuilder.EntitySet<User>("Users");
            odataBuilder.EntitySet<UserType>("UserTypes");

            return odataBuilder.GetEdmModel();
        }

    }
}
