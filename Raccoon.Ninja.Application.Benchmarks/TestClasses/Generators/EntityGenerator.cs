using Bogus;
using Raccoon.Ninja.Application.Benchmarks.TestClasses.Entities;
using Raccoon.Ninja.Application.Benchmarks.TestClasses.Entities.Records;

namespace Raccoon.Ninja.Application.Benchmarks.TestClasses.Generators;

public static class EntityGenerator
{
    public static Product[] Products(int quantity)
    {
        var faker = new Faker<Product>()
            .RuleFor(x => x.Id, f => f.Random.Guid())
            .RuleFor(x => x.Name, f => f.Commerce.ProductName())
            .RuleFor(x => x.CreatedAt, f => f.Date.Past())
            .RuleFor(x => x.Description, f => f.Commerce.ProductDescription())
            .RuleFor(x => x.BaseValue, f => f.Random.Float(0.5f, 4200f))
            .RuleFor(x => x.TaxPercent, f => f.Random.Float());

        return faker.Generate(quantity).ToArray();
    }
    
    public static Address[] Addresses(int quantity)
    {
        var faker = new Faker<Address>()
            .RuleFor(x => x.Id, f => f.Random.Guid())
            .RuleFor(x => x.Street, f => f.Address.StreetAddress())
            .RuleFor(x => x.City, f => f.Address.City())
            .RuleFor(x => x.State, f => f.Address.State())
            .RuleFor(x => x.ZipCode, f => f.Address.ZipCode());

        return faker.Generate(quantity).ToArray();
    }
    
    public static User[] Users(int quantity)
    {
        var faker = new Faker<User>()
            .RuleFor(x => x.Id, f => f.Random.Guid())
            .RuleFor(x => x.Name, f => f.Name.FullName())
            .RuleFor(x => x.BirthDate, f => f.Date.Past())
            .RuleFor(x => x.IsActive, f => f.Random.Bool())
            .RuleFor(x => x.RewardPoints, f => f.Random.Float(0.5f, 4200f))
            .RuleFor(x => x.LastAccessed, f => f.Date.Past());

        return faker.Generate(quantity).ToArray();
    }
    
    public static Purchase[] Purchases(int quantity)
    {
        var faker = new Faker<Purchase>()
            .RuleFor(x => x.Id, f => f.Random.Guid())
            .RuleFor(x => x.User, f => f.PickRandom(Users(10)))
            .RuleFor(x => x.PurchaseDate, f => f.Date.Past())
            .RuleFor(x => x.AnomalyDetected, f => f.Random.Bool())
            .RuleFor(x => x.ShippingAddress, f => f.PickRandom(Addresses(10)))
            .RuleFor(x => x.Items, f => Products(25));

        return faker.Generate(quantity).ToArray();
    }
}