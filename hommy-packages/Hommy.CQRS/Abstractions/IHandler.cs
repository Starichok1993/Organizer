namespace Hommy.CQRS.Abstractions
{
    public interface IHandler<TIn,TOut> 
        where TIn : IRequest<TOut>
    {
        TOut Handle(TIn input);
    }
}
