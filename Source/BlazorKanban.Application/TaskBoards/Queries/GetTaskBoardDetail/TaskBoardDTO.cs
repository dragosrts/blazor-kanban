using System.Collections.Generic;

namespace BlazorKanban.Application.TaskBoards.Queries.GetTaskBoardDetail
{
    public class TaskBoardDTO
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public IEnumerable<TaskListDTO> Columns { get; set; }
    }
}