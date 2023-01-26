using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using Raccoon.Ninja.Application.Benchmarks.TestClasses.Entities;
using Raccoon.Ninja.Application.Benchmarks.TestClasses.Generators;

namespace Raccoon.Ninja.Application.Benchmarks.Benchmarks;

[ExcludeFromCodeCoverage]
[MemoryDiagnoser, RankColumn, MinColumn, MaxColumn, MeanColumn, MedianColumn, UnicodeConsoleLogger,
 Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class FindOneBenchmarks
{
    private List<Product> _list;
    private Dictionary<Guid, Product> _dictionary;
    private HashSet<Product> _hashSet;
    private List<Guid> _ids;

    [Params(2, 10, 100, 500)] public int QtyElements { get; set; }

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
    public void List_FirstOrDefault()
    {
        for (var i = 0; i < _ids.Count; i++)
        {
            var x = _list.FirstOrDefault(x => x.Id == _ids[i]);
        }
    }

    [Benchmark]
    public void Dictionary_FirstOrDefault()
    {
        for (var i = 0; i < _ids.Count; i++)
        {
            //The value might be null.
            var x = _dictionary.FirstOrDefault(x => x.Key == _ids[i]);
        }
    }
    
    [Benchmark]
    public void Dictionary_GetValueRefOrAddDefault()
    {
        for (var i = 0; i < _ids.Count; i++)
        {
            //If using this, make sure the dictionary is not being modified while iterating.
            ref var x = ref CollectionsMarshal.GetValueRefOrAddDefault(_dictionary, _ids[i], out var exists);
        }
    }
    
    [Benchmark]
    public void Dictionary_TryGet()
    {
        for (var i = 0; i < _ids.Count; i++)
        {
            var x = _dictionary.TryGetValue(_ids[i], out var _);
        }
    }

    [Benchmark]
    public void Dictionary_ContainsThenGet()
    {
        for (var i = 0; i < _ids.Count; i++)
        {
            if (!_dictionary.ContainsKey(_ids[i]))
                continue;
            var x = _dictionary[_ids[i]];
        }
    }


    [Benchmark]
    public void HashSet_FirstOrDefault()
    {
        for (var i = 0; i < _ids.Count; i++)
        {
            var x = _hashSet.FirstOrDefault(x => x.Id == _ids[i]);
        }
    }
}