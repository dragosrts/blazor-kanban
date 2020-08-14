using Microsoft.AspNetCore.Components;
using System;

namespace BlazorKanban.Client.Shared.Components.Modal
{
    public class ModalBase : ComponentBase, IDisposable
    {
        [Parameter]
        public bool IsVisible { get; set; } = false;

        [Parameter]
        public string Title { get; set; } = string.Empty;

        protected string ModalDisplay = "none;";
        protected string ModalClass = "";

        protected override void OnInitialized()
        {
            this.ModalOpen(string.Empty);
        }

        public void ModalOpen(string title)
        {
            Title = title;
            IsVisible = true;

            ModalDisplay = "block;";
            ModalClass = "show";

            StateHasChanged();
        }

        public void ModalClose()
        {
            IsVisible = false;
            Title = "";

            ModalDisplay = "none;";
            ModalClass = "";

            StateHasChanged();
        }

        public void Dispose()
        {
        }
    }
}