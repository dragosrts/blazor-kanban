using MediatR;

namespace BlazorKanban.Application.TaskCards.Commands.DeleteTaskCard
{
    public class DeleteTaskCardCommand : IRequest<bool>
    {
        public DeleteTaskCardCommand(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}