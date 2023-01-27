namespace Raccoon.Ninja.Application.Benchmarks.TestClasses.Entities;

public record Product
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public float BaseValue { get; set; }
    public float TaxPercent { get; set; }
    public DateTime CreatedAt { get; set; }
}