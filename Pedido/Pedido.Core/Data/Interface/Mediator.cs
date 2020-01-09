using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Pedido.Core.Data.Interface
{
    public class Mediator : IMediator
    {
        private readonly IServiceProvider serviceProvider;

        public Mediator(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public Task<TResponse> SendAsync<TRequest, TResponse>(ICommand<TRequest,TResponse> request)
            where TRequest : ICommand<TRequest,TResponse>
        {
            var service = serviceProvider.GetService<ICommandHandler<TRequest, TResponse>>() ?? throw new Exception("Command Handler não encontrado");
            return service.Handler((TRequest)request);
        }
    }

    public interface IMediator
    {
        Task<TResponse> SendAsync<TRequest, TResponse>(ICommand<TRequest, TResponse> request) where TRequest : ICommand<TRequest, TResponse>;
   }
}
