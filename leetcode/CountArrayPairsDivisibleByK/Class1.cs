namespace CountArrayPairsDivisibleByK;

public class Solution
{
    // O(n^2) TL
    public long CountPairs_000(int[] nums, int k)
    {
        var pairs = 0;

        for (var i = 0; i < nums.Length; i++)
        for (var j = i + 1; j < nums.Length; j++)
        {
            long product = nums[i] * nums[j];
            if (product % k == 0)
            {
                pairs++;
            }
        }

        return pairs;
    }

    public long CountPairs_001(int[] nums, int k)
    {
        var pairs = 0;

        // for (var i = 0; i < nums.Length; i++)
        // for (var j = i + 1; j < nums.Length; j++)
        // {
        //     if ((nums[i] * nums[j]) % k == 0)
        //     {
        //         pairs++;
        //     }
        // }

        return pairs;
    }
}