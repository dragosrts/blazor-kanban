using BlazorKanban.Domain.Objects.Entities;
using MediatR;

namespace BlazorKanban.Application.TaskLists.Queries.GetTaskListDetailsById
{
    public class GetTaskListDetailsByIdQuery : IRequest<TaskList>
    {
        public GetTaskListDetailsByIdQuery(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}