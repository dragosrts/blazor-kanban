using BlazorKanban.Domain.Contracts.Common;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorKanban.Domain.Contracts.TaskLists
{
    public interface IGetTaskListEntity<TList> : IGetEntity<TList>
    {
        public Task<IEnumerable<TList>> GetAllByTaskBoardIdAsync(string BoardId, CancellationToken cancellationToken);
    }
}