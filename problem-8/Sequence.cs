using System;
using System.Collections.Generic;

namespace problem_8
{
  public class Sequence
  {
    public int Count { get { return _digits.Count; } }

    private readonly List<long> _digits;

    public long Product
    {
      get
      {
        long product = 1;
        _digits.ForEach(x => product = product * x);
        return product;
      }
    }

    public Sequence(IEnumerable<char> digits)
    {
      _digits = new List<long>();
      foreach (char digit in digits)
      {
        if (Int64.TryParse(digit.ToString(), out long result))
        {
          _digits.Add(result);
        }
      }
    }

    public Sequence(Sequence sequence)
    {
      this._digits = new List<long>(sequence._digits);
    }

    public override string ToString()
    {
      return string.Join("", _digits);
    }

    public bool Contains(long digit)
    {
      return _digits.Contains(digit);
    }

    public long FindMatch(Sequence sequence)
    {
      foreach (var digit in _digits)
      {
        if (sequence.Contains(digit))
        {
          return digit;
        }
      }

      return -1;
    }

    public void Remove(long digit)
    {
      _digits.Remove(digit);
    }
  }
}
