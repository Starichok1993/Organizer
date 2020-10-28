using Hommy.CQRS.Abstractions;
using Hommy.ResultModel;
using System.Threading.Tasks;

namespace Hommy.CQRS
{
    public abstract class QueryBase<TOut> : IQuery<Task<Result<TOut>>>
    {

    }
}
