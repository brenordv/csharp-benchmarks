using Raccoon.Ninja.Application.Benchmarks.TestClasses.Entities.Records;

namespace Raccoon.Ninja.Application.Benchmarks.TestClasses.Entities;

public record Purchase
{
    public Guid Id { get; set; }
    public User User { get; set; }
    public DateTime PurchaseDate { get; set; }
    public bool AnomalyDetected { get; set; }
    public Address ShippingAddress { get; set; }
    public IList<Product> Items { get; set; }
}