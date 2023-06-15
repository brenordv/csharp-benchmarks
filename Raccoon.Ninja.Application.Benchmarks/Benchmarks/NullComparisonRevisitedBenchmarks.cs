using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using Raccoon.Ninja.Application.Benchmarks.TestClasses.Entities.Classes;
using Raccoon.Ninja.Application.Benchmarks.TestClasses.Generators;

namespace Raccoon.Ninja.Application.Benchmarks.Benchmarks;

[MemoryDiagnoser, RankColumn, MinColumn, MaxColumn, MeanColumn, MedianColumn, UnicodeConsoleLogger,
 Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class NullComparisonRevisitedBenchmarks
{
    private List<SimpleProduct> _list;
    private List<string> _listOfStrings;

    [Params(10, 100, 500)] public int QtyElements { get; set; }

    [GlobalSetup]
    public void Init()
    {
        _list = new List<SimpleProduct>();
        _listOfStrings = new List<string>();
        if (QtyElements == 500)
        {
            for (var i = 0; i < QtyElements; i++)
            {
                _list.Add(null);
                _listOfStrings.Add(null);
            }

            return;
        }
        
        foreach (var mockClass in EntityGenerator.SimpleProducts(QtyElements / 2))
        {
            _list.Add(mockClass);
            _list.Add(null);
            _listOfStrings.Add("Some string");
            _listOfStrings.Add(null);
        }
    }

    [Benchmark]
    public void Object_Equals_Null()
    {
        for (var i = 0; i < QtyElements; i++)
        {
            var isNull = _list[i] == null;
        }
    }
    
    [Benchmark]
    public void Object_Is_Null()
    {
        for (var i = 0; i < QtyElements; i++)
        {
            var isNull = _list[i] is null;
        }
    }    
    
    [Benchmark]
    public void Object_Is_Empty()
    {
        for (var i = 0; i < QtyElements; i++)
        {
            var isNotNull = _list[i] is {};
        }
    }
    
    [Benchmark]
    public void Pattern_Match__Child_Prop_Value_Is_Null()
    {
        for (var i = 0; i < QtyElements; i++)
        {
            var isNotNull = _list[i] is { Company.Name: null };
        }
    }
        
    [Benchmark]
    public void Null_Coalesce__Child_Prop_Value_Is_Null()
    {
        for (var i = 0; i < QtyElements; i++)
        {
            var isNotNull = _list[i]?.Company?.Name == null;
        }
    }
    
    [Benchmark]
    public void Null_Coalesce__Child_Prop_Value_Is_NullOrWhitespace()
    {
        for (var i = 0; i < QtyElements; i++)
        {
            var isNotNull = string.IsNullOrWhiteSpace(_list[i]?.Company?.Name);
        }
    }
    
    [Benchmark]
    public void Control__IsNullOrWhitespace()
    {
        for (var i = 0; i < QtyElements; i++)
        {
            var isNotNull = string.IsNullOrWhiteSpace(_listOfStrings[i]);
        }
    }
}