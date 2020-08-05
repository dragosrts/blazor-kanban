using System.Collections.Generic;

namespace BlazorKanban.Domain.Objects.Entities
{
    public class TaskList
    {
        public string Id { get; set; }

        public string BoardId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public IEnumerable<TaskCard> Cards { get; set; }
    }
}