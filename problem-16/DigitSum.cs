using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problem_16
{
  internal static class DigitSum
  {
    public static string FindSum(int number, uint exponent)
    {
      if (exponent == 0)
      {
        return $"{number}^{exponent} = 1 = 1";
      }

      var digits = new List<int> { number };

      for (uint c = 1; c<exponent; c++)
      {
        var nextDigits = new List<int>();
        var carry = 0;
        foreach (var digit in digits)
        {
          var next = digit * number + carry;
          nextDigits.Add(next % 10);
          carry = next / 10;
        }

        if (carry != 0)
        {
          nextDigits.Add(carry);
        }

        digits = nextDigits;
      }

      digits.Reverse();
      return $"{number}^{exponent} = {string.Join("", digits)} = {digits.Sum()}";
    }
  }
}
