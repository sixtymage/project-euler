namespace problem_12
{
  public class Problem12
  {
    public static void Solve()
    {
      int n = 1;
      long maxFactors = 0;
      List<long> primes = new() { 2, 3, 5, 7, 11, 13, 17, 19 };

      while (true)
      {
        long triangle = CalcTriangle(n);
        var builder = new PrimeFactorBuilder(triangle, primes);
        var factors = FindFactors(builder.PrimeFactors);

        if (factors.Count > maxFactors)
        {
          maxFactors = factors.Count;
          PrintFactors(n, triangle, factors);
        }

        if (maxFactors > 500)
        {
          HandleAnswer(n, triangle, factors);
          break;
        }

        n++;
        primes = UpdatePrimes(primes, builder.PrimeFactors);
      }
    }

    private static long CalcTriangle(long n)
    {
      return n * (n + 1) / 2;
    }


    private static List<long> FindFactors(IReadOnlyList<PrimeFactor> primeFactors)
    {
      if (primeFactors.Count == 0)
      {
        return new List<long> { 1 };
      }

      Dictionary<long, bool> factors = new Dictionary<long, bool> { { 1, true } };

      var availablePrimes = primeFactors.ToDictionary(pf => pf.Prime, pf => pf.Count);
     
      while (true)
      {
        List<long> candidates = new();
        foreach (var prime in availablePrimes.Keys)
        {
          if (availablePrimes[prime] > 0)
          {
            candidates.Add(prime);
            availablePrimes[prime]--;
          }
        }

        if (candidates.Count == 0)
        {
          break;
        }

        List<List<long>>? combinations = new List<List<long>>();
        for (int k=0; k<candidates.Count; k++)
        {
          var combinationsForCountK = CombinationFinder<long>.FindCombinations(candidates, k + 1);
          combinations = combinations == null ? combinationsForCountK : combinations.Concat(combinationsForCountK).ToList();
        }

        if (factors.Count == 1)
        {
          foreach (var combination in combinations)
          {
            long product = combination.Aggregate((long)1, (acc, val) => acc * val);
            factors[product] = true;
          }
        }
        else
        {
          var allNewFactors = new Dictionary<long, bool>();
          foreach (var combination in combinations)
          {
            long product = combination.Aggregate((long)1, (acc, val) => acc * val);
            var newFactors = factors.Keys.Select(ef => ef * product);

            foreach (var newFactor in newFactors)
            {
              allNewFactors[newFactor] = true;
            }
          }

          foreach (var newFactor in allNewFactors.Keys)
          {
            factors[newFactor] = true;
          }
        }
      }

      return factors.Keys.OrderBy(f => f).ToList();
    }

    private static void PrintFactors(long n, long triangle, List<long> factors)
    {
      Console.WriteLine($"{n}:{triangle}({factors.Count})");
    }

    private static void HandleAnswer(int n, long triangle, List<long> factors)
    {
      var simpleFactors = FindSimpleFactors(triangle);
      PrintAnswer(n, triangle, factors, simpleFactors);
    }

    private static List<long> FindSimpleFactors(long triangle)
    {
      var factors = new List<long>();

      long sqrt = (long)Math.Sqrt(triangle);
      for (long candidate = 1; candidate <= sqrt; candidate++)
      {
        if (triangle % candidate == 0)
        {
          var coFactor = triangle / candidate;
          factors.Add(candidate);
          if (coFactor != candidate)
          {
            factors.Add(coFactor);
          }
        }
      }

      return factors.OrderBy(f => f).ToList();
    }

    private static void PrintAnswer(int n, long triangle, List<long> factors, List<long> simpleFactors)
    {
      Console.WriteLine();

      if (factors.SequenceEqual(simpleFactors))
      {
        Console.WriteLine($"Success! The {n}th triangle number {triangle} has {factors.Count} factors.");
        return;
      }

      Console.WriteLine("Failure :(. The two sequences are different.");
      PrintSequence("Primes:", factors);
      PrintSequence("Simple:", simpleFactors);
    }

    private static void PrintSequence(string v, List<long> sequence)
    {
      Console.WriteLine(v);
      Console.WriteLine(string.Join(',', sequence));
    }

    private static List<long> UpdatePrimes(List<long> primes, IReadOnlyList<PrimeFactor> primeFactors)
    {
      if (primeFactors == null || primeFactors.Count == 0)
      {
        return primes;
      }

      foreach(var primeFactor in primeFactors)
      {
        if (primes.Contains(primeFactor.Prime))
        {
          break;
        }

        primes.Add(primeFactor.Prime);
      }

      return primes;
    }
  }
}
