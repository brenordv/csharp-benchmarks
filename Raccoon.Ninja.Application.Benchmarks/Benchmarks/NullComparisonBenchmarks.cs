using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using Raccoon.Ninja.Application.Benchmarks.TestClasses.Entities;
using Raccoon.Ninja.Application.Benchmarks.TestClasses.Entities.Records;

namespace Raccoon.Ninja.Application.Benchmarks.Benchmarks;

[MemoryDiagnoser, RankColumn, MinColumn, MaxColumn, MeanColumn, MedianColumn, UnicodeConsoleLogger,
 Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class NullComparisonBenchmarks
{
    private Product _product = null;
    private DateTime? _foo = null;

    [Benchmark]
    public void NativeObject_Equals_Null()
    {
        var isNull = _product == null;
    }

    [Benchmark]
    public void NativeObject_Method_Equals_Null()
    {
        var isNull = Equals(_product, null);
    }

    [Benchmark]
    public void NativeObject_Method_ReferenceEquals_Null()
    {
        var isNull = ReferenceEquals(_product, null);
    }

    [Benchmark]
    public void NativeObject_Is_Null()
    {
        var isNull = _product is null;
    }


    [Benchmark]
    public void NativeObject_Is_Not_Type()
    {
        var isNull = _product is not Product;
    }

    [Benchmark]
    public void NativeObject_Is_Not_Anonymous()
    {
        var isNull = _product is not { };
    }

    [Benchmark]
    public void NullableObject_Equals_Null()
    {
        var isNull = _foo == null;
    }

    [Benchmark]
    public void NullableObject_Method_Equals_Null()
    {
        var isNull = Equals(_foo, null);
    }

    [Benchmark]
    public void NullableObject_Method_ReferenceEquals_Null()
    {
        var isNull = ReferenceEquals(_foo, null);
    }

    [Benchmark]
    public void NullableObject_Is_Null()
    {
        var isNull = _foo is null;
    }


    [Benchmark]
    public void NullableObject_Is_Not_Type()
    {
        var isNull = _foo is not DateTime;
    }

    [Benchmark]
    public void NullableObject_Is_Not_Anonymous()
    {
        var isNull = _foo is not { };
    }

    [Benchmark]
    public void NullableObject_HasValue()
    {
        var isNull = _foo.HasValue;
    }
}