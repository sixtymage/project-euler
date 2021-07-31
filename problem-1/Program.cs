using System;

namespace problem_1
{
  class Program
  {
    static void Main(string[] args)
    {
      const int limit = 1000;
      var sum1 = FindSumMethod1(limit);
      var sum2 = FindSumMethod2(limit);

      Console.WriteLine($"Sum below {limit} is {sum1} ({sum2}).");
    }

    private static int FindSumMethod1(int limit)
    {
      int multipleOfThree = 3;
      int multipleOfFive = 5;
      int sum = 0;

      while (true)
      {
        if (multipleOfThree == multipleOfFive)
        {
          sum += multipleOfThree;
          multipleOfThree += 3;
          multipleOfFive += 5;
        }
        else if (multipleOfThree < multipleOfFive)
        {
          sum += multipleOfThree;
          multipleOfThree += 3;
        }
        else
        {
          sum += multipleOfFive;
          multipleOfFive += 5;
        }

        if (multipleOfThree >= limit && multipleOfFive >= limit)
        {
          break;
        }
      }
      return sum;
    }

    private static int FindSumMethod2(int limit)
    {
      int sum = 0;
      for (int i=3; i<limit; i++)
      {
        if (i % 3 == 0 || i % 5 == 0)
        {
          sum += i;
        }
      }
      return sum;
    }
  }
}
