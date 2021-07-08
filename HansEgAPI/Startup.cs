using AutoMapper;
using HansEgAPI.Data;
using HansEgAPI.Models;
using HansEgAPI.Repository;
using HansEgAPI.Repository.ClientRepo;
using HansEgAPI.Repository.OrderRepo;
using HansEgAPI.Services;
using HansEgAPI.Services.ClientService;
using HansEgAPI.Services.GovernorateService;
using HansEgAPI.Services.OrderService;
using HansEgAPI.Services.RegionService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HansEgAPI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var key = "this is my test key";


            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
                //options.Authority = $"https://{Configuration["Auth0:Domain"]}/";
                //options.Audience = Configuration["Auth0:Audience"];
            });


            services.AddDbContext<HansContext>(opt => opt.UseSqlServer
                (Configuration.GetConnectionString("HansEgConnection")));
            services.AddControllers().AddNewtonsoftJson(s =>
            {
                s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });


            //services.AddSwaggerGen();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyProject", Version = "v1.0.0" });

                //👇 new code
                var securitySchema = new OpenApiSecurityScheme
                {
                    Description = "Using the Authorization header with the Bearer scheme.",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                };

                c.AddSecurityDefinition("Bearer", securitySchema);

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { securitySchema, new[] { "Bearer" } }
                });
                //👆 new code
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Governorate
            services.AddScoped<IAsyncGovernorateRepo, SqlAsyncGovernorateRepo>();
            services.AddScoped<IAsyncGovernorateService, AsyncGovernorateService>();
            
            // Region
            services.AddScoped<IAsyncRegionRepo, SqlAsyncRegionRepo>();
            services.AddScoped<IAsyncRegionService, AsyncRegionService>();

            // Client
            services.AddScoped<IAsyncClientRepo, SqlAsyncClientRepo>();
            services.AddScoped<IAsyncClientService, AsyncClientService>();

            // Order
            services.AddScoped<IAsyncOrderRepo, SqlAsyncOrderRepo>();
            services.AddScoped<IAsyncOrderService, AsyncOrderService>();

            // Jwt Manager
            services.AddSingleton<IJwtAuthManager>(new JwtAuthManager(key));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
