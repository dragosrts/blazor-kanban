using System.Collections.Generic;

namespace BlazorKanban.Domain.Objects.Entities
{
    public class TaskBoard
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public IEnumerable<TaskList> Lists { get; set; }
    }
}