using System.Text.RegularExpressions;

namespace Raccoon.Ninja.Application.Benchmarks.TestClasses.Helpers;

/// <summary>
/// With exception of the first method, all the others were created by ChatGPT
/// and I just copied them here for comparison purposes. Didn't change anything.
/// </summary>
public static class PrimeNumberCheckers
{
    public static bool IsPrimeRegex(int n)
    {
        return !Regex.IsMatch(new String('1', n), @"^1?$|^(11+?)\1+$");
    }
    
    /// <summary>
    /// Method created by ChatGPT with focus on code readability.
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public static bool IsPrimeReadable(int n)
    {
        if (n <= 1) return false;
        if (n == 2) return true;

        for (int i = 2; i < n; i++)
        {
            if (n % i == 0) return false;
        }

        return true;
    }

    /// <summary>
    /// Method created by ChatGPT with focus on performance.
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public static bool IsPrimePerformance(int n)
    {
        if (n <= 1) return false;
        if (n == 2 || n == 3) return true;
        if (n % 2 == 0 || n % 3 == 0) return false;

        int i = 5;
        int w = 2;

        while (i * i <= n)
        {
            if (n % i == 0) return false;

            i += w;
            w = 6 - w;
        }

        return true;
    }

    /// <summary>
    /// Method created by ChatGPT using recursion.
    /// </summary>
    /// <param name="n"></param>
    /// <param name="i"></param>
    /// <returns></returns>
    public static bool IsPrimeRecursion(int n, int i = 2)
    {
        if (n <= 2)
            return (n == 2) ? true : false;
        if (n % i == 0)
            return false;
        if (i * i > n)
            return true;

        // Check for next divisor
        return IsPrimeRecursion(n, i + 1);
    }

}