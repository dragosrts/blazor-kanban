using BlazorKanban.Domain.Objects.Entities;
using MediatR;

namespace BlazorKanban.Application.TaskCards.Queries.GetTaskCardById
{
    public class GetTaskCardByIdQuery : IRequest<TaskCard>
    {
        public GetTaskCardByIdQuery(string cardId)
        {
            CardId = cardId;
        }

        public string CardId { get; }
    }
}