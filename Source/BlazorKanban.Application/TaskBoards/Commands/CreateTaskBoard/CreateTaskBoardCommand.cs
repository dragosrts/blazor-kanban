using MediatR;

namespace BlazorKanban.Application.TaskBoards.Commands.CreateTaskBoard
{
    public class CreateTaskBoardCommand : IRequest<string>
    {
        public CreateTaskBoardCommand(string userId, string title, string description)
        {
            UserId = userId;
            Title = title;
            Description = description;
        }

        public string UserId { get; }

        public string Title { get; }

        public string Description { get; }
    }
}