using BlazorKanban.Domain.Contracts.TaskBoards;
using BlazorKanban.Domain.Contracts.TaskCards;
using BlazorKanban.Domain.Contracts.TaskLists;
using BlazorKanban.Domain.Objects.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorKanban.Application.TaskBoards.Commands.DeleteTaskBoard
{
    public class DeleteTaskBoardCommandHandler : IRequestHandler<DeleteTaskBoardCommand, bool>
    {
        private readonly IDeleteTaskBoardEntity<TaskBoard> deleteTaskBoard;
        private readonly IGetTaskListEntity<TaskList> getTaskList;
        private readonly IDeleteTaskListEntity<TaskList> deleteTaskList;
        private readonly IDeleteTaskCardEntity<TaskCard> deleteTaskCard;

        public DeleteTaskBoardCommandHandler(
            IDeleteTaskBoardEntity<TaskBoard> deleteTaskBoard,
            IGetTaskListEntity<TaskList> getTaskList,
            IDeleteTaskListEntity<TaskList> deleteTaskList,
            IDeleteTaskCardEntity<TaskCard> deleteTaskCard)
        {
            this.deleteTaskBoard = deleteTaskBoard;
            this.getTaskList = getTaskList;
            this.deleteTaskList = deleteTaskList;
            this.deleteTaskCard = deleteTaskCard;
        }

        public async Task<bool> Handle(DeleteTaskBoardCommand request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            bool result = true;

            var taskLists = await getTaskList.GetAllByTaskBoardIdAsync(request.Id, cancellationToken).ConfigureAwait(false);

            foreach (var list in taskLists)
            {
                result &= await deleteTaskCard.DeleteAllByTaskListIdAsync(list.Id, cancellationToken).ConfigureAwait(false);
            }

            result &= await deleteTaskList.DeleteAllByTaskBoardIdAsync(request.Id, cancellationToken).ConfigureAwait(false);

            result &= await deleteTaskBoard.DeleteAsync(request.Id, cancellationToken).ConfigureAwait(false);

            return result;
        }
    }
}