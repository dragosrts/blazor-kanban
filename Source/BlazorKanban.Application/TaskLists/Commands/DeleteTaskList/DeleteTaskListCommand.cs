using MediatR;

namespace BlazorKanban.Application.TaskLists.Commands.DeleteTaskList
{
    public class DeleteTaskListCommand : IRequest<bool>
    {
        public DeleteTaskListCommand(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}