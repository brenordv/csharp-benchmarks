using System.Diagnostics.CodeAnalysis;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace Raccoon.Ninja.Application.Benchmarks.Benchmarks;

[ExcludeFromCodeCoverage]
[MemoryDiagnoser, RankColumn, MinColumn, MaxColumn, MeanColumn, MedianColumn, UnicodeConsoleLogger,
 Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class NumericBenchmarks
{
    private const int IntFloatPointValue = 003;
    private const int IntWholePartValue = 2;
    private const decimal DecimalValue = 2.003m;

    private List<decimal> _decimalList;
    private List<float> _floatList;
    private List<double> _doubleList;
    private List<(int, int)> _intList;
    
    [GlobalSetup]
    public void Init()
    {
        _decimalList = new List<decimal>();
        _intList = new List<(int, int)>();
        _floatList = new List<float>();
        _doubleList = new List<double>();
        
        for (var i = 0; i < 10000; i++)
        {
            _decimalList.Add(DecimalValue);
            _floatList.Add((float)DecimalValue);
            _doubleList.Add((double)DecimalValue);
            _intList.Add((IntFloatPointValue, IntWholePartValue));
        }
    }

    [Benchmark]
    public void Sum_Decimal()
    {
        var total = 0m;
        for (var i = 0; i < _decimalList.Count; i++)
        {
            total += _decimalList[i];
        }
    }
    
    [Benchmark]
    public void Sum_Int_to_Float()
    {
        var total = 0f;
        for (var i = 0; i < _intList.Count; i++)
        {
            total += _intList[i].Item1 + (float)_intList[i].Item2 / 100;
        }
    }
    
    [Benchmark]
    public void Sum_Int_to_Double()
    {
        var total = 0d;
        for (var i = 0; i < _intList.Count; i++)
        {
            total += _intList[i].Item1 + (float)_intList[i].Item2 / 100;
        }
    }
    
    [Benchmark]
    public void Sum_Double()
    {
        var total = 0d;
        for (var i = 0; i < _doubleList.Count; i++)
        {
            total += _doubleList[i];
        }
    }
    
    [Benchmark]
    public void Sum_Float()
    {
        var total = 0f;
        for (var i = 0; i < _floatList.Count; i++)
        {
            total += _floatList[i];
        }
    }
}