using Blazored.Modal;
using Microsoft.Extensions.DependencyInjection;
using Plk.Blazor.DragDrop;

namespace BlazorKanban.Client
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBlazorKanbanClient(this IServiceCollection services)
        {
            services.AddBlazoredModal();
            services.AddBlazorDragDrop();

            return services;
        }
    }
}