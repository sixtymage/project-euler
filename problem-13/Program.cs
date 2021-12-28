using System;
using System.Collections.Generic;
using System.Linq;

namespace problem_13
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var a = new BigDecimal("1234");
      var b = new BigDecimal("8962");

      var c = a + b;
      
      Console.WriteLine($"{a} + {b} = {c}");
    }
  }
}