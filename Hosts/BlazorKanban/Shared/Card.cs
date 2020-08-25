using System.ComponentModel.DataAnnotations;

namespace BlazorKanban.Shared
{
    public class Card
    {
        public string Id { get; set; }

        public string ColumnId { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public long Position { get; set; }
    }
}