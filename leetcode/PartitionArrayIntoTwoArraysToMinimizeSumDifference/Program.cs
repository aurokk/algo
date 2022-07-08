namespace PartitionArrayIntoTwoArraysToMinimizeSumDifference;

public class Solution
{
    public int MinimumDifference_000(int[] nums)
    {
        // find target
        var sum = nums.Select(x => x).Sum();
        var targetSum = sum / 2;
        var targetCount = nums.Length / 2;

        // generate sums
        var sums1 = new Dictionary<int, List<int>>();
        for (var i = 0; i <= targetCount; i++)
            sums1[i] = new List<int>();
        sums1[0].Add(0);
        GenerateSums_000(nums, 0, targetCount, 0, 0, sums1);
        foreach (var (k, _) in sums1) sums1[k].Sort();

        // generate sums
        var sums2 = new Dictionary<int, List<int>>();
        for (var i = 0; i <= targetCount; i++)
            sums2[i] = new List<int>();
        sums2[0].Add(0);
        GenerateSums_000(nums, targetCount, nums.Length, 0, 0, sums2);
        foreach (var (k, _) in sums1) sums2[k].Sort();

        // meet in the middle
        var diff = int.MaxValue;
        foreach (var (n, _) in sums1)
        {
            var sums1L = sums1[n];
            var k = targetCount - n;
            var sums2L = sums2[k];

            // Вообще, если тут использовать что-то вроде бинарного поиска — должно стать побыстрее
            var l = 0;
            var r = sums2L.Count - 1;
            while (l < sums1L.Count && r >= 0)
            {
                var currSum = sums1L[l] + sums2L[r];
                diff = Math.Min(diff, Math.Abs(sum - 2 * currSum));

                if (currSum > targetSum)
                    r--;
                else if (currSum < targetSum)
                    l++;
                else
                    break;
            }

            if (diff == 0)
            {
                break;
            }
        }

        return diff;
    }

    private static void GenerateSums_000(
        int[] nums,
        int index,
        int endIndex,
        int items,
        int sum,
        Dictionary<int, List<int>> sums1)
    {
        if (items > 0)
        {
            sums1[items].Add(sum);
        }

        if (index == endIndex)
        {
            return;
        }

        GenerateSums_000(nums, index + 1, endIndex, items, sum, sums1);
        GenerateSums_000(nums, index + 1, endIndex, items + 1, sum + nums[index], sums1);
    }
}