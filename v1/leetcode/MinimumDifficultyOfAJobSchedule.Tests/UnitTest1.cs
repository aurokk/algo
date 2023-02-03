namespace MinimumDifficultyOfAJobSchedule.Tests;

#nullable disable

// public class Solution
// {
//     private int _jobs, _days;
//     private int[] _jobDifficulty;
//     private int[] _hardestRemaining;
//
//     private int Dp(int i, int d)
//     {
//         //
//         if (d == _days)
//         {
//             return _hardestRemaining[i];
//         }
//
//         // 
//         var hardest = 0;
//         var min = int.MaxValue;
//         for (var j = i; j < _jobs - (_days - d); j++)
//         {
//             hardest = Math.Max(hardest, _jobDifficulty[i]);
//             min = Math.Min(min, hardest + Dp(j + 1, d + 1));
//         }
//
//         return min;
//     }
//
//     public int MinDifficulty(int[] jobDifficulty, int d)
//     {
//         //
//         this._jobs = jobDifficulty.Length;
//         this._days = d;
//         this._jobDifficulty = jobDifficulty;
//
//         //
//         if (_days > _jobs)
//         {
//             return -1;
//         }
//
//         //
//         this._hardestRemaining = new int[_jobs];
//         var hardest = 0;
//         for (var i = _jobs - 1; i >= 0; i--)
//         {
//             hardest = Math.Max(hardest, jobDifficulty[i]);
//             _hardestRemaining[i] = hardest;
//         }
//
//         //
//         return Dp(0, 1);
//     }
// }

public class Solution
{
    public int MinDifficulty(int[] jobDifficulty, int d)
    {
        var jobs = jobDifficulty.Length;
        var days = d;

        if (jobs < days)
        {
            return -1;
        }
        
        var dp = new int[days+1][];
        for (var i = 0; i < days+1; i++) 
        {
            dp[i] = new int[jobs+1];
        }

        // base case, last day
        for (var i = jobs - 1; i >= 0; i--)
        {
            dp[days - 1][i] = Math.Max(dp[days - 1][i + 1], jobDifficulty[i]);
        }
        
        for (var day = days-2; day >= 0; day--) 
        {
            var minJob = day;
            var maxJob = (jobs - 1) - ((days - 1) - day);
            for (var start = minJob; start <= maxJob; start++)
            {
                dp[day][start] = int.MaxValue;
                var hardest = 0;
                for (var end = start; end <= maxJob; end++) 
                {
                    hardest = Math.Max(hardest, jobDifficulty[end]);
                    dp[day][start] = Math.Min(dp[day][start], hardest + dp[day+1][end+1]);
                }
            }
        }
        
        return dp[0][0];
    }
}

public class Tests
{
    [Test]
    public void Test1()
    {
        var result = new Solution().MinDifficulty(new[] { 6, 5, 4, 3, 2, 1 }, 2);
        Assert.That(result, Is.EqualTo(7));
    }

    [Test]
    public void Test2()
    {
        var result = new Solution().MinDifficulty(new[] { 11, 111, 22, 222, 33, 333, 44, 444 }, 6);
        Assert.That(result, Is.EqualTo(843));
    }
}