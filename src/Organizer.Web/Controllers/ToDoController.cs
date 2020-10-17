using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Organizer.Domain.Entities;

namespace Organizer.Web.Controllers
{
    public class ToDoController : ApiControllerBase
    {
        private readonly DbContext _dbContext;

        public ToDoController(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("todo")]
        public async Task<IActionResult> GetTodos()
        {
            var todos = await _dbContext.Set<ToDo>().ToListAsync();

            return Ok(todos);
        }
    }
}
