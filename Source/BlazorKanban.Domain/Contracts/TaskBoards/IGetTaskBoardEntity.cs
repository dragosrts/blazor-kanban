using BlazorKanban.Domain.Contracts.Common;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorKanban.Domain.Contracts.TaskBoards
{
    public interface IGetTaskBoardEntity<TBoard> : IGetEntity<TBoard>
    {
        Task<TBoard> GetAllBoardsAsync(CancellationToken cancellationToken);
    }
}