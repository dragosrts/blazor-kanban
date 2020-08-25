using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlazorKanban.Shared
{
    public class Board
    {
        public string Id { get; set; }

        public string UserId { get; set; }

        [Required]
        [StringLength(25, ErrorMessage = "The title is too long.")]
        public string Title { get; set; }

        public string Description { get; set; }

        public IList<Column> Columns { get; set; }
    }
}