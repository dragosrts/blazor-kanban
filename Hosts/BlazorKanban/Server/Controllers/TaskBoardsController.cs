using AutoMapper;
using BlazorKanban.Application.TaskBoards.Commands.CreateTaskBoard;
using BlazorKanban.Application.TaskBoards.Commands.DeleteTaskBoard;
using BlazorKanban.Application.TaskBoards.Commands.UpdateTaskBoard;
using BlazorKanban.Application.TaskBoards.Queries.GetTaskBoard;
using BlazorKanban.Domain.Objects.Entities;
using BlazorKanban.Shared;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorKanban.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TaskBoardsController : ControllerBase
    {
        private readonly ILogger<TaskBoardsController> logger;

        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public TaskBoardsController(ILogger<TaskBoardsController> logger, IMediator mediator, IMapper mapper)
        {
            this.logger = logger;
            this.mediator = mediator;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<Board>> GetTaskBoards()
        {
            var list =
                new List<Board>();

            return list;
        }

        [HttpGet("{id}")]
        public async Task<Board> GetTaskBoard(string id)
        {
            var vm = await mediator.Send(new GetTaskBoardDetailQuery(id: id));

            var result = mapper.Map<Board>(vm);

            return result;
        }

        [HttpPost]
        public async Task<string> CreateTaskBoard(Board board)
        {
            var result = await mediator.Send(
                new CreateTaskBoardCommand(
                    title: board.Title,
                    description: board.Description
                ));

            return result;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<string>> UpdateTaskBoard(Board board)
        {
            var request = mapper.Map<TaskBoard>(board);

            var result = await mediator.Send(
                new UpdateTaskBoardCommand(
                    id: request.Id,
                    title: request.Title,
                    description: request.Description,
                    lists: request.Lists
                ));

            return result;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteTaskBoard(string id)
        {
            var result = await mediator.Send(new DeleteTaskBoardCommand(id: id));

            return Ok(result);
        }
    }
}