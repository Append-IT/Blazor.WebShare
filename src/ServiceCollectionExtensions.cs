using Microsoft.Extensions.DependencyInjection;
namespace Append.Blazor.WebShare;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddWebShare(this IServiceCollection services)
    {
        return services.AddScoped<IWebShareService, WebShareService>();
    }
}

