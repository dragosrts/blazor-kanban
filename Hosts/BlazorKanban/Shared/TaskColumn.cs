﻿using System.Collections.Generic;

namespace BlazorKanban.Shared
{
    public class TaskColumn
    {
        public string Id { get; set; }

        public string BoardId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public IEnumerable<TaskCard> Cards { get; set; }
    }
}