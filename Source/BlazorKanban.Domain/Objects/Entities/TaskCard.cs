﻿namespace BlazorKanban.Domain.Objects.Entities
{
    public class TaskCard
    {
        public string Id { get; set; }

        public string ListId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}