using System;
using System.Collections.Generic;
using System.Linq;

namespace problem_5
{
  public static class Program
  {
    public static void Main(string[] args)
    {
      const long upperBound = 20;
      var factors = FindFactors(upperBound);
      var answer = FindProduct(factors);

      WriteResults(upperBound, answer, factors);
    }

    private static void WriteResults(long upperBound, long answer, IList<PrimeFactor> factors)
    {
      Console.WriteLine($"Smallest number evenly divided by each of (1..{upperBound}): {answer}");
      
      Console.WriteLine("Chosen Factors:");
      foreach (var factor in factors)
      {
        Console.WriteLine($"  {factor}");
      }
    }

    private static IList<PrimeFactor> FindFactors(long upperBound)
    {
      var factorInfo = new Dictionary<long, IReadOnlyCollection<PrimeFactor>>();
      for (int n = 1; n <= upperBound; n++)
      {
        factorInfo[n] = FindPrimeFactors(n);
      }

      return ExtractSuitablePrimeFactors(factorInfo);
    }

    private static IList<PrimeFactor> ExtractSuitablePrimeFactors(IDictionary<long,IReadOnlyCollection<PrimeFactor>> factorInfo)
    {
      var chosenFactors = new Dictionary<long, PrimeFactor>();

      foreach (var number in factorInfo.Keys)
      {
        var primeFactors = factorInfo[number];
        foreach(var primeFactor in primeFactors)
        {
          UpdateChosenFactors(chosenFactors, primeFactor);
        }

      }
      return chosenFactors.Values.ToList();
    }

    private static void UpdateChosenFactors(IDictionary<long, PrimeFactor> chosenFactors, PrimeFactor primeFactor)
    {
      if (!chosenFactors.ContainsKey(primeFactor.Prime) || chosenFactors[primeFactor.Prime].Count < primeFactor.Count)
      {
        chosenFactors[primeFactor.Prime] = new PrimeFactor(primeFactor);
      }
    }

    private static long FindProduct(IList<PrimeFactor> suitableFactors)
    {
      long product = 1;
      foreach(var factor in suitableFactors)
      {
        product = product * factor.Product;
      }
      return product;
    }

    private static IReadOnlyCollection<PrimeFactor> FindPrimeFactors(long n)
    {
      var builder = new PrimeFactorBuilder(n);
      return builder.PrimeFactors;
    }
  }
}
