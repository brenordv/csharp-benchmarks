namespace Raccoon.Ninja.Application.Benchmarks.TestClasses.Entities.Records;

public record struct PersonRecordStruct(
    Guid Id,
    string Name,
    DateTime BirthDate,
    bool IsActive,
    float RewardPoints,
    DateTime LastAccessed
);