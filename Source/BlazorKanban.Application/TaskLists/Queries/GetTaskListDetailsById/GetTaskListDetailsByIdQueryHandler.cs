using BlazorKanban.Domain.Contracts.TaskCards;
using BlazorKanban.Domain.Contracts.TaskLists;
using BlazorKanban.Domain.Objects.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorKanban.Application.TaskLists.Queries.GetTaskListDetailsById
{
    public class GetTaskListDetailsByIdQueryHandler : IRequestHandler<GetTaskListDetailsByIdQuery, TaskList>
    {
        private readonly IGetTaskListEntity<TaskList> taskListGetter;
        private readonly IGetTaskCardEntity<TaskCard> taskCardGetter;

        public GetTaskListDetailsByIdQueryHandler(IGetTaskListEntity<TaskList> taskListGetter, IGetTaskCardEntity<TaskCard> taskCardGetter)
        {
            this.taskListGetter = taskListGetter ?? throw new ArgumentNullException(nameof(taskListGetter));
            this.taskCardGetter = taskCardGetter ?? throw new ArgumentNullException(nameof(taskCardGetter));
        }

        public async Task<TaskList> Handle(GetTaskListDetailsByIdQuery request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var taskListResult = await taskListGetter.GetByIdAsync(request.Id, cancellationToken);

            if (taskListResult == null) throw new ArgumentNullException(nameof(taskListResult));

            var taskCards = await taskCardGetter.GetAllByTaskListIdAsync(taskListResult.Id, cancellationToken);

            var taskList =
                new TaskList(
                    id: taskListResult.Id,
                    boardId: taskListResult.BoardId,
                    title: taskListResult.Title,
                    description: taskListResult.Description,
                    cards: taskCards
                );

            return taskList;
        }
    }
}