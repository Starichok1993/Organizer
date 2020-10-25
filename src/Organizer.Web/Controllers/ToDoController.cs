﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hommy.ApiResult;
using Hommy.CQRS;
using Hommy.ResultModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Organizer.Application.Features.ToDos.Commands;
using Organizer.Application.Features.ToDos.Queries;
using Organizer.Domain.Entities;
using Organizer.Web.Models;

namespace Organizer.Web.Controllers
{
    public class ToDoController : ApiControllerBase
    {
        private readonly IHandlerDispatcher _handlerDispatcher;

        public ToDoController(IHandlerDispatcher handlerDispatcher)
        {
            _handlerDispatcher = handlerDispatcher;
        }

        [HttpGet("todo")]
        public async Task<ApiResult> GetAll ()
        {
            return await _handlerDispatcher.Handle<GetAllToDoQuery, List<ToDo>>(new GetAllToDoQuery());
        }

        [HttpPost("todo")]
        public async Task<ApiResult> Add([FromBody] CreateToDoRequest item)
        {
            return await _handlerDispatcher.Handle<CreateToDoCommand, int>(new CreateToDoCommand {
                Description = item.Description
            });
        }

        [HttpPost("todo/{id}")]
        public async Task<ApiResult> Update(int id, [FromBody] UpdateToDoRequest item)
        {
            return await _handlerDispatcher.Handle(new UpdateToDoCommand {
                Id = id,
                Description = item.Description,
                IsDone = item.IsDone
            });
        }

        [HttpDelete("todo/{id}")]
        public async Task<ApiResult> Delete(int id)
        {
            return await _handlerDispatcher.Handle(new DeleteToDoCommand { Id = id });
        }
    }
}
