using System.Threading;
using System.Threading.Tasks;

namespace BlazorKanban.Domain.Contracts.Common
{
    public interface IGetEntity<T> : IBaseGetEntity
    {
        public Task<T> GetByIdAsync(string Id, CancellationToken cancellationToken);
    }
}