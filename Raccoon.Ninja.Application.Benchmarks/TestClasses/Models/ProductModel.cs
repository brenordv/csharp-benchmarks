using Raccoon.Ninja.Application.Benchmarks.TestClasses.Entities;
using Raccoon.Ninja.Application.Benchmarks.TestClasses.Entities.Records;

namespace Raccoon.Ninja.Application.Benchmarks.TestClasses.Models;

public record ProductModel
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    public float FinalValue { get; init; }

    public static implicit operator ProductModel(Product entity)
    {
        return new ProductModel
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            FinalValue = entity.BaseValue + entity.BaseValue * entity.TaxPercent
        };
    }
}