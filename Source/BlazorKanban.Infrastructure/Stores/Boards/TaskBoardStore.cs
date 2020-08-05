using BlazorKanban.Domain.Contracts;
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
    public class TaskBoardStore<TBoard> : ICreateTaskBoardEntity<TBoard>, IUpdateTaskBoardEntity<TBoard>, IDeleteTaskBoardEntity<TBoard>, IFindTaskBoardEntity<TBoard>
        where TBoard : TaskBoard
    {
        private readonly IMongoCollection<TBoard> _boardsCollection;

        public TaskBoardStore(IMongoCollection<TBoard> boardsCollection)
        {
            _boardsCollection = boardsCollection ?? throw new ArgumentNullException(nameof(boardsCollection));
        }

        public async Task<string> CreateAsync(TBoard board, CancellationToken cancellationToken)
        {
            if (board == null) throw new ArgumentNullException(nameof(board));

            var found = await _boardsCollection.FirstOrDefaultAsync(x => x.Id == board.Id, cancellationToken).ConfigureAwait(false);

            if (found == null) await _boardsCollection.InsertOneAsync(board, cancellationToken: cancellationToken).ConfigureAwait(false);

            return board.Id;
        }

        public async Task<string> UpdateAsync(TBoard board, CancellationToken cancellationToken)
        {
            if (board == null) throw new ArgumentNullException(nameof(board));

            var x = await _boardsCollection.ReplaceOneAsync(x => x.Id == board.Id, board, cancellationToken: cancellationToken).ConfigureAwait(false);

            return board.Id;
        }

        public async Task<bool> DeleteAsync(TBoard board, CancellationToken cancellationToken)
        {
            if (board == null) throw new ArgumentNullException(nameof(board));

            var result = await _boardsCollection.DeleteOneAsync(x => x.Id == board.Id, cancellationToken).ConfigureAwait(false);

            if (result.DeletedCount > 0)
            {
                return true;
            }

            return false;
        }

        public async Task<TBoard> FindByIdAsync(string Id, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(Id)) throw new ArgumentNullException(nameof(Id));

            //var board = new MongoBoard();
            //return _boardsCollection.FirstOrDefaultAsync(x => x.Id == ObjectId.Parse(Id), cancellationToken: cancellationToken);

            return await _boardsCollection.FirstOrDefaultAsync(x => x.Id == (Id), cancellationToken: cancellationToken);
        }
    }
}