using System.Text;

namespace problem_5
{
  public class PrimeFactor
  {
    public long Prime { get; private set; }

    public long Count { get; private set; }

    public long Product
    {
      get
      {
        long product = 1;
        for(int i=0; i<Count; i++)
        {
          product = product * Prime;
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
      for (var i=1; i<Count; i++)
      {
        sb.Append($"x{Prime}");
      }
      sb.Append($" = {Product}");
      return sb.ToString();
    }

    public void Inc()
    {
      Count++;
    }
  }
}