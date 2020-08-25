using BlazorKanban.Domain.Contracts.TaskLists;
using BlazorKanban.Domain.Objects.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorKanban.Application.TaskLists.Queries.GetTaskListById
{
    public class GetTaskListByIdQueryHandler : IRequestHandler<GetTaskListByIdQuery, TaskList>
    {
        private readonly IGetTaskListEntity<TaskList> taskListGetter;

        public GetTaskListByIdQueryHandler(IGetTaskListEntity<TaskList> taskListGetter)
        {
            this.taskListGetter = taskListGetter;
        }

        public async Task<TaskList> Handle(GetTaskListByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await taskListGetter.GetByIdAsync(request.ListId, cancellationToken);

            return result;
        }
    }
}