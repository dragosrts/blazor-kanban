using BlazorKanban.Infrastructure.Common;

namespace BlazorKanban.Infrastructure.Stores.Boards
{
    public class MongoTaskBoard : MongoStoreBaseEntity
    {
        public string Title { get; set; }

        public string Description { get; set; }
    }
}