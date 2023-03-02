using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using Raccoon.Ninja.Application.Benchmarks.TestClasses.Entities;
using Raccoon.Ninja.Application.Benchmarks.TestClasses.Entities.Records;
using Raccoon.Ninja.Application.Benchmarks.TestClasses.Generators;

namespace Raccoon.Ninja.Application.Benchmarks.Benchmarks;

[ExcludeFromCodeCoverage]
[MemoryDiagnoser, RankColumn, MinColumn, MaxColumn, MeanColumn, MedianColumn, UnicodeConsoleLogger,
 Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class FindOneAndModifyBenchmarks
{
    private List<Product> _list;
    private Dictionary<Guid, Product> _dictionary;
    private HashSet<Product> _hashSet;
    private List<Guid> _ids;

    [Params(2, 100, 1000)] public int QtyElements { get; set; }

    [GlobalSetup]
    public void Init()
    {
        _ids = new List<Guid>();
        _list = new List<Product>();
        _dictionary = new Dictionary<Guid, Product>();
        _hashSet = new HashSet<Product>();

        foreach (var mockClass in EntityGenerator.Products(QtyElements))
        {
            _list.Add(mockClass);
            _dictionary.Add(mockClass.Id, mockClass);
            _hashSet.Add(mockClass);

            _ids.Add(mockClass.Id);

            //Add some noise to the list of Ids, so not all searches will be successful.
            _ids.Add(Guid.NewGuid());
        }
    }

    [Benchmark]
    public void List__FindIndex()
    {
        for (var i = 0; i < _ids.Count; i++)
        {
            var itemIndex = _list.FindIndex(x => x.Id == _ids[i]);
            
            if (itemIndex == -1) continue;
            
            _list[itemIndex].Name = "Test Updated";
        }
    }
    
    [Benchmark]
    public void Dictionary__CollectionsMarshal_GetValueRefOrNullRef()
    {
        for (var i = 0; i < _ids.Count; i++)
        {
            //If using this, make sure the dictionary is not being modified while iterating.
            ref var x = ref CollectionsMarshal.GetValueRefOrNullRef(_dictionary, _ids[i]);
            if (Unsafe.IsNullRef(ref x)) continue;
            x.Name = "Test Updated";
        }
    }
    
    [Benchmark]
    public void Dictionary__TryGet()
    {
        for (var i = 0; i < _ids.Count; i++)
        {
            var exist = _dictionary.TryGetValue(_ids[i], out var _);
            if (!exist) continue;
            
            _dictionary[_ids[i]].Name = "Test Updated";
        }
    }

    [Benchmark]
    public void Dictionary__ContainsThenGet()
    {
        for (var i = 0; i < _ids.Count; i++)
        {
            if (!_dictionary.ContainsKey(_ids[i]))
                continue;
            _dictionary[_ids[i]].Name = "Test Updated";
        }
    }

    [Benchmark]
    public void HashSet__FirstOrDefault()
    {
        for (var i = 0; i < _ids.Count; i++)
        {
            var x = _hashSet.FirstOrDefault(x => x.Id == _ids[i]);
            if (x == null) continue;
            _hashSet.Remove(x);
            x.Name = "Test Updated";
            _hashSet.Add(x);
        }
    }
}