using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace problem_3
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var number = GetInput(args, 600851475143);
      if (number <= 1)
      {
        Console.WriteLine($"Input needs to be >= 1");
        return;
      }

      var primes = PreparePrimes(number);
      var factor = FindLargestPrimeFactor(number, primes);

      Console.WriteLine($"Largest Prime Factor({number}): {factor}");
    }

    private static long GetInput(string[] args, long defaultNumber)
    {
      if (args.Length == 1)
      {
        if (Int64.TryParse(args[0], out long result))
        {
          return result;
        }
      }
      return defaultNumber;
    }

    private static List<long> PreparePrimes(long number)
    {
      if (IsLessThan10(number))
      {
        return PreparePrimesSmall(number);
      }
      return PreparePrimesLarge(number);
    }

    private static bool IsLessThan10(long number)
    {
      return number >= 0 && number < 10;
    }

    private static List<long> PreparePrimesSmall(long number)
    {
      switch (number)
      {
        case 9:
        case 8:
        case 7:
          return new List<long> { 2, 3, 5, 7 };
        case 6:
          return new List<long> { 2, 3, 5 };
        case 5:
          return new List<long> { 2, 3, 5 };
        case 4:
        case 3:
          return new List<long> { 2, 3 };
        case 2:
          return new List<long> { 2 };
      }
      return new List<long>();
    }

    private static List<long> PreparePrimesLarge(long number)
    {
      var primes = new List<long> { 2, 3 };

      var start = primes.Last();
      var end = (long)Math.Sqrt(number);
      AddPrimes(primes, start, end);
      AddPrimes(primes, number, number);

      return primes;
    }

    private static void AddPrimes(List<long> primes, long start, long end)
    {
      for (long candidate = start; candidate <= end; candidate += 2)
      {
        if (!primes.Any(x => candidate % x == 0))
        {
          primes.Add(candidate);
        }
      }
    }

    private static long FindLargestPrimeFactor(long number, IList<long> primes)
    {
      for (var i = primes.Count - 1; i >= 0; i--)
      {
        if (number % primes[i] == 0)
        {
          return primes[i];
        }
      }
      return number;
    }
  }
}
