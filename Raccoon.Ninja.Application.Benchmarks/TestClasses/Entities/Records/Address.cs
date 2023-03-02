namespace Raccoon.Ninja.Application.Benchmarks.TestClasses.Entities.Records;

public record Address
{
    public Guid Id { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
}