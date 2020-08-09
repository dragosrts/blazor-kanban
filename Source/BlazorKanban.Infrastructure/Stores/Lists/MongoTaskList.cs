using BlazorKanban.Infrastructure.Common;
using MongoDB.Bson;

namespace BlazorKanban.Infrastructure.Stores.Lists
{
    public class MongoTaskList : MongoStoreBaseEntity
    {
        public MongoTaskList()
        {
            Title = string.Empty;
            Description = string.Empty;
        }

        // reference to MongoBoard
        public ObjectId BoardId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}