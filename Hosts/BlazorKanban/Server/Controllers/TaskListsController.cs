using AutoMapper;
using BlazorKanban.Application.TaskLists.Commands.CreateTaskList;
using BlazorKanban.Application.TaskLists.Commands.DeleteTaskList;
using BlazorKanban.Application.TaskLists.Commands.UpdateTaskList;
using BlazorKanban.Domain.Objects.Entities;
using BlazorKanban.Shared;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace BlazorKanban.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TaskListsController : ControllerBase
    {
        private readonly ILogger<TaskListsController> logger;
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public TaskListsController(ILogger<TaskListsController> logger, IMediator mediator, IMapper mapper)
        {
            this.logger = logger;
            this.mediator = mediator;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<string>> CreateTaskList(Column column)
        {
            var result = await mediator.Send(
                new CreateTaskListCommand(
                    boardId: column.BoardId,
                    title: column.Title,
                    description: column.Description
                ));

            return Ok(result);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<string>> UpdateTaskList(Column column)
        {
            var request = mapper.Map<TaskList>(column);

            var result = await mediator.Send(
                new UpdateTaskListCommand(
                    id: request.Id,
                    boardId: request.BoardId,
                    title: request.Title,
                    description: request.Description,
                    cards: request.Cards
                ));

            return Ok(result);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteTaskList(string id)
        {
            var result = await mediator.Send(new DeleteTaskListCommand(id: id));

            return Ok(result);
        }
    }
}