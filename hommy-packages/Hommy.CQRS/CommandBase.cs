using Hommy.CQRS.Abstractions;
using Hommy.ResultModel;
using System.Threading.Tasks;

namespace Hommy.CQRS
{
    public abstract class CommandBase<TOut> : ICommand<Task<Result<TOut>>>
    {
    }
    public abstract class CommandBase : ICommand<Task<Result>>
    {
        
    }

}
