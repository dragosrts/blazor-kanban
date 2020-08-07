using AutoMapper;
using BlazorKanban.Domain.Contracts.TaskBoards;
using BlazorKanban.Domain.Objects.Entities;
using BlazorKanban.Infrastructure.Common;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
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
        private readonly IMongoCollection<TMongoCollection> boardsCollection;
        private readonly IMapper mapper;

        public TaskBoardStore(IMongoCollection<TMongoCollection> boardsCollection, IMapper mapper)
        {
            this.boardsCollection = boardsCollection ?? throw new ArgumentNullException(nameof(boardsCollection));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<string> CreateAsync(TBoard board, CancellationToken cancellationToken)
        {
            if (board == null) throw new ArgumentNullException(nameof(board));

            var mongoBoard = mapper.Map<TBoard, TMongoCollection>(board);

            var foundBoard = await boardsCollection.FirstOrDefaultAsync(x => x.Id == mongoBoard.Id, cancellationToken).ConfigureAwait(false);

            if (foundBoard == null) await boardsCollection.InsertOneAsync(mongoBoard, cancellationToken: cancellationToken).ConfigureAwait(false);

            return mongoBoard.Id.ToString();
        }

        public async Task<string> UpdateAsync(TBoard board, CancellationToken cancellationToken)
        {
            if (board == null) throw new ArgumentNullException(nameof(board));

            var mongoBoard = mapper.Map<TBoard, TMongoCollection>(board);

            await boardsCollection.ReplaceOneAsync(x => x.Id == mongoBoard.Id, mongoBoard, cancellationToken: cancellationToken).ConfigureAwait(false);

            return mongoBoard.Id.ToString();
        }

        public async Task<bool> DeleteAsync(TBoard board, CancellationToken cancellationToken)
        {
            if (board == null) throw new ArgumentNullException(nameof(board));

            var mongoBoard = mapper.Map<TBoard, TMongoCollection>(board);

            var result = await boardsCollection.DeleteOneAsync(x => x.Id == mongoBoard.Id, cancellationToken).ConfigureAwait(false);

            if (result.DeletedCount > 0)
            {
                return true;
            }

            return false;
        }

        public async Task<TBoard> GetByIdAsync(string Id, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(Id)) throw new ArgumentNullException(nameof(Id));

            var mongoBoard = await boardsCollection.FirstOrDefaultAsync(x => x.Id == ObjectId.Parse(Id), cancellationToken: cancellationToken).ConfigureAwait(true);

            var domainBoard = mapper.Map<TMongoCollection, TBoard>(mongoBoard);

            return domainBoard;
        }
    }
}