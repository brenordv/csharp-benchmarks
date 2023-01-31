using System.Diagnostics.CodeAnalysis;
using AutoMapper;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using Raccoon.Ninja.Application.Benchmarks.TestClasses.Entities;
using Raccoon.Ninja.Application.Benchmarks.TestClasses.Generators;
using Raccoon.Ninja.Application.Benchmarks.TestClasses.Models;

namespace Raccoon.Ninja.Application.Benchmarks.Benchmarks;

[ExcludeFromCodeCoverage]
[MemoryDiagnoser, RankColumn, MinColumn, MaxColumn, MeanColumn, MedianColumn,UnicodeConsoleLogger, Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class AutoMapperCompositeBenchmarks
{
    
    #region Benchmark Setup
    private IMapper _mapper;
    private Purchase[] _entities;

    [Params(1, 1000, 10000)]
    public int QuantityEntities { get; set; }

    private void CreateMapper()
    {
        _mapper = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Address, AddressModel>();
            cfg.CreateMap<User, UserModel>();
            cfg.CreateMap<Product, ProductModel>()
                .ForMember(
                    dest => dest.FinalValue, 
                    opt => 
                        opt.MapFrom(src => src.BaseValue + src.BaseValue * src.TaxPercent));
            cfg.CreateMap<Purchase, PurchaseModel>();
        }).CreateMapper();
    }
    
    private void CreateEntities()
    {
        _entities = EntityGenerator.Purchases(QuantityEntities);
    }
    
    [GlobalSetup]
    public void Init()
    {
        CreateMapper();
        CreateEntities();
    }
    
    #endregion

    [Benchmark]
    public void AutoMapper_ListConvertedInForLoop()
    {
        for (var i = 0; i < _entities.Length; i++)
        {
            var purchaseModel = _mapper.Map<PurchaseModel>(_entities[i]);
        }
    }
    
    [Benchmark]
    public void AutoMapper_ListConvertedLINQ()
    {
        var purchaseModel = _entities.Select(purchase => _mapper.Map<PurchaseModel>(purchase)).ToList();
    }
    
    
    [Benchmark]
    public void AutoMapper_ListOfEntitiesConverted()
    {
        var purchaseModels = _mapper.Map<List<PurchaseModel>>(_entities);
    }
    
    [Benchmark]
    public void Explicit_ListConvertedInForLoop()
    {
        for (var i = 0; i < _entities.Length; i++)
        {
            var purchaseModels = (PurchaseModel)_entities[i];
        }
    }
    
    [Benchmark]
    public void Implicit_ListConvertedInForLoop()
    {
        for (var i = 0; i < _entities.Length; i++)
        {
            PurchaseModel purchaseModel = _entities[i];
        }
    }
    
    [Benchmark]
    public void Explicit_ListConvertedLINQ()
    {
        var purchaseModels = _entities.Select(x => (PurchaseModel)x).ToList();
    }
        
    [Benchmark]
    public void Implicit_ListConvertedLINQ()
    {
        var purchaseModels = _entities.Select(x =>
        {
            PurchaseModel purchaseModel = x;
            return purchaseModel;
        }).ToList();
    }
    
    [Benchmark]
    public void DirectAssignment_ListConvertedInForLoop()
    {
        for (var i = 0; i < _entities.Length; i++)
        {
            var purchase = _entities[i]; 
            var productModels = new ProductModel[purchase.Items.Count];
            for (var j = 0; j < purchase.Items.Count; j++)
            {
                productModels[j] = new ProductModel
                {
                    Id = purchase.Items[j].Id,
                    Name = purchase.Items[j].Name,
                    Description = purchase.Items[j].Description,
                    FinalValue = purchase.Items[j].BaseValue + purchase.Items[j].BaseValue * purchase.Items[j].TaxPercent
                };
            }
            var purchaseModel = new PurchaseModel
            {
                Id = purchase.Id,
                User = new UserModel
                {
                    Id = purchase.User.Id,
                    Name = purchase.User.Name,
                    BirthDate = purchase.User.BirthDate,
                    IsActive = purchase.User.IsActive,
                    RewardPoints = purchase.User.RewardPoints,
                    LastAccessed = purchase.User.LastAccessed
                },
                PurchaseDate = purchase.PurchaseDate,
                AnomalyDetected = purchase.AnomalyDetected,
                ShippingAddress = new AddressModel
                {
                    Id = purchase.ShippingAddress.Id,
                    Street = purchase.ShippingAddress.Street,
                    City = purchase.ShippingAddress.City,
                    State = purchase.ShippingAddress.State,
                    ZipCode = purchase.ShippingAddress.ZipCode
                },
                Items = productModels
            };            
        }
    }
    
    [Benchmark]
    public void DirectAssignment_ListConvertedLINQ()
    {
        var purchaseModels = _entities.Select(purchase =>  new PurchaseModel
        {
            Id = purchase.Id,
            User = new UserModel
            {
                Id = purchase.User.Id,
                Name = purchase.User.Name,
                BirthDate = purchase.User.BirthDate,
                IsActive = purchase.User.IsActive,
                RewardPoints = purchase.User.RewardPoints,
                LastAccessed = purchase.User.LastAccessed
            },
            PurchaseDate = purchase.PurchaseDate,
            AnomalyDetected = purchase.AnomalyDetected,
            ShippingAddress = new AddressModel
            {
                Id = purchase.ShippingAddress.Id,
                Street = purchase.ShippingAddress.Street,
                City = purchase.ShippingAddress.City,
                State = purchase.ShippingAddress.State,
                ZipCode = purchase.ShippingAddress.ZipCode
            },
            Items = purchase.Items.Select(product => (ProductModel)product).ToList()
        }).ToList();
    }
}