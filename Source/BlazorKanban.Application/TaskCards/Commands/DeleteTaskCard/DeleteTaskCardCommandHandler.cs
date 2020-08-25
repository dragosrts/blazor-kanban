using BlazorKanban.Domain.Contracts.TaskCards;
using BlazorKanban.Domain.Objects.Entities;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorKanban.Application.TaskCards.Commands.DeleteTaskCard
{
    public class DeleteTaskCardCommandHandler : IRequestHandler<DeleteTaskCardCommand, bool>
    {
        private readonly IDeleteTaskCardEntity<TaskCard> deleteTaskCard;
        private readonly IUpdateTaskCardEntity<TaskCard> updateTaskCard;
        private readonly IGetTaskCardEntity<TaskCard> getTaskCard;

        public DeleteTaskCardCommandHandler(IDeleteTaskCardEntity<TaskCard> deleteTaskCard, IUpdateTaskCardEntity<TaskCard> updateTaskCard, IGetTaskCardEntity<TaskCard> getTaskCard)
        {
            this.deleteTaskCard = deleteTaskCard;
            this.updateTaskCard = updateTaskCard;
            this.getTaskCard = getTaskCard;
        }

        public async Task<bool> Handle(DeleteTaskCardCommand request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            bool result = false;

            // First: Get the card that should be deleted so that you can have the list id
            var getTaskCardDeleted = await getTaskCard.GetByIdAsync(request.Id, cancellationToken).ConfigureAwait(false);

            // Second: delete the card
            var taskCardDeleteResult = await deleteTaskCard.DeleteAsync(request.Id, cancellationToken).ConfigureAwait(false);

            if (taskCardDeleteResult)
            {
                // Third: Get the remaining cards in the column
                var getTaskCardList = await getTaskCard.GetAllByTaskListIdAsync(getTaskCardDeleted.ListId, cancellationToken).ConfigureAwait(false);

                //Forth: Update the cards positioning
                result = await updateTaskCard.UpdateTaskCardsPositionAsync(getTaskCardList.ToList(), cancellationToken).ConfigureAwait(false);
            }

            return result;
        }
    }
}