namespace Raccoon.Ninja.Application.Benchmarks.TestClasses.Entities.Records;

public record User
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public DateTime BirthDate { get; init; }
    public bool IsActive { get; init; }
    public float RewardPoints { get; init; }
    public DateTime LastAccessed { get; init; }
}