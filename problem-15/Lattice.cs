namespace problem_15
{
  internal class Lattice
  {
    private readonly int _dimVertices;

    public Lattice(int numSquares)
    {
      _dimVertices = numSquares+1;
    }

    public long CalcPaths()
    {
      var growthPhase = true;
      var pathCounts = new List<long> { 1 };

      while (true)
      {
        if (pathCounts.Count == 1 && !growthPhase)
        {
          break;
        }
        pathCounts = CalcNewPathCounts(growthPhase, pathCounts);

        if (pathCounts.Count == _dimVertices && growthPhase)
        {
          growthPhase = false;
        }
      }

      return pathCounts[0];
    }

    private static List<long> CalcNewPathCounts(bool growthPhase, List<long> pathCounts)
    {
      var nextPathCounts = new List<long>();

      if (growthPhase)
      {
        for (int i = 0; i < pathCounts.Count + 1; i++)
        {
          if (i == 0 || i == pathCounts.Count)
          {
            nextPathCounts.Add(1);
          }
          else
          {
            nextPathCounts.Add(pathCounts[i - 1] + pathCounts[i]);
          }
        }
      }
      else
      {
        for (int i = 0; i < pathCounts.Count - 1; i++)
        {
          nextPathCounts.Add(pathCounts[i] + pathCounts[i+1]);
        }
      }

      return nextPathCounts;
    }
  }
}
