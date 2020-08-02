using BlazorKanban.Client.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;

namespace BlazorKanban.Client.Shared.Components.DragDrop
{
    public class DraggableProperty
    {
        private readonly DragDropService dragDropService;

        public DraggableProperty(DragDropService dragDropService)
        {
            this.dragDropService = dragDropService;
        }

        internal Dictionary<string, object> OtherAttributes { get; set; }

        internal RenderFragment<DraggableProperty> RenderFragment { get; set; }

        /// <summary>
        /// Gets or sets the id of this draggable.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the draggable.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the id of the dropzone this draggable belongs to.
        /// </summary>
        public int DropzoneId { get; set; }

        /// <summary>
        /// Gets the name of the dropzone this draggable belongs to.
        /// </summary>
        public string DropzoneName
        {
            get
            {
                return dragDropService.GetDropzonePropertyById(DropzoneId).Name;
            }
        }

        public int OriginDropzoneId { get; set; }

        /// <summary>
        /// Gets or sets the dynamic data which belongs to this draggable.
        /// </summary>
        public dynamic Tag { get; set; }

        /// <summary>
        /// Gets or sets the delegate that is called when this draggable is dropped.
        /// </summary>
        public Action<DraggableProperty> OnDrop { get; set; }

        /// <summary>
        /// Gets or sets a delegate that determines if this draggable can be dragged.
        /// </summary>
        public Func<DraggableProperty, bool> AllowDrag { get; set; }

        /// <summary>
        /// Order position of this draggable inside the dropzone.
        /// </summary>
        public int OrderPosition
        {
            get
            {
                return dragDropService.GetOrderPosition(DropzoneId, Id);
            }
        }
    }
}