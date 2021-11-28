namespace problem_12
{
  using System.Collections.Generic;
  using System.Linq;
  public static class CombinationFinder<T>
  {
    public static List<List<T>> FindCombinations(List<T> values, int k)
    {
      var indexes = Enumerable.Range(0, values.Count).ToList();
      var indexTuples = FindIndexTuples(indexes, k, true);
      return ResultsFromIndexTuples(values, indexTuples);
    }

    private static List<List<int>> FindIndexTuples(List<int> indexes, int k, bool ignoreOrder)
    {
      if (k == 1)
      {
        return SelectSingleIndexTuples(indexes);
      }

      return SelectIndexesWithSubTuples(indexes, k, ignoreOrder);
    }

    private static List<List<int>> SelectSingleIndexTuples(List<int> indexes)
    {
      var indexTuples = new List<List<int>>();
      foreach (var index in indexes)
      {
        indexTuples.Add(new List<int> { index });
      }
      return indexTuples;
    }

    private static List<List<int>> SelectIndexesWithSubTuples(List<int> indexes, int k, bool ignoreOrder)
    {
      var indexTuples = new List<List<int>>();
      for (int curr = 0; curr < indexes.Count; curr++)
      {
        int index = indexes[curr];
        var otherIndexes = indexes.Take(curr).Concat(indexes.Skip(curr + 1)).ToList();

        var subIndexTuples = FindIndexTuples(otherIndexes, k - 1, ignoreOrder);
        var newIndexTuples = subIndexTuples.Select(subIndexTuple => subIndexTuple.Concat(new List<int> { index }).ToList()).ToList();

        indexTuples = AddSubIndexTuples(indexTuples, newIndexTuples, ignoreOrder);
      }

      return indexTuples;
    }

    private static List<List<int>> AddSubIndexTuples(List<List<int>> indexTuples, List<List<int>> newIndexTuples, bool ignoreOrder)
    {
      if (!ignoreOrder)
      {
        return indexTuples.Concat(newIndexTuples).ToList();
      }

      return AddSubIndexTuplesIgnoreOrder(indexTuples, newIndexTuples);
    }

    private static List<List<int>> AddSubIndexTuplesIgnoreOrder(List<List<int>> indexTuples, List<List<int>> newIndexTuples)
    {
      foreach (var newIndexTuple in newIndexTuples)
      {
        var orderedIndexTuple = newIndexTuple.OrderBy(i => i).ToList();

        if (IndexTupleExists(indexTuples, orderedIndexTuple))
        {
          continue;
        }
        indexTuples.Add(orderedIndexTuple);
      }
      return indexTuples;
    }

    private static bool IndexTupleExists(List<List<int>> indexTuples, List<int> orderedIndexTuple)
    {
      foreach (var indexTuple in indexTuples)
      {
        if (indexTuple.SequenceEqual(orderedIndexTuple))
        {
          return true;
        }
      }
      return false;
    }

    private static List<List<T>> ResultsFromIndexTuples(List<T> values, List<List<int>> indexTuples)
    {
      return indexTuples.Select(indexTuple => indexTuple.Select(index => values[index]).ToList()).ToList<List<T>>();
    }
  }
}
