using Hommy.CQRS;
using Hommy.ResultModel;
using Microsoft.EntityFrameworkCore;
using Organizer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Organizer.Application.Features.ToDos.Queries
{
    public class GetAllToDoQuery : QueryBase<List<ToDo>>
    {

    }

    public class GetAllToDoQueryHandler : QueryHandlerBase<GetAllToDoQuery, List<ToDo>>
    {
        private readonly DbContext _dbContext;

        public GetAllToDoQueryHandler(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async override Task<Result<List<ToDo>>> Handle(GetAllToDoQuery input)
        {
            var todos = await _dbContext.Set<ToDo>().ToListAsync();
            return todos;
        }
    }

}
