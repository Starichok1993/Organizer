using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Organizer.Domain.Entities;

namespace Organizer.Web.Controllers
{
    
    public class AppController : ApiControllerBase
    {
        private readonly DbContext _dbContext;

        public AppController(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("ping")]        
        public async Task<string> Ping()
        {

            return (await _dbContext.Set<DbVersion>().FirstAsync()).Version;
        }
    }
}