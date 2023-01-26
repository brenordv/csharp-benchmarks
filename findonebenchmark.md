[< Back to readme.md](./readme.md)


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

| Method                             | QtyElements |            Mean |          Error |         StdDev |          Median |             Min |             Max | Rank |   Gen0 | Allocated |
|------------------------------------|-------------|----------------:|---------------:|---------------:|----------------:|----------------:|----------------:|-----:|-------:|----------:|
| Dictionary_TryGet                  | 2           |        39.22 ns |       0.812 ns |       1.603 ns |        39.08 ns |        36.23 ns |        43.27 ns |    1 |      - |         - |
| Dictionary_GetValueRefOrAddDefault | 2           |        52.61 ns |       1.072 ns |       2.065 ns |        52.41 ns |        49.28 ns |        58.37 ns |    2 |      - |         - |
| Dictionary_ContainsThenGet         | 2           |        67.94 ns |       1.391 ns |       2.040 ns |        67.56 ns |        63.65 ns |        72.09 ns |    3 |      - |         - |
| List_FirstOrDefault                | 2           |       189.42 ns |       3.823 ns |       7.180 ns |       190.61 ns |       175.63 ns |       203.05 ns |    4 | 0.0420 |     264 B |
| Dictionary_TryGet                  | 10          |       196.13 ns |       3.882 ns |       7.291 ns |       194.77 ns |       185.68 ns |       212.40 ns |    5 |      - |         - |
| HashSet_FirstOrDefault             | 2           |       204.14 ns |       4.048 ns |       6.874 ns |       203.07 ns |       195.11 ns |       219.64 ns |    6 | 0.0420 |     264 B |
| Dictionary_GetValueRefOrAddDefault | 10          |       267.16 ns |       5.378 ns |      12.886 ns |       262.26 ns |       248.65 ns |       295.39 ns |    7 |      - |         - |
| Dictionary_FirstOrDefault          | 2           |       297.03 ns |       5.906 ns |      12.839 ns |       297.33 ns |       276.13 ns |       325.51 ns |    8 | 0.0572 |     360 B |
| Dictionary_ContainsThenGet         | 10          |       330.61 ns |       6.630 ns |      13.838 ns |       333.69 ns |       302.81 ns |       359.05 ns |    9 |      - |         - |
| Dictionary_TryGet                  | 100         |     2,438.05 ns |      48.505 ns |      97.982 ns |     2,403.25 ns |     2,282.09 ns |     2,662.03 ns |   10 |      - |         - |
| HashSet_FirstOrDefault             | 10          |     2,571.12 ns |      50.841 ns |      86.332 ns |     2,585.45 ns |     2,407.95 ns |     2,758.76 ns |   11 | 0.1411 |     904 B |
| List_FirstOrDefault                | 10          |     2,661.42 ns |      53.225 ns |     129.556 ns |     2,641.75 ns |     2,474.10 ns |     2,978.82 ns |   12 | 0.1411 |     904 B |
| Dictionary_GetValueRefOrAddDefault | 100         |     2,965.06 ns |      53.775 ns |      88.353 ns |     2,945.49 ns |     2,842.30 ns |     3,148.67 ns |   13 |      - |         - |
| Dictionary_ContainsThenGet         | 100         |     3,695.06 ns |      49.818 ns |      41.600 ns |     3,701.89 ns |     3,613.70 ns |     3,768.52 ns |   14 |      - |         - |
| Dictionary_FirstOrDefault          | 10          |     4,120.01 ns |      75.438 ns |     157.467 ns |     4,061.50 ns |     3,888.77 ns |     4,625.84 ns |   15 | 0.2136 |    1384 B |
| Dictionary_TryGet                  | 500         |    13,606.36 ns |     268.230 ns |     503.800 ns |    13,609.74 ns |    12,805.79 ns |    14,440.04 ns |   16 |      - |         - |
| Dictionary_GetValueRefOrAddDefault | 500         |    16,452.52 ns |     325.917 ns |     570.818 ns |    16,529.13 ns |    15,447.68 ns |    17,759.54 ns |   17 |      - |         - |
| Dictionary_ContainsThenGet         | 500         |    21,033.12 ns |     375.690 ns |     351.420 ns |    21,122.58 ns |    20,181.49 ns |    21,413.56 ns |   18 |      - |         - |
| HashSet_FirstOrDefault             | 100         |   190,971.83 ns |   3,815.672 ns |   8,612.608 ns |   191,581.81 ns |   174,966.38 ns |   211,830.83 ns |   19 | 1.2207 |    8104 B |
| List_FirstOrDefault                | 100         |   198,725.14 ns |   3,705.092 ns |   3,638.895 ns |   199,570.64 ns |   192,381.91 ns |   205,008.94 ns |   20 | 1.2207 |    8104 B |
| Dictionary_FirstOrDefault          | 100         |   326,888.59 ns |   6,416.722 ns |  12,052.159 ns |   321,802.00 ns |   308,638.77 ns |   357,116.06 ns |   21 | 1.9531 |   12904 B |
| HashSet_FirstOrDefault             | 500         | 4,644,058.66 ns |  91,346.957 ns | 155,114.065 ns | 4,568,172.66 ns | 4,352,534.38 ns | 4,923,088.28 ns |   22 |      - |   40112 B |
| List_FirstOrDefault                | 500         | 4,999,293.68 ns |  99,367.221 ns | 218,113.459 ns | 5,050,513.67 ns | 4,546,469.53 ns | 5,466,908.59 ns |   23 |      - |   40112 B |
| Dictionary_FirstOrDefault          | 500         | 7,943,646.99 ns | 157,444.379 ns | 417,520.158 ns | 7,799,445.31 ns | 7,348,021.09 ns | 9,002,802.34 ns |   24 |      - |   64119 B |


### Analysis
What did we learn from that?

1. Calling Dictionary.FirstOrDefault is a bad idea. It's 30 times slower than calling Dictionary.TryGetValue.
2. Calling Dictionary.TryGetValue is 5 times slower than calling Dictionary.ContainsKey + Dictionary[key].
3. If you have a dataset and need to find objects based on one property (like Id), use a Dictionary. It's the fastest way to do it. 


