public interface ITransientService
{
    Guid Id { get; }
}

public class TransientService : ITransientService
{
    public Guid Id { get; } = Guid.NewGuid();
}

