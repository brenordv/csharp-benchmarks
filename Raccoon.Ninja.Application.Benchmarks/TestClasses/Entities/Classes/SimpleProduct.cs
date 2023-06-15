namespace Raccoon.Ninja.Application.Benchmarks.TestClasses.Entities.Classes;

public record SimpleProduct
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public SimpleCompany Company { get; set; }
}