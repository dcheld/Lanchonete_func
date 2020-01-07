using System.Threading.Tasks;

namespace Pedido.Core.Data.Interface
{
    public interface ICommandHandler<in T>
        where T: ICommand
    {
        Task Handler(T command);
    }

    public interface ICommand
    {
    }
}
