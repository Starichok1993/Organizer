using Hommy.CQRS;
using Hommy.ResultModel;
using Microsoft.EntityFrameworkCore;
using Organizer.Domain.Entities;
using System.Threading.Tasks;

namespace Organizer.Application.Features.App.Queries
{
    public class PingQuery : QueryBase<string>
    {
    }

    public class PingQueryHandler : QueryHandlerBase<PingQuery, string>
    {
        private readonly DbContext _dbContext;

        public PingQueryHandler(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async override Task<Result<string>> Handle(PingQuery input)
        {
            var version = (await _dbContext.Set<DbVersion>().FirstAsync()).Version;

            return version;
        }
    }
}
