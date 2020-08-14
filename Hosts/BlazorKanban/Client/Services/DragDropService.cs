﻿using BlazorKanban.Client.Shared.Components.DragDrop;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlazorKanban.Client.Services
{
    public class DragDropService
    {
        private readonly ILogger<DragDropService> _logger;

        private Dictionary<int, DropzoneProperty> _DropzoneProperty = new Dictionary<int, DropzoneProperty>();
        private Dictionary<int, List<DraggableProperty>> _dic = new Dictionary<int, List<DraggableProperty>>();

        private int _idDropzoneCounter = 1;
        private int _idDraggableCounter = 1;

        private DraggableProperty? _activeItem;

        internal DraggableProperty _lastDraggedOverItem;

        public DragDropService(ILogger<DragDropService> logger)
        {
            _logger = logger;
        }

        public void RemoveDraggableProperty(int dropzoneId, string name)
        {
            var element = _dic[dropzoneId].Single(x => x.Name == name);

            _dic[dropzoneId].Remove(element);
        }

        public void RemoveDraggableProperty(DraggableProperty item)
        {
            _dic[item.DropzoneId].Remove(item);
        }

        /// <summary>
        /// Removes all items from a dropzone.
        /// </summary>
        /// <param name="dropzoneName">Name of the Dropzone. Assigned via the Name attribute on the dropzone</param>
        public void ClearDropzone(string dropzoneName)
        {
            var dropzoneId = _DropzoneProperty.Single(x => x.Value.Name == dropzoneName).Key;
            _dic[dropzoneId].Clear();
        }

        public bool EnableDebug { get; set; }

        public DraggableProperty? ActiveItem
        {
            get => _activeItem;
            set
            {
                _logger?.LogTrace(value == null ? "Clearing active item" : $"Set draggable {value.Id} as active - item belongs to dropzone {value.DropzoneId}");

                SupressRendering = false;

                _activeItem = value;

                StateHasChanged?.Invoke();

                SupressRendering = true;
            }
        }

        public bool SupressRendering { get; set; }

        public event Action StateHasChanged;

        internal int GetDropzoneId()
        {
            _idDropzoneCounter++;
            return _idDropzoneCounter;
        }

        internal int GetDraggableId()
        {
            _idDraggableCounter++;
            return _idDraggableCounter;
        }

        public void DropActiveItem(int targetDropzoneId)
        {
            _logger?.LogTrace($"Trying to Drop ActiveItem {ActiveItem.Id} from Dropzone {ActiveItem.DropzoneId} at Dropzone {targetDropzoneId}");

            bool acceptsDrop = AcceptsElement(targetDropzoneId);
            bool maxItemLimitReached = _dic[targetDropzoneId].Count >= _DropzoneProperty[targetDropzoneId].MaxItems;
            bool allowSwap = _DropzoneProperty[targetDropzoneId].AllowSwap;
            var orderPosition = GetOrderPosition(targetDropzoneId, ActiveItem.Id);

            if (targetDropzoneId == ActiveItem.DropzoneId)
            {
                //inform about the drop
                ActiveItem.OnDrop?.Invoke(ActiveItem);
                //Clear active item
                ActiveItem = null;
                //early exit
                _logger?.LogTrace($"Droped in same dropzone.");
                return;
            }

            //no drop accept // max-item limit
            if (!acceptsDrop || maxItemLimitReached && !allowSwap)
            {
                _logger?.LogTrace($"Drop rejected. Accept Func: {acceptsDrop} , Max-Item-Limit: {maxItemLimitReached}");

                ActiveItem = null;
                return;
            }

            _logger?.LogTrace($"Drop accepted");

            if (maxItemLimitReached && allowSwap)
            {
                if (_lastDraggedOverItem == null)
                {
                    return;
                }

                MoveItem(_lastDraggedOverItem, _lastDraggedOverItem.DropzoneId, newDropzoneId: ActiveItem.OriginDropzoneId);

                _lastDraggedOverItem = null;
            }

            //remove active item from sourcedropzone
            _dic[ActiveItem.DropzoneId].Remove(ActiveItem);

            //insert active into new dropzone
            var index = _dic[targetDropzoneId].Count();
            _dic[targetDropzoneId].Insert(index, ActiveItem);

            //assign new dropzone
            ActiveItem.DropzoneId = targetDropzoneId;

            //inform about the drop
            ActiveItem.OnDrop?.Invoke(ActiveItem);

            //Clear active item
            ActiveItem = null;
        }

        public int GetOrderPosition(int dropzoneId, int draggableId)
        {
            var item = _dic[dropzoneId].SingleOrDefault(x => x.Id == draggableId);

            if (item != null)
            {
                return _dic[dropzoneId].IndexOf(item);
            }
            else
            {
                return 0;
            }
        }

        public void SetActiveItem(int dropzoneId, int draggableId)
        {
            ActiveItem = _dic[dropzoneId].Single(x => x.Id == draggableId);
        }

        public void SwapOrInsert(int draggedOverId)
        {
            var targetDropzoneId = _dic.Where(v => v.Value != null).Single(x => x.Value.Any(y => y.Id == draggedOverId)).Key;

            _logger?.LogTrace($"Trying to SwapOrInsert draggable {ActiveItem.Id} with dragged over item {draggedOverId} in dropzone {targetDropzoneId}");

            bool acceptsDrop = AcceptsElement(targetDropzoneId);
            bool maxItemLimitReached = _dic[targetDropzoneId].Count >= _DropzoneProperty[targetDropzoneId].MaxItems;
            bool allowSwap = _DropzoneProperty[targetDropzoneId].AllowSwap;

            //find dropzone
            var dropzone = _dic.Where(v => v.Value != null).Single(x => x.Value.Any(y => y.Id == draggedOverId)).Value;

            //get dragged over item
            var draggedOverItem = dropzone.Single(x => x.Id == draggedOverId);

            _lastDraggedOverItem = draggedOverItem;

            //drop not accepted due to delegate
            if (!acceptsDrop)
            {
                _logger?.LogTrace($"SwapOrInsert rejected. Accept Func: {acceptsDrop}");
                return;
            }

            // if same dropzone -> swap
            if (ActiveItem.DropzoneId == draggedOverItem.DropzoneId)
            {
                _logger?.LogTrace("SwapOrInsert accepted");
                SwapWithActiveItem(draggedOverItem);
            }
            else // different dropzone -> move item over
            {
                if (maxItemLimitReached)
                {
                    _logger?.LogTrace($"SwapOrInsert rejected. MaxItemLimitReached");
                    return;
                }

                _logger?.LogTrace("SwapOrInsert accepted");

                var activeItemDropzoneId = ActiveItem.DropzoneId;

                MoveActiveItem(targetDropzoneId: draggedOverItem.DropzoneId, index: draggedOverItem.OrderPosition);

                if (maxItemLimitReached && allowSwap)
                {
                    MoveItem(draggedOverItem, draggedOverItem.DropzoneId, newDropzoneId: activeItemDropzoneId);
                }
            }

            SupressRendering = false;

            StateHasChanged?.Invoke();

            SupressRendering = true;
        }

        internal DraggableProperty MoveItem(DraggableProperty item, int oldDropzoneId, int newDropzoneId)
        {
            item.OriginDropzoneId = oldDropzoneId;

            //remove draggedover item from old dropzone
            _dic[item.DropzoneId].Remove(item);

            //assign new dropzone to dragged over item
            item.DropzoneId = newDropzoneId;

            //insert into other dropzone
            _dic[newDropzoneId].Insert(0, item);

            return item;
        }

        internal void SwapWithActiveItem(DraggableProperty draggedOverItem)
        {
            var activeItemPosition = ActiveItem.OrderPosition;
            var draggedOverItemPosition = draggedOverItem.OrderPosition;

            var dropzone = _dic[draggedOverItem.DropzoneId];

            dropzone[draggedOverItemPosition] = ActiveItem;

            dropzone[activeItemPosition] = draggedOverItem;
        }

        internal void MoveActiveItem(int targetDropzoneId, int index)
        {
            var activeItemDropzoneId = ActiveItem.DropzoneId;

            //remove from old dropzone
            _dic[activeItemDropzoneId].Remove(ActiveItem);

            //assign correct dropzone
            ActiveItem.DropzoneId = targetDropzoneId;

            //insert into new dropzone
            _dic[ActiveItem.DropzoneId].Insert(index, ActiveItem);
        }

        public void RegisterDropzone(int dropzoneId, DropzoneProperty options)
        {
            _logger?.LogTrace($"Register dropzone {dropzoneId}");

            _dic.Add(dropzoneId, new List<DraggableProperty>());

            _DropzoneProperty.Add(dropzoneId, options);
        }

        public void UnregisterDropzone(int dropzoneId)
        {
            _logger?.LogTrace($"Unregister dropzone {dropzoneId}");

            _idDropzoneCounter--;

            _idDraggableCounter -= _dic[dropzoneId].Count;

            _dic.Remove(dropzoneId);

            _DropzoneProperty.Remove(dropzoneId);

            SupressRendering = false;
        }

        public void RegisterDraggableForDropzone(DraggableProperty dataItem)
        {
            _logger?.LogTrace($"Register draggable {dataItem.Id} for dropzone {dataItem.DropzoneId}");

            _dic[dataItem.DropzoneId].Add(dataItem);

            StateHasChanged?.Invoke();
        }

        public bool HasDropzoneDraggables(int dropzoneId)
        {
            var result = _dic.ContainsKey(dropzoneId) && _dic[dropzoneId]?.Count > 0;

            _logger?.LogTrace($"HasDraggablesForDropzone {dropzoneId} returns {result} with draggable count: {_dic[dropzoneId]?.Count}");

            return result;
        }

        public bool HasDropzoneDraggables(string dropzoneName)
        {
            var hit = _DropzoneProperty.SingleOrDefault(x => x.Value.Name == dropzoneName);

            if (hit.Key == 0) return false;

            return HasDropzoneDraggables(hit.Key);
        }

        public List<DraggableProperty> GetDraggablesForDropzone(string dropzoneName)
        {
            var id = _DropzoneProperty.Single(x => x.Value.Name == dropzoneName).Key;
            return GetDraggablesForDropzone(id);
        }

        public List<DraggableProperty> GetDraggablesForDropzone(int id)
        {
            var draggables = _dic[id];

            _logger?.LogTrace($"GetDraggablesForDropzone {id} returned {draggables.Count} items");

            return draggables;
        }

        public bool IsDraggable(DraggableProperty draggable)
        {
            return draggable.AllowDrag == null || draggable.AllowDrag(draggable);
        }

        public DropzoneProperty GetDropzonePropertyById(int dropzoneId)
        {
            return _DropzoneProperty[dropzoneId];
        }

        public DropzoneProperty GetDropzonePropertyByName(string dropzoneName)
        {
            return _DropzoneProperty.Single(x => x.Value.Name == dropzoneName).Value;
        }

        private bool AcceptsElement(int dropzoneId)
        {
            bool acceptsElement = true;

            if (_DropzoneProperty[dropzoneId].Accepts != null)
            {
                acceptsElement = (bool)_DropzoneProperty[dropzoneId].Accepts(ActiveItem.Tag);
            }

            return acceptsElement;
        }
    }
}