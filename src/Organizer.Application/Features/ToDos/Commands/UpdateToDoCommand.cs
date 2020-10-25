using Hommy.CQRS;
using Hommy.ResultModel;
using Microsoft.EntityFrameworkCore;
using Organizer.Domain.Entities;
using System.Threading.Tasks;

namespace Organizer.Application.Features.ToDos.Commands
{
    public class UpdateToDoCommand : CommandBase
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
    }

    public class UpdateToDoCommandHandler : CommandHandlerBase<UpdateToDoCommand>
    {
        private readonly DbContext _dbContext;

        public UpdateToDoCommandHandler(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async override Task<Result> Handle(UpdateToDoCommand input)
        {
            var todo = await _dbContext.Set<ToDo>().FindAsync(input.Id);

            if (todo == null)
            {
                return Result.NotFound(input.Id.ToString());
            }

            todo.Update(input.Description, input.IsDone);

            await _dbContext.SaveChangesAsync();

            return Result.Success();
        }
    }
}
