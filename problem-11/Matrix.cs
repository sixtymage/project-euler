using System.Collections.Generic;
using System.Linq;

namespace problem_11
{
  public class Matrix
  {
    public int Rows { get; private set; }
    public int Cols { get; private set; }
    public bool IsSquare
    {
      get { return Rows == Cols; }
    }

    private readonly long[,] _data = null;

    public Matrix(int rows, int cols)
    {
      _data = new long[rows, cols];
      Rows = rows;
      Cols = cols;
    }

    public Matrix(string data)
    {
      _data = Build(data);
      Rows = _data.GetLength(0);
      Cols = _data.GetLength(1);
    }

    public void Set(int row, int col, long value)
    {
      _data[row, col] = value;
    }

    public Matrix Extract(int row, int col, int size)
    {
      var m = new Matrix(size, size);
      for (var i = 0; i < size; i++)
      {
        for (var j = 0; j < size; j++)
        {
          m.Set(i, j, _data[row + i, col + j]);
        }
      }
      return m;
    }

    public long CalcLargestProduct()
    {
      var largestHorizontalProduct = CalcLargestHorizontalProduct();
      var largestVerticalProduct = CalcLargestVerticalProduct();
      var largestDiagonalProduct = CalcLargestDiagonalProduct();

      var largestRectilinear = largestHorizontalProduct > largestVerticalProduct
          ? largestHorizontalProduct
          : largestVerticalProduct;

      return largestRectilinear > largestDiagonalProduct
        ? largestRectilinear
        : largestDiagonalProduct;
    }

    private long[,] Build(string text)
    {
      var matrixValues = new List<List<long>>();

      string[] lines = text.Split(new char[]{'\n', '\r'});
      foreach (var line in lines)
      {
        var trimmed = TrimLine(line);
        if (trimmed == string.Empty)
        {
          continue;
        }

        string[] textValues = line.Split(' ');
        var rowValues = new List<long>();
        foreach (var textValue in textValues)
        {
          if (long.TryParse(textValue, out var value))
          {
            rowValues.Add(value);
          }
        }
        matrixValues.Add(rowValues);
      }

      int numRows = matrixValues.Count;
      var maxCols = matrixValues.Max(x => x.Count);
      var minCols = matrixValues.Min(x => x.Count);

      if (numRows != maxCols || numRows != minCols)
      {
        throw new System.Exception($"Not a Square matrix (rows={numRows} minCols={minCols} maxCols={maxCols})");
      }

      var data = new long[numRows, maxCols];
      for (int row = 0; row < numRows; row++)
      {
        for (int col = 0; col < maxCols; col++)
        {
          data[row, col] = matrixValues[row][col];
        }
      }
      return data;
    }

    private string TrimLine(string line)
    {
      string trimmed = line.Replace("\n", "");
      return trimmed.Replace("\r", "");
    }

    private long CalcLargestHorizontalProduct()
    {
      long largestProduct = 0;
      for (var row = 0; row < Rows; row++)
      {
        long product = 1;
        for (var col = 0; col < Cols; col++)
        {
          product = product * _data[row, col];
        }

        largestProduct = product > largestProduct ? product : largestProduct;
      }

      return largestProduct;
    }

    private long CalcLargestVerticalProduct()
    {
      long largestProduct = 0;
      for (var col = 0; col < Cols; col++)
      {
        long product = 1;
        for (var row = 0; row < Rows; row++)
        {
          product = product * _data[row, col];
        }

        largestProduct = product > largestProduct ? product : largestProduct;
      }

      return largestProduct;
    }

    private long CalcLargestDiagonalProduct()
    {
      if (Rows != Cols)
      {
        return 0;
      }

      long backslashProduct = 1;
      long forwardslashProduct = 1;
      for (var i = 0; i < Cols; i++)
      {
        backslashProduct = backslashProduct * _data[i, i];
        forwardslashProduct = forwardslashProduct * _data[Rows - i - 1, i];
      }

      return forwardslashProduct > backslashProduct ? forwardslashProduct : backslashProduct;
    }
  }
}