using System.Diagnostics.CodeAnalysis;
using AutoMapper;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using Raccoon.Ninja.Application.Benchmarks.TestClasses.Entities;
using Raccoon.Ninja.Application.Benchmarks.TestClasses.Entities.Records;
using Raccoon.Ninja.Application.Benchmarks.TestClasses.Generators;
using Raccoon.Ninja.Application.Benchmarks.TestClasses.Models;

namespace Raccoon.Ninja.Application.Benchmarks.Benchmarks;

[ExcludeFromCodeCoverage]
[MemoryDiagnoser, RankColumn, MinColumn, MaxColumn, MeanColumn, MedianColumn,UnicodeConsoleLogger, Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class AutoMapperSimpleBenchmarks
{
    
    #region Benchmark Setup
    private IMapper _mapper;
    private Product[] _entities;

    [Params(1, 1000, 10000)]
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
    public void AutoMapper_ListConvertedInForLoop()
    {
        for (var i = 0; i < _entities.Length; i++)
        {
            var productModel = _mapper.Map<ProductModel>(_entities[i]);
        }
    }
    
    [Benchmark]
    public void AutoMapper_ListConvertedLINQ()
    {
        var productModels = _entities.Select(product => _mapper.Map<ProductModel>(product)).ToList();
    }
    
    [Benchmark]
    public void AutoMapper_ListOfEntitiesConverted()
    {
        var productModels = _mapper.Map<List<ProductModel>>(_entities);
    }
    
    [Benchmark]
    public void Explicit_ListConvertedInForLoop()
    {
        for (var i = 0; i < _entities.Length; i++)
        {
            var productModel = (ProductModel)_entities[i];
        }
    }
    
    [Benchmark]
    public void Implicit_ListConvertedInForLoop()
    {
        for (var i = 0; i < _entities.Length; i++)
        {
            ProductModel productModel = _entities[i];
        }
    }
    
    [Benchmark]
    public void Explicit_ListConvertedLINQ()
    {
        var productModels = _entities.Select(x => (ProductModel)x).ToList();
    }
        
    [Benchmark]
    public void Implicit_ListConvertedLINQ()
    {
        var productModels = _entities.Select(x =>
        {
            ProductModel productModel = x;
            return productModel;
        }).ToList();
    }
    
    [Benchmark]
    public void DirectAssignment_ListConvertedInForLoop()
    {
        foreach (var product in _entities)
        {
            var productModel = new ProductModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                FinalValue = product.BaseValue + product.BaseValue * product.TaxPercent
            };
        }
    }
    
    [Benchmark]
    public void DirectAssignment_ListConvertedLINQ()
    {
        var productModels = _entities.Select(product => new ProductModel
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            FinalValue = product.BaseValue + product.BaseValue * product.TaxPercent
        }).ToList();
    }
}