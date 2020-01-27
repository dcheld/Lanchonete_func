using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pedido.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Tango.Modules;
using Tango.Types;

namespace Pedido.Core.Infra
{
    public static class DbInitializer
    {
        public static IHost InitializeDatabase(this IHost host) =>
            host.AsContinuation<string, IHost>()
                .Then(host => host.Services.CreateScope())
                .Then(services => services.ServiceProvider.GetRequiredService<SnackBarContext>())
                .Then(context => Initialize(context))
                .Match(
                    s => host,
                    f => throw new Exception("Não foi possível inicializa o banco")
                );


        public static Unit Initialize(SnackBarContext context)
        {
            var ingredients = new Ingredient[]
            {
                new Ingredient(1, "Tomate", 1.5m),
                new Ingredient(2, "Alface", 0.5m),
                new Ingredient(3, "Carne", 4m),
                new Ingredient(4, "Bacon", 3.5m),
            };


            context.Ingredients.AddRange(ingredients);

            context.SaveChanges();

            return new Unit();
        }
    }
}
