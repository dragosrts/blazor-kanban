using System.Collections.Generic;

namespace BlazorKanban.Shared
{
    public class Column
    {
        public int Id { get; set; }

        public int BoardId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public IEnumerable<Card> Cards { get; set; }
    }
}