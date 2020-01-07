using Pedido.Core.Data.Interface;
using System;
using System.Threading.Tasks;

namespace Pedido.Core.Application.Ingredientes.Commands
{
    public class CreateIngredienteHandler : ICommandHandler<CreateIngrediente>
    {
        public Task Handler(CreateIngrediente command) =>
            throw new NotImplementedException();
    }
}
