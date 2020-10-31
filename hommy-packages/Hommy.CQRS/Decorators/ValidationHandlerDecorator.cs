using FluentValidation;
using Hommy.CQRS.Abstractions;
using Hommy.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hommy.CQRS.Decorators
{
    public class ValidationHandlerDecorator<TIn, TOut> : HandlerDecoratorBase<TIn, TOut>
        where TIn : IRequest<Task<Result<TOut>>>
    {
        private readonly IEnumerable<IValidator<TIn>> _validators;
        
        public ValidationHandlerDecorator(IHandler<TIn, Task<Result<TOut>>> decorated, IEnumerable<IValidator<TIn>> validators) : base(decorated)
        {
            _validators = validators;
        }

        public override async Task<Result<TOut>> Handle(TIn input)
        {
            var context = new ValidationContext<TIn>(input);
            
            foreach(var validator in _validators)
            {
                var result = validator.Validate(context);
                if (!result.IsValid)
                    return await Task.FromResult( Result.ValidationError(result.Errors.Select(e=>new ValidationError( e.PropertyName,  e.ErrorMessage)).ToArray()));
                
            }

            return await _decorated.Handle(input);
        }
    }


    public class ValidationHandlerDecorator<TIn> : HandlerDecoratorBase<TIn>
    where TIn : IRequest<Task<Result>>
    {
        private readonly IEnumerable<IValidator<TIn>> _validators;

        public ValidationHandlerDecorator(IHandler<TIn, Task<Result>> decorated, IEnumerable<IValidator<TIn>> validators) : base(decorated)
        {
            _validators = validators;
        }

        public override async Task<Result> Handle(TIn input)
        {
            var context = new ValidationContext<TIn>(input);

            foreach (var validator in _validators)
            {
                var result = validator.Validate(context);
                if (!result.IsValid)
                    return await Task.FromResult(Result.ValidationError(result.Errors.Select(e => new ValidationError(e.PropertyName, e.ErrorMessage)).ToArray()));
            }

            return await _decorated.Handle(input);
        }
    }
}
