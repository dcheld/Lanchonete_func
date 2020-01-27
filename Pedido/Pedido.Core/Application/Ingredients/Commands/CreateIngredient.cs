namespace Pedido.Core.Application.Ingredients.Commands
{
    public class CreateIngredient
    {
        public string Name { get; set; }

        public decimal Value { get; set; }

        public CreateIngredient(string name, decimal value)
        {
            Name = name;
            Value = value;
        }
    }
}
