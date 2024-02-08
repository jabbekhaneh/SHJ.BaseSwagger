using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SHJ.BaseSwaggerSample.Controllers.v1;



[ApiVersion("1.1")]
public class TestController : BaseController
{
    [HttpGet]

    public IActionResult Get()
    {
        var response = "Test Versioning" + "v1";
        return Ok(response);

    }


    [HttpGet("{name}"),Authorize,ActionName("byName")]
    public IActionResult Get(string name)
    {
        var response = $"{name}-" + "v1";
        return Ok(response);

    }



}
