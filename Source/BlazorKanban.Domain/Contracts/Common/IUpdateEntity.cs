using System.Threading;
using System.Threading.Tasks;

namespace BlazorKanban.Domain.Contracts.Common
{
    public interface IUpdateEntity<T> : IBaseUpdateEntity
    {
        Task<string> UpdateAsync(T entity, CancellationToken cancellationToken);
    }
}