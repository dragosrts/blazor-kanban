using BlazorKanban.Domain.Objects.Entities;
using MediatR;

namespace BlazorKanban.Application.TaskBoards.Queries.GetTaskBoardDetailsById
{
    public class GetTaskBoardDetailsByIdQuery : IRequest<TaskBoard>
    {
        public GetTaskBoardDetailsByIdQuery(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}