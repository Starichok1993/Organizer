using FluentValidation;
using Hommy.CQRS;
using Hommy.ResultModel;
using Microsoft.EntityFrameworkCore;
using Organizer.Domain.Entities;
using System.Threading.Tasks;

namespace Organizer.Application.Features.ToDos.Commands
{
    public class CreateToDoCommand : CommandBase<int>
    {
        public string Description { get; set; }
    }

    public class CreateToDoCommandValitator : AbstractValidator<CreateToDoCommand>
    {
        public CreateToDoCommandValitator()
        {
            RuleFor(x => x.Description).NotEmpty();
        }
    }

    public class CreateToDoCommandHandler : CommandHandlerBase<CreateToDoCommand, int>
    {
        private readonly DbContext _dbContext;

        public CreateToDoCommandHandler(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async override Task<Result<int>> Handle(CreateToDoCommand input)
        {
            var todo = new ToDo(input.Description);

            await _dbContext.Set<ToDo>().AddAsync(todo);
            await _dbContext.SaveChangesAsync();

            return todo.Id;
        }
    }
}
