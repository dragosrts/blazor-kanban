using BlazorKanban.Domain.Contracts.TaskCards;
using BlazorKanban.Domain.Objects.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorKanban.Application.TaskCards.Commands.UpdateTaskCardsDetails
{
    public class UpdateTaskCardsDetailsCommandHandler : IRequestHandler<UpdateTaskCardsDetailsCommand, bool>
    {
        private readonly IUpdateTaskCardEntity<TaskCard> updateTaskCard;

        public UpdateTaskCardsDetailsCommandHandler(IUpdateTaskCardEntity<TaskCard> updateTaskCard)
        {
            this.updateTaskCard = updateTaskCard;
        }

        public async Task<bool> Handle(UpdateTaskCardsDetailsCommand request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var result = false;

            var taskCardIds = new List<string>();

            foreach (var cardDetail in request.TaskCardDetails)
            {
                var entity =
                    new TaskCard(
                        id: cardDetail.Id,
                        listId: cardDetail.ListId,
                        title: cardDetail.Title,
                        description: cardDetail.Description,
                        position: cardDetail.Position
                    );

                taskCardIds.Add(await updateTaskCard.UpdateAsync(entity, cancellationToken).ConfigureAwait(false));
            }

            if (taskCardIds.Count == request.TaskCardDetails.Count())
            {
                result = true;
            }

            return result;
        }
    }
}