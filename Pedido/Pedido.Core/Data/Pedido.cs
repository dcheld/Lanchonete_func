using System;

namespace Pedido.Core.Data
{
    public class Pedido
    {
        public int Id { get; private set; }
        public decimal Itens { get; private set; }
        public decimal Desconto { get; private set; }
        public decimal Total { get; private set; }

        public Pedido()
        {
        }
    }
}