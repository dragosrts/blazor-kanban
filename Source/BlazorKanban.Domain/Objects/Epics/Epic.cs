using BlazorKanban.Domain.Objects.Bugs;
using BlazorKanban.Domain.Objects.Stories;
using System.Collections.Generic;

namespace BlazorKanban.Domain.Objects.Epics
{
    public class Epic
    {
        public List<Story> Stories { get; set; }

        public List<Bug> Bugs { get; set; }
    }
}
