using BlazorKanban.Domain.Contracts.TaskBoards;
using BlazorKanban.Domain.Contracts.TaskCards;
using BlazorKanban.Domain.Contracts.TaskLists;
using BlazorKanban.Domain.Objects.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorKanban.Application.TaskBoards.Queries.GetTaskBoard
{
    public class GetTaskBoardDetailQueryHandler : IRequestHandler<GetTaskBoardDetailQuery, TaskBoard>
    {
        private readonly IGetTaskBoardEntity<TaskBoard> taskBoardGetter;
        private readonly IGetTaskListEntity<TaskList> taskListGetter;
        private readonly IGetTaskCardEntity<TaskCard> taskCardGetter;

        public GetTaskBoardDetailQueryHandler(IGetTaskBoardEntity<TaskBoard> taskBoardGetter, IGetTaskListEntity<TaskList> taskListGetter, IGetTaskCardEntity<TaskCard> taskCardGetter)
        {
            this.taskBoardGetter = taskBoardGetter ?? throw new ArgumentNullException(nameof(taskBoardGetter));
            this.taskListGetter = taskListGetter ?? throw new ArgumentNullException(nameof(taskListGetter));
            this.taskCardGetter = taskCardGetter ?? throw new ArgumentNullException(nameof(taskCardGetter));
        }

        public async Task<TaskBoard> Handle(GetTaskBoardDetailQuery request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var boardResult = await taskBoardGetter.GetByIdAsync(request.Id, cancellationToken).ConfigureAwait(false);

            if (boardResult == null) throw new ArgumentNullException(nameof(boardResult));

            var columnsResult = await taskListGetter.GetAllByTaskBoardIdAsync(boardResult.Id, cancellationToken);

            var taskLists = new List<TaskList>();

            foreach (var column in columnsResult)
            {
                if (column == null) throw new ArgumentNullException(nameof(column));

                var taskCards = new List<TaskCard>();

                taskCards.AddRange(await taskCardGetter.GetAllByTaskListIdAsync(column.Id, cancellationToken));

                taskLists.Add(
                    new TaskList(
                        id: column.Id,
                        boardId: column.BoardId,
                        title: column.Title,
                        description: column.Description,
                        cards: taskCards
                        )
                    );
            }

            var taskBoard =
                new TaskBoard(
                    id: boardResult.Id,
                    title: boardResult.Title,
                    description: boardResult.Description,
                    lists: taskLists
                );

            return taskBoard;
        }
    }
}