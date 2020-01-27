using System.Collections.Generic;
using System.Threading.Tasks;
using Pedido.Core.Data;
using Tango.Types;

namespace Pedido.Core.Infra.Intefaces
{
   public interface IIngredientRepository
    {
        Task<IList<Ingredient>> Get();
        Task<Option<Ingredient>> Get(string name);
        Task<Option<Ingredient>> Get(int id);
        Task<int> Create(Ingredient ingredient);
        Task<Unit> Update(Ingredient ingredient);
        Task<Unit> Delete(int ingredientId);
    }
}