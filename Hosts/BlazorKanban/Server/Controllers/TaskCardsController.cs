using AutoMapper;
using BlazorKanban.Application.TaskCards.Commands.CreateTaskCard;
using BlazorKanban.Application.TaskCards.Commands.DeleteTaskCard;
using BlazorKanban.Application.TaskCards.Commands.UpdateTaskCard;
using BlazorKanban.Domain.Objects.Entities;
using BlazorKanban.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace BlazorKanban.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskCardsController : ControllerBase
    {
        private readonly ILogger<TaskListsController> logger;
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public TaskCardsController(ILogger<TaskListsController> logger, IMediator mediator, IMapper mapper)
        {
            this.logger = logger;
            this.mediator = mediator;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<string>> CreateTaskCard(Card card)
        {
            var result = await mediator.Send(
                new CreateTaskCardCommand(
                    listId: card.ColumnId,
                    title: card.Title,
                    description: card.Description
                ));

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<string>> UpdateTaskCard(Card card)
        {
            var request = mapper.Map<TaskCard>(card);

            var result = await mediator.Send(
                new UpdateTaskCardCommand(
                    id: request.Id,
                    listId: request.ListId,
                    title: request.Title,
                    description: request.Description
                ));

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteTaskCard(string id)
        {
            var result = await mediator.Send(new DeleteTaskCardCommand(id: id));

            return Ok(result);
        }
    }
}