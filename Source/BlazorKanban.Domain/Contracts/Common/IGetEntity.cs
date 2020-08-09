using System.Threading;
using System.Threading.Tasks;

namespace BlazorKanban.Domain.Contracts.Common
{
    public interface IGetEntity<T> : IBaseGetEntity
    {
        Task<T> GetByIdAsync(string Id, CancellationToken cancellationToken);
    }
}