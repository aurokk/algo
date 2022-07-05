using System.Data.Common;

namespace PartitionArrayIntoTwoArraysToMinimizeSumDifference;

public class Solution
{
    public int MinimumDifference(int[] nums)
    {
        // // find target
        // var sum = nums.Select(x => (long)x).Sum();
        // var target = sum / 2;
        //
        // // init dp
        // var dp = new long[nums.Length][];
        // for (var i = 0; i < nums.Length; i++) dp[i] = new long[target];
        //
        // // calculate closest sum to target
        // for (var curNumI = 0; curNumI < nums.Length; curNumI++)
        // for (var curSum = 1; curSum < target; curSum++)
        // {
        //     var curNum = nums[curNumI];
        //
        //     var previousMax = curNumI - 1 >= 0
        //         ? dp[curNumI - 1][curSum - 1]
        //         : 0;
        //
        //     var previousMaxMinusCurNum = curNumI - 1 >= 0 && curSum - curNum >= 0
        //         ? dp[curNumI - 1][curSum - curNum] + curNum
        //         : 0;
        //
        //     var max = Math.Min(Math.Max(Math.Max(previousMax, previousMaxMinusCurNum), curNum), curSum);
        //
        //     dp[curNumI][curSum] = max;
        // }
        //
        // // result
        // var result = dp[^1][^1];
        // return (int)(sum - result * 2);

        // find target
        // var sum = nums.Select(x => (long)x).Sum();
        // var target = sum / 2;
        //
        // for (var i = 0; i < UPPER; i++)
        // {
        //     
        // }

        throw new NotImplementedException();
    }
}