using System.Runtime.CompilerServices;

namespace Raccoon.Ninja.Application.Benchmarks.TestClasses.Entities.Records;

public record Person(
    Guid Id,
    string Name,
    DateTime BirthDate,
    bool IsActive,
    float RewardPoints,
    DateTime LastAccessed
);