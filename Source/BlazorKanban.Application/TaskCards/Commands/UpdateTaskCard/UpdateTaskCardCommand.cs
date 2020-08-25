using MediatR;

namespace BlazorKanban.Application.TaskCards.Commands.UpdateTaskCard
{
    public class UpdateTaskCardCommand : IRequest<string>
    {
        public UpdateTaskCardCommand(string id, string listId, string title, string description, long position)
        {
            Id = id;
            ListId = listId;
            Title = title;
            Description = description;
            Position = position;
        }

        public string Id { get; }

        public string ListId { get; }

        public string Title { get; }

        public string Description { get; }

        public long Position { get; }
    }
}