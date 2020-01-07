using Pedido.Core.Data.Interface;
using System;
using System.Threading.Tasks;

namespace Pedido.Core.Application.Ingredientes.Commands
{
    public class UpdateLancheHandler : ICommandHandler<UpdateLanche>
    {
        public Task Handler(UpdateLanche command) =>
            throw new NotImplementedException();
    }
}
