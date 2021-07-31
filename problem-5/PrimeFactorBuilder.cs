using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace problem_5
{
  public class PrimeFactorBuilder
  {
    public long N { get; private set; }

    public IReadOnlyCollection<PrimeFactor> PrimeFactors { get; private set; }

    private readonly IList<long> _defaultPrimes = new List<long> { 2, 3, 5, 7, 11, 13, 17, 19 };

    public PrimeFactorBuilder(long n, IList<long> primes = null)
    {
      N = n;
      PrimeFactors = new ReadOnlyCollection<PrimeFactor>(FindPrimeFactors(n, primes ?? _defaultPrimes));
    }

    public static IList<PrimeFactor> FindPrimeFactors(long n, IList<long> primes)
    {
      var primeFactors = new Dictionary<long, PrimeFactor>();

      var index = primes.Count - 1;
      while (true)
      {
        if (index < 0)
        {
          break;
        }

        if (n % primes[index] == 0)
        {
          IncPrimeFactor(primes[index], primeFactors);
          n  = n / primes[index];
        }
        else
        {
          index--;
        }
      }
      return primeFactors.Values.ToList();
    }

    private static void IncPrimeFactor(long prime, IDictionary<long, PrimeFactor> primeFactors)
    {
      if (primeFactors.ContainsKey(prime))
      {
        primeFactors[prime].Inc();
      }
      else
      {
        primeFactors[prime] = new PrimeFactor(prime);
      }
    }
  }
}