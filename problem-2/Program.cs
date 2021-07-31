using System;
using System.Collections.Generic;
using System.Linq;

namespace problem_2
{
  class Program
  {
    static void Main(string[] args)
    {
      const long limit = 4000000;
      var sequence = Fibonacci(limit);
      var sum = sequence.Where(x => x % 2 == 0).Sum();
      Console.WriteLine($"Fibonacci Even Sum ({limit}): {sum}");
      Console.ReadLine();
    }

    private static List<long> Fibonacci(long limit)
    {
      int x = 1;
      int y = 2;
      var sequence = new List<long>() { x, y };

      while (true)
      {
        var z = x + y;
        if (z > limit)
        {
          break;
        }

        sequence.Add(z);
        x = y;
        y = z;
      }

      return sequence;
    }
  }
}
