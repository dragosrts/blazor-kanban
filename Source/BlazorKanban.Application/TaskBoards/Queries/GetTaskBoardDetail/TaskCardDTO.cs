namespace BlazorKanban.Application.TaskBoards.Queries.GetTaskBoardDetail
{
    public class TaskCardDTO
    {
        public string Id { get; set; }

        public string ColumnId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}