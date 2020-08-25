using AutoMapper;
using BlazorKanban.Domain.Contracts.TaskCards;
using BlazorKanban.Domain.Objects.Entities;
using BlazorKanban.Infrastructure.Common;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorKanban.Infrastructure.Stores.Cards
{
    public class TaskCardStore<TCard, TMongoCollection> :
        ICreateTaskCardEntity<TCard>,
        IUpdateTaskCardEntity<TCard>,
        IDeleteTaskCardEntity<TCard>,
        IGetTaskCardEntity<TCard>
        where TCard : TaskCard
        where TMongoCollection : MongoTaskCard
    {
        private readonly IMongoCollection<TMongoCollection> _cardsCollection;
        private readonly IMapper mapper;

        public TaskCardStore(IMongoCollection<TMongoCollection> cardsCollection, IMapper mapper)
        {
            _cardsCollection = cardsCollection ?? throw new ArgumentNullException(nameof(cardsCollection));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public string GenerateIdentifier()
        {
            return ObjectId.GenerateNewId().ToString();
        }

        public async Task<string> CreateAsync(TCard card, CancellationToken cancellationToken)
        {
            if (card == null) throw new ArgumentNullException(nameof(card));

            var mongoCard = mapper.Map<TCard, TMongoCollection>(card);
            
            await _cardsCollection.InsertOneAsync(mongoCard, cancellationToken: cancellationToken).ConfigureAwait(false);

            return mongoCard.Id.ToString();
        }

        public async Task<string> UpdateAsync(TCard card, CancellationToken cancellationToken)
        {
            if (card == null) throw new ArgumentNullException(nameof(card));

            var mongoCard = mapper.Map<TCard, TMongoCollection>(card);

            var updateDefinition =
                Builders<TMongoCollection>.Update
                .Set(c => c.ListId, mongoCard.ListId)
                .Set(c => c.Position, mongoCard.Position)
                .Set(c => c.Title, mongoCard.Title)
                .Set(c => c.Description, mongoCard.Description);

            await _cardsCollection.UpdateOneAsync(x => x.Id == mongoCard.Id, updateDefinition, cancellationToken: cancellationToken).ConfigureAwait(false);

            return mongoCard.Id.ToString();
        }

        public async Task<bool> UpdateTaskCardsPositionAsync(IList<TCard> cards, CancellationToken cancellationToken)
        {
            if (cards == null) throw new ArgumentNullException(nameof(cards));

            var mongoCards = mapper.Map<IList<TCard>, IList<TMongoCollection>>(cards);

            bool result = false;
            long updatedTaskCardsCount = 0;

            foreach (var mongoCard in mongoCards)
            {
                var updateDefinition =
                    Builders<TMongoCollection>.Update
                    .Set(c => c.Position, (long)mongoCards.IndexOf(mongoCard) + 1);

                var updateResult = await _cardsCollection.UpdateOneAsync(x => x.Id == mongoCard.Id, updateDefinition, cancellationToken: cancellationToken).ConfigureAwait(false);

                updatedTaskCardsCount += updateResult.ModifiedCount;
            }

            if (updatedTaskCardsCount == mongoCards.Count)
            {
                result = true;
            }

            return result;
        }

        public async Task<bool> DeleteAsync(string Id, CancellationToken cancellationToken)
        {
            if (Id == null) throw new ArgumentNullException(nameof(Id));

            var mongoCardId = ObjectId.Parse(Id);

            var result = await _cardsCollection.DeleteOneAsync(x => x.Id == mongoCardId, cancellationToken).ConfigureAwait(false);

            if (result.DeletedCount > 0)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> DeleteAllByTaskListIdAsync(string taskListId, CancellationToken cancellationToken)
        {
            if (taskListId == null) throw new ArgumentNullException(nameof(taskListId));

            var mongoTaskListId = ObjectId.Parse(taskListId);

            var result = await _cardsCollection.DeleteManyAsync(x => x.ListId == mongoTaskListId, cancellationToken).ConfigureAwait(false);

            if (result.DeletedCount > 0)
            {
                return true;
            }

            return false;
        }

        public async Task<TCard> GetByIdAsync(string Id, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(Id)) throw new ArgumentNullException(nameof(Id));

            var mongoCard = await _cardsCollection.FirstOrDefaultAsync(x => x.Id == ObjectId.Parse(Id), cancellationToken: cancellationToken).ConfigureAwait(true);

            var domainCard = mapper.Map<TMongoCollection, TCard>(mongoCard);

            return domainCard;
        }

        public async Task<IEnumerable<TCard>> GetAllByTaskListIdAsync(string ListId, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(ListId)) throw new ArgumentNullException(nameof(ListId));

            var mongoCards = await _cardsCollection.WhereAsync(x => x.ListId == ObjectId.Parse(ListId), cancellationToken: cancellationToken).ConfigureAwait(true);

            var domainCards = mapper.Map<IEnumerable<TMongoCollection>, IEnumerable<TCard>>(mongoCards);

            return domainCards;
        }
    }
}