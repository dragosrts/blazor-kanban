using BlazorKanban.Domain.Contracts.Common;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorKanban.Domain.Contracts.TaskCards
{
    public interface IGetTaskCardEntity<TCard> : IGetEntity<TCard>
    {
        public Task<IEnumerable<TCard>> GetAllByTaskListIdAsync(string ListId, CancellationToken cancellationToken);
    }
}