using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using SHJ.BaseSwagger.RouterVersioningConfigs;

namespace SHJ.BaseSwagger;

internal static class SwaggerConfigurationExtensions
{

    public static void RegisterApiVersioning(this IServiceCollection services)
    {
        services.AddApiVersioning(option =>
        {
            option.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
            option.AssumeDefaultVersionWhenUnspecified = true;
            option.ReportApiVersions = true;
        });
        services.AddVersionedApiExplorer(options =>
        {
            options.SubstituteApiVersionInUrl = true;
        });
    }

    public static void RegisterRouting(this IServiceCollection services)
    {
        services.AddControllersWithViews(option =>
        {
            option.UseGeneralRoutePrefix("api/v{version:apiVersion}");
        });


    }

    public static void UseGeneralRoutePrefix(this MvcOptions opts, IRouteTemplateProvider routeAttribute)
    {
        opts.Conventions.Add(new RoutePrefixConvention(routeAttribute));
    }
    public static void UseGeneralRoutePrefix(this MvcOptions opts, string prefix)
    {
        opts.UseGeneralRoutePrefix(new RouteAttribute(prefix));
    }
}
