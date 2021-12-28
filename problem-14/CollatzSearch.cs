namespace problem_14
{
  internal class CollatzSearch
  {
    private readonly Dictionary<long, long> _collatz = new Dictionary<long, long>();

    public void Populate(long n)
    {
      long current = n;

      while (true)
      {
        if (_collatz.ContainsKey(current))
        {
          break;
        }

        var next = Next(current);
        _collatz[current] = next;
        current = next;
      }
    }

    public List<long> GetSequence(long n)
    {
      if (n < 0 )
      {
        return new List<long>();
      }

      if (!_collatz.ContainsKey(n))
      {
        Populate(n);
      }

      var sequence = new List<long>();
      while (true)
      {
        sequence.Add(n);
        if (n == 1)
        {
          break;
        }

        n = _collatz[n];
      }

      return sequence;
    }


    private static long Next(long n)
    {
      if (n % 2 == 0)
      {
        return n / 2;
      }
      return n * 3 + 1;
    }
  }
}
