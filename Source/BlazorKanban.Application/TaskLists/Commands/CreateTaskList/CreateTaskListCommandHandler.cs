using BlazorKanban.Domain.Contracts.TaskLists;
using BlazorKanban.Domain.Objects.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorKanban.Application.TaskLists.Commands.CreateTaskList
{
    public class CreateTaskListCommandHandler : IRequestHandler<CreateTaskListCommand, string>
    {
        private readonly ICreateTaskListEntity<TaskList> createTaskList;

        public CreateTaskListCommandHandler(ICreateTaskListEntity<TaskList> createTaskList)
        {
            this.createTaskList = createTaskList;
        }

        public async Task<string> Handle(CreateTaskListCommand request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var entity =
                new TaskList(
                    id: createTaskList.GenerateIdentifier(),
                    boardId: request.BoardId,
                    title: request.Title,
                    description: request.Description,
                    cards: new List<TaskCard>()
                );

            var listResult = await createTaskList.CreateAsync(entity, cancellationToken).ConfigureAwait(false);

            return listResult;
        }
    }
}