using Blazored.Modal;
using BlazorKanban.Client.Services;
using BlazorKanban.Client.Services.Contracts;
using Microsoft.AspNetCore.Components.Authorization;
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

            services.AddOptions();
            services.AddAuthorizationCore();
            services.AddScoped<IdentityAuthenticationStateProvider>();
            services.AddScoped<AuthenticationStateProvider>(s => s.GetRequiredService<IdentityAuthenticationStateProvider>());
            services.AddScoped<IAuthorizeApi, AuthorizeApi>();

            return services;
        }
    }
}