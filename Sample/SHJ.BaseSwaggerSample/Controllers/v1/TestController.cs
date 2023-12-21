using Microsoft.AspNetCore.Mvc;

namespace SHJ.BaseSwaggerSample.Controllers.v1;



[ApiVersion("1.1")]
public class TestController : BaseController
{
    [HttpGet]

    public IActionResult GetTest()
    {
        var response = "Test Versioning" + "v1";
        return Ok(response);
    }



}
