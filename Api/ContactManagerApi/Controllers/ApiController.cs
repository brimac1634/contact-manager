using Microsoft.AspNetCore.Mvc;

namespace ContactManagerApi.Controllers;

[ApiVersion("1.0")]
[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
public class ApiController : ControllerBase
{

}