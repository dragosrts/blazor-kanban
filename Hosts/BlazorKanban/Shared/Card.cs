using System.ComponentModel.DataAnnotations;

namespace BlazorKanban.Shared
{
    public class Card
    {
        public string Id { get; set; }

        public string ColumnId { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "The Title is too long.")]
        public string Title { get; set; }

        [StringLength(255, ErrorMessage = "The description is too long.")]
        public string Description { get; set; }

        public long Position { get; set; }
    }
}