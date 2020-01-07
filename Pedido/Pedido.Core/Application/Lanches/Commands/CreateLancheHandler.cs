using Pedido.Core.Data.Interface;
using System;
using System.Threading.Tasks;

namespace Pedido.Core.Application.Ingredientes.Commands
{
    public class CreateLancheHandler : ICommandHandler<CreateLanche>
    {
        public Task Handler(CreateLanche command) =>
            throw new NotImplementedException();
    }
}
