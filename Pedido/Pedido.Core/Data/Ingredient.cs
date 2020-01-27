namespace Pedido.Core.Data
{
    public class Ingredient
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Value { get; set; }

        public Ingredient(int id, string name, decimal value) :this(name, value)
        {
            Id = id;
        }
        public Ingredient(string name, decimal value)
        {
            Name = name;
            Value = value;
        }
        private Ingredient()
        {

        }
    }
}