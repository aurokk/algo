namespace NumberOfDiceRollsWithTargetSum.Tests;

public class Solution 
{
    public int NumRollsToTarget(int n, int k, int target) 
    {
        var dp = new long[n+1, target+1];
        var mod = 1_000_000_007;
        
        // base case
        for (var i = 1; i < Math.Min(k+1, target+1); i++) 
        {
            dp[1, i] = 1;
        }

        // main
        for (var i = 2; i < n+1; i++)
        {
            for (var j = 0; j < target+1; j++) 
            {
                long sum = 0;
                
                var min = i-1;      // inc
                var max = (i-1)*k;  // inc
                var length = max+1-min;
                
                var start = Math.Max(0, j-length); // inc
                var end = j-1;                     // inc

                for (var l = start; l < end+1; l++) 
                {
                    sum += dp[i-1, l];
                }
                
                dp[i, j] = sum % mod;
            }
        }
        
        // answer
        return (int) dp[n, target];
    }
}

public class Tests
{
    [Test]
    public void Test1()
    {
        var actual = new Solution().NumRollsToTarget(30, 30, 500);
        Assert.That(actual, Is.EqualTo(222616187));
    }
}