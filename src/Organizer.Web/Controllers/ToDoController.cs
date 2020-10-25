using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hommy.ApiResult;
using Hommy.CQRS;
using Hommy.ResultModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Organizer.Application.Features.ToDos.Commands;
using Organizer.Domain.Entities;
using Organizer.Web.Models;

namespace Organizer.Web.Controllers
{
    public class ToDoController : ApiControllerBase
    {
        private readonly DbContext _dbContext;
        private readonly IHandlerDispatcher _handlerDispatcher;

        public ToDoController(DbContext dbContext, IHandlerDispatcher handlerDispatcher)
        {
            _dbContext = dbContext;
            _handlerDispatcher = handlerDispatcher;
        }

        [HttpGet("todo")]
        public async Task<IActionResult> GetAll ()
        {
            var todos = await _dbContext.Set<ToDo>().ToListAsync();

            return Ok(todos);
        }

        [HttpPost("todo")]
        public async Task<ApiResult> Add([FromBody] CreateToDoRequest item)
        {
            return await _handlerDispatcher.Handle<CreateToDoCommand, int>(new CreateToDoCommand { Description = item.Description }); 
        }

        [HttpPost("todo/{id}")]
        public async Task<ApiResult> Update(int id, [FromBody] UpdateToDoRequest item)
        {
            return await _handlerDispatcher.Handle<UpdateToDoCommand>(new UpdateToDoCommand {
                Id = id, Description = item.Description, IsDone = item.IsDone });
        }

        [HttpDelete("todo/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var todo = await _dbContext.Set<ToDo>().FindAsync(id);

            if (todo == null)
            {
                return NotFound(id);
            }

            _dbContext.Remove(todo);

            await _dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
