using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Organizer.Domain.Entities;
using Organizer.Web.Models;

namespace Organizer.Web.Controllers
{
    public class ToDoController : ApiControllerBase
    {
        private readonly DbContext _dbContext;

        public ToDoController(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("todo")]
        public async Task<IActionResult> GetAll ()
        {
            var todos = await _dbContext.Set<ToDo>().ToListAsync();

            return Ok(todos);
        }

        [HttpPost("todo")]
        public async Task<IActionResult> Add([FromBody] CreateToDoRequest item)
        {
            var todo = new ToDo(item.Description);
            await _dbContext.Set<ToDo>().AddAsync(todo);
            await _dbContext.SaveChangesAsync();

            return Ok(todo.Id);
        }

        [HttpPost("todo/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateToDoRequest item)
        {
            var todo = await _dbContext.Set<ToDo>().FindAsync(id);

            if(todo == null)
            {
                return NotFound(id);
            }

            todo.Update(item.Description, item.IsDone);

            await _dbContext.SaveChangesAsync();
           
            return Ok();
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
