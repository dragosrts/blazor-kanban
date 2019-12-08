using BlazorKanban.Domain.Objects.Epics;
using BlazorKanban.Domain.Objects.Tasks;
using System.Collections.Generic;

namespace BlazorKanban.Domain.Objects.Stories
{
    public class Story
    {
        public Epic Parent { get; set; }

        public List<Task> Tasks { get; set; }
    }
}