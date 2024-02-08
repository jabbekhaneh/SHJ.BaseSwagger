SHJ.BaseSwagger
=======

Documentation From Your API Design in asp.net

Examples in the [wiki](https://github.com/jabbekhaneh/SHJ.BaseSwagger).

<!-- ### How do I get started? -->

### Installing SHJ.FileManager
You should install [SHJ.BaseSwagger with NuGet](https://www.nuget.org/packages/SHJ.BaseSwagger):

```bash
> Install-Package SHJ.BaseSwagger
```

Or via the .NET Core command line interface:
   
```bash
> dotnet add package SHJ.BaseSwagger
```

### Registering with `IServiceCollection`

```
srvices.RegisterSwagger(options =>
{
    options.ProjectName = "*** TEST API VERSIONING ***";
});
```

### Registering with `IApplicationBuilder`

```
 app.RegisterUseSwaggerAndUI();
```



