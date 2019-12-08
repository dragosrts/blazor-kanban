using BlazorKanban.Domain.Objects.Epics;
using System.Collections.Generic;

namespace BlazorKanban.Domain.Objects.Backlogs
{
    public class Backlog
    {
        public  List<Epic> Epics { get; set; }
    }
}