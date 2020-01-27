
namespace Pedido.Core.Application.Ingredients.Commands
{
    public class UpdateIngredient
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Value { get; set; }

        public UpdateIngredient(int id, string name, decimal value)
        {
            Id = id;
            Name = name;
            Value = value;
        }
    }
}
