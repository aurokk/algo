namespace MinimumDifficultyOfAJobSchedule.Tests;

#nullable disable

public class Solution
{
    private int _jobs, _days;
    private int[] _jobDifficulty;
    private int[] _hardestRemaining;

    private int Dp(int i, int d)
    {
        //
        if (d == _days)
        {
            return _hardestRemaining[i];
        }

        // 
        var hardest = 0;
        var min = int.MaxValue;
        for (var j = i; j < _jobs - (_days - d); j++)
        {
            hardest = Math.Max(hardest, _jobDifficulty[i]);
            min = Math.Min(min, hardest + Dp(j + 1, d + 1));
        }

        return min;
    }

    public int MinDifficulty(int[] jobDifficulty, int d)
    {
        //
        this._jobs = jobDifficulty.Length;
        this._days = d;
        this._jobDifficulty = jobDifficulty;

        //
        if (_days > _jobs)
        {
            return -1;
        }

        //
        this._hardestRemaining = new int[_jobs];
        var hardest = 0;
        for (var i = _jobs - 1; i >= 0; i--)
        {
            hardest = Math.Max(hardest, jobDifficulty[i]);
            _hardestRemaining[i] = hardest;
        }

        //
        return Dp(0, 1);
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
}