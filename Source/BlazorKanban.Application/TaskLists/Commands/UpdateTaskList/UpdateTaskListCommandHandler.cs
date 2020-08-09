using BlazorKanban.Domain.Contracts.TaskLists;
using BlazorKanban.Domain.Objects.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorKanban.Application.TaskLists.Commands.UpdateTaskList
{
    public class UpdateTaskListCommandHandler : IRequestHandler<UpdateTaskListCommand, string>
    {
        private readonly IUpdateTaskListEntity<TaskList> updateTaskList;

        public UpdateTaskListCommandHandler(IUpdateTaskListEntity<TaskList> updateTaskList)
        {
            this.updateTaskList = updateTaskList;
        }

        public async Task<string> Handle(UpdateTaskListCommand request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var entity =
                new TaskList(
                    id: request.Id,
                    boardId: request.BoardId,
                    title: request.Title,
                    description: request.Description,
                    cards: request.Cards
                );

            var taskListResult = await updateTaskList.UpdateAsync(entity, cancellationToken).ConfigureAwait(false);

            return taskListResult;
        }
    }
}