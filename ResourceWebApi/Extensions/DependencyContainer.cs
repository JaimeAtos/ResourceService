using Microsoft.AspNetCore.Mvc;

namespace ResourceWebApi.Extensions;

public static class DependencyContainer
{
    public static void AddApiVersioningExtension(this IServiceCollection services)
    {
        services.AddApiVersioning(cfg =>
        {
            cfg.DefaultApiVersion = new ApiVersion(1, 0);
            cfg.AssumeDefaultVersionWhenUnspecified = true;
            cfg.ReportApiVersions = true;
        });
    }
}
