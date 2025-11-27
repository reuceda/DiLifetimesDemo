using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/singletons")]
public class SingletonsController : ControllerBase
{
    private readonly ISingletonSafe _singleton;

    public SingletonsController(ISingletonSafe singleton)
    {
        _singleton = singleton;
    }

    [HttpGet("safe-scoped")]
    public IActionResult SafeScoped()
    {
        return Ok(new
        {
            ScopedId = _singleton.GetScopedIdSafely()
        });
    }
}

