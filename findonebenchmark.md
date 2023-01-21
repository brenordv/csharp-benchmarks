[< Back to readme.md](./readme.md)


# Find one record in a Dictionary vs. List vs. HashSet
If we have a dataset and need to find one record at a time by Id, which is faster? A List, a Dictionary, or a HashSet?

The benchmark has a few test scenarios:
1. Using the method FirstOrDefault() on a List;
2. Using the method FirstOrDefault() on a HashSet;
3. Using the method FirstOrDefault() on a Dictionary;
4. Using the method ContainsKey and then fetching the value from the Dictionary;
5. Using the method TryGetValue() on a Dictionary;

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

In summary, finding an element in a Dictionary or HashSet is faster than in a List, because they use a hash table to store the elements and the
key is used to calculate the index, which allows for fast O(1) average-case lookup time. While Dictionary stores key-value pair, HashSet stores
only unique element, both of them use HashTable data structure which makes them faster than List.

Now let's see how they perform in practice.


## Results
(For this benchmark I have not divided the result table)
| Method                     | QtyElements |             Mean |          Error |         StdDev |             Min |              Max |           Median | Rank |   Gen0 | Allocated |
|----------------------------|-------------|-----------------:|---------------:|---------------:|----------------:|-----------------:|-----------------:|-----:|-------:|----------:|
| Dictionary_TryGet          | 2           |         69.07 ns |       1.361 ns |       3.235 ns |        59.36 ns |         73.65 ns |         69.62 ns |    1 |      - |         - |
| Dictionary_ContainsThenGet | 2           |        107.87 ns |       3.137 ns |       9.102 ns |        87.04 ns |        133.28 ns |        107.21 ns |    2 |      - |         - |
| List_FirstOrDefault        | 2           |        229.73 ns |       4.608 ns |      12.998 ns |       195.04 ns |        253.66 ns |        229.88 ns |    3 | 0.0420 |     264 B |
| HashSet_FirstOrDefault     | 2           |        272.67 ns |       7.371 ns |      21.385 ns |       214.80 ns |        329.15 ns |        272.38 ns |    4 | 0.0420 |     264 B |
| Dictionary_FirstOrDefault  | 2           |        351.67 ns |       7.034 ns |      18.652 ns |       303.06 ns |        394.75 ns |        351.92 ns |    5 | 0.0572 |     360 B |
| Dictionary_TryGet          | 10          |        411.29 ns |       9.398 ns |      27.414 ns |       335.05 ns |        474.13 ns |        408.96 ns |    6 |      - |         - |
| Dictionary_ContainsThenGet | 10          |        561.41 ns |      14.298 ns |      41.254 ns |       459.93 ns |        654.60 ns |        564.24 ns |    7 |      - |         - |
| List_FirstOrDefault        | 10          |      3,386.11 ns |      87.117 ns |     256.867 ns |     2,790.65 ns |      3,935.31 ns |      3,403.35 ns |    8 | 0.1411 |     904 B |
| HashSet_FirstOrDefault     | 10          |      3,424.75 ns |      67.417 ns |     143.671 ns |     3,048.54 ns |      3,776.97 ns |      3,413.38 ns |    8 | 0.1411 |     904 B |
| Dictionary_TryGet          | 100         |      5,051.88 ns |     165.625 ns |     483.137 ns |     3,876.73 ns |      6,169.05 ns |      5,037.90 ns |    9 |      - |         - |
| Dictionary_FirstOrDefault  | 10          |      5,454.85 ns |     137.447 ns |     387.673 ns |     4,375.26 ns |      6,451.03 ns |      5,429.87 ns |   10 | 0.2136 |    1384 B |
| Dictionary_ContainsThenGet | 100         |      6,530.88 ns |     152.187 ns |     441.521 ns |     5,257.93 ns |      7,456.09 ns |      6,526.27 ns |   11 |      - |         - |
| Dictionary_TryGet          | 500         |     28,091.56 ns |     708.103 ns |   2,076.744 ns |    22,418.94 ns |     32,799.63 ns |     27,793.49 ns |   12 |      - |         - |
| Dictionary_ContainsThenGet | 500         |     35,684.67 ns |   1,004.662 ns |   2,946.500 ns |    28,015.11 ns |     42,610.21 ns |     35,637.52 ns |   13 |      - |         - |
| List_FirstOrDefault        | 100         |    266,899.65 ns |   6,309.472 ns |  18,304.922 ns |   215,329.37 ns |    310,728.98 ns |    269,101.78 ns |   14 | 0.9766 |    8104 B |
| HashSet_FirstOrDefault     | 100         |    284,769.15 ns |   8,823.562 ns |  25,316.453 ns |   225,520.53 ns |    343,525.32 ns |    284,587.87 ns |   15 | 0.9766 |    8104 B |
| Dictionary_FirstOrDefault  | 100         |    429,681.85 ns |  11,207.326 ns |  32,514.484 ns |   349,844.65 ns |    510,972.44 ns |    429,311.84 ns |   16 | 1.9531 |   12904 B |
| List_FirstOrDefault        | 500         |  7,017,832.04 ns | 207,082.310 ns | 587,458.047 ns | 5,619,112.50 ns |  8,632,520.31 ns |  7,031,775.00 ns |   17 |      - |   40119 B |
| HashSet_FirstOrDefault     | 500         |  7,388,715.79 ns | 181,152.038 ns | 531,287.570 ns | 6,094,797.27 ns |  8,622,659.77 ns |  7,386,728.52 ns |   18 |      - |   40112 B |
| Dictionary_FirstOrDefault  | 500         | 10,867,006.90 ns | 308,956.406 ns | 886,453.845 ns | 8,509,385.16 ns | 12,996,911.72 ns | 10,945,785.16 ns |   19 |      - |   64119 B |

### Analysis
What did we learn from that?

1. Calling Dictionary.FirstOrDefault is a bad idea. It's 30 times slower than calling Dictionary.TryGetValue.
2. Calling Dictionary.TryGetValue is 5 times slower than calling Dictionary.ContainsKey + Dictionary[key].
3. If you have a dataset and need to find objects based on one property (like Id), use a Dictionary. It's the fastest way to do it. 


