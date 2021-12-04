using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problem_12
{
  public static class CombinationCalculator
  {
    public static int CalcCombinations(int n, int k)
    {
      int a = 1;
      int m = n;
      while (m>k)
      {
        a *= m;
        m--;
      }

      m = n-k;
      while (m>0)
      {
        a /= m;
        m--;
      }

      return a;
    }

  }
}
