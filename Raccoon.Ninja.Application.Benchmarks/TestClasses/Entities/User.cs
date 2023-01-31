namespace Raccoon.Ninja.Application.Benchmarks.TestClasses.Entities;

public record User
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }
    public bool IsActive { get; set; }
    public float RewardPoints { get; set; }
    public DateTime LastAccessed { get; set; }
}