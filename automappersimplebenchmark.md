[Readme](./readme.md) > [AutoMapper Benchmark](./automapperbenchmark.md)

# AutoMapper Simple Benchmark
## Entity
```csharp
public record Product
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public float BaseValue { get; set; }
    public float TaxPercent { get; set; }
    public DateTime CreatedAt { get; set; }
}
```

## Model
```csharp
public record ProductModel
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    public float FinalValue { get; init; }
}
```


## Results
| Method                                  | QuantityEntities |             Mean |          Error |         StdDev |           Median |              Min |              Max | Rank |     Gen0 |    Gen1 |    Gen2 | Allocated |
|-----------------------------------------|------------------|-----------------:|---------------:|---------------:|-----------------:|-----------------:|-----------------:|-----:|---------:|--------:|--------:|----------:|
| Explicit_ListConvertedInForLoop         | 1                |         8.647 ns |      0.1995 ns |      0.3697 ns |         8.531 ns |         8.086 ns |         9.690 ns |    1 |   0.0089 |       - |       - |      56 B |
| DirectAssignment_ListConvertedInForLoop | 1                |         8.907 ns |      0.2091 ns |      0.5582 ns |         8.985 ns |         7.905 ns |        10.364 ns |    2 |   0.0089 |       - |       - |      56 B |
| Implicit_ListConvertedInForLoop         | 1                |         8.936 ns |      0.2048 ns |      0.4274 ns |         8.951 ns |         8.284 ns |         9.781 ns |    2 |   0.0089 |       - |       - |      56 B |
| Explicit_ListConvertedLINQ              | 1                |        55.719 ns |      1.1408 ns |      2.0861 ns |        55.729 ns |        52.744 ns |        60.802 ns |    3 |   0.0268 |       - |       - |     168 B |
| DirectAssignment_ListConvertedLINQ      | 1                |        57.918 ns |      1.2112 ns |      3.5714 ns |        57.510 ns |        52.771 ns |        66.731 ns |    4 |   0.0268 |       - |       - |     168 B |
| Implicit_ListConvertedLINQ              | 1                |        63.086 ns |      1.6583 ns |      4.6772 ns |        61.774 ns |        55.936 ns |        75.988 ns |    5 |   0.0268 |       - |       - |     168 B |
| AutoMapper_ListConvertedInForLoop       | 1                |        98.559 ns |      1.9846 ns |      2.2059 ns |        98.010 ns |        96.108 ns |       103.569 ns |    6 |   0.0088 |       - |       - |      56 B |
| AutoMapper_ListOfEntitiesConverted      | 1                |       124.542 ns |      2.5236 ns |      4.6146 ns |       123.727 ns |       119.203 ns |       136.325 ns |    7 |   0.0229 |       - |       - |     144 B |
| AutoMapper_ListConvertedLINQ            | 1                |       145.792 ns |      0.9940 ns |      0.8811 ns |       145.959 ns |       144.286 ns |       147.573 ns |    8 |   0.0370 |       - |       - |     232 B |
| DirectAssignment_ListConvertedInForLoop | 1000             |     8,782.417 ns |    175.2428 ns |    163.9222 ns |     8,843.095 ns |     8,547.931 ns |     9,059.572 ns |    9 |   8.9264 |       - |       - |   56000 B |
| Implicit_ListConvertedInForLoop         | 1000             |    10,093.958 ns |    191.2182 ns |    234.8332 ns |    10,079.356 ns |     9,630.954 ns |    10,491.277 ns |   10 |   8.9264 |       - |       - |   56000 B |
| Explicit_ListConvertedInForLoop         | 1000             |    10,541.264 ns |    141.9899 ns |    132.8175 ns |    10,539.351 ns |    10,336.105 ns |    10,738.193 ns |   11 |   8.9264 |       - |       - |   56000 B |
| DirectAssignment_ListConvertedLINQ      | 1000             |    13,835.707 ns |    270.2320 ns |    321.6919 ns |    13,929.976 ns |    13,317.441 ns |    14,243.372 ns |   12 |  10.2081 |  1.6785 |       - |   64104 B |
| Explicit_ListConvertedLINQ              | 1000             |    14,068.178 ns |    182.7289 ns |    161.9844 ns |    14,070.295 ns |    13,794.986 ns |    14,297.040 ns |   12 |  10.2081 |  1.6785 |       - |   64104 B |
| Implicit_ListConvertedLINQ              | 1000             |    14,341.197 ns |    284.3339 ns |    593.5108 ns |    14,465.900 ns |    13,409.798 ns |    15,985.426 ns |   12 |  10.2081 |  1.6785 |       - |   64104 B |
| AutoMapper_ListOfEntitiesConverted      | 1000             |    18,755.543 ns |    356.1501 ns |    349.7870 ns |    18,599.483 ns |    18,407.730 ns |    19,469.247 ns |   13 |  11.5662 |  1.9226 |       - |   72600 B |
| AutoMapper_ListConvertedInForLoop       | 1000             |    96,660.704 ns |  1,919.0465 ns |  3,043.8111 ns |    98,146.570 ns |    90,985.327 ns |   100,940.381 ns |   14 |   8.9111 |       - |       - |   56000 B |
| DirectAssignment_ListConvertedInForLoop | 10000            |    97,572.916 ns |  1,914.3615 ns |  3,995.9854 ns |    96,964.270 ns |    90,736.938 ns |   106,744.849 ns |   14 |  89.2334 |       - |       - |  560000 B |
| AutoMapper_ListConvertedLINQ            | 1000             |   100,143.725 ns |  1,978.3433 ns |  3,194.6556 ns |    99,945.770 ns |    95,212.390 ns |   105,190.466 ns |   15 |  10.1318 |  1.5869 |       - |   64168 B |
| Explicit_ListConvertedInForLoop         | 10000            |   113,975.152 ns |  2,241.9198 ns |  2,302.2866 ns |   113,211.304 ns |   111,252.563 ns |   119,793.896 ns |   16 |  89.2334 |       - |       - |  560000 B |
| Implicit_ListConvertedInForLoop         | 10000            |   116,120.808 ns |  1,257.9297 ns |  1,176.6682 ns |   116,345.032 ns |   113,594.531 ns |   117,466.138 ns |   17 |  89.2334 |       - |       - |  560000 B |
| DirectAssignment_ListConvertedLINQ      | 10000            |   186,010.936 ns |  3,700.2757 ns |  4,261.2430 ns |   186,835.645 ns |   179,188.770 ns |   191,703.394 ns |   18 | 101.8066 | 41.0156 |       - |  640104 B |
| Explicit_ListConvertedLINQ              | 10000            |   186,838.391 ns |  3,591.9402 ns |  3,843.3358 ns |   186,955.347 ns |   178,879.297 ns |   194,612.769 ns |   18 | 101.8066 | 41.0156 |       - |  640104 B |
| Implicit_ListConvertedLINQ              | 10000            |   192,103.914 ns |  3,735.1283 ns |  3,668.3955 ns |   192,140.649 ns |   182,759.595 ns |   198,899.585 ns |   19 | 101.8066 | 41.0156 |       - |  640104 B |
| AutoMapper_ListConvertedInForLoop       | 10000            |   995,521.141 ns | 19,836.4412 ns | 48,284.6394 ns |   987,702.051 ns |   917,358.984 ns | 1,083,250.586 ns |   20 |  87.8906 |       - |       - |  560002 B |
| AutoMapper_ListConvertedLINQ            | 10000            | 1,051,677.007 ns | 20,739.9704 ns | 30,400.3797 ns | 1,039,105.859 ns | 1,007,458.984 ns | 1,102,852.148 ns |   21 | 101.5625 | 41.0156 |       - |  640170 B |
| AutoMapper_ListOfEntitiesConverted      | 10000            | 1,106,267.364 ns | 21,729.0737 ns | 33,182.5904 ns | 1,100,171.484 ns | 1,029,599.609 ns | 1,192,829.297 ns |   22 | 136.7188 | 91.7969 | 33.2031 |  822480 B |

In that test, AutoMapper was awful across the board. It was the slowest in every scenario. It was also the most memory intensive. I’m not sure why it was so slow and memory intensive, but I’m guessing it has something to do
with the fact that it’s using reflection to map the properties. 

In this set of tests, for workload of 1000 AutoMapper batch conversion performed really well in comparison with other workloads. It was still bad, but it was the best of the bad.

As for the composite workload, explicit and implicit mapping performed the best in terms of speed and memory usage. AutoMapper was the slowest and most memory intensive.