using System;
using System.Collections.Generic;
using System.Linq;


namespace problem_7
{
  class Program
  {
    static void Main(string[] args)
    {
      const int n = 2000000;
      var primes = PrimeFinder.FindPrimesLessThan(n);

      var sum = primes.Sum();

      Console.WriteLine($"Sum of primes less than n={n}: {sum}");
    }
  }
}
