using System.Threading.Tasks;
using Hommy.CQRS;
using Microsoft.AspNetCore.Mvc;
using Organizer.Application.Features.App.Queries;

namespace Organizer.Web.Controllers
{
    
    public class AppController : ApiControllerBase
    {
        

        private readonly IHandlerDispatcher _handlerDispatcher;

        public AppController(IHandlerDispatcher handlerDispatcher)
        {
            _handlerDispatcher = handlerDispatcher;
        }

        [HttpGet("ping")]        
        public async Task<string> Ping()
        {
            var version = (await _handlerDispatcher.Handle<PingQuery, string>(new PingQuery())).Data;

            return version;
        }
    }
}