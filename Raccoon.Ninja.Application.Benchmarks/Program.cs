using BenchmarkDotNet.Running;
using Raccoon.Ninja.Application.Benchmarks.Benchmarks;

#if DEBUG
    throw new Exception("Benchmark must be run in Release mode");
#endif


//Uncomment to run Auto Mapper benchmarks.
//BenchmarkRunner.Run<AutoMapperBenchmarks>();

//Uncomment to run "Find one" benchmark.
//BenchmarkRunner.Run<FindOneBenchmarks>();

//Uncomment to run "Numeric benchmarks" benchmark.
BenchmarkRunner.Run<NumericBenchmarks>();
