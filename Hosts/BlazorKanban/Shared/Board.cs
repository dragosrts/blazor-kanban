using System.Collections.Generic;

namespace BlazorKanban.Shared
{
    public class Board
    {
        public string Id { get; set; }

        public string UserId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public IList<Column> Columns { get; set; }
    }
}