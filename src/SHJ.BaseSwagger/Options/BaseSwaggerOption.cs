using Microsoft.OpenApi.Models;

namespace SHJ.BaseSwagger.Options;

public class BaseSwaggerOption
{
    public BaseSwaggerOption()
    {
        VersionsDocumentation = new();
    }
    public string DocumentName { get; set; } = "Portal Document";
    public List<BaseVersionDocumentation> VersionsDocumentation { get; set; }
    public BaseSwaggerSecurityDefinition Authorize { get; set; } = new BaseSwaggerSecurityDefinition
    {
        Key = "_OAuth2_",
        SecurityScheme = new OpenApiSecurityScheme
        {
            Scheme= "_OAuth2_",
            Type = SecuritySchemeType.OAuth2,
            Name = "_NAME_",
            Flows = new OpenApiOAuthFlows
            {
                Password = new OpenApiOAuthFlow
                {
                    TokenUrl = new Uri("/api/v1/Account/SingIn", UriKind.Relative),
                    AuthorizationUrl = new Uri("/api/v1/Account/SingIn", UriKind.Relative),
                    Scopes = new Dictionary<string, string>
                    {
                        { "readAccess", "Access read operations" },
                        { "writeAccess", "Access write operations" }
                    }
                }
            }
        }
    };
}
public class BaseSwaggerSecurityDefinition
{
    public string? Key { get; set; }
    public OpenApiSecurityScheme? SecurityScheme { get; set; }
}