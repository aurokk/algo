namespace CoinChange.Tests;

public class Solution
{
    public int CoinChange(int[] coins, int amount) // [1], 1
    {
        // edge case
        if (amount == 0)
        {
            return 0;
        }

        // init dp
        var dp = new int[coins.Length + 1][];
        for (var i = 0; i < coins.Length + 1; i++)
        {
            dp[i] = new int[amount + 1];
        }

        for (var i = 1; i < amount + 1; i++)
        for (var j = 0; j < coins.Length + 1; j++)
        {
            dp[j][i] = 100_000;
        }

        // calc
        for (var i = 1; i < coins.Length + 1; i++)
        for (var j = 1; j < amount + 1; j++)
        {
            var coin = coins[i - 1];
 
            var div = amount / coin;
            var rem = amount % coin;


            // dp[i][j] = dp[i-1][j];
            // if (j >= coins[i - 1])
            // {
            //     dp[i][j] = Math.Min(dp[i][j], dp[i][j - coins[i - 1]] + 1);
            // }
        }

        return dp[coins.Length][amount] >= 100_000 ? -1 : dp[coins.Length][amount];
    }
}

public class Tests
{
    [Test]
    public void Test1()
    {
        var actual = new Solution().CoinChange(new[] { 186, 419, 83, 408 }, 6249);
        Assert.That(actual, Is.EqualTo(20));
    }
}