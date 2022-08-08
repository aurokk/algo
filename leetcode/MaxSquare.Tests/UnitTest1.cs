namespace MaxSquare.Tests;

public class Solution
{
    public int MaximalSquare(char[][] matrix)
    {
        var max = 0;
        var check = new bool[matrix.Length][];
        var cache = new int[matrix.Length][];
        for (var i = 0; i < matrix.Length; i++)
        {
            check[i] = new bool[matrix[0].Length];
            cache[i] = new int[matrix[0].Length];
        }

        int Dp(int row, int cell)
        {
            if (check[row][cell])
            {
                return cache[row][cell];
            }

            if (row == 0 || cell == 0)
            {
                check[row][cell] = true;
                cache[row][cell] = matrix[row][cell] == '1' ? 1 : 0;
                max = Math.Max(max, cache[row][cell]);
                return cache[row][cell];
            }

            if (matrix[row][cell] == '0')
            {
                check[row][cell] = true;
                cache[row][cell] = 0;
                return cache[row][cell];
            }

            check[row][cell] = true;
            cache[row][cell] =
                Math.Min(
                    Math.Min(
                        Dp(row - 1, cell),
                        Dp(row, cell - 1)
                    ),
                    Dp(row - 1, cell - 1)
                ) + 1;
            max = Math.Max(max, cache[row][cell]);
            return cache[row][cell];
        }

        for (var i = 0; i < matrix.Length; i++)
        for (var j = 0; j < matrix[0].Length; j++)
        {
            Dp(i, j);
        }

        return max * max;
    }
}

public class Tests
{
    [Test]
    public void Test1()
    {
        var result = new Solution().MaximalSquare(new[] { new[] { '0', '1' }, new[] { '1', '0' } });
        Assert.That(result, Is.EqualTo(1));
    }
}