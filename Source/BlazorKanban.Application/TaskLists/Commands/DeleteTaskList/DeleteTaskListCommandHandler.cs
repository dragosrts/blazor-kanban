using BlazorKanban.Domain.Contracts.TaskCards;
using BlazorKanban.Domain.Contracts.TaskLists;
using BlazorKanban.Domain.Objects.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorKanban.Application.TaskLists.Commands.DeleteTaskList
{
    public class DeleteTaskListCommandHandler : IRequestHandler<DeleteTaskListCommand, bool>
    {
        private readonly IDeleteTaskListEntity<TaskList> deleteTaskList;
        private readonly IDeleteTaskCardEntity<TaskCard> deleteTaskCard;

        public DeleteTaskListCommandHandler(IDeleteTaskListEntity<TaskList> deleteTaskList, IDeleteTaskCardEntity<TaskCard> deleteTaskCard)
        {
            this.deleteTaskList = deleteTaskList;
            this.deleteTaskCard = deleteTaskCard;
        }

        public async Task<bool> Handle(DeleteTaskListCommand request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            bool result = true;

            result &= await deleteTaskCard.DeleteAllByTaskListIdAsync(request.Id, cancellationToken).ConfigureAwait(false);

            result &= await deleteTaskList.DeleteAsync(request.Id, cancellationToken).ConfigureAwait(false);

            return result;
        }
    }
}