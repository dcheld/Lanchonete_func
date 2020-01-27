using Pedido.Core.Data;
using Pedido.Core.Extension;
using Pedido.Core.Infra.Intefaces;
using System.Threading.Tasks;
using Tango.Types;
using Tango.Linq;
using static Pedido.Core.Application.Validators;

namespace Pedido.Core.Application.Ingredients.Commands
{

    public interface ICreateIngredientHandler
    {
        Task<Either<string, int>> Handle(CreateIngredient command);
    }

    public class CreateIngredientHandler : ICreateIngredientHandler
    {
        public readonly IIngredientRepository _ingredientRepository;

        public CreateIngredientHandler(IIngredientRepository ingredientRepository)
        {
            _ingredientRepository = ingredientRepository;
        }

        public async Task<Either<string, int>> Handle(CreateIngredient command) =>
            await (await Validate(command))
                 .Match<Task<Either<string, int>>>(
                     async id => await _ingredientRepository.Create(new Ingredient(command.Name, command.Value)),
                    (v) => Task.FromResult(new Either<string, int>($"Ja existe um ingrendient com id {v.Id}, cadastrado com o nome {command.Name}"))
                );

        private async Task<Either<Ingredient, Unit>> Validate(CreateIngredient command) =>
            (await _ingredientRepository.Get(command.Name))
                .ToEither(new Unit())
                .Swap();

    }
}
