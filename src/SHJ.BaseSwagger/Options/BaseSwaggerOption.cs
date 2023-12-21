using Microsoft.OpenApi.Models;

namespace SHJ.BaseSwagger.Options;

public class BaseSwaggerOption
{
    public BaseSwaggerOption()
    {
        VersionsDocumentation = new();
    }
    public string ProjectName { get; set; } = "Portal Document";
    public List<BaseVersionDocumentation> VersionsDocumentation { get; set; }

}

public class BaseVersionDocumentation
{

    public string Title { get; set; } = string.Empty;
    public string Vesrion { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string UrlDocument { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public Uri? URL { get; set; } = new Uri("https://github.com/Jabbekhaneh/SHJ.BaseSwagger");
    public OpenApiLicense? License { get; set; }
    
}
