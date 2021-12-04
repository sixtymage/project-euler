using System.Collections.ObjectModel;

namespace problem_12
{
  public class PrimeFactorBuilder
  {
    public long N { get; private set; }

    public IReadOnlyList<PrimeFactor> PrimeFactors { get; private set; }

    private readonly List<long> _defaultPrimes = new List<long> { 2, 3, 5, 7, 11, 13, 17, 19 };

    public PrimeFactorBuilder(long n, List<long>? primes = null)
    {
      N = n;
      primes = PreparePrimes(n, primes ?? _defaultPrimes);
      PrimeFactors = new ReadOnlyCollection<PrimeFactor>(FindPrimeFactors(n, primes));
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
          n /= primes[index];
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

    private static List<long> PreparePrimes(long number, List<long> primes)
    {
      if (number <= primes.Last() * primes.Last())
      {
        return primes;
      }
      return PreparePrimesLarge(number, primes);
    }

    private static List<long> PreparePrimesLarge(long number, List<long> primes)
    {
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
  }
}