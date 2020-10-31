using Hommy.CQRS.Abstractions;
using Hommy.ResultModel;
using SimpleInjector;
using System.Threading.Tasks;

namespace Hommy.CQRS
{
    public class HandlerDispatcher : IHandlerDispatcher
    {
        private readonly Container _container;

        public HandlerDispatcher(Container container)
        {
            _container = container;            
        }

        

        public Task<Result<TOut>> Handle<TIn, TOut>(TIn input) where TIn : IRequest<Task<Result<TOut>>>
        {
            var handler = (IHandler<TIn, Task<Result<TOut>>>) _container.GetInstance(typeof(IHandler<TIn, Task<Result<TOut>>>));

            return handler.Handle(input);
        }

        public Task<Result> Handle<TIn>(TIn input) where TIn : IRequest<Task<Result>>
        {
            var handler = (IHandler<TIn, Task<Result>>)_container.GetInstance(typeof(IHandler<TIn, Task<Result>>));

            return handler.Handle(input);
        }
    }
}
