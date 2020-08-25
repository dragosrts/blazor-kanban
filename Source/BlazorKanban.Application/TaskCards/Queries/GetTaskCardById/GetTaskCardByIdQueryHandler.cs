using BlazorKanban.Domain.Contracts.TaskCards;
using BlazorKanban.Domain.Objects.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorKanban.Application.TaskCards.Queries.GetTaskCardById
{
    public class GetTaskCardByIdQueryHandler : IRequestHandler<GetTaskCardByIdQuery, TaskCard>
    {
        private readonly IGetTaskCardEntity<TaskCard> taskCardGetter;

        public GetTaskCardByIdQueryHandler(IGetTaskCardEntity<TaskCard> taskCardGetter)
        {
            this.taskCardGetter = taskCardGetter;
        }

        public async Task<TaskCard> Handle(GetTaskCardByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await taskCardGetter.GetByIdAsync(request.CardId, cancellationToken);

            return result;
        }
    }
}