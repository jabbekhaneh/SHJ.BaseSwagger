using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using SHJ.BaseSwagger.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace SHJ.BaseSwagger.SwaggerConfigs;

public class BaseConfigSwaggerGenOptions : IConfigureNamedOptions<SwaggerGenOptions>
{
    private readonly IApiVersionDescriptionProvider _apiVersionDescriptionProvider;
    private readonly IOptions<BaseSwaggerOption> _options;
    public BaseConfigSwaggerGenOptions(IApiVersionDescriptionProvider apiVersionDescriptionProvider, IOptions<BaseSwaggerOption> options)
    {
        _apiVersionDescriptionProvider = apiVersionDescriptionProvider;
        _options = options;
    }

    /// <summary>
    /// Configure each API discovered for Swagger Documentation
    /// </summary>
    /// <param name="options"></param>
    public void Configure(SwaggerGenOptions options)
    {
        foreach (var desc in _apiVersionDescriptionProvider.ApiVersionDescriptions)
        {
            if (_options.Value.VersionsDocumentation.Any(_ => _.Vesrion == desc.GroupName))
            {
                var versionDocument = _options.Value.VersionsDocumentation.Single(_ => _.Vesrion == desc.GroupName);
                options.SwaggerDoc(desc.GroupName, CreateVersionDocumnet(versionDocument));
            }
            else
            {
                var versionDocument = new BaseVersionDocumentation
                {
                    Vesrion = desc.GroupName,
                    Description = $"{_options.Value.ProjectName}: API Version {desc.GroupName}",
                };
                options.SwaggerDoc(desc.GroupName, CreateVersionDocumnet(versionDocument));
            }

        }
    }
    /// <summary>
    /// Configure Swagger Options. Inherited from the Interface
    /// </summary>
    /// <param name="name"></param>
    /// <param name="options"></param>
    public void Configure(string name, SwaggerGenOptions options)
    {
        Configure(options);
    }

    private OpenApiInfo CreateVersionDocumnet(BaseVersionDocumentation documentation)
    {
        return new OpenApiInfo
        {
            Title = documentation.Title,
            Version = documentation.Vesrion,
            Contact = new OpenApiContact
            {
                Email = documentation.Email,
                Name = documentation.Author,
                Url = documentation.URL,
            },
            Description = documentation.Description,
            License = documentation.License,

        };
    }


}