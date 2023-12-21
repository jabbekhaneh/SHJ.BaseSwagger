using Microsoft.AspNetCore.Mvc;
using SHJ.BaseSwaggerSample;

namespace SHJ.BaseSwaggerSample.Controllers.v2;

[ApiVersion("2.0")]
public class TestController : BaseController
{
    [HttpGet]
    public string GetTest()
    {
        return "Test Versioning" + "v2";
    }
}

