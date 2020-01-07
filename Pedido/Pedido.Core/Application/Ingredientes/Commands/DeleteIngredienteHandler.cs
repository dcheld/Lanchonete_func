using Pedido.Core.Data.Interface;
using System;
using System.Threading.Tasks;

namespace Pedido.Core.Application.Ingredientes.Commands
{
    public class DeleteIngredienteHandler : ICommandHandler<DeleteIngrediente>
    {
        public Task Handler(DeleteIngrediente command) =>
            throw new NotImplementedException();
    }
}
