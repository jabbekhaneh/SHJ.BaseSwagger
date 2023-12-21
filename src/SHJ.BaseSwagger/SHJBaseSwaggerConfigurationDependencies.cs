using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SHJ.BaseSwagger.Options;
using SHJ.BaseSwagger.SwaggerConfigs;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace SHJ.BaseSwagger;

public static class SHJBaseSwaggerConfigurationDependencies
{


    public static void RegisterSwagger(this IServiceCollection services,Action<BaseSwaggerOption> option)
    {
        services.Configure<BaseSwaggerOption>(option);

        services.RegisterRouting();

        services.AddSwaggerGen(options =>
        {
            options.DocumentFilter<BaseSwaggerDocumentFilter>();
            options.OperationFilter<BaseSwaggerOperationFilter>();
        });

        services.AddTransient<IConfigureOptions<SwaggerGenOptions>, BaseConfigSwaggerGenOptions>();
        services.AddTransient<IConfigureOptions<SwaggerUIOptions>, BaseSwaggerUIOptionsConfig>();

        services.RegisterApiVersioning();
    }

    public static IApplicationBuilder RegisterUseSwaggerAndUI(this IApplicationBuilder app,IServiceProvider serviceProvider)
    {        
        app.UseSwagger();
        app.UseSwaggerUI();

        return app;
    }


}


