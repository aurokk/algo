namespace CheckIfNumberIsASumOfPowersOfThree;

public class Solution
{
    public bool CheckPowersOfThree_000(int n)
    {
        var quo = n;

        while (quo > 0)
        {
            var rem = quo % 3;
            if (rem == 2)
            {
                return false;
            }

            quo /= 3;
        }

        return true;
    }

    public bool CheckPowersOfFour(int n)
    {
        var quo = n;

        while (quo > 0)
        {
            var rem = quo % 4;
            if (rem is 2 or 3)
            {
                return false;
            }

            quo /= 4;
        }

        return true;
    }

    public bool CheckPowersOfFive(int n)
    {
        var quo = n;

        while (quo > 0)
        {
            var rem = quo % 5;
            if (rem is 2 or 3 or 4)
            {
                return false;
            }

            quo /= 5;
        }

        return true;
    }

    public bool CheckPowersOfThree_001(int n)
    {
        var x = new int[n + 1];

        var curr = 0;
        var next = 1;
        for (var i = 0; i < n + 1; i++)
        {
            if (i == next)
            {
                curr = next;
                next *= 3;
            }

            x[i] = curr;
        }

        var r = new Dictionary<int, bool>();
        while (n > 0)
        {
            var y = x[n];
            if (r.ContainsKey(y))
            {
                return false;
            }
        
            r[y] = true;
            n -= y;
        
            if (n < 0)
            {
                return false;
            }
        }

        return true;
    }
}