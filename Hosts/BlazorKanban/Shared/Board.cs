﻿using System.Collections.Generic;

namespace BlazorKanban.Shared
{
    public class Board
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public IEnumerable<Column> Columns { get; set; }
    }
}