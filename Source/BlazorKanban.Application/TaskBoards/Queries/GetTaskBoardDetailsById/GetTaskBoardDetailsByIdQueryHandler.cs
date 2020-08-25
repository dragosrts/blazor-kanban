using BlazorKanban.Domain.Contracts.TaskBoards;
using BlazorKanban.Domain.Contracts.TaskCards;
using BlazorKanban.Domain.Contracts.TaskLists;
using BlazorKanban.Domain.Objects.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorKanban.Application.TaskBoards.Queries.GetTaskBoardDetailsById
{
    public class GetTaskBoardDetailsByIdQueryHandler : IRequestHandler<GetTaskBoardDetailsByIdQuery, TaskBoard>
    {
        private readonly IGetTaskBoardEntity<TaskBoard> taskBoardGetter;
        private readonly IGetTaskListEntity<TaskList> taskListGetter;
        private readonly IGetTaskCardEntity<TaskCard> taskCardGetter;

        public GetTaskBoardDetailsByIdQueryHandler(IGetTaskBoardEntity<TaskBoard> taskBoardGetter, IGetTaskListEntity<TaskList> taskListGetter, IGetTaskCardEntity<TaskCard> taskCardGetter)
        {
            this.taskBoardGetter = taskBoardGetter ?? throw new ArgumentNullException(nameof(taskBoardGetter));
            this.taskListGetter = taskListGetter ?? throw new ArgumentNullException(nameof(taskListGetter));
            this.taskCardGetter = taskCardGetter ?? throw new ArgumentNullException(nameof(taskCardGetter));
        }

        public async Task<TaskBoard> Handle(GetTaskBoardDetailsByIdQuery request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var boardResult = await taskBoardGetter.GetByIdAsync(request.Id, cancellationToken).ConfigureAwait(false);

            if (boardResult == null) throw new ArgumentNullException(nameof(boardResult));

            var columnsResult = await taskListGetter.GetAllByTaskBoardIdAsync(boardResult.Id, cancellationToken);

            var taskLists = new List<TaskList>();

            foreach (var column in columnsResult)
            {
                if (column == null) throw new ArgumentNullException(nameof(column));

                var orderedTaskCards = new List<TaskCard>();

                orderedTaskCards.AddRange((await taskCardGetter.GetAllByTaskListIdAsync(column.Id, cancellationToken)).OrderBy(opts => opts.Position));

                taskLists.Add(
                    new TaskList(
                        id: column.Id,
                        boardId: column.BoardId,
                        title: column.Title,
                        description: column.Description,
                        cards: orderedTaskCards
                        )
                    );
            }

            var taskBoard =
                new TaskBoard(
                    id: boardResult.Id,
                    userId: boardResult.UserId,
                    title: boardResult.Title,
                    description: boardResult.Description,
                    lists: taskLists
                );

            return taskBoard;
        }
    }
}