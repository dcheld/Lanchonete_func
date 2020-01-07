using Pedido.Core.Data.Interface;
using System;
using System.Threading.Tasks;

namespace Pedido.Core.Application.Ingredientes.Commands
{
    public class CreatePedidoHandler : ICommandHandler<CreatePedido>
    {
        public Task Handler(CreatePedido command) =>
            throw new NotImplementedException();
    }
}
