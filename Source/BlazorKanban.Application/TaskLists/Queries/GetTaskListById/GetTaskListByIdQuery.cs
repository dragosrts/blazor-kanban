using BlazorKanban.Domain.Objects.Entities;
using MediatR;

namespace BlazorKanban.Application.TaskLists.Queries.GetTaskListById
{
    public class GetTaskListByIdQuery : IRequest<TaskList>
    {
        public GetTaskListByIdQuery(string listId)
        {
            ListId = listId;
        }

        public string ListId { get; }
    }
}