namespace Pedido.Core.Application.Ingredients.Commands
{
    public class DeleteIngredient
    {
        public int Id { get; }

        public DeleteIngredient(int id)
        {
            Id = id;
        }
    }
}
