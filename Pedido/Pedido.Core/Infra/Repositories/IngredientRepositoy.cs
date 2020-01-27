using Microsoft.EntityFrameworkCore;
using Pedido.Core.Data;
using Pedido.Core.Infra.Intefaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tango.Types;
namespace Pedido.Core.Infra
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly SnackBarContext _snackBarContext;

        public IngredientRepository(SnackBarContext snackBarContext)
        {
            _snackBarContext = snackBarContext;
        }

        public async Task<IList<Ingredient>> Get() =>
            await _snackBarContext.Ingredients.ToListAsync();

        public async Task<Option<Ingredient>> Get(string name) =>
            await _snackBarContext.Ingredients.FirstOrDefaultAsync(f => f.Name == name);

        public async Task<Option<Ingredient>> Get(int id) =>
            await _snackBarContext.Ingredients.FirstOrDefaultAsync(f => f.Id == id);

        public async Task<int> Create(Ingredient ingredient)
        {
            _snackBarContext.Ingredients.Add(ingredient);
            await _snackBarContext.SaveChangesAsync();
            return ingredient.Id;
        }

        public async Task<Unit> Update(Ingredient ingredient)
        {
            _snackBarContext.Ingredients.Update(ingredient);
            await _snackBarContext.SaveChangesAsync();
            return new Unit();
        }

        public async Task<Unit> Delete(int ingredientId)
        {
            var ingredient = await _snackBarContext.Ingredients.FindAsync(ingredientId);
            _snackBarContext.Ingredients.Remove(ingredient);
            await _snackBarContext.SaveChangesAsync();
            return new Unit();
        }
    }
}