using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace Raccoon.Ninja.Application.Benchmarks.Benchmarks;

[MemoryDiagnoser, RankColumn, MinColumn, MaxColumn, MeanColumn, MedianColumn, UnicodeConsoleLogger,
 Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class ListHasItemsBenchmark
{
    private static readonly List<string> _emptyList = new();
    private static readonly string[] _emptyArray = new string[250];

    private List<string> _stringList250;
    private string[] _stringArray250;

    private List<string> _stringList1000;
    private string[] _stringArray1000;

    [GlobalSetup]
    public void Init()
    {
        _stringList250 = new List<string>();
        _stringList1000 = new List<string>();
        _stringArray250 = new string[250];
        _stringArray1000 = new string[1000];
        
        for (var i = 0; i < 250; i++)
        {
            _stringList250.Add("Some string");
            _stringArray250[i] = "Some string";
        }
        
        for (var i = 0; i < 1000; i++)
        {
            _stringList1000.Add("Some string");
            _stringArray1000[i] = "Some string";
        }
    }
    
    [Benchmark]
    public void List_Has_Items_250__Any()
    {
        var hasItems = _stringList250.Any();
    }
    
    [Benchmark]
    public void List_Has_Items_250__Count()
    {
        var hasItems = _stringList250.Count > 0;
    }

    [Benchmark]
    public void List_Has_Items_250__Extension_Count()
    {
        var hasItems = _stringList250.HasItems();
    }
    
    [Benchmark]
    public void List_Has_Items_1000__Any()
    {
        var hasItems = _stringList1000.Any();
    }
    
    [Benchmark]
    public void List_Has_Items_1000__Count()
    {
        var hasItems = _stringList1000.Count > 0;
    }
    
    [Benchmark]
    public void List_Has_Items_1000__Extension_Count()
    {
        var hasItems = _stringList1000.HasItems();
    }
    
    [Benchmark]
    public void Array_Has_Items_250__Any()
    {
        var hasItems = _stringArray250.Any();
    }
    
    [Benchmark]
    public void Array_Has_Items_250__Length()
    {
        var hasItems = _stringArray250.Length > 0;
    }
    
    [Benchmark]
    public void Array_Has_Items_250__Extension_Count()
    {
        var hasItems = _stringArray250.HasItems();
    }
    
    [Benchmark]
    public void Array_Has_Items_1000__Any()
    {
        var hasItems = _stringArray1000.Any();
    }
    
    [Benchmark]
    public void Array_Has_Items_1000__Length()
    {
        var hasItems = _stringArray1000.Length > 0;
    }
    
    [Benchmark]
    public void Array_Has_Items_1000__Extension_Count()
    {
        var hasItems = _stringArray1000.HasItems();
    }
    
    [Benchmark]
    public void Empty_List_Has_Items__Any()
    {
        var hasItems = _emptyList.Any();
    }
    
    [Benchmark]
    public void Empty_List_Has_Items__Count()
    {
        var hasItems = _emptyList.Count > 0;
    }
    
    [Benchmark]
    public void Empty_List_Has_Items__Extension_Count()
    {
        var hasItems = _emptyList.HasItems();
    }
    
    [Benchmark]
    public void Empty_Array_Has_Items__Any()
    {
        var hasItems = _emptyArray.Any();
    }
    
    [Benchmark]
    public void Empty_Array_Has_Items__Length()
    {
        var hasItems = _emptyArray.Length > 0;
    }
    
    [Benchmark]
    public void Empty_Array_Has_Items__Extension_Count()
    {
        var hasItems = _emptyArray.HasItems();
    }
}

public static class ListHasItemsBenchmarkExtensions
{
    public static bool HasItems<T>(this IList<T> list)
    {
        return list.Count > 0;
    }
}