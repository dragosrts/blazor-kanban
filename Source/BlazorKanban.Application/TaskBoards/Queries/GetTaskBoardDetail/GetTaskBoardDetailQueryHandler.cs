using BlazorKanban.Domain.Contracts.Common;
using BlazorKanban.Domain.Objects.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorKanban.Application.TaskBoards.Queries.GetTaskBoardDetail
{
    public class GetTaskBoardDetailQueryHandler : IRequestHandler<GetTaskBoardDetailQuery, TaskBoard>
    {
        private readonly IFindEntity<TaskBoard> taskBoard;

        public GetTaskBoardDetailQueryHandler(IFindEntity<TaskBoard> taskBoard)
        {
            this.taskBoard = taskBoard;
        }

        public async Task<TaskBoard> Handle(GetTaskBoardDetailQuery request, CancellationToken cancellationToken)
        {
            var board = await taskBoard.FindByIdAsync(request.Id, cancellationToken);

            return board;
        }
    }
}