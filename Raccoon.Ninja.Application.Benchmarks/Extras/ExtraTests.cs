using Raccoon.Ninja.Application.Benchmarks.TestClasses.Entities;
using Raccoon.Ninja.Application.Benchmarks.TestClasses.Entities.Records;
using Raccoon.Ninja.Application.Benchmarks.TestClasses.Generators;
using Raccoon.Ninja.Application.Benchmarks.TestClasses.Models;

namespace Raccoon.Ninja.Application.Benchmarks.Extras;

public static class ExtraTests
{
    public static void TestConversion()
    {
        var product = EntityGenerator.Products(1)[0];
        var productModel = ConvertToPM(product);
        var product2 = ConvertToP(productModel);
        var productModel2 = (ProductModel)product;
        ProductModel productModel3 = product;
        var product4 = (Product)productModel;
        Product product5 = productModel;
    }
    
    public static Product ConvertToP(ProductModel pm)
    {
        return pm;
    }

    public static ProductModel ConvertToPM(Product p)
    {
        return p;
    }
}