using Hommy.CQRS.Abstractions;
using Hommy.ResultModel;
using System.Threading.Tasks;

namespace Hommy.CQRS
{
    public interface IHandlerDispatcher
    {
        Task<Result<TOut>> Handle<TIn, TOut>(TIn input) where TIn : IRequest<Task<Result<TOut>>>;

        Task<Result> Handle<TIn>(TIn input) where TIn : IRequest<Task<Result>>;
    }
}
