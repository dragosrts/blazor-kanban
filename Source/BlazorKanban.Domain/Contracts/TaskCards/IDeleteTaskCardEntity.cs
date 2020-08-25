using BlazorKanban.Domain.Contracts.Common;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorKanban.Domain.Contracts.TaskCards
{
    public interface IDeleteTaskCardEntity<TCard> : IDeleteEntity<TCard>
    {
        Task<bool> DeleteAllByTaskListIdAsync(string taskListId, CancellationToken cancellationToken);
    }
}