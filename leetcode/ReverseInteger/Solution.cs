namespace ReverseInteger;

public class Solution
{
    public int Reverse(int x)
    {
        var isNegative = x < 0;

        var min = int.MinValue.ToString();
        var max = int.MaxValue.ToString();

        var revUnsigned = x switch
        {
            > 0 => string.Join(string.Empty, x.ToString().Reverse()).TrimStart('0'),
            < 0 => string.Join(string.Empty, x.ToString().Substring(1).Reverse()).TrimStart('0'),
            _ => "0",
        };

        var rev = isNegative
            ? $"-{revUnsigned}"
            : revUnsigned;

        var comp = isNegative
            ? min.Substring(1)
            : max;

        if (revUnsigned.Length == comp.Length)
        {
            for (var i = 0; i < revUnsigned.Length; i++)
            {
                if (revUnsigned[i] > comp[i])
                {
                    return 0;
                }
                else if (revUnsigned[i] < comp[i])
                {
                    return int.Parse(rev);
                }
            }

            return int.Parse(rev);
        }
        else if (revUnsigned.Length < comp.Length)
        {
            return int.Parse(rev);
        }
        else
        {
            return 0;
        }
    }
}