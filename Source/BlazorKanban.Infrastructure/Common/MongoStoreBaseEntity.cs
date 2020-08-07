using MongoDB.Bson;

namespace BlazorKanban.Infrastructure.Common
{
    public class MongoStoreBaseEntity
    {
        public ObjectId Id { get; set; }
    }
}