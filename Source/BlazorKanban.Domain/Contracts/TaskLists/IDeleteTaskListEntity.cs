using BlazorKanban.Domain.Contracts.Common;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorKanban.Domain.Contracts.TaskLists
{
    public interface IDeleteTaskListEntity<TList> : IDeleteEntity<TList>
    {
        Task<bool> DeleteAllByTaskBoardIdAsync(string taskBoardId, CancellationToken cancellationToken);
    }
}