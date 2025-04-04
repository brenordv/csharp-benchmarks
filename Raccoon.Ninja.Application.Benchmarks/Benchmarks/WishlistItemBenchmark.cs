using System.Diagnostics.CodeAnalysis;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using Raccoon.Ninja.Application.Benchmarks.TestClasses.Entities.Records;
using Raccoon.Ninja.Application.Benchmarks.TestClasses.Generators;
using Raccoon.Ninja.Application.Benchmarks.TestClasses.Helpers;

namespace Raccoon.Ninja.Application.Benchmarks.Benchmarks;

[ExcludeFromCodeCoverage]
[MemoryDiagnoser, RankColumn, MinColumn, MaxColumn, MeanColumn, MedianColumn, UnicodeConsoleLogger,
 Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class WishlistItemBenchmark
{
    [Params(100, 10_000, 100_000)] public int QtyElements { get; set; }
    private List<WishlistItem> _list;
    private const int DeactivateEveryNth = 30;
    private const int PutInThePastEveryNth = 50;
    private const int CorrectWishListItemEveryNth = 15;
    private const WishlistItemUserType TargetUserType = WishlistItemUserType.Premium;
    private static readonly List<WishlistItemUserType> TargetUserTypes = new() { TargetUserType };
    
    private List<WishlistItem> _resultList = new();
    
    [GlobalSetup]
    public void Init()
    {
        _list = new List<WishlistItem>();


        foreach (var mockClass in EntityGenerator.WishlistItems(QtyElements))
        {
            mockClass.IsEnabled = _list.Count % DeactivateEveryNth != 0;

            if (_list.Count % PutInThePastEveryNth == 0)
            {
                mockClass.EndDate = mockClass.StartDate; //StartDate is always in the Past.
                mockClass.StartDate = mockClass.EndDate.AddDays(-1);
            }
            
            mockClass.UserType = _list.Count % CorrectWishListItemEveryNth == 0 
                ? TargetUserType
                : WishlistItemUserType.Business;

            _list.Add(mockClass);
        }
    }
    
    
    [IterationSetup]
    public void BenchmarkSetup()
    {
        _resultList = new List<WishlistItem>();
    }
    
    [Benchmark]
    public List<WishlistItem> FilterWishListItems__UsingFor()
    {
        for(var i = 0; i < _list.Count; i++)
        {
            var result = WishlistItemHelper.FilterWishListItems(_list[i], TargetUserTypes);
            if (result == null) continue;
            _resultList.Add(result);
        }
        
        return _resultList;
    }
    
    [Benchmark]
    public List<WishlistItem> FilterWishListItems__UsingForEach()
    {
        foreach (var wishlistItem in _list)
        {
            var result = WishlistItemHelper.FilterWishListItems(wishlistItem, TargetUserTypes);
            if (result == null) continue;
            _resultList.Add(result);
        }

        return _resultList;
    }
}