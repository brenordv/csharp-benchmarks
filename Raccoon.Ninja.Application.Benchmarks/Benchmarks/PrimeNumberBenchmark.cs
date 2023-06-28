using System.Diagnostics.CodeAnalysis;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using Raccoon.Ninja.Application.Benchmarks.TestClasses.Helpers;

namespace Raccoon.Ninja.Application.Benchmarks.Benchmarks;

[ExcludeFromCodeCoverage]
[MemoryDiagnoser, RankColumn, MinColumn, MaxColumn, MeanColumn, MedianColumn, UnicodeConsoleLogger,
 Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class PrimeNumberBenchmark
{

    [Benchmark]
    public void IsPrimeRegex()
    {
        PrimeNumberCheckers.IsPrimeRegex(0);
        PrimeNumberCheckers.IsPrimeRegex(1);
        PrimeNumberCheckers.IsPrimeRegex(2);
        PrimeNumberCheckers.IsPrimeRegex(3);
        PrimeNumberCheckers.IsPrimeRegex(4);
        PrimeNumberCheckers.IsPrimeRegex(5);
        PrimeNumberCheckers.IsPrimeRegex(6);
        PrimeNumberCheckers.IsPrimeRegex(7);
    }
    
    [Benchmark]
    public void IsPrimeReadable()
    {
        PrimeNumberCheckers.IsPrimeReadable(0);
        PrimeNumberCheckers.IsPrimeReadable(1);
        PrimeNumberCheckers.IsPrimeReadable(2);
        PrimeNumberCheckers.IsPrimeReadable(3);
        PrimeNumberCheckers.IsPrimeReadable(4);
        PrimeNumberCheckers.IsPrimeReadable(5);
        PrimeNumberCheckers.IsPrimeReadable(6);
        PrimeNumberCheckers.IsPrimeReadable(7);
    }

    [Benchmark]
    public void IsPrimePerformance()
    {
        PrimeNumberCheckers.IsPrimePerformance(0);
        PrimeNumberCheckers.IsPrimePerformance(1);
        PrimeNumberCheckers.IsPrimePerformance(2);
        PrimeNumberCheckers.IsPrimePerformance(3);
        PrimeNumberCheckers.IsPrimePerformance(4);
        PrimeNumberCheckers.IsPrimePerformance(5);
        PrimeNumberCheckers.IsPrimePerformance(6);
        PrimeNumberCheckers.IsPrimePerformance(7);
    }
    
    [Benchmark]
    public void IsPrimeRecursion()
    {
        PrimeNumberCheckers.IsPrimeRecursion(0);
        PrimeNumberCheckers.IsPrimeRecursion(1);
        PrimeNumberCheckers.IsPrimeRecursion(2);
        PrimeNumberCheckers.IsPrimeRecursion(3);
        PrimeNumberCheckers.IsPrimeRecursion(4);
        PrimeNumberCheckers.IsPrimeRecursion(5);
        PrimeNumberCheckers.IsPrimeRecursion(6);
        PrimeNumberCheckers.IsPrimeRecursion(7);
    }
    
}