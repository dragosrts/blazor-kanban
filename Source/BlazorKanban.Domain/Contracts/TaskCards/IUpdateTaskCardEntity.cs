using BlazorKanban.Domain.Contracts.Common;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorKanban.Domain.Contracts.TaskCards
{
    public interface IUpdateTaskCardEntity<TCard> : IUpdateEntity<TCard>
    {
        Task<bool> UpdateTaskCardsPositionAsync(IList<TCard> cards, CancellationToken cancellationToken);
    }
}