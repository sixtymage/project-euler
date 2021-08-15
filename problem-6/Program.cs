using System;

namespace problem_6
{
  class Program
  {
    static void Main(string[] args)
    {
      const long n = 100;
      long sum = CalcSum(n);
      long sumOfSquares = CalcSumOfSquares(n);
      long squareOfSum = sum * sum;
      long difference = squareOfSum - sumOfSquares;
      Console.WriteLine($"Difference (∑k)² - ∑(k²) (kϵ1..10): {squareOfSum} - {sumOfSquares} = {difference}");
    }

    private static long CalcSum(long n)
    {
      return (n * (n + 1)) / 2;
    }

    private static long CalcSumOfSquares(long n)
    {
      return (n * (n + 1) * (2 * n + 1)) / 6;
    }
  }
}