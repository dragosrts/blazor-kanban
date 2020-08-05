using System.Threading;
using System.Threading.Tasks;

namespace BlazorKanban.Domain.Contracts.Common
{
    public interface IFindEntity<T> : IBaseFindEntity
    {
        public Task<T> FindByIdAsync(string Id, CancellationToken cancellationToken);
    }
}