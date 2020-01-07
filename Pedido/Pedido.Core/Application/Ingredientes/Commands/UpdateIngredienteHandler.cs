using Pedido.Core.Data.Interface;
using System;
using System.Threading.Tasks;

namespace Pedido.Core.Application.Ingredientes.Commands
{
    public class UpdateIngredienteHandler : ICommandHandler<UpdateIngrediente>
    {
        public Task Handler(UpdateIngrediente command) =>
            throw new NotImplementedException();
    }
}
