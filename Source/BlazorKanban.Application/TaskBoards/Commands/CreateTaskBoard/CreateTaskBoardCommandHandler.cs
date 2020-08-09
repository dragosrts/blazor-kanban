using BlazorKanban.Domain.Contracts.TaskBoards;
using BlazorKanban.Domain.Objects.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorKanban.Application.TaskBoards.Commands.CreateTaskBoard
{
    public class CreateTaskBoardCommandHandler : IRequestHandler<CreateTaskBoardCommand, string>
    {
        private readonly ICreateTaskBoardEntity<TaskBoard> createTaskBoard;

        public CreateTaskBoardCommandHandler(ICreateTaskBoardEntity<TaskBoard> createTaskBoard)
        {
            this.createTaskBoard = createTaskBoard;
        }

        public async Task<string> Handle(CreateTaskBoardCommand request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var newId = createTaskBoard.GenerateIdentifier();

            var entity =
                new TaskBoard(
                    id: newId,
                    title: request.Title,
                    description: request.Description,
                    lists: new List<TaskList>()
                );

            var boardResult = await createTaskBoard.CreateAsync(entity, cancellationToken).ConfigureAwait(false);

            return boardResult;
        }
    }
}