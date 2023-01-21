using Bogus;
using Raccoon.Ninja.Application.Benchmarks.TestClasses.Entities;

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
}