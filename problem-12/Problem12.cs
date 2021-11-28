namespace problem_12
{
  public class Problem12
  {
    public static void Solve()
    {
      foreach (var n in Enumerable.Range(1, 20)) 
      {
        long triangle = FindTriangleN(n);
        var builder = new PrimeFactorBuilder(triangle);
        var factors = FindFactors(builder.PrimeFactors);

        PrintFactors(triangle, factors);
      }
    }

    private static long FindTriangleN(long n)
    {
      return n * (n + 1) / 2;
    }

    private static void PrintFactors(long triangle, List<long> factors)
    {
      Console.WriteLine($"{triangle}: {factors.Count} ({string.Join(',', factors)})");
    }

    private static List<long> FindFactors(IReadOnlyCollection<PrimeFactor> primeFactors)
    {
      var flattenedPrimeFactors = Flatten(primeFactors);

      var factors = new List<long> { 1 };
      for (int k = 1; k<= flattenedPrimeFactors.Count; k++)
      {
        AddUniqueFactors(flattenedPrimeFactors, factors, k);
      }

      return factors.OrderBy(f => f).ToList();
    }

    private static void AddUniqueFactors(List<long> flattenedPrimeFactors, List<long> factors, int k)
    {
      var primeFactorCombinations = CombinationFinder<long>.FindCombinations(flattenedPrimeFactors, k);

      foreach (var primeFactorCombination in primeFactorCombinations)
      {
        var product = primeFactorCombination.Aggregate((long)1, (acc, val) => acc * val);

        if (!factors.Contains(product))
        {
          factors.Add(product);
        }
      }
    }

    private static List<long> Flatten(IReadOnlyCollection<PrimeFactor> primeFactors)
    {
      var flattened  = new List<long>();
      foreach (var primeFactor in primeFactors)
      {
        for (int i = 0; i < primeFactor.Count; i++)
        {
          flattened.Add(primeFactor.Prime);
        }
      }
      return flattened;
    }
  }
}
