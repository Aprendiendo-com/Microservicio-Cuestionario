using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microservicio_Cuestionario.AccessData.Context;
using Microservicio_Cuestionario.AccessData.Queries;
using Microservicio_Cuestionario.Aplication.Services;
using Microservicio_Cuestionario.Domain.Entities;
using Microservicio_Cuestionario.Domain.Queries;
using Microservicio_Cuestionario.Domain.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Microservicio_Cuestionario
{



    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddSwaggerGen();

            services.AddMvc();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "MicroService APIs v1.0",
                    Description = "Test services"
                });
            });

            var mapConfig = new MapperConfiguration(mc =>
               mc.AddProfile(new AutoMappingProfile())
               ) ;

            IMapper mapper = mapConfig.CreateMapper();
            services.AddSingleton(mapper);


            //services.AddScoped(typeof(ICuestionarioService), typeof(Cuestionario));
            //services.AddScoped(typeof(ICuestionarioRepository), typeof(CuestionarioRepository));
            services.AddScoped<ICuestionarioService, CuestionarioService>();
            services.AddScoped<ICuestionarioRepository, CuestionarioRepository>();

            //Modificado
            services.AddScoped<IRegistroService, RegistroService>();
            services.AddScoped<IRegistroRepository, RegistroRepository>();

            services.AddScoped<IPreguntaService, PreguntaService>();
            services.AddScoped<IPreguntaRepository, PreguntaRepository>();

            services.AddScoped<IRepuestaService, RepuestaService>();
            services.AddScoped<IRespuestaRepository, RepuestaRepository>();

            services.AddDbContext<GenericContext>(option => option.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllers();

            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling =
                Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MicroService APIs v1.0");
                c.RoutePrefix = string.Empty;

            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});
            });
        }
    }
}
