using AutoMapper;
using BlazorKanban.Application.TaskCards.Commands.CreateTaskCard;
using BlazorKanban.Application.TaskCards.Commands.DeleteTaskCard;
using BlazorKanban.Application.TaskCards.Commands.UpdateTaskCard;
using BlazorKanban.Application.TaskCards.Commands.UpdateTaskCardsDetails;
using BlazorKanban.Application.TaskCards.Queries.GetAllTaskCardsByListId;
using BlazorKanban.Application.TaskCards.Queries.GetTaskCardById;
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

        [HttpGet("{columnid}/cards")]
        public async Task<IEnumerable<Card>> GetTaskCardsByColumnId(string columnid)
        {
            var result = await mediator.Send(new GetAllTaskCardsByListIdQuery(listId: columnid));

            var response = mapper.Map<IEnumerable<Card>>(result);

            return response;
        }

        [HttpGet("{id}")]
        public async Task<Card> GetTaskCard(string id)
        {
            var result = await mediator.Send(new GetTaskCardByIdQuery(cardId: id));

            var response = mapper.Map<Card>(result);

            return response;
        }

        [HttpPost]
        public async Task<ActionResult<string>> CreateTaskCard(Card card)
        {
            var request = mapper.Map<TaskCard>(card);

            var result = await mediator.Send(
                new CreateTaskCardCommand(
                    listId: request.ListId,
                    title: request.Title,
                    description: request.Description,
                    position: request.Position
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
                    description: request.Description,
                    position: request.Position
                ));

            return Ok(result);
        }

        [HttpPut("{columnid}/cards")]
        public async Task<ActionResult<bool>> UpdateTaskCards(IEnumerable<Card> cards)
        {
            var requestDetails = mapper.Map<IEnumerable<TaskCard>>(cards);

            var taskCardDetails = new List<TaskCardDetail>();

            foreach (var requestDetail in requestDetails)
            {
                taskCardDetails.Add(new TaskCardDetail(
                        id: requestDetail.Id,
                        listId: requestDetail.ListId,
                        title: requestDetail.Title,
                        description: requestDetail.Description,
                        position: requestDetail.Position
                    ));
            }

            var result = await mediator.Send(new UpdateTaskCardsDetailsCommand(taskCardDetails));

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