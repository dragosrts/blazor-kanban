using System.Collections.Generic;

namespace BlazorKanban.Shared
{
    public class TaskBoard
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public IEnumerable<TaskColumn> Columns { get; set; }
    }
}