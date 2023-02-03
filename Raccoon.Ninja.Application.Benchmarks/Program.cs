using BenchmarkDotNet.Running;
using Raccoon.Ninja.Application.Benchmarks.Benchmarks;
using Raccoon.Ninja.Application.Benchmarks.Extras;

//Uncomment to run some extra conversion tests. 
//ExtraTests.TestConversion();

#if DEBUG
    throw new Exception("Benchmark must be run in Release mode");
#endif


//Uncomment to run AutoMapper Light benchmarks.
//BenchmarkRunner.Run<AutoMapperSimpleBenchmarks>();

//Uncomment to run AutoMapper Composite benchmarks.
//BenchmarkRunner.Run<AutoMapperCompositeBenchmarks>();

//Uncomment to run "Find one" benchmark.
//BenchmarkRunner.Run<FindOneBenchmarks>();

//Uncomment to run "Numeric benchmarks" benchmark.
//BenchmarkRunner.Run<NumericBenchmarks>();

//Uncomment to run "Find one and modify" benchmark.
//BenchmarkRunner.Run<FindOneAndModifyBenchmarks>();

//Uncomment to run "String Extraction" benchmark.
BenchmarkRunner.Run<SubStringExtractionBenchmark>();
