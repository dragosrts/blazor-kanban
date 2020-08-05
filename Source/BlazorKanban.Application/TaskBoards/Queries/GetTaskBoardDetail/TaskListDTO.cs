using System.Collections.Generic;

namespace BlazorKanban.Application.TaskBoards.Queries.GetTaskBoardDetail
{
    public class TaskListDTO
    {
        public string Id { get; set; }

        public string BoardId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public IEnumerable<TaskCardDTO> Cards { get; set; }
    }
}