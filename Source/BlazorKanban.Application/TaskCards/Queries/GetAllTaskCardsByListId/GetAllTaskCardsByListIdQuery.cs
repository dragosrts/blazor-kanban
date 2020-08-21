using BlazorKanban.Domain.Objects.Entities;
using MediatR;
using System.Collections.Generic;

namespace BlazorKanban.Application.TaskCards.Queries.GetAllTaskCardsByListId
{
    public class GetAllTaskCardsByListIdQuery : IRequest<IEnumerable<TaskCard>>
    {
        public GetAllTaskCardsByListIdQuery(string listId)
        {
            ListId = listId;
        }

        public string ListId { get; }
    }
}