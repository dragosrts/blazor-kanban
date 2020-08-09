using MediatR;

namespace BlazorKanban.Application.TaskBoards.Commands.DeleteTaskBoard
{
    public class DeleteTaskBoardCommand : IRequest<bool>
    {
        public DeleteTaskBoardCommand(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}