using System.Threading;
using System.Threading.Tasks;

namespace BlazorKanban.Domain.Contracts.Common
{
    public interface IDeleteEntity<T> : IBaseDeleteEntity
    {
        Task<bool> DeleteAsync(string entityId, CancellationToken cancellationToken);
    }
}