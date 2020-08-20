using BlazorKanban.Domain.Contracts.TaskBoards;
using BlazorKanban.Domain.Objects.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorKanban.Application.TaskBoards.Queries.GetAllTaskBoardsByUserId
{
    public class GetAllTaskBoardsByUserIdQueryHandler : IRequestHandler<GetAllTaskBoardsByUserIdQuery, IEnumerable<TaskBoard>>
    {
        private readonly IGetTaskBoardEntity<TaskBoard> taskBoardGetter;

        public GetAllTaskBoardsByUserIdQueryHandler(IGetTaskBoardEntity<TaskBoard> taskBoardGetter)
        {
            this.taskBoardGetter = taskBoardGetter;
        }

        public async Task<IEnumerable<TaskBoard>> Handle(GetAllTaskBoardsByUserIdQuery request, CancellationToken cancellationToken)
        {
            var result = await taskBoardGetter.GetAllBoardsByUserIdAsync(request.UserId, cancellationToken);

            return result;
        }
    }
}