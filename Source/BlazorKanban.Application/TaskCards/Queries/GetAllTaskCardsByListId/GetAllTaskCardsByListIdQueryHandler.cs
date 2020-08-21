using BlazorKanban.Domain.Contracts.TaskCards;
using BlazorKanban.Domain.Objects.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorKanban.Application.TaskCards.Queries.GetAllTaskCardsByListId
{
    public class GetAllTaskCardsByListIdQueryHandler : IRequestHandler<GetAllTaskCardsByListIdQuery, IEnumerable<TaskCard>>
    {
        private readonly IGetTaskCardEntity<TaskCard> taskCardGetter;

        public GetAllTaskCardsByListIdQueryHandler(IGetTaskCardEntity<TaskCard> taskCardGetter)
        {
            this.taskCardGetter = taskCardGetter;
        }

        public async Task<IEnumerable<TaskCard>> Handle(GetAllTaskCardsByListIdQuery request, CancellationToken cancellationToken)
        {
            var result = await taskCardGetter.GetAllByTaskListIdAsync(request.ListId, cancellationToken);

            return result;
        }
    }
}