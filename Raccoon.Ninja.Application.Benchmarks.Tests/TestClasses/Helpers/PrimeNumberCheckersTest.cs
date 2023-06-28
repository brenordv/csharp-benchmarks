using FluentAssertions;
using Raccoon.Ninja.Application.Benchmarks.TestClasses.Helpers;

namespace Raccoon.Ninja.Application.Benchmarks.Tests.TestClasses.Helpers;

public class PrimeNumberCheckersTest
{
    [Theory]
    [MemberData(nameof(GetTestData))]
    public void IsPrimeReadableTest(int n, bool expected)
    {
        var result = PrimeNumberCheckers.IsPrimeReadable(n);

        result.Should().Be(expected);
    }
    
    [Theory]
    [MemberData(nameof(GetTestData))]
    public void IsPrimePerformanceTest(int n, bool expected)
    {
        var result = PrimeNumberCheckers.IsPrimePerformance(n);

        result.Should().Be(expected);
    }
    
    [Theory]
    [MemberData(nameof(GetTestData))]
    public void IsPrimeRecursionTest(int n, bool expected)
    {
        var result = PrimeNumberCheckers.IsPrimeRecursion(n);

        result.Should().Be(expected);
    }
    
    [Theory]
    [MemberData(nameof(GetTestData))]
    public void IsPrimeRegexTest(int n, bool expected)
    {
        var result = PrimeNumberCheckers.IsPrimeRegex(n);

        result.Should().Be(expected);
    }
    
    
    public static IEnumerable<object[]> GetTestData()
    {
        yield return new object[] { 0, false };
        yield return new object[] { 1, false };
        yield return new object[] { 2, true };
        yield return new object[] { 3, true };
        yield return new object[] { 5, true };
        yield return new object[] { 6, false };
        yield return new object[] { 7, true };
        yield return new object[] { 8, false };
        yield return new object[] { 9, false };
        yield return new object[] { 10, false };
        yield return new object[] { 11, true };
        yield return new object[] { 12, false };
        yield return new object[] { 13, true };
    }
}