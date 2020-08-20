using BlazorKanban.Infrastructure.Common;
using MongoDB.Bson;

namespace BlazorKanban.Infrastructure.Stores.Boards
{
    public class MongoTaskBoard : MongoStoreBaseEntity
    {
        public MongoTaskBoard()
        {
            UserId = ObjectId.Empty;
            Title = string.Empty;
            Description = string.Empty;
        }

        public ObjectId UserId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}