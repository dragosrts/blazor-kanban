namespace BlazorKanban.Domain.Objects.Entities
{
    public class TaskCard
    {
        public TaskCard()
        {
            Id = string.Empty;
            ListId = string.Empty;
            Title = string.Empty;
            Description = string.Empty;
            Position = 0;
        }

        public TaskCard(string id, string listId, string title, string description, long position)
        {
            Id = id;
            ListId = listId;
            Title = title;
            Description = description;
            Position = position;
        }

        public string Id { get; private set; }

        public string ListId { get; private set; }

        public string Title { get; private set; }

        public string Description { get; private set; }

        public long Position { get; set; }
    }
}