namespace LargestVariance;

public class Solution
{
    //
    //   abbbbb
    // a 111000
    // b 012111
    // r 000000
    //
    //   abbbbb
    // b 012345
    // a 111111
    // r 001234
    //
    //   abbaaa
    // a 111123
    // b 012000
    // r 000012
    public int LargestVariance_000(string s)
    {
        var chars = new HashSet<char>(s.ToCharArray());

        var maxDeviation = 0;
        foreach (var a in chars)
        foreach (var b in chars)
        {
            if (a == b) continue;

            var aCount = 0;
            var bCount = 0;

            var wasReset = false;

            foreach (var c in s)
            {
                if (c == a) aCount++;
                if (c == b) bCount++;

                if (bCount > 0)
                {
                    maxDeviation = Math.Max(maxDeviation, aCount - bCount);
                }
                else if (bCount == 0 && wasReset)
                {
                    maxDeviation = Math.Max(maxDeviation, aCount - 1);
                }

                if (bCount > aCount)
                {
                    aCount = bCount = 0;
                    wasReset = true;
                }
            }
        }

        return maxDeviation;
    }

    public int LargestVariance_001(string s)
    {
        var maxVariance = 0;

        for (var a = 'a'; a <= 'z'; a++)
        for (var b = 'a'; b <= 'z'; b++)
        {
            var aCount = 0;
            var bCount = 0;

            var wasReset = false;

            foreach (var c in s)
            {
                if (c == a) aCount++;
                if (c == b) bCount++;

                if (bCount > 0)
                {
                    maxVariance = Math.Max(maxVariance, aCount - bCount);
                }

                if (bCount == 0 && wasReset)
                {
                    maxVariance = Math.Max(maxVariance, aCount - 1);
                }

                if (bCount > aCount)
                {
                    aCount = bCount = 0;
                    wasReset = true;
                }
            }
        }

        return maxVariance;
    }
}