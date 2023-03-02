using Raccoon.Ninja.Application.Benchmarks.TestClasses.Entities.Records;

namespace Raccoon.Ninja.Application.Benchmarks.TestClasses.Entities;

public record UserModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }
    public bool IsActive { get; set; }
    public float RewardPoints { get; set; }
    public DateTime LastAccessed { get; set; }
    
    public static implicit operator UserModel(User entity)
    {
        return new UserModel
        {
            Id = entity.Id,
            Name = entity.Name,
            BirthDate = entity.BirthDate,
            IsActive = entity.IsActive,
            RewardPoints = entity.RewardPoints,
            LastAccessed = entity.LastAccessed
        };
    }
}