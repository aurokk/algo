using System.Numerics;

namespace CountEqualAndDivisiblePairsInAnArray;

public class Solution
{
    // O(n^2)
    public int CountPairs_000(int[] nums, int k)
    {
        var pairs = 0;

        for (var i = 0; i < nums.Length; i++)
        for (var j = i + 1; j < nums.Length; j++)
        {
            if (i == j)
                continue;

            if (nums[i] == nums[j] && i * j % k == 0)
                pairs++;
        }

        return pairs;
    }

    // O(n*sqrt(n))
    public int CountPairs_001(int[] nums, int k)
    {
        var res = 0;

        var dictionary = new Dictionary<int, List<int>>();
        for (var i = 0; i < nums.Length; i++)
        {
            if (!dictionary.ContainsKey(nums[i]))
            {
                dictionary[nums[i]] = new List<int>();
            }

            dictionary[nums[i]].Add(i);
        }

        var gcds = new Dictionary<int, int>();
        foreach (var (_, ids) in dictionary)
        {
            gcds.Clear();
            foreach (var id in ids)
            {
                var gcdI = GCD(id, k);
                foreach (var (gcdJ, count) in gcds)
                {
                    res += ((gcdI * gcdJ) % k) == 0 ? count : 0;
                }

                if (!gcds.ContainsKey(gcdI))
                {
                    gcds[gcdI] = 0;
                }

                gcds[gcdI]++;
            }
        }

        return res;
    }

    public static int GCD(int a, int b)
    {
        while (a != 0 && b != 0)
        {
            if (a > b)
                a %= b;
            else
                b %= a;
        }

        return a | b;
    }
}