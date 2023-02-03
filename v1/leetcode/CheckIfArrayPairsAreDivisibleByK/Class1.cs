namespace CheckIfArrayPairsAreDivisibleByK;

public class Solution
{
    public bool CanArrange(int[] arr, int k)
    {
        var freq = new Dictionary<int, int>();
        for (var i = 0; i < arr.Length; i++)
        {
            var rem = (arr[i] % k + k) % k;

            if (!freq.ContainsKey(rem))
            {
                freq[rem] = 0;
            }

            freq[rem]++;
        }

        foreach (var (n, freqN) in freq)
        {
            if (n == 0)
            {
                if (freqN % 2 != 0)
                {
                    return false;
                }
                else
                {
                    continue;
                }
            }

            var m = k - n;
            if (!freq.ContainsKey(m))
            {
                return false;
            }

            var freqM = freq[m];
            if (freqN != freqM)
            {
                return false;
            }
        }

        return true;
    }
}