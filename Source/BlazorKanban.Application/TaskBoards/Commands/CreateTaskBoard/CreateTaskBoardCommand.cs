using MediatR;

namespace BlazorKanban.Application.TaskBoards.Commands.CreateTaskBoard
{
    public class CreateTaskBoardCommand : IRequest<string>
    {
        public CreateTaskBoardCommand(string title, string description)
        {
            Title = title;
            Description = description;
        }

        public string Title { get; }

        public string Description { get; }
    }
}