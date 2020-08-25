using BlazorKanban.Client.Services;
using BlazorKanban.Client.Services.Contracts;
using MatBlazor;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Plk.Blazor.DragDrop;

namespace BlazorKanban.Client
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBlazorKanbanClient(this IServiceCollection services)
        {
            services.AddAuthorizationCore();
            services.AddOptions();
            services.AddScoped<IdentityAuthenticationStateProvider>();
            services.AddScoped<AuthenticationStateProvider>(s => s.GetRequiredService<IdentityAuthenticationStateProvider>());
            services.AddScoped<IAuthorizeApi, AuthorizeApi>();

            services.AddBlazorDragDrop();

            services.AddMatToaster(config =>
            {
                config.Position = MatToastPosition.BottomRight;
                config.PreventDuplicates = true;
                config.NewestOnTop = true;
                config.ShowCloseButton = true;
                config.MaximumOpacity = 95;
                config.VisibleStateDuration = 3000;
            });

            return services;
        }
    }
}