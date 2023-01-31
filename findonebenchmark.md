[Readme](./readme.md)


# Find one record in a Dictionary vs. List vs. HashSet
If we have a dataset and need to find one record at a time by Id, which is faster? A List, a Dictionary, or a HashSet?

The benchmark has a few test scenarios:
1. Using the method FirstOrDefault() on a List;
2. Using the method FirstOrDefault() on a HashSet;
3. Using the method FirstOrDefault() on a Dictionary;
4. Using the method ContainsKey and then fetching the value from the Dictionary;
5. Using the method TryGetValue() on a Dictionary;
6. Using the CollectionsMarshal's method GetValueRefOrAddDefault() on a Dictionary.

The workloads are: 2, 10, 100, 500.

## What to expect
In C#, the performance of finding a record depends on the type of collection you are using.

A List<T> is an ordered collection, which means that the elements are stored in a specific order and can be accessed by index.
Finding an element in a List requires iterating through all the elements until the target element is found.
This can be slow if the list is large and the target element is near the end. The average-case time complexity for finding an element in a
List is O(n) where n is the number of elements in the list.

A Dictionary<TKey, TValue> is a collection that stores key-value pairs, where each key is unique. It uses a hash table to store the elements,
and the key is used to calculate the index, which allows for fast O(1) average-case lookup time. This makes finding an element in a Dictionary
much faster than in a List, especially when dealing with large collections.

A HashSet<T> is a collection that stores unique elements and it is based on a HashTable data structure, which means that it uses a hash
function to calculate an index for each element. The average-case time complexity for finding an element in a HashSet is also O(1).

The CollectionsMarshal approach is a great option when you need to find an element in a Dictionary and modify it without having to search for that element 
twice (one checking if it exists and another to set the modified object.) It's super fast for those cases, but doesn't do much if you just want to find an item. 
If you want to use this, remember that the dictionary must not be modified during the iteration.

In summary, finding an element in a Dictionary or HashSet is faster than in a List, because they use a hash table to store the elements and the
key is used to calculate the index, which allows for fast O(1) average-case lookup time. While Dictionary stores key-value pair, HashSet stores
only unique element, both of them use HashTable data structure which makes them faster than List.

Now let's see how they perform in practice.


## Results
(For this benchmark I have not divided the result table)

| Method                                              | QtyElements |             Mean |          Error |           StdDev |              Min |              Max |           Median | Rank |   Gen0 | Allocated |
|-----------------------------------------------------|-------------|-----------------:|---------------:|-----------------:|-----------------:|-----------------:|-----------------:|-----:|-------:|----------:|
| Dictionary__CollectionsMarshal_GetValueRefOrNullRef | 2           |         41.10 ns |       1.003 ns |         2.956 ns |         35.86 ns |         48.73 ns |         41.47 ns |    1 |      - |         - |
| Dictionary__TryGet                                  | 2           |         43.58 ns |       0.895 ns |         2.343 ns |         38.68 ns |         48.51 ns |         43.43 ns |    2 |      - |         - |
| Dictionary__ContainsThenGet                         | 2           |         81.98 ns |       3.560 ns |        10.496 ns |         64.96 ns |        108.65 ns |         79.27 ns |    3 |      - |         - |
| HashSet__FirstOrDefault                             | 2           |        199.80 ns |       4.399 ns |        12.691 ns |        172.07 ns |        226.76 ns |        198.26 ns |    4 | 0.0420 |     264 B |
| List__FirstOrDefault                                | 2           |        202.96 ns |       4.427 ns |        13.055 ns |        177.00 ns |        231.23 ns |        204.63 ns |    4 | 0.0420 |     264 B |
| Dictionary__FirstOrDefault                          | 2           |        309.36 ns |       6.165 ns |        17.985 ns |        269.03 ns |        348.21 ns |        310.98 ns |    5 | 0.0572 |     360 B |
| Dictionary__CollectionsMarshal_GetValueRefOrNullRef | 100         |      2,406.87 ns |      47.579 ns |       113.076 ns |      2,190.51 ns |      2,666.40 ns |      2,377.57 ns |    6 |      - |         - |
| Dictionary__TryGet                                  | 100         |      2,494.71 ns |      49.788 ns |       132.030 ns |      2,215.68 ns |      2,733.05 ns |      2,509.53 ns |    7 |      - |         - |
| Dictionary__ContainsThenGet                         | 100         |      3,963.01 ns |      89.919 ns |       259.436 ns |      3,519.08 ns |      4,652.10 ns |      3,932.00 ns |    8 |      - |         - |
| Dictionary__CollectionsMarshal_GetValueRefOrNullRef | 1000        |     32,599.94 ns |     831.568 ns |     2,451.898 ns |     27,363.43 ns |     37,684.91 ns |     32,264.76 ns |    9 |      - |         - |
| Dictionary__TryGet                                  | 1000        |     34,804.76 ns |   1,305.040 ns |     3,827.457 ns |     27,587.27 ns |     45,394.50 ns |     34,392.67 ns |   10 |      - |         - |
| Dictionary__ContainsThenGet                         | 1000        |     46,214.23 ns |   1,046.737 ns |     3,069.898 ns |     38,766.02 ns |     52,997.17 ns |     46,285.89 ns |   11 |      - |         - |
| List__FirstOrDefault                                | 100         |    219,969.16 ns |   4,377.738 ns |    12,839.146 ns |    190,649.17 ns |    249,507.15 ns |    220,343.48 ns |   12 | 1.2207 |    8104 B |
| HashSet__FirstOrDefault                             | 100         |    220,436.44 ns |   6,945.222 ns |    20,149.348 ns |    183,246.75 ns |    265,970.09 ns |    219,111.69 ns |   12 | 0.9766 |    8104 B |
| Dictionary__FirstOrDefault                          | 100         |    343,186.13 ns |   6,847.097 ns |    16,536.510 ns |    309,748.63 ns |    382,418.21 ns |    342,601.51 ns |   13 | 1.9531 |   12904 B |
| HashSet__FirstOrDefault                             | 1000        | 21,114,784.97 ns | 578,472.890 ns | 1,696,560.849 ns | 18,026,646.88 ns | 24,862,593.75 ns | 21,431,121.88 ns |   14 |      - |   80134 B |
| List__FirstOrDefault                                | 1000        | 21,368,201.58 ns | 537,567.801 ns | 1,576,593.304 ns | 17,665,471.88 ns | 24,550,143.75 ns | 21,426,546.88 ns |   14 |      - |   80134 B |
| Dictionary__FirstOrDefault                          | 1000        | 37,349,783.80 ns | 838,812.617 ns | 2,433,547.499 ns | 30,810,128.57 ns | 42,532,164.29 ns | 37,278,807.14 ns |   15 |      - |  128198 B |


### Analysis
What did we learn from that?

1. Calling Dictionary.FirstOrDefault is a bad idea. It's 30 times slower than calling Dictionary.TryGetValue.
2. Calling Dictionary.TryGetValue is somewhat faster than calling Dictionary.ContainsKey + Dictionary[key].
3. CollectionsMarshal.GetValueRefOrNullRef is the fastest, but not by much. 
4. If you have a dataset and need to find objects based on one property (like Id), use a Dictionary. It's the fastest way to do it. 


