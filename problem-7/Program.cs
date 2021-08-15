using System;
using System.Collections.Generic;
using System.Linq;


namespace problem_7
{
  class Program
  {
    static void Main(string[] args)
    {
      const int n = 10001;
      var primes = PrimeFinder.FindPrimes(n);

      Console.WriteLine($"nth prime (n=10001): {primes.Last()}");
    }
  }
}
