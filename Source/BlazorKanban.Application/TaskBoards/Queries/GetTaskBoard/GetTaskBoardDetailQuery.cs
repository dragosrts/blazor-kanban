using BlazorKanban.Domain.Objects.Entities;
using MediatR;

namespace BlazorKanban.Application.TaskBoards.Queries.GetTaskBoard
{
    public class GetTaskBoardDetailQuery : IRequest<TaskBoard>
    {
        public GetTaskBoardDetailQuery(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}