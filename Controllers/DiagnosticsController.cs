using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/diagnostics")]
public class DiagnosticsController : ControllerBase
{
    private readonly ITransientService _t1;
    private readonly ITransientService _t2;
    private readonly IScopedService _s1;
    private readonly IScopedService _s2;
    private readonly ISingletonService _sg1;
    private readonly ISingletonService _sg2;

    public DiagnosticsController(
        ITransientService t1,
        ITransientService t2,
        IScopedService s1,
        IScopedService s2,
        ISingletonService sg1,
        ISingletonService sg2)
    {
        _t1 = t1;
        _t2 = t2;
        _s1 = s1;
        _s2 = s2;
        _sg1 = sg1;
        _sg2 = sg2;
    }

    [HttpGet("lifetimes")]
    public IActionResult Get()
    {
        return Ok(new
        {
            Transient1 = _t1.Id,
            Transient2 = _t2.Id,
            Scoped1 = _s1.Id,
            Scoped2 = _s2.Id,
            Singleton1 = _sg1.Id,
            Singleton2 = _sg2.Id
        });
    }
}
