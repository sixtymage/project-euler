using System;

namespace problem_9
{
  class Program
  {
    static void Main(string[] args)
    {
      const long a = 8;
      const long b = 15;
      const long c = 17;

      Console.WriteLine($"{a}² + {b}² = {c}²");
      Console.WriteLine($"{a*a} + {b*b} = {c*c}");
      Console.WriteLine($"{a} + {b} + {c} = {a+b+c}");
      Console.WriteLine($"1000 / {a+b+c} = {1000 / (a+b+c)}");
      Console.WriteLine($"25²x{a}² + 25²x{b}² = 25²x{c}²");
      Console.WriteLine($"(25x{a})² + (25x{b})² = (25x{c})²");
      Console.WriteLine($"{25*a}² + {25*b}² = {25*c}²");
      Console.WriteLine($"{25*a} + {25*b} + {25*c} = {25*a + 25*b + 25*c}");
      Console.WriteLine($"{25*a} x {25*b} x {25*c} = {25*a*25*b*25*c}");
    }
  }
}