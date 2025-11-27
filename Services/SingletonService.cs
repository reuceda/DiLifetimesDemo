public interface ISingletonService
{
    Guid Id { get; }
}

public class SingletonService : ISingletonService
{
    public Guid Id { get; }

    public SingletonService()
    {
        Id = Guid.NewGuid();
    }
}

