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

        public DeleteTaskListCommandHandler(IDeleteTaskListEntity<TaskList> deleteTaskList)
        {
            this.deleteTaskList = deleteTaskList;
        }

        public async Task<bool> Handle(DeleteTaskListCommand request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var taskListResult = await deleteTaskList.DeleteAsync(request.Id, cancellationToken).ConfigureAwait(false);

            return taskListResult;
        }
    }
}