using Pedido.Core.Data;
using Pedido.Core.Extension;
using Pedido.Core.Infra.Intefaces;
using System.Threading.Tasks;
using Tango.Linq;
using Tango.Types;
using static Pedido.Core.Application.Validators;

namespace Pedido.Core.Application.Ingredients.Queries
{
    public interface IGetIngredientByIdHandler
    {
        Task<Either<string, Ingredient>> Handle(GetIngredientById query);
    }
    
    public class GetIngredientByIdHandler: IGetIngredientByIdHandler
    {

        public readonly IIngredientRepository _ingredientRepository;

        public GetIngredientByIdHandler(IIngredientRepository ingredientRepository)
        {
            _ingredientRepository = ingredientRepository;
        }

        public Task<Either<string, Ingredient>> Handle(GetIngredientById query) =>
            Validate(query)
                .Match(
                    id => RetrieveIngredient(id),
                    e => Task.FromResult(new Either<string, Ingredient>(e))
                );

        private Either<string, int> Validate(GetIngredientById query) =>
             GreatThanZero(query.Id)
                .ToEither("O id de para pequisa tem que ser maior que 0");

        private async Task<Either<string, Ingredient>> RetrieveIngredient(int id) =>
            (await _ingredientRepository.Get(id))
                .ToEither($"Não foi encontrado um ingrediente com id {id}");

    }
}