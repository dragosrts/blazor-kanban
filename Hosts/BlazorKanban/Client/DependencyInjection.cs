using BlazorKanban.Client.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorKanban.Client
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBlazorDragDrop(this IServiceCollection services)
        {
            return services.AddScoped<DragDropService>();
        }
    }
}