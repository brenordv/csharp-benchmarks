using Raccoon.Ninja.Application.Benchmarks.TestClasses.Entities;
using Raccoon.Ninja.Application.Benchmarks.TestClasses.Entities.Records;

namespace Raccoon.Ninja.Application.Benchmarks.TestClasses.Models;

public record AddressModel
{
    public Guid Id { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
    
    public static implicit operator AddressModel(Address entity)
    {
        return new AddressModel
        {
            Id = entity.Id,
            Street = entity.Street,
            City = entity.City,
            State = entity.State,
            ZipCode = entity.ZipCode
        };
    }
}