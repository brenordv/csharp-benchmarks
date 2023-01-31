using Raccoon.Ninja.Application.Benchmarks.TestClasses.Entities;

namespace Raccoon.Ninja.Application.Benchmarks.TestClasses.Models;

public record PurchaseModel
{
    public Guid Id { get; set; }
    public UserModel User { get; set; }
    public DateTime PurchaseDate { get; set; }
    public bool AnomalyDetected { get; set; }
    public AddressModel ShippingAddress { get; set; }
    public IList<ProductModel> Items { get; set; }
    
    public static implicit operator PurchaseModel(Purchase entity)
    {
        var productModels = new ProductModel[entity.Items.Count];
        
        for (var i = 0; i < entity.Items.Count; i++)
        {
            productModels[i] = entity.Items[i];
        }
        
        return new PurchaseModel
        {
            Id = entity.Id,
            User = entity.User,
            PurchaseDate = entity.PurchaseDate,
            AnomalyDetected = entity.AnomalyDetected,
            ShippingAddress = entity.ShippingAddress,
            Items = productModels
        };
    }
}
