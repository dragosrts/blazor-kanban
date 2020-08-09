using MediatR;

namespace BlazorKanban.Application.TaskCards.Commands.CreateTaskCard
{
    public class CreateTaskCardCommand : IRequest<string>
    {
        public CreateTaskCardCommand(string listId, string title, string description)
        {
            ListId = listId;
            Title = title;
            Description = description;
        }

        public string ListId { get; }

        public string Title { get; }

        public string Description { get; }
    }
}