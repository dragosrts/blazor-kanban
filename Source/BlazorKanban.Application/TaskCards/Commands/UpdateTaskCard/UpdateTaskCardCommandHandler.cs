using BlazorKanban.Domain.Contracts.TaskCards;
using BlazorKanban.Domain.Objects.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorKanban.Application.TaskCards.Commands.UpdateTaskCard
{
    public class UpdateTaskCardCommandHandler : IRequestHandler<UpdateTaskCardCommand, string>
    {
        private readonly IUpdateTaskCardEntity<TaskCard> updateTaskCard;

        public UpdateTaskCardCommandHandler(IUpdateTaskCardEntity<TaskCard> updateTaskCard)
        {
            this.updateTaskCard = updateTaskCard;
        }

        public async Task<string> Handle(UpdateTaskCardCommand request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var entity =
                new TaskCard(
                    id: request.Id,
                    listId: request.ListId,
                    title: request.Title,
                    description: request.Description
                );

            var taskCardResult = await updateTaskCard.UpdateAsync(entity, cancellationToken).ConfigureAwait(false);

            return taskCardResult;
        }
    }
}