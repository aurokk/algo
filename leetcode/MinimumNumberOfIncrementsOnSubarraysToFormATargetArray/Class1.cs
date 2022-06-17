namespace MinimumNumberOfIncrementsOnSubarraysToFormATargetArray;

public class Solution
{
    public int MinNumberOperations_000(int[] target)
    {
        var ops = 0;

        var allZeros = false;
        while (!allZeros)
        {
            allZeros = true;

            var isInSection = false;
            for (var i = 0; i < target.Length; i++)
            {
                if (target[i] != 0)
                {
                    allZeros = false;
                }

                if (target[i] > 0)
                {
                    if (!isInSection)
                    {
                        isInSection = true;
                        ops++;
                    }

                    target[i]--;
                }
                else if (target[i] == 0 && isInSection)
                {
                    isInSection = false;
                }
            }
        }

        return ops;
    }

    public int MinNumberOperations_001(int[] target)
    {
        var ops = 0;

        if (target.Length == 0)
        {
            return ops;
        }

        var previous = target.First();
        ops += previous;

        for (var i = 1; i < target.Length; i++)
        {
            var current = target[i];
            var diff = current - previous;
            if (diff > 0)
            {
                ops += diff;
            }

            previous = current;
        }

        return ops;
    }
}