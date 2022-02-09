using AliGulmen.Week5.HomeWork.RestfulApi.Entities;
using AliGulmen.Week5.HomeWork.RestfulApi.Filters;
using AliGulmen.Week5.HomeWork.RestfulApi.Middlewares;
using AliGulmen.Week5.HomeWork.RestfulApi.Repositories;
using AliGulmen.Week5.HomeWork.RestfulApi.Repositories.ContainerRepositories;
using AliGulmen.Week5.HomeWork.RestfulApi.Repositories.LocationRepositories;
using AliGulmen.Week5.HomeWork.RestfulApi.Repositories.ProductRepositories;
using AliGulmen.Week5.HomeWork.RestfulApi.Repositories.RotationRepositories;
using AliGulmen.Week5.HomeWork.RestfulApi.Repositories.UomRepositories;
using AliGulmen.Week5.HomeWork.RestfulApi.Services.LoggerService;
using AliGulmen.Week5.HomeWork.RestfulApi.Services.StorageService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Text;

namespace AliGulmen.Week5.HomeWork.RestfulApi
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
            //we add filters to controller. Because we want it works in each reponse time!

            services.AddControllers(config =>
            {
                config.Filters.Add(new CreationTimeFilter());
                config.Filters.Add(new ResponseTimeFilter());
            });



            // For Entity Framework  
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));

            // For Identity  
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();





            // https://www.c-sharpcorner.com/article/authentication-and-authorization-in-asp-net-core-web-api-with-json-web-tokens/
            services.AddAuthentication(
                options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                }
                )


                //Adding JWT Bearer
                .AddJwtBearer(
                 options =>
                 {
                     options.SaveToken = true;
                     options.TokenValidationParameters = new TokenValidationParameters
                     {
                         ValidateAudience = true,                       //will it check audience?
                         ValidAudience = Configuration["Jwt:Audience"], //appsettings.json > Jwt > Audience
                         ValidateIssuer = true,                         //will it check issuer?
                         ValidIssuer = Configuration["Jwt:Issuer"],     //appsettings.json > Jwt > Issuer
                         ValidateLifetime = true,                       //we will define different life times for different tokens. Not here.
                         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"])),
                         ClockSkew = TimeSpan.Zero

                     };


                 }
                 );

            services.AddScoped<TokenGenerator>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AliGulmen.Week5.HomeWork.RestfulApi", Version = "v1" });
            });

            services.AddSingleton<ILoggerService, TextFileLogger>();
            services.AddSingleton<IStorageService, WarehouseStorage>();


            services.AddMemoryCache();

            services.AddSingleton<IContainerRepository, InMemContainerRepository>();
            services.AddSingleton<ILocationRepository, InMemLocationRepository>();
            services.AddSingleton<IProductRepository, InMemProductRepository>();
            services.AddSingleton<IRotationRepository, InMemRotationRepository>();
            services.AddSingleton<IStockRepository, InMemStockRepository>();
            services.AddSingleton<IUomRepository, InMemUomRepository>();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AliGulmen.Week5.HomeWork.RestfulApi v1"));
            }


            app.UseCustomGlobalException();

            app.UseCustomLoggingMiddleware();

            app.UseRouting();

            //for JWT
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
