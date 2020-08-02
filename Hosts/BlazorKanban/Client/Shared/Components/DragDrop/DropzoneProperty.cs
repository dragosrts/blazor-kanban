using System;

namespace BlazorKanban.Client.Shared.Components.DragDrop
{
    public class DropzoneProperty
    {
        public int? MaxItems { get; set; }

        public bool AllowSwap { get; set; }

        public Func<dynamic, bool> Accepts { get; set; }

        public string Name { get; set; }

        public int DropzoneId { get; set; }
    }
}