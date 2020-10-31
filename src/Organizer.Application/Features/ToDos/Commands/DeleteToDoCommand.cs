using FluentValidation;
using Hommy.CQRS;
using Hommy.ResultModel;
using Microsoft.EntityFrameworkCore;
using Organizer.Domain.Entities;
using System.Threading.Tasks;

namespace Organizer.Application.Features.ToDos.Commands
{
    public class DeleteToDoCommand : CommandBase
    {
        public int Id { get; set; }
    }


    public class DeleteToDoCommandValidator : AbstractValidator<DeleteToDoCommand>
    {
        public DeleteToDoCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }

    public class DeleteToDoCommandHandler : CommandHandlerBase<DeleteToDoCommand>
    {
        private readonly DbContext _dbContext;

        public DeleteToDoCommandHandler(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async override Task<Result> Handle(DeleteToDoCommand input)
        {

            var todo = await _dbContext.Set<ToDo>().FindAsync(input.Id);

            if (todo == null)
            {
                return Result.NotFound($"ToDo with Id: {input.Id} doesn't exist!");
            }

            _dbContext.Remove(todo);

            await _dbContext.SaveChangesAsync();

            return Result.Success();
        }
    }
}
