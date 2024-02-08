using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using SHJ.BaseSwagger.Options;
using SHJ.BaseSwagger.SwaggerConfigs;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace SHJ.BaseSwagger;

public static class SHJBaseSwaggerConfigurationDependencies
{


    public static void RegisterSwagger(this IServiceCollection services, Action<BaseSwaggerOption> BaseOption)
    {
        services.Configure<BaseSwaggerOption>(BaseOption);

        services.RegisterRouting();

        services.AddSwaggerGen(options =>
        {
            options.DocumentFilter<BaseSwaggerDocumentFilter>();
            options.OperationFilter<BaseSwaggerOperationFilter>();
            //options.OperationFilter<UnauthorizedResponsesOperationFilter>(true, "OAuth2");
        });
        services.AddTransient<IConfigureOptions<SwaggerGenOptions>, BaseConfigSwaggerGenOptions>();
        services.AddTransient<IConfigureOptions<SwaggerUIOptions>, BaseSwaggerUIOptionsConfig>();
        services.RegisterApiVersioning();
    }

    public static IApplicationBuilder RegisterUseSwaggerAndUI(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        return app;
    }


}


