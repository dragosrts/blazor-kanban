using System.Collections.Generic;

namespace BlazorKanban.Domain.Objects.Entities
{
    public class TaskList
    {
        public TaskList()
        {
            Id = string.Empty;
            BoardId = string.Empty;
            Title = string.Empty;
            Description = string.Empty;
            Cards = new List<TaskCard>();
        }

        public TaskList(string id, string boardId, string title, string description, IEnumerable<TaskCard> cards)
        {
            Id = id;
            BoardId = boardId;
            Title = title;
            Description = description;
            Cards = cards;
        }

        public string Id { get; private set; }

        public string BoardId { get; private set; }

        public string Title { get; private set; }

        public string Description { get; private set; }

        public IEnumerable<TaskCard> Cards { get; private set; }
    }
}