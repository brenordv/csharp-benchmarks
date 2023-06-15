[Readme](./readme.md)


# String Contains letter benchmark
Simple benchmark to check the fastest way to check if a string contains any letter.

I used 3 scenarios:
1. Using char.IsLetter on every character of the string
2. Using Regex to check if the string contains any letter
3. Using a foreach loop to check if the string contains any letter
4. Checking if string contains every letter manually

And for every method I used 3 different strings:
1. One with 15 characters;
2. One with 36 characters;
3. One with 106 characters;

In all cases, the last character of the string as a letter.

To keep things fair, I didn't create any methods to avoid any extra overhead.


# Results
| Method                    |      Mean |    Error |   StdDev |       Min |       Max |    Median | Rank |   Gen0 | Allocated |
|---------------------------|----------:|---------:|---------:|----------:|----------:|----------:|-----:|-------:|----------:|
| ForLoop__15chars          |  14.20 ns | 0.308 ns | 0.442 ns |  13.34 ns |  14.85 ns |  14.22 ns |    1 |      - |         - |
| ForLoop__36chars          |  26.09 ns | 0.226 ns | 0.200 ns |  25.78 ns |  26.57 ns |  26.02 ns |    2 |      - |         - |
| ForLoop__106chars         |  78.65 ns | 1.578 ns | 1.399 ns |  74.65 ns |  80.33 ns |  79.04 ns |    3 |      - |         - |
| Regex__15chars            |  82.90 ns | 1.351 ns | 1.264 ns |  81.34 ns |  85.42 ns |  82.50 ns |    4 |      - |         - |
| Char_IsLetter__15chars    |  97.66 ns | 1.274 ns | 1.129 ns |  95.89 ns |  99.88 ns |  97.55 ns |    5 | 0.0153 |      96 B |
| Regex__36chars            | 126.86 ns | 1.407 ns | 1.316 ns | 124.66 ns | 128.74 ns | 126.50 ns |    6 |      - |         - |
| CheckEveryLetter_15chars  | 148.55 ns | 1.225 ns | 1.146 ns | 146.90 ns | 150.46 ns | 148.41 ns |    7 |      - |         - |
| CheckEveryLetter_36chars  | 180.93 ns | 3.409 ns | 6.486 ns | 170.67 ns | 198.11 ns | 179.58 ns |    8 |      - |         - |
| Char_IsLetter__36chars    | 215.84 ns | 1.593 ns | 1.412 ns | 214.37 ns | 218.45 ns | 215.29 ns |    9 | 0.0153 |      96 B |
| Regex__106chars           | 254.73 ns | 1.478 ns | 1.382 ns | 252.88 ns | 257.52 ns | 254.82 ns |   10 |      - |         - |
| CheckEveryLetter_106chars | 308.13 ns | 4.883 ns | 6.684 ns | 301.71 ns | 326.79 ns | 306.21 ns |   11 |      - |         - |
| Char_IsLetter__106chars   | 584.24 ns | 4.092 ns | 3.827 ns | 578.77 ns | 593.64 ns | 583.25 ns |   12 | 0.0153 |      96 B |

![Result Chart](./stringcontainsletterbenchmark.png)

Well, the winning method was the `ForLoop` (no surprises there), which is the most intuitive way to do it. The Regex method was the slowest, 
which is expected. The Char.IsLetter method was the second slowest, which is also expected, since it's a method call. 
Also it was the only method that allocated memory. 
The CheckEveryLetter method was the second fastest, but it's also the most verbose and not very readable.