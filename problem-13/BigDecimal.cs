namespace problem_13
{
  internal class BigDecimal
  {
    public int Count
    {
      get { return _digits.Count; }
    }

    public int this [int index]
    {
      get { return _digits[index]; }
    }

    private readonly List<int> _digits = new();

    public BigDecimal()
      : this("0")
    {
    }

    public BigDecimal(string digits)
    {
      foreach (char c in digits)
      {
        _digits.Add(ToInt32(c));
      }
    }

    private BigDecimal(List<int> digits)
    {
      _digits = digits;
    }

    public static BigDecimal operator +(BigDecimal a, BigDecimal b)
    {
      int i = a.Count - 1;
      int j = b.Count - 1;
      int carry = 0;

      var digits = new List<int>();

      while(i >= 0 || j >= 0)
      {
        var digitA = i >= 0 ? a[i] : 0;
        var digitB = j >= 0 ? b[j] : 0;

        var sum = digitA + digitB + carry;
        carry = sum / 10;
        var digit = sum % 10;

        digits.Add(digit);

        i--;
        j--;
      }

      if (carry > 0)
      {
        digits.Add(carry);
      }

      digits = digits.Reverse<int>().ToList();
      return new BigDecimal(digits);
    }

    public override string ToString()
    {
      return new string(_digits.Select(b => ToChar(b)).ToArray());
    }

    private static char ToChar(int digit)
    {
      switch (digit)
      {
        case 0:
          return '0';
        case 1:
          return '1';
        case 2:
          return '2';
        case 3:
          return '3';
        case 4:
          return '4';
        case 5:
          return '5';
        case 6:
          return '6';
        case 7:
          return '7';
        case 8:
          return '8';
        case 9:
          return '9';
      }

      throw new OverflowException();
    }

    private static byte ToInt32(char digit)
    {
      switch (digit)
      {
        case '0':
          return 0;
        case '1':
          return 1;
        case '2':
          return 2;
        case '3':
          return 3;
        case '4':
          return 4;
        case '5':
          return 5;
        case '6':
          return 6;
        case '7':
          return 7;
        case '8':
          return 8;
        case '9':
          return 9;
      }

      throw new OverflowException();
    }
  }
}
