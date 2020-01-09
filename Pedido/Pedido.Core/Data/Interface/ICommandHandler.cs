using System.Threading.Tasks;

namespace Pedido.Core.Data.Interface
{
    public interface ICommandHandler<in TRequest, TResponse>
        where TRequest: ICommand<TRequest, TResponse>
    {
        Task<TResponse> Handler(TRequest command);
    }

    public interface ICommand<TRequest, out TResponse>
    {
    }
}
