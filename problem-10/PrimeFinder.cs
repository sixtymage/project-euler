using System;
using System.Collections.Generic;
using System.Linq;

namespace problem_7
{
  public static class PrimeFinder
  {
    private static readonly IList<long> _defaultPrimes = new List<long> { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29 };

    public static IList<long> FindPrimes(int n)
    {
      var primes = _defaultPrimes.Take(n >= _defaultPrimes.Count ? _defaultPrimes.Count : n).ToList();

      while (primes.Count < n)
      {
        var prime = FindNextPrime(primes);
        primes.Add(prime);
      }
      return primes;
    }

    public static IList<long> FindPrimesLessThan(int n)
    {
      var primes = _defaultPrimes.Where(p => p < n).ToList();
      if (primes.Count == 0 || n == _defaultPrimes.Last() + 1)
      {
        return primes;
      }

      while (true)
      {
        var nextPrime = FindNextPrime(primes);
 
        if (nextPrime >= n)
        {
          return primes;
        }
        primes.Add(nextPrime);
      }
    }

    private static long FindNextPrime(IList<long> primes)
    {
      var candidatePrime = primes.Last();

      while (true)
      {
        candidatePrime = candidatePrime + 2;

        var possibleFactors = primes.TakeWhile(prime => prime <= (long)Math.Sqrt(candidatePrime));
        if (possibleFactors.Any(prime => candidatePrime % prime == 0))
        {
          continue;
        }

        return candidatePrime;
      }
    }
  }
}