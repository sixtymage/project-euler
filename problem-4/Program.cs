using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace problem_4
{
  public static class Program
  {
    public static void Main(string[] args)
    {
      var palindromes = FindPalindromes();
      ReportResults(palindromes);
      ReportAllResults(palindromes);
    }

    private static void ReportAllResults(IList<Palindrome> palindromes)
    {
      var orderedPalindromes = palindromes.OrderByDescending(p=>p.P);
      foreach(var p in orderedPalindromes)
      {
        Console.WriteLine($"{p.X} x {p.Y} = {p.P}");
      }
    }

    private static void ReportResults(IList<Palindrome> palindromes)
    {
      if (palindromes.Count == 0)
      {
        Console.WriteLine("No palindromes found!");
        return;
      }
      var ordered = palindromes.OrderByDescending(p => p.P);
      var largest = ordered.First();

      Console.WriteLine($"Largest palindrome (of {palindromes.Count}): {largest.P} = {largest.X} x {largest.Y}");
    }

    private static IList<Palindrome> FindPalindromes()
    {
      var palindromes = new List<Palindrome>();

      for (var x = 100; x < 1000; x++)
      {
        for (var y = 100; y < 1000; y++)
        {
          var p = x * y;
          var s = p.ToString();
          var r = s.Reverse();

          if (s == r)
          {
            palindromes.Add(new Palindrome(x, y, p));
          }
        }
      }
      return palindromes;
    }

    private static string Reverse(this string value)
    {
      if (value == null)
      {
        return null;
      }
      var sb = new StringBuilder();
      for (var i = value.Length - 1; i >= 0; i--)
      {
        sb.Append(value[i]);
      }

      return sb.ToString();
    }
  }
}
