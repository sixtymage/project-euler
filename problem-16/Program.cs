// See https://aka.ms/new-console-template for more information
using problem_16;

Console.WriteLine("Hello, World!");

for (int i = 0; i<=1000; i++)
{
  string sum = DigitSum.FindSum(2, (uint)i);
  Console.WriteLine(sum);
}
