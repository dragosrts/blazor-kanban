namespace BlazorKanban.Infrastructure.Common
{
    public class MongoStoreOptions
    {
        public string ConnectionString { get; set; } = "mongodb://localhost/default";

        public string TaskCardsCollection { get; set; } = "TaskCards";

        public string TaskListsCollection { get; set; } = "TaskLists";

        public string TaskBoardsCollection { get; set; } = "TaskBoards";
    }
}