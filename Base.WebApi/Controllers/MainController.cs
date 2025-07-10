using Microsoft.AspNetCore.Mvc;

namespace Base.Controllers;

[ApiController]
[Route("/")]
public class MainController : ControllerBase
{
    public MainController()
    {
    }

    [HttpGet(Name = "Get")]
    public string Get()
    {
        return "Hi, there!";
    }
}
