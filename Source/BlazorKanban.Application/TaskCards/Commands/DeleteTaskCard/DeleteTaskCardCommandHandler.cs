using BlazorKanban.Domain.Contracts.TaskCards;
using BlazorKanban.Domain.Objects.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorKanban.Application.TaskCards.Commands.DeleteTaskCard
{
    public class DeleteTaskCardCommandHandler : IRequestHandler<DeleteTaskCardCommand, bool>
    {
        private readonly IDeleteTaskCardEntity<TaskCard> deleteTaskCard;

        public DeleteTaskCardCommandHandler(IDeleteTaskCardEntity<TaskCard> deleteTaskCard)
        {
            this.deleteTaskCard = deleteTaskCard;
        }

        public async Task<bool> Handle(DeleteTaskCardCommand request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var taskCardResult = await deleteTaskCard.DeleteAsync(request.Id, cancellationToken).ConfigureAwait(false);

            return taskCardResult;
        }
    }
}