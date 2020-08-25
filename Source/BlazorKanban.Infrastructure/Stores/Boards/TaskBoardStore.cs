using AutoMapper;
using BlazorKanban.Domain.Contracts.TaskBoards;
using BlazorKanban.Domain.Objects.Entities;
using BlazorKanban.Infrastructure.Common;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorKanban.Infrastructure.Stores.Boards
{
    public class TaskBoardStore<TBoard, TMongoCollection> :
        ICreateTaskBoardEntity<TBoard>,
        IUpdateTaskBoardEntity<TBoard>,
        IDeleteTaskBoardEntity<TBoard>,
        IGetTaskBoardEntity<TBoard>
        where TBoard : TaskBoard
        where TMongoCollection : MongoTaskBoard
    {
        private readonly IMongoCollection<TMongoCollection> _boardsCollection;
        private readonly IMapper mapper;

        public TaskBoardStore(IMongoCollection<TMongoCollection> boardsCollection, IMapper mapper)
        {
            _boardsCollection = boardsCollection ?? throw new ArgumentNullException(nameof(boardsCollection));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public string GenerateIdentifier()
        {
            return ObjectId.GenerateNewId().ToString();
        }

        public async Task<string> CreateAsync(TBoard board, CancellationToken cancellationToken)
        {
            if (board == null) throw new ArgumentNullException(nameof(board));

            var mongoBoard = mapper.Map<TBoard, TMongoCollection>(board);
            
            await _boardsCollection.InsertOneAsync(mongoBoard, cancellationToken: cancellationToken).ConfigureAwait(false);

            return mongoBoard.Id.ToString();
        }

        public async Task<string> UpdateAsync(TBoard board, CancellationToken cancellationToken)
        {
            if (board == null) throw new ArgumentNullException(nameof(board));

            var mongoBoard = mapper.Map<TBoard, TMongoCollection>(board);

            var updateDefinition =
                Builders<TMongoCollection>.Update
                .Set(b => b.Title, mongoBoard.Title)
                .Set(b => b.Description, mongoBoard.Description);

            await _boardsCollection.UpdateOneAsync(x => x.Id == mongoBoard.Id, updateDefinition, cancellationToken: cancellationToken).ConfigureAwait(false);

            return mongoBoard.Id.ToString();
        }

        public async Task<bool> DeleteAsync(string Id, CancellationToken cancellationToken)
        {
            if (Id == null) throw new ArgumentNullException(nameof(Id));

            var mongoBoardId = ObjectId.Parse(Id);

            var result = await _boardsCollection.DeleteOneAsync(x => x.Id == mongoBoardId, cancellationToken).ConfigureAwait(false);

            if (result.DeletedCount > 0)
            {
                return true;
            }

            return false;
        }

        public async Task<TBoard> GetByIdAsync(string Id, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(Id)) throw new ArgumentNullException(nameof(Id));

            var mongoBoard = await _boardsCollection.FirstOrDefaultAsync(x => x.Id == ObjectId.Parse(Id), cancellationToken: cancellationToken).ConfigureAwait(true);

            var domainBoard = mapper.Map<TMongoCollection, TBoard>(mongoBoard);

            return domainBoard;
        }

        public async Task<IEnumerable<TBoard>> GetAllBoardsByUserIdAsync(string UserId, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(UserId)) throw new ArgumentNullException(nameof(UserId));

            var mongoBoards = await _boardsCollection.WhereAsync(x => x.UserId == ObjectId.Parse(UserId), cancellationToken: cancellationToken).ConfigureAwait(true);

            var domainBoards = mapper.Map<IEnumerable<TMongoCollection>, IEnumerable<TBoard>>(mongoBoards);

            return domainBoards;
        }
    }
}