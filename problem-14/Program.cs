namespace problem_14
{ 
  public class Program
  {
    public static void Main(string[] args)
    {
      const int searchSpace = 1000000;
      var collatzSearch = new CollatzSearch();

      var maxSequence = new List<long>();

      for (long n = 1; n <= searchSpace; n++)
      {
        var sequence = collatzSearch.GetSequence(n);
        if (sequence.Count > maxSequence.Count)
        {
          maxSequence = sequence;
        }
      }

      Console.WriteLine($"{maxSequence.First()}: {maxSequence.Count} ({SequenceDescription(maxSequence, 10)})");
    }

    private static string SequenceDescription(List<long> sequence, int maxTerms)
    {
      if (sequence.Count <= maxTerms)
      {
        return string.Join(',', sequence);
      }
      return string.Concat(string.Join(',', sequence.Take(maxTerms)),",...");
    }
  }
}
