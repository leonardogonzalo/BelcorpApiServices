using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Belcorp.ServicesQuerys.Domain.Supervisor;
using Belcorp.ServicesQuerys.Domain.Interfaces;
using Belcorp.ServicesQuerys.Data.Repository;
using Belcorp.ServicesQuerys.Entities;
using Swashbuckle.AspNetCore.Swagger;

namespace ServicesQuerys
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
            services.AddMvc();
            services.AddSwaggerGen(s => s.SwaggerDoc("v1", new Info
            {
                Title = "Belcorp APIs Querys",
                Description = "Apis "
            }));

            services.AddTransient<ISMatrizProducto,SMatrizProducto>();
            services.AddTransient<IMatrizProducto<MatrizProducto>,RepMatrizProducto>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            app.UseSwagger()
                .UseSwaggerUI(c => {
                    c.SwaggerEndpoint("../swagger/v1/swagger.json", "Belcorp API Querys");
                });
        }
    }
}
