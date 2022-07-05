namespace ClosestSubsequenceSum;

public class Solution
{
    public int MinAbsDifference_000(int[] nums, int goal)
    {
        // find possible sums in first half
        var left = new List<int>();
        GenerateSums_000(nums, 0, nums.Length / 2, 0, left);
        left.Sort();

        // find possible sums in second half
        var right = new List<int>();
        GenerateSums_000(nums, nums.Length / 2, nums.Length, 0, right);
        right.Sort();

        // find answer
        var answer = SearchResult_000(left, right, goal);
        return answer;
    }

    private static void GenerateSums_000(int[] nums, int i, int limit, int total, List<int> sums)
    {
        if (i == limit)
        {
            sums.Add(total);
            return;
        }

        GenerateSums_000(nums, i + 1, limit, total, sums);
        GenerateSums_000(nums, i + 1, limit, total + nums[i], sums);
    }

    private static int SearchResult_000(List<int> left, List<int> right, int goal)
    {
        var answer = int.MaxValue;

        var li = 0;
        var ri = right.Count - 1;

        while (li < left.Count && ri >= 0)
        {
            var sum = left[li] + right[ri];

            answer = Math.Min(answer, Math.Abs(goal - sum));

            if (sum < goal)
                li++;
            else if (sum > goal)
                ri--;
            else
                break;
        }

        return answer;
    }
}