namespace BlazorKanban.Shared
{
    public class TaskCard
    {
        public int Id { get; set; }

        public int ColumnId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}