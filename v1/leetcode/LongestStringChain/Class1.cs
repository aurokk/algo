namespace LongestStringChain;

public class Solution
{
    public int LongestStrChain_000(string[] words)
    {
        words = words.OrderBy(x => x.Length).ToArray();

        var max = 1;
        var dp = new int[words.Length];
        for (var i = 0; i < words.Length; i++)
        {
            max = Math.Max(Dfs(words, i, dp), max);
        }

        return max;
    }

    private int Dfs(string[] words, int start, int[] dp)
    {
        if (dp[start] > 0)
        {
            return dp[start];
        }

        var max = 0;

        var a = words[start];
        for (var i = start + 1; i < words.Length; i++)
        {
            var b = words[i];
            if (CanChain(a, b))
            {
                max = Math.Max(Dfs(words, i, dp), max);
            }
        }

        dp[start] = max + 1;
        return max + 1;
    }

    static bool CanChain(string s, string l)
    {
        if (l.Length - 1 != s.Length)
            return false;

        var skipped = false;
        var li = 0;
        var si = 0;
        while (li < l.Length && si < s.Length)
        {
            if (l[li] == s[si])
            {
                li++;
                si++;
            }
            else if (!skipped)
            {
                li++;
                skipped = true;
            }
            else if (skipped)
            {
                return false;
            }
        }

        return true;
    }


    public int LongestStrChain_001(string[] words)
    {
        words = words.OrderBy(x => x.Length).ToArray();

        var max = 1;
        var dp = new Dictionary<string, int>();
        for (var i = 0; i < words.Length; i++)
        {
            var curr = words[i];
            dp[curr] = 1;

            foreach (var (pred, value) in dp)
            {
                if (CanChain(pred, curr))
                {
                    dp[curr] = Math.Max(dp[curr], value + 1);
                    max = Math.Max(dp[curr], max);
                }
            }
        }

        return max;
    }
}