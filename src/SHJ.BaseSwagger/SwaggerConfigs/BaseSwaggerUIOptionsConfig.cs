using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using SHJ.BaseSwagger.Options;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace SHJ.BaseSwagger.SwaggerConfigs;

internal class BaseSwaggerUIOptionsConfig : IConfigureNamedOptions<SwaggerUIOptions>
{
    private readonly IApiVersionDescriptionProvider _apiVersionDescriptionProvider;

    private readonly IOptions<BaseSwaggerOption> _options;
    public BaseSwaggerUIOptionsConfig(IApiVersionDescriptionProvider apiVersionDescriptionProvider, IOptions<BaseSwaggerOption> options)
    {
        _apiVersionDescriptionProvider = apiVersionDescriptionProvider;
        _options = options;
    }

    public void Configure(string name, SwaggerUIOptions options)
    {
        Configure(options);
    }

    public void Configure(SwaggerUIOptions options)
    {

        foreach (var desc in _apiVersionDescriptionProvider.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint($"/swagger/{desc.GroupName}/swagger.json", 
                $"{_options.Value.DocumentName} - {desc.GroupName.ToUpper()}");
        }
    }
}
