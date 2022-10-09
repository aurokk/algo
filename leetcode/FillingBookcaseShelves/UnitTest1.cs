namespace FillingBookcaseShelves;

public class Solution
{
    public int MinHeightShelves(int[][] books, int shelfWidth)
    {
        var n = books.Length;
        var dp = new int[n + 1]; // dp[0] = 0;

        for (var i = 1; i < n + 1; i++) // n books
        {
            dp[i] = int.MaxValue; // the worst option

            var width = 0;
            var height = 0;

            for (var j = i; j > 0; j--)
            {
                var book = books[j - 1];
                var bookWidth = book[0];
                var bookHeight = book[1];

                if (width + bookWidth > shelfWidth)
                {
                    break;
                }

                width += bookWidth;
                height = Math.Max(height, bookHeight);
                dp[i] = Math.Min(dp[i], dp[j - 1] + height);
            }
        }

        return dp[n];
    }
}

public class Tests
{
    [Test]
    public void Test1()
    {
        var books = new[]
        {
            new[] { 1, 1 },
            new[] { 2, 3 },
            new[] { 2, 3 },
            new[] { 1, 1 },
            new[] { 1, 1 },
            new[] { 1, 1 },
            new[] { 1, 2 },
        };
        var actual = new Solution().MinHeightShelves(books, 4);
        Assert.That(actual, Is.EqualTo(6));
    }
}