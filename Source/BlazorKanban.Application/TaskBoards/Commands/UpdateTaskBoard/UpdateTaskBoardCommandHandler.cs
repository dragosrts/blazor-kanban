using BlazorKanban.Domain.Contracts.TaskBoards;
using BlazorKanban.Domain.Objects.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorKanban.Application.TaskBoards.Commands.UpdateTaskBoard
{
    public class UpdateTaskBoardCommandHandler : IRequestHandler<UpdateTaskBoardCommand, string>
    {
        private readonly IUpdateTaskBoardEntity<TaskBoard> updateTaskBoard;

        public UpdateTaskBoardCommandHandler(IUpdateTaskBoardEntity<TaskBoard> updateTaskBoard)
        {
            this.updateTaskBoard = updateTaskBoard;
        }

        public async Task<string> Handle(UpdateTaskBoardCommand request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var entity =
                new TaskBoard(
                    id: request.Id,
                    title: request.Title,
                    description: request.Description,
                    lists: request.Lists
                );

            var taskBoardResult = await updateTaskBoard.UpdateAsync(entity, cancellationToken).ConfigureAwait(false);

            return taskBoardResult;
        }
    }
}