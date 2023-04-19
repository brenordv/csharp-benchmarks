using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace Raccoon.Ninja.Application.Benchmarks.Benchmarks;

[ExcludeFromCodeCoverage]
[MemoryDiagnoser, RankColumn, MinColumn, MaxColumn, MeanColumn, MedianColumn, UnicodeConsoleLogger,
 Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class StringContainsLetterBenchmark
{
    private const string Text15Chars = "TheQuickBrownF8";
    private const string Text36Chars = "TheQuickBrownFoxJumpsOverTheLazyDog8";

    private const string Text106Chars =
        "TheQuickBrownFoxJumpsOverTheLazyDogTheQuickBrownFoxJumpsOverTheLazyDogTheQuickBrownFoxJumpsOverTheLazyDog8";

    private static readonly Regex _regex = new("[a-zA-Z]");

    [Benchmark]
    public void Char_IsLetter__15chars()
    {
        var containsLetter = Text15Chars.Any(char.IsLetter);
    }

    [Benchmark]
    public void Char_IsLetter__36chars()
    {
        var containsLetter = Text36Chars.Any(char.IsLetter);
    }

    [Benchmark]
    public void Char_IsLetter__106chars()
    {
        var containsLetter = Text106Chars.Any(char.IsLetter);
    }

    [Benchmark]
    public void Regex__15chars()
    {
        var containsLetter = _regex.IsMatch(Text15Chars);
    }

    [Benchmark]
    public void Regex__36chars()
    {
        var containsLetter = _regex.IsMatch(Text36Chars);
    }

    [Benchmark]
    public void Regex__106chars()
    {
        var containsLetter = _regex.IsMatch(Text106Chars);
    }

    [Benchmark]
    public void ForLoop__15chars()
    {
        var containsLetter = false;
        foreach (var c in Text15Chars)
        {
            if (c is (< 'a' or > 'z') and (< 'A' or > 'Z')) continue;
            containsLetter = true;
            break;
        }
    }

    [Benchmark]
    public void ForLoop__36chars()
    {
        var containsLetter = false;
        foreach (var c in Text36Chars)
        {
            if (c is (< 'a' or > 'z') and (< 'A' or > 'Z')) continue;
            containsLetter = true;
            break;
        }
    }

    [Benchmark]
    public void ForLoop__106chars()
    {
        var containsLetter = false;
        foreach (var c in Text106Chars)
        {
            if (c is (< 'a' or > 'z') and (< 'A' or > 'Z')) continue;
            containsLetter = true;
            break;
        }
    }

    [Benchmark]
    public void CheckEveryLetter_15chars()
    {
        var containsLetter = Text15Chars.Contains('a') || Text15Chars.Contains('b') || Text15Chars.Contains('c') ||
                             Text15Chars.Contains('d') || Text15Chars.Contains('e') || Text15Chars.Contains('f') ||
                             Text15Chars.Contains('g') || Text15Chars.Contains('h') || Text15Chars.Contains('i') ||
                             Text15Chars.Contains('j') || Text15Chars.Contains('k') || Text15Chars.Contains('l') ||
                             Text15Chars.Contains('m') || Text15Chars.Contains('n') || Text15Chars.Contains('o') ||
                             Text15Chars.Contains('p') || Text15Chars.Contains('q') || Text15Chars.Contains('r') ||
                             Text15Chars.Contains('s') || Text15Chars.Contains('t') || Text15Chars.Contains('u') ||
                             Text15Chars.Contains('v') || Text15Chars.Contains('w') || Text15Chars.Contains('x') ||
                             Text15Chars.Contains('y') || Text15Chars.Contains('z') || Text15Chars.Contains('A') ||
                             Text15Chars.Contains('B') || Text15Chars.Contains('C') || Text15Chars.Contains('D') ||
                             Text15Chars.Contains('E') || Text15Chars.Contains('F') || Text15Chars.Contains('G') ||
                             Text15Chars.Contains('H') || Text15Chars.Contains('I') || Text15Chars.Contains('J') ||
                             Text15Chars.Contains('K') || Text15Chars.Contains('L') || Text15Chars.Contains('M') ||
                             Text15Chars.Contains('N') || Text15Chars.Contains('O') || Text15Chars.Contains('P') ||
                             Text15Chars.Contains('Q') || Text15Chars.Contains('R') || Text15Chars.Contains('S') ||
                             Text15Chars.Contains('T') || Text15Chars.Contains('U') || Text15Chars.Contains('V') ||
                             Text15Chars.Contains('W') || Text15Chars.Contains('X') || Text15Chars.Contains('Y') ||
                             Text15Chars.Contains('Z');
    }
    
        [Benchmark]
    public void CheckEveryLetter_36chars()
    {
        var containsLetter = Text36Chars.Contains('a') || Text36Chars.Contains('b') || Text36Chars.Contains('c') ||
                             Text36Chars.Contains('d') || Text36Chars.Contains('e') || Text36Chars.Contains('f') ||
                             Text36Chars.Contains('g') || Text36Chars.Contains('h') || Text36Chars.Contains('i') ||
                             Text36Chars.Contains('j') || Text36Chars.Contains('k') || Text36Chars.Contains('l') ||
                             Text36Chars.Contains('m') || Text36Chars.Contains('n') || Text36Chars.Contains('o') ||
                             Text36Chars.Contains('p') || Text36Chars.Contains('q') || Text36Chars.Contains('r') ||
                             Text36Chars.Contains('s') || Text36Chars.Contains('t') || Text36Chars.Contains('u') ||
                             Text36Chars.Contains('v') || Text36Chars.Contains('w') || Text36Chars.Contains('x') ||
                             Text36Chars.Contains('y') || Text36Chars.Contains('z') || Text36Chars.Contains('A') ||
                             Text36Chars.Contains('B') || Text36Chars.Contains('C') || Text36Chars.Contains('D') ||
                             Text36Chars.Contains('E') || Text36Chars.Contains('F') || Text36Chars.Contains('G') ||
                             Text36Chars.Contains('H') || Text36Chars.Contains('I') || Text36Chars.Contains('J') ||
                             Text36Chars.Contains('K') || Text36Chars.Contains('L') || Text36Chars.Contains('M') ||
                             Text36Chars.Contains('N') || Text36Chars.Contains('O') || Text36Chars.Contains('P') ||
                             Text36Chars.Contains('Q') || Text36Chars.Contains('R') || Text36Chars.Contains('S') ||
                             Text36Chars.Contains('T') || Text36Chars.Contains('U') || Text36Chars.Contains('V') ||
                             Text36Chars.Contains('W') || Text36Chars.Contains('X') || Text36Chars.Contains('Y') ||
                             Text36Chars.Contains('Z');
    }
    
            [Benchmark]
    public void CheckEveryLetter_106chars()
    {
        var containsLetter = Text106Chars.Contains('a') || Text106Chars.Contains('b') || Text106Chars.Contains('c') ||
                             Text106Chars.Contains('d') || Text106Chars.Contains('e') || Text106Chars.Contains('f') ||
                             Text106Chars.Contains('g') || Text106Chars.Contains('h') || Text106Chars.Contains('i') ||
                             Text106Chars.Contains('j') || Text106Chars.Contains('k') || Text106Chars.Contains('l') ||
                             Text106Chars.Contains('m') || Text106Chars.Contains('n') || Text106Chars.Contains('o') ||
                             Text106Chars.Contains('p') || Text106Chars.Contains('q') || Text106Chars.Contains('r') ||
                             Text106Chars.Contains('s') || Text106Chars.Contains('t') || Text106Chars.Contains('u') ||
                             Text106Chars.Contains('v') || Text106Chars.Contains('w') || Text106Chars.Contains('x') ||
                             Text106Chars.Contains('y') || Text106Chars.Contains('z') || Text106Chars.Contains('A') ||
                             Text106Chars.Contains('B') || Text106Chars.Contains('C') || Text106Chars.Contains('D') ||
                             Text106Chars.Contains('E') || Text106Chars.Contains('F') || Text106Chars.Contains('G') ||
                             Text106Chars.Contains('H') || Text106Chars.Contains('I') || Text106Chars.Contains('J') ||
                             Text106Chars.Contains('K') || Text106Chars.Contains('L') || Text106Chars.Contains('M') ||
                             Text106Chars.Contains('N') || Text106Chars.Contains('O') || Text106Chars.Contains('P') ||
                             Text106Chars.Contains('Q') || Text106Chars.Contains('R') || Text106Chars.Contains('S') ||
                             Text106Chars.Contains('T') || Text106Chars.Contains('U') || Text106Chars.Contains('V') ||
                             Text106Chars.Contains('W') || Text106Chars.Contains('X') || Text106Chars.Contains('Y') ||
                             Text106Chars.Contains('Z');
    }
}