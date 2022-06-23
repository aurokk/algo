namespace CountArrayPairsDivisibleByK;

public class Solution
{
    // O(n^2) TL
    public long CountPairs_000(int[] nums, int k)
    {
        long pairs = 0;

        for (var i = 0; i < nums.Length; i++)
        for (var j = i + 1; j < nums.Length; j++)
        {
            long product = nums[i] * (long)nums[j];
            if (product % k == 0)
            {
                pairs++;
            }
        }

        return pairs;
    }

    public long CountPairs_001(int[] nums, int k)
    {
        long pairs = 0;

        var gcds = new Dictionary<long, long>();
        foreach (var num in nums)
        {
            var gcdA = GCD(num, k);

            foreach (var (gcdB, gcdBCount) in gcds)
            {
                long product = gcdA * gcdB;
                pairs += product % k == 0 ? gcdBCount : 0;
            }

            if (!gcds.ContainsKey(gcdA))
            {
                gcds[gcdA] = 0;
            }

            gcds[gcdA]++;
        }

        return pairs;
    }

    public long CountPairs_002(int[] nums, int k)
    {
        long pairs = 0;

        var factors = new Dictionary<long, long>();
        for (var i = 1; i * i <= k; i++)
        {
            if (k % i == 0)
            {
                factors[i] = 0;
                if (k / i != i)
                {
                    factors[k / i] = 0;
                }
            }
        }

        foreach (var num in nums)
        {
            var gcd = GCD(num, k);
            foreach (var (factor, factorCount) in factors)
            {
                if (gcd * factor % k == 0)
                {
                    pairs += factorCount;
                }

                if (gcd == factor)
                {
                    factors[factor]++;
                }
            }
        }

        return pairs;
    }

    public static long GCD(long a, long b)
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