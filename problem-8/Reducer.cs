namespace problem_8
{
  public static class SequenceComparer
  {
    public static int Compare(Sequence sequence1, Sequence sequence2)
    {
      var seq1 = new Sequence(sequence1);
      var seq2 = new Sequence(sequence2);

      while (true)
      {
        var match = seq1.FindMatch(seq2);

        if (match != -1)
        {
          seq1.Remove(match);
          seq2.Remove(match);
        }
        else
        {
          break;
        }
      }

      var product1 = seq1.Product;
      var product2 = seq2.Product;

      return product1 > product2 ? 1 : product1 < product2 ? -1 : 0;
    }
  }
}
