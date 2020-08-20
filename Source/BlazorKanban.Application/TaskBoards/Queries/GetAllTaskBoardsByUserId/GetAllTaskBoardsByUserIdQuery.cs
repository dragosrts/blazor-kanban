using BlazorKanban.Domain.Objects.Entities;
using MediatR;
using System.Collections.Generic;

namespace BlazorKanban.Application.TaskBoards.Queries.GetAllTaskBoardsByUserId
{
    public class GetAllTaskBoardsByUserIdQuery : IRequest<IEnumerable<TaskBoard>>
    {
        public GetAllTaskBoardsByUserIdQuery(string userId)
        {
            UserId = userId;
        }

        public string UserId { get; }
    }
}