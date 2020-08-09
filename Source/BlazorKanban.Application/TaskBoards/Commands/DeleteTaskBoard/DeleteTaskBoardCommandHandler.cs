using BlazorKanban.Domain.Contracts.TaskBoards;
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

        public DeleteTaskBoardCommandHandler(IDeleteTaskBoardEntity<TaskBoard> deleteTaskBoard)
        {
            this.deleteTaskBoard = deleteTaskBoard;
        }

        public async Task<bool> Handle(DeleteTaskBoardCommand request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var taskBoardResult = await deleteTaskBoard.DeleteAsync(request.Id, cancellationToken).ConfigureAwait(false);

            return taskBoardResult;
        }
    }
}