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
public class AutoMapperBenchmarks
{
    
    #region Benchmark Setup
    private IMapper _mapper;
    private Product[] _entities;

    [Params(1, 10, 100, 1000, 5000)]
    public int QuantityEntities { get; set; }

    private void CreateMapper()
    {
        _mapper = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Product, ProductModel>()
                .ForMember(
                    dest => dest.FinalValue, 
                    opt => 
                        opt.MapFrom(src => src.BaseValue + src.BaseValue * src.TaxPercent));
            
        }).CreateMapper();
    }
    
    private void CreateEntities()
    {
        _entities = EntityGenerator.Products(QuantityEntities);
    }
    
    [GlobalSetup]
    public void Init()
    {
        CreateMapper();
        CreateEntities();
    }
    
    #endregion

    [Benchmark]
    public void AutoMapper_SingleProductConverted()
    {
        foreach (var Product in _entities)
        {
            var ProductModel = _mapper.Map<ProductModel>(Product);
        }
    }
    
    [Benchmark]
    public void AutoMapper_ListOfEntitiesConverted()
    {
        var ProductModels = _mapper.Map<ProductModel[]>(_entities);
    }
    
    [Benchmark]
    public void Explicit_SingleProductConverted()
    {
        foreach (var Product in _entities)
        {
            var ProductModel = (ProductModel)Product;
        }
    }
    
    [Benchmark]
    public void Implicit_SingleProductConverted()
    {
        foreach (var Product in _entities)
        {
            ProductModel ProductModel = Product;
        }
    }
    
    [Benchmark]
    public void Explicit_ListOfEntitiesLINQConverted()
    {
        var ProductModels = _entities.Select(x => (ProductModel)x).ToArray();
    }
        
    [Benchmark]
    public void Implicit_ListOfEntitiesLINQConverted()
    {
        var ProductModels = _entities.Select(x =>
        {
            ProductModel ProductModel = x;
            return ProductModel;
        }).ToArray();
    }
    
    [Benchmark]
    public void DirectAssignment_SingleProductConverted()
    {
        foreach (var Product in _entities)
        {
            var ProductModel = new ProductModel
            {
                Id = Product.Id,
                Name = Product.Name,
                Description = Product.Description,
                FinalValue = Product.BaseValue + Product.BaseValue * Product.TaxPercent
            };
        }
    }
    
    [Benchmark]
    public void DirectAssignment_ListOfEntitiesConverted()
    {
        var ProductModels = _entities.Select(Product => new ProductModel
        {
            Id = Product.Id,
            Name = Product.Name,
            Description = Product.Description,
            FinalValue = Product.BaseValue + Product.BaseValue * Product.TaxPercent
        }).ToArray();
    }
}