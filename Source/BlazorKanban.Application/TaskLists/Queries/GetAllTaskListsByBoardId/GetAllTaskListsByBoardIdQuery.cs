using BlazorKanban.Domain.Objects.Entities;
using MediatR;
using System.Collections.Generic;

namespace BlazorKanban.Application.TaskLists.Queries.GetAllTaskListsByBoardId
{
    public class GetAllTaskListsByBoardIdQuery : IRequest<IEnumerable<TaskList>>
    {
        public GetAllTaskListsByBoardIdQuery(string boardId)
        {
            BoardId = boardId;
        }

        public string BoardId { get; }
    }
}