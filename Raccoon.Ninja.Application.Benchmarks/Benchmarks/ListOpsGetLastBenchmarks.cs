using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace Raccoon.Ninja.Application.Benchmarks.Benchmarks;

[MemoryDiagnoser, RankColumn, MinColumn, MaxColumn, MeanColumn, MedianColumn, UnicodeConsoleLogger,
 Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class ListOpsGetLastBenchmarks
{
    private List<string> _stringList;
    
    [Params(1, 1000, 10000)]
    public int QuantityEntities { get; set; }
    
    
    [GlobalSetup]
    public void Init()
    {
        _stringList = new List<string>();
        
        for (var i = 0; i < QuantityEntities; i++)
        {
            _stringList.Add($"Item {i}");
        }
    }
    
    [Benchmark]
    public void LINQ_Last()
    {
        var last = _stringList.Last();
    }
    
    [Benchmark]
    public void LINQ_LastOrDefault()
    {
        var last = _stringList.LastOrDefault();
    }    
    
    [Benchmark]
    public void Length_Minus_One()
    {
        var last = _stringList[_stringList.Count - 1];
    }
    
        
    [Benchmark]
    public void Index_From_End()
    {
        var last = _stringList[^1];
    }
}