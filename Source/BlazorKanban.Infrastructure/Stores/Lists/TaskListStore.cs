using AutoMapper;
using BlazorKanban.Domain.Contracts.TaskLists;
using BlazorKanban.Domain.Objects.Entities;
using BlazorKanban.Infrastructure.Common;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorKanban.Infrastructure.Stores.Lists
{
    public class TaskListStore<TList, TMongoCollection> :
        ICreateTaskListEntity<TList>,
        IUpdateTaskListEntity<TList>,
        IDeleteTaskListEntity<TList>,
        IGetTaskListEntity<TList>
        where TList : TaskList
        where TMongoCollection : MongoTaskList
    {
        private readonly IMongoCollection<TMongoCollection> _listsCollection;
        private readonly IMapper mapper;

        public TaskListStore(IMongoCollection<TMongoCollection> listsCollection, IMapper mapper)
        {
            _listsCollection = listsCollection ?? throw new ArgumentNullException(nameof(listsCollection));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public string GenerateIdentifier()
        {
            return ObjectId.GenerateNewId().ToString();
        }

        public async Task<string> CreateAsync(TList list, CancellationToken cancellationToken)
        {
            if (list == null) throw new ArgumentNullException(nameof(list));

            var mongoList = mapper.Map<TList, TMongoCollection>(list);

            var foundList = await _listsCollection.FirstOrDefaultAsync(x => x.Title == mongoList.Title, cancellationToken).ConfigureAwait(false);

            if (foundList == null) await _listsCollection.InsertOneAsync(mongoList, cancellationToken: cancellationToken).ConfigureAwait(false);

            return mongoList.Id.ToString();
        }

        public async Task<string> UpdateAsync(TList list, CancellationToken cancellationToken)
        {
            if (list == null) throw new ArgumentNullException(nameof(list));

            var mongoList = mapper.Map<TList, TMongoCollection>(list);

            var updateDefinition =
                Builders<TMongoCollection>.Update
                .Set(l => l.Title, mongoList.Title)
                .Set(l => l.Description, mongoList.Description);

            await _listsCollection.UpdateOneAsync(x => x.Id == mongoList.Id, updateDefinition, cancellationToken: cancellationToken).ConfigureAwait(false);

            return mongoList.Id.ToString();
        }

        public async Task<bool> DeleteAsync(string Id, CancellationToken cancellationToken)
        {
            if (Id == null) throw new ArgumentNullException(nameof(Id));
            
            var mongoListId = ObjectId.Parse(Id);

            var result = await _listsCollection.DeleteOneAsync(x => x.Id == mongoListId, cancellationToken).ConfigureAwait(false);

            if (result.DeletedCount > 0)
            {
                return true;
            }

            return false;
        }

        public async Task<TList> GetByIdAsync(string Id, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(Id)) throw new ArgumentNullException(nameof(Id));

            var mongoList = await _listsCollection.FirstOrDefaultAsync(x => x.Id == ObjectId.Parse(Id), cancellationToken: cancellationToken).ConfigureAwait(true);

            var domainList = mapper.Map<TMongoCollection, TList>(mongoList);

            return domainList;
        }

        public async Task<IEnumerable<TList>> GetAllByTaskBoardIdAsync(string BoardId, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(BoardId)) throw new ArgumentNullException(nameof(BoardId));

            var mongoLists = await _listsCollection.WhereAsync(x => x.BoardId == ObjectId.Parse(BoardId), cancellationToken: cancellationToken).ConfigureAwait(true);

            var domainLists = mapper.Map<IEnumerable<TMongoCollection>, IEnumerable<TList>>(mongoLists);

            return domainLists;
        }
    }
}