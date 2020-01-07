using Pedido.Core.Data.Interface;
using System;
using System.Threading.Tasks;

namespace Pedido.Core.Application.Ingredientes.Commands
{
    public class DeleteLancheHandler : ICommandHandler<DeleteLanche>
    {
        public Task Handler(DeleteLanche command) =>
            throw new NotImplementedException();
    }
}
