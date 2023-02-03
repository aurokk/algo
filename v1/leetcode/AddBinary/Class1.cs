namespace AddBinary;

public class Solution
{
    public string AddBinary(string a, string b)
    {
        var ap = a.Length - 1;
        var bp = b.Length - 1;

        var rl = a.Length > b.Length ? a.Length : b.Length;
        var res = new char[rl + 1];

        var carry = 0;
        var i = res.Length - 1;

        while (ap >= 0 || bp >= 0)
        {
            var ac = ap >= 0 ? a[ap] - '0' : 0;
            var bc = bp >= 0 ? b[bp] - '0' : 0;

            var sum = ac + bc + carry;
            carry = sum > 1 ? 1 : 0;

            res[i] = sum % 2 == 1 ? '1' : '0';

            ap--;
            bp--;
            i--;
        }

        if (carry > 0)
        {
            res[i] = '1';
        }

        return new string(res.SkipWhile(x => x == 0).ToArray());
    }
}