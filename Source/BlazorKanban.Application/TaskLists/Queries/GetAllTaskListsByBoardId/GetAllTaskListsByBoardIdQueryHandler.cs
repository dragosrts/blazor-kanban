using BlazorKanban.Domain.Contracts.TaskLists;
using BlazorKanban.Domain.Objects.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorKanban.Application.TaskLists.Queries.GetAllTaskListsByBoardId
{
    public class GetAllTaskListsByBoardIdQueryHandler : IRequestHandler<GetAllTaskListsByBoardIdQuery, IEnumerable<TaskList>>
    {
        private readonly IGetTaskListEntity<TaskList> tasklistGetter;

        public GetAllTaskListsByBoardIdQueryHandler(IGetTaskListEntity<TaskList> tasklistGetter)
        {
            this.tasklistGetter = tasklistGetter;
        }

        public async Task<IEnumerable<TaskList>> Handle(GetAllTaskListsByBoardIdQuery request, CancellationToken cancellationToken)
        {
            var result = await tasklistGetter.GetAllByTaskBoardIdAsync(request.BoardId, cancellationToken);

            return result;
        }
    }
}