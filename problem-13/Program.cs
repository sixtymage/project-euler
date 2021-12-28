namespace problem_13
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var numbers = LoadNumbers(".\\numbers.txt");
      var sum = FindSum(numbers);

      Console.WriteLine($"Sum: {sum}");
    }

    private static BigDecimal FindSum(List<BigDecimal> numbers)
    {
      var sum = new BigDecimal();

      foreach (var number in numbers)
      {
        sum += number;
      }

      return sum;
    }

    private static List<BigDecimal> LoadNumbers(string filename)
    {
      return File.ReadAllLines(filename).Select(line => new BigDecimal(line)).ToList();
    }
  }
}