using System.Threading;
using System.Threading.Tasks;

namespace BlazorKanban.Domain.Contracts.Common
{
    public interface IDeleteEntity<T> : IBaseDeleteEntity
    {
        public Task<bool> DeleteAsync(T entity, CancellationToken cancellationToken);
    }
}