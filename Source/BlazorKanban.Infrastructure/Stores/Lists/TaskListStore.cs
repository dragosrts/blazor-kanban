using BlazorKanban.Domain.Contracts.TaskLists;
using BlazorKanban.Domain.Objects.Entities;
using BlazorKanban.Infrastructure.Common;
using MongoDB.Driver;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorKanban.Infrastructure.Stores.Lists
{
    public class TaskListStore<TList> : ICreateTaskListEntity<TList>, IUpdateTaskListEntity<TList>, IDeleteTaskListEntity<TList>
        where TList : TaskList
    {
        private readonly IMongoCollection<TList> _listsCollection;

        public TaskListStore(IMongoCollection<TList> listsCollection)
        {
            _listsCollection = listsCollection ?? throw new ArgumentNullException(nameof(listsCollection));
        }

        public async Task<string> CreateAsync(TList list, CancellationToken cancellationToken)
        {
            if (list == null) throw new ArgumentNullException(nameof(list));

            var found = await _listsCollection.FirstOrDefaultAsync(x => x.Id == list.Id, cancellationToken).ConfigureAwait(false);

            if (found == null) await _listsCollection.InsertOneAsync(list, cancellationToken: cancellationToken).ConfigureAwait(false);

            return list.Id;
        }

        public async Task<string> UpdateAsync(TList list, CancellationToken cancellationToken)
        {
            if (list == null) throw new ArgumentNullException(nameof(list));

            var x = await _listsCollection.ReplaceOneAsync(x => x.Id == list.Id, list, cancellationToken: cancellationToken).ConfigureAwait(false);

            return list.Id;
        }

        public async Task<bool> DeleteAsync(TList list, CancellationToken cancellationToken)
        {
            if (list == null) throw new ArgumentNullException(nameof(list));

            var result = await _listsCollection.DeleteOneAsync(x => x.Id == list.Id, cancellationToken).ConfigureAwait(false);

            if (result.DeletedCount > 0)
            {
                return true;
            }

            return false;
        }
    }
}