using MediatR;

namespace BlazorKanban.Application.TaskLists.Commands.CreateTaskList
{
    public class CreateTaskListCommand : IRequest<string>
    {
        public CreateTaskListCommand(string boardId, string title, string description)
        {
            BoardId = boardId;
            Title = title;
            Description = description;
        }

        public string BoardId { get; }

        public string Title { get; }

        public string Description { get; }
    }
}