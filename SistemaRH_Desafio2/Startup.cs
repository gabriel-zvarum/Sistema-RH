using Application.Core.Application;
using Application.Core.Application.Interfaces;
using Application.Core.Repository;
using Application.Core.Repository.Interfaces;
using Application.Infra.Crosscuting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace SistemaRH_Desafio2
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
            services.AddSwaggerGen(c =>
            {
                services.AddControllers();

                services.AddCors();

                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Sistema RH API",
                    Version = "v1.01",
                    Description = "Desafio voltado para o aprendizado sobre a relação de uma solução backend e banco de dados",
                });
            });
            services.AddControllers();

            services.AddFluentValidationConfig();

            services.AddTransient<IFuncionariosApplicationService, FuncionariosApplicationService>();
            services.AddTransient<IFuncionariosRepository, FuncionariosRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sistema RH V1");
                });
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true)
                .AllowCredentials());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
