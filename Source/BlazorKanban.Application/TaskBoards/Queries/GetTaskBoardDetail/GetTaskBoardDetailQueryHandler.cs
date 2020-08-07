using BlazorKanban.Domain.Contracts.TaskBoards;
using BlazorKanban.Domain.Contracts.TaskCards;
using BlazorKanban.Domain.Contracts.TaskLists;
using BlazorKanban.Domain.Objects.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorKanban.Application.TaskBoards.Queries.GetTaskBoardDetail
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

            var board = await taskBoardGetter.GetByIdAsync(request.Id, cancellationToken).ConfigureAwait(false);

            if (board == null) throw new ArgumentNullException(nameof(board));

            var columns = await taskListGetter.GetAllByTaskBoardIdAsync(board.Id, cancellationToken);

            foreach (var column in columns)
            {
                if (column == null) throw new ArgumentNullException(nameof(column));

                var cards = new List<TaskCard>();
                cards.AddRange(await taskCardGetter.GetAllByTaskListIdAsync(column.Id, cancellationToken));
                column.Cards = cards;
            }

            board.Lists = columns;

            return board;
        }
    }
}