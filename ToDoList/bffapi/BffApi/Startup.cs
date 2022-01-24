using System;
using System.IO;
using System.Reflection;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using BffApi.Model;
using LoginDataAccess;
using LoginDataAccess.Store;
using ToDoDataAccess;
using ToDoDataAccess.Store;


namespace BffApi {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // Kapsayıcıya hizmet eklemek için bu yöntem kullanılır. 
        public void ConfigureServices(IServiceCollection services) {
            services.AddControllers();
            services.AddHealthChecks();

            services.AddScoped<LoginStore>();
            services.AddDbContext<LoginContext>(opt => opt.UseInMemoryDatabase("Login"));
            
            services.AddScoped<ToDoStore>();
            services.AddDbContext<ToDoContext>(opt => opt.UseInMemoryDatabase("ToDo"));
           
            services.AddAutoMapper(typeof(MapperProfile));
        }

        // HTTP istek ardışık düzenini yapılandırmak için kullanılır. 
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { //mapper kullanmamdaki amaç gözümle gelen değerleri görmek
                endpoints.MapControllers();
               
            });
        }
    }
}