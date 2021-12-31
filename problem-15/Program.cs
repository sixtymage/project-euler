namespace problem_15
{
  public static class Program
  {
    public static void Main(string[] args)
    {
      const int maxSize = 20;

      for (int latticeSize = 2; latticeSize <= maxSize; latticeSize++)
      {
        var lattice = new Lattice(latticeSize);
        var numPaths = lattice.CalcPaths();
        Console.WriteLine($"Lattice({latticeSize}): {numPaths}");
      }
    }
  }
}