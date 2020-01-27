namespace Pedido.Core.Application.Ingredients.Queries
{
    public class GetIngredientById
    {
        public int Id { get; }

        public GetIngredientById(int id)
        {
            Id = id;
        }
    }
}
