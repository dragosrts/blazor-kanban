using System.Collections.Generic;

namespace BlazorKanban.Domain.Objects.Entities
{
    public class TaskBoard
    {
        public TaskBoard()
        {
            Id = string.Empty;
            UserId = string.Empty;
            Title = string.Empty;
            Description = string.Empty;
            Lists = new List<TaskList>();
        }

        public TaskBoard(string id, string userId, string title, string description, IEnumerable<TaskList> lists)
        {
            Id = id;
            UserId = userId;
            Title = title;
            Description = description;
            Lists = lists;
        }

        public string Id { get; private set; }

        public string UserId { get; private set; }

        public string Title { get; private set; }

        public string Description { get; private set; }

        public IEnumerable<TaskList> Lists { get; private set; }
    }
}