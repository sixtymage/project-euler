using System.Text;

namespace problem_12
{
  public class PrimeFactor
  {
    public long Prime { get; private set; }

    public int Count { get; private set; }

    public long Product
    {
      get
      {
        long product = 1;
        for (int i = 0; i < Count; i++)
        {
          product *= Prime;
        }
        return product;
      }
    }

    public PrimeFactor(long prime)
    {
      Prime = prime;
      Count = 1;
    }

    public PrimeFactor(PrimeFactor copyFrom)
    {
      Prime = copyFrom.Prime;
      Count = copyFrom.Count;
    }

    public override string ToString()
    {
      var sb = new StringBuilder();
      sb.Append(Prime);
      for (var i = 1; i < Count; i++)
      {
        sb.Append($"x{Prime}");
      }
      return sb.ToString();
    }

    public void Inc()
    {
      Count++;
    }
  }
}