using Pedido.Core.Data;
using Pedido.Core.Infra.Intefaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pedido.Core.Application.Ingredients.Queries
{
    public interface IGetIngredientAllHandler
    {
        Task<IList<Ingredient>> Handle();
    }
    
    public class GetIngredientAllHandler : IGetIngredientAllHandler
    {

        public readonly IIngredientRepository _ingredientRepository;

        public GetIngredientAllHandler(IIngredientRepository ingredientRepository)
        {
            _ingredientRepository = ingredientRepository;
        }

        public async Task<IList<Ingredient>> Handle() =>
            await _ingredientRepository.Get();

    }
}