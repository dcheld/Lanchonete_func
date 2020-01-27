using Pedido.Core.Data;
using Pedido.Core.Extension;
using Pedido.Core.Infra.Intefaces;
using System.Threading.Tasks;
using Tango.Types;
using static Pedido.Core.Application.Validators;

namespace Pedido.Core.Application.Ingredients.Commands
{
    public interface IUpdateIngredientHandler
    {
        Task<Either<string, Unit>> Handle(UpdateIngredient command);
    }

    public class UpdateIngredientHandler : IUpdateIngredientHandler
    {
        public readonly IIngredientRepository _ingredientRepository;

        public UpdateIngredientHandler(IIngredientRepository ingredientRepository)
        {
            _ingredientRepository = ingredientRepository;
        }

        public Task<Either<string, Unit>> Handle(UpdateIngredient command) =>
            Validate(command)
                 .Match<Task<Either<string, Unit>>>(
                     async id => await _ingredientRepository.Update(new Ingredient(id, command.Name, command.Value)),
                    (v) => Task.FromResult(new Either<string, Unit>(v))
                );

        private Either<string, int> Validate(UpdateIngredient command) =>
            GreatThanZero(command.Id)
                .ToEither("O id para deletar tem que ser maior que 0");

    }
}
