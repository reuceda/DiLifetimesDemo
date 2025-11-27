using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/scopes")]
public class ScopesController : ControllerBase
{
    private readonly IServiceProvider _provider;
    private readonly IScopedService _scopedFromRequest;

    public ScopesController(IServiceProvider provider, IScopedService scopedFromRequest)
    {
        _provider = provider;
        _scopedFromRequest = scopedFromRequest;
    }

    [HttpGet("compare")]
    public IActionResult Compare()
    {
        using var scope = _provider.CreateScope();
        var scopedManual = scope.ServiceProvider.GetRequiredService<IScopedService>();

        return Ok(new
        {
            ScopedRequest = _scopedFromRequest.Id,
            ScopedManual = scopedManual.Id
        });
    }
}

