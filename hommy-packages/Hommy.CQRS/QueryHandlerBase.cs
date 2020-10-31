using Hommy.CQRS.Abstractions;
using Hommy.ResultModel;
using System.Threading.Tasks;

namespace Hommy.CQRS
{
    public abstract class QueryHandlerBase<TIn, TOut> : IHandler<TIn, Task<Result<TOut>>>
        where TIn : QueryBase<TOut>
    {
        public abstract Task<Result<TOut>> Handle(TIn input);
    }
}
