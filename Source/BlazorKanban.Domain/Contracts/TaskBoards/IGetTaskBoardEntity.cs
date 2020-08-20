using BlazorKanban.Domain.Contracts.Common;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorKanban.Domain.Contracts.TaskBoards
{
    public interface IGetTaskBoardEntity<TBoard> : IGetEntity<TBoard>
    {
        Task<IEnumerable<TBoard>> GetAllBoardsByUserIdAsync(string UserId, CancellationToken cancellationToken);
    }
}