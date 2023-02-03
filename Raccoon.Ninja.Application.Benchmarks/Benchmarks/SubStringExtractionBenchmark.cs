using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace Raccoon.Ninja.Application.Benchmarks.Benchmarks;

[ExcludeFromCodeCoverage]
[MemoryDiagnoser, RankColumn, MinColumn, MaxColumn, MeanColumn, MedianColumn, UnicodeConsoleLogger,
 Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class SubStringExtractionBenchmark
{
    private const string Text = "42--bacon-7";
    private const int FirstNumberStartIndex = 0;
    private const int FirstNumberEndIndex = 2;
    private const int SecondNumberStartIndex = 10;
    private const int SecondNumberLength = 1;
    private const string Divider = "-";
    private const string RegexPattern = @"\d+";
    
    [Benchmark]
    public void Substring()
    {
        var firstNumber = Text.Substring(FirstNumberStartIndex, FirstNumberEndIndex);
        var secondNumber = Text.Substring(SecondNumberStartIndex, SecondNumberLength);
        var fNumber = int.Parse(firstNumber);
        var sNumber = int.Parse(secondNumber);
    }

    [Benchmark]
    public void ReadOnlySpan()
    {
        ReadOnlySpan<char> span = Text;
        var firstNumber = span.Slice(FirstNumberStartIndex, FirstNumberEndIndex);
        var secondNumber = span.Slice(SecondNumberStartIndex, SecondNumberLength);
        var fNumber = int.Parse(firstNumber);
        var sNumber = int.Parse(secondNumber);
    }
    
    [Benchmark]
    public void SplitString()
    {
        var textParts = Text.Split(Divider);
        
        var firstNumber = textParts[0];
        var secondNumber = textParts[^1];
        var fNumber = int.Parse(firstNumber);
        var sNumber = int.Parse(secondNumber);
    }
    
    [Benchmark]
    public void RegexCapture()
    {
        var  matches = Regex.Matches(Text, RegexPattern);
        
        var firstNumber = matches[0].Value;
        var secondNumber = matches[^1].Value;
        var fNumber = int.Parse(firstNumber);
        var sNumber = int.Parse(secondNumber);
    }

    [Benchmark]
    public void BestAccordingToChatGPT()
    {
        var numbers = new List<int>();
        var number = 0;
        var isNegative = false;

        foreach (char c in Text)
        {
            if (char.IsDigit(c))
            {
                number = number * 10 + (c - '0');
            }
            else if (number != 0)
            {
                numbers.Add(isNegative ? -number : number);
                number = 0;
                isNegative = false;
            }
            else if (c == '-')
            {
                isNegative = true;
            }
        }

        if (number != 0)
        {
            //This was the original line of code, I changed it to the one below.
            //numbers.Add(isNegative ? -number : number);
            numbers.Add(number);
        }
        
        var fNumber = numbers[0];
        var sNumber = numbers[^1];
    }
}