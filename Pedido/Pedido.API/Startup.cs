using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Pedido.Core.Application.Ingredients.Commands;
using Pedido.Core.Application.Ingredients.Queries;
using Pedido.Core.Infra;
using Pedido.Core.Infra.Intefaces;

namespace Pedido.API
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
            services.AddMvc()
                .AddNewtonsoftJson();

            services.AddDbContext<SnackBarContext>(opt => opt.UseInMemoryDatabase("Lanchonete"));

            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "Lanchonete", Version = "v1" }));

            AddServices(services);
        }

        private void AddServices(IServiceCollection services) =>
            services
                .AddScoped<IGetIngredientByIdHandler, GetIngredientByIdHandler>()
                .AddScoped<IGetIngredientAllHandler, GetIngredientAllHandler>()
                .AddScoped<IDeleteIngredientHandler, DeleteIngredientHandler>()
                .AddScoped<ICreateIngredientHandler, CreateIngredientHandler>()
                .AddScoped<IUpdateIngredientHandler, UpdateIngredientHandler>()
                .AddScoped<IIngredientRepository, IngredientRepository>();

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Lanchonet v1");
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}