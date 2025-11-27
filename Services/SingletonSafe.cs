public interface ISingletonSafe
{
    Guid GetScopedIdSafely();
}

public class SingletonSafe : ISingletonSafe
{
    private readonly IServiceProvider _provider;

    public SingletonSafe(IServiceProvider provider)
    {
        _provider = provider;
    }

    public Guid GetScopedIdSafely()
    {
        using var scope = _provider.CreateScope();
        var scoped = scope.ServiceProvider.GetRequiredService<IScopedService>();
        return scoped.Id;
    }
}

