using Hommy.CQRS.Abstractions;
using Hommy.ResultModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hommy.CQRS.Decorators
{
    public abstract class HandlerDecoratorBase<TIn, TOut> : IHandler<TIn, Task<Result<TOut>>> 
        where TIn : IRequest<Task<Result<TOut>>>
    {
        protected readonly IHandler<TIn, Task<Result<TOut>>> _decorated; 
        protected HandlerDecoratorBase(IHandler<TIn, Task<Result<TOut>>> decorated)
        {
            _decorated = decorated;
        }

        public abstract Task<Result<TOut>> Handle(TIn input);
    }

    public abstract class HandlerDecoratorBase<TIn> : IHandler<TIn, Task<Result>>
        where TIn : IRequest<Task<Result>>
    {
        protected readonly IHandler<TIn, Task<Result>> _decorated;
        protected HandlerDecoratorBase(IHandler<TIn, Task<Result>> decorated)
        {
            _decorated = decorated;
        }

        public abstract Task<Result> Handle(TIn input);
    }
}
