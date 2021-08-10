using ContadorPalabras.Aplicacion;
using ContadorPalabras.Aplicacion.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.IO;
using System.Reflection;

namespace ContadorPalabras.Api
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
            services.AddControllers();
            services.AddScoped<ICoreContadorPalabras, CoreContadorPalabras>();
           
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc($"v{GetAssemblyVersion()}", new OpenApiInfo
                {
                    Version = $"v{GetAssemblyVersion()}",
                    Title = "Api Contador Palabras",
                    Description = "Servicio encargado de contar cuantas veces se repite una palabra en el texto ingresado"
                });
                
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }
       
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/v{GetAssemblyVersion()}/swagger.json", "Api Contador Palabras");
                c.DefaultModelRendering(ModelRendering.Model);

            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private string GetAssemblyVersion()
        {
            return GetType().Assembly.GetName().Version.ToString().Substring(0, 3);
        }
    }
}
