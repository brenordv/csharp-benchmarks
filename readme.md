# Project
I created this project to centralize my benchmark tests. This is in no way a super precise benchmark nor should it be
considered as "empiric proof" or anything. Take it with a grain of salt.
It's just someone curious about the performance of some common operations.

All benchmarks were run in a Windows 10 machine using .net6.


# Benchmarks
1. [AutoMapper](./automapperbenchmark.md)
2. [Find One](./findonebenchmark.md)
3. [Find One and Modify](./findoneandmodifybenchmark.md) 
4. [Numeric Operation](./numericbenchmark.md)
5. [String Extraction](./stringextractionbenchmark.md)
6. [String contains letter](./stringcontainsletterbenchmark.md)
6. [Null Check](./nullcomparisonbenchmark.md)
7. [Null Check - Revisited](./nullcomparisonbenchmarkrevisited.md)
8. [List Operations - Find Last](./listoperationsfindlast.md)
9. [Prime Number](./primenumbersbenchmark.md)


# What does the result columns means
1. Mean        : Arithmetic mean of all measurements
2. Error       : Half of 99.9% confidence interval
3. StdDev      : Standard deviation of all measurements
4. Min         : Minimum
5. Max         : Maximum
6. Median      : Value separating the higher half of all measurements (50th percentile)
7. Rank        : Relative position of current benchmark mean among all benchmarks (Arabic style)
8. Gen0        : GC Generation 0 collects per 1000 operations
9. Allocated   : Allocated memory per single operation (managed only, inclusive, 1KB = 1024B)


# Timing reference
Just as a refresher:
Here is a reference chart for common time units in the context of computer science and engineering:

| Unit        | Abbreviation | Conversion Factor       |
|-------------|--------------|-------------------------|
| Millisecond | ms           | 1 ms = 0.001 s          |
| Microsecond | µs           | 1 µs = 0.000001 s       |
| Nanosecond  | ns           | 1 ns = 0.000000001 s    |
| Picosecond  | ps           | 1 ps = 0.000000000001 s |

- 1 Second (s) is the basic unit of time in the International System of Units (SI).
- 1 Millisecond (ms) is equal to 1/1000th of a second.
- 1 Microsecond (µs) is equal to 1/1000000th of a second.
- 1 Nanosecond (ns) is equal to 1/1000000000th of a second.
- 1 Picosecond (ps) is equal to 1/1000000000000th of a second.

It is important to notice that these units are used in different context. Milliseconds and seconds are common in context of human perception and everyday life. Microseconds, nanoseconds and picoseconds are commonly used in context of computer systems and physics.


# Notes
Charts created using: https://chartbenchmark.net/