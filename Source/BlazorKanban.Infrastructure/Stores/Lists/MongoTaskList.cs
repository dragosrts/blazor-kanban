using BlazorKanban.Infrastructure.Common;
using MongoDB.Bson;

namespace BlazorKanban.Infrastructure.Stores.Lists
{
    public class MongoTaskList : MongoStoreBaseEntity
    {
        // reference to MongoBoard
        public ObjectId BoardId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}