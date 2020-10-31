using Hommy.CQRS.Abstractions;
using Hommy.ResultModel;
using System.Threading.Tasks;

namespace Hommy.CQRS
{
    public abstract class CommandHandlerBase<TIn, TOut> : IHandler<TIn, Task<Result<TOut>>>
        where TIn : CommandBase<TOut>
    {
        public abstract Task<Result<TOut>> Handle(TIn input);
    }

    public abstract class CommandHandlerBase<TIn> : IHandler<TIn, Task<Result>>
            where TIn : CommandBase
    {
        public abstract Task<Result> Handle(TIn input);
    }
}
