using BlazorKanban.Domain.Contracts.TaskCards;
using BlazorKanban.Domain.Objects.Entities;
using BlazorKanban.Infrastructure.Common;
using MongoDB.Driver;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorKanban.Infrastructure.Stores.Cards
{
    public class TaskCardStore<TCard> : ICreateTaskCardEntity<TCard>, IUpdateTaskCardEntity<TCard>, IDeleteTaskCardEntity<TCard>, IFindTaskCardEntity<TCard>
        where TCard : TaskCard
    {
        private readonly IMongoCollection<TCard> _cardsCollection;

        public TaskCardStore(IMongoCollection<TCard> cardsCollection)
        {
            _cardsCollection = cardsCollection ?? throw new ArgumentNullException(nameof(cardsCollection));
        }

        public async Task<string> CreateAsync(TCard card, CancellationToken cancellationToken)
        {
            if (card == null) throw new ArgumentNullException(nameof(card));

            var found = await _cardsCollection.FirstOrDefaultAsync(x => x.Id == card.Id, cancellationToken).ConfigureAwait(false);

            if (found == null) await _cardsCollection.InsertOneAsync(card, cancellationToken: cancellationToken).ConfigureAwait(false);

            return card.Id;
        }

        public async Task<string> UpdateAsync(TCard card, CancellationToken cancellationToken)
        {
            if (card == null) throw new ArgumentNullException(nameof(card));

            var x = await _cardsCollection.ReplaceOneAsync(x => x.Id == card.Id, card, cancellationToken: cancellationToken).ConfigureAwait(false);

            return card.Id;
        }

        public async Task<bool> DeleteAsync(TCard card, CancellationToken cancellationToken)
        {
            if (card == null) throw new ArgumentNullException(nameof(card));

            var result = await _cardsCollection.DeleteOneAsync(x => x.Id == card.Id, cancellationToken).ConfigureAwait(false);

            if (result.DeletedCount > 0)
            {
                return true;
            }

            return false;
        }

        public Task<TCard> FindByIdAsync(string Id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}