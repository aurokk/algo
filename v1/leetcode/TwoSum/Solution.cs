namespace TwoSum;

public class Solution
{
    // O(N^2) time
    // O(1) memory
    public int[] TwoSum_0(int[] nums, int target)
    {
        for (var i = 0; i < nums.Length - 1; i++)
        for (var j = i + 1; j < nums.Length; j++)
        {
            if (nums[i] + nums[j] == target)
            {
                return new[] { i, j };
            }
        }

        return Array.Empty<int>();
    }

    // O(N) time
    // O(N) memory
    public int[] TwoSum_1(int[] nums, int target)
    {
        var past = new Dictionary<int, int>();
        for (var i = 0; i < nums.Length; i++)
        {
            var pastVal = target - nums[i];
            if (past.ContainsKey(pastVal))
            {
                return new[] { past[pastVal], i };
            }
            else if (!past.ContainsKey(nums[i]))
            {
                past.Add(nums[i], i);
            }
        }

        return Array.Empty<int>();
    }
}

