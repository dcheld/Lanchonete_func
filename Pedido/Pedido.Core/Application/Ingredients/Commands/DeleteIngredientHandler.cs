using Pedido.Core.Extension;
using Pedido.Core.Infra.Intefaces;
using System.Threading.Tasks;
using Tango.Types;
using static Pedido.Core.Application.Validators;

namespace Pedido.Core.Application.Ingredients.Commands
{
    public interface IDeleteIngredientHandler
    {
        Task<Either<string, Unit>> Handle(DeleteIngredient command);
    }

    public class DeleteIngredientHandler: IDeleteIngredientHandler
    {
        public readonly IIngredientRepository _ingredientRepository;

        public DeleteIngredientHandler(IIngredientRepository ingredientRepository)
        {
            _ingredientRepository = ingredientRepository;
        }

        public Task<Either<string, Unit>> Handle(DeleteIngredient command) =>
            Validate(command)
                 .Match<Task<Either<string, Unit>>>(
                     async id => await _ingredientRepository.Delete(id),
                    (v) => Task.FromResult(new Either<string, Unit>(v))
                );


        private Either<string, int> Validate(DeleteIngredient command) =>
            GreatThanZero(command.Id)
                .ToEither("O id para deletar tem que ser maior que 0");

    }
}
