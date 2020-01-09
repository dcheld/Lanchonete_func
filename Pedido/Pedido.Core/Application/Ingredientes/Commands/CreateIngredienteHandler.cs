using LanguageExt;
using Pedido.Core.Data;
using Pedido.Core.Data.Interface;
using System;
using System.Threading.Tasks;
using static LanguageExt.Prelude;

namespace Pedido.Core.Application.Ingredientes.Commands
{
    public class CreateIngredienteHandler : ICommandHandler<CreateIngrediente, Either<string, int>>
    {

        public Task<Either<string, int>> Handler(CreateIngrediente command) =>
            Validate(command)
                .Map(PersisteIngredient)
                .ToEitherAsync();

        public Task<int> PersisteIngredient(Ingrediente createIngrediente) => Task.FromResult(10);

        public static Validation<string, Ingrediente> Validate(CreateIngrediente createIngrediente) =>
           (ValidateName(createIngrediente))
                .Apply(name => new Ingrediente(1, "", 0) );

        private static Validation<string, string> ValidateName(CreateIngrediente createIngrediente) =>
           NotEmpty(createIngrediente.Name)
                .Bind(GreatThan(3));

        public static Validation<string, string> NotEmpty(string str) =>
          Optional(str)
              .Where(s => !string.IsNullOrWhiteSpace(s))
              .ToValidation<string>("Can not be empty.");

        public static Func<string, Validation<string, string>> GreatThan(int min) =>
            str => Optional(str)
                .Where(w => w.Length > min)
                .ToValidation($"Must be more then {min}");

    }
}
