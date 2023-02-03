namespace ExpressionAddOperators;

public class Solution
{
    public IList<string> AddOperators_000(string num, int target)
    {
        var results = new List<string>();

        AddOperatorsInternal_000(results, num, 0, target, string.Empty, 0, 0);

        return results;
    }

    private static void AddOperatorsInternal_000(
        List<string> acc,
        string num,
        int numPosition,
        int target,
        string path,
        long result,
        long previous)
    {
        if (numPosition == num.Length)
        {
            if (result == target)
            {
                acc.Add(path);
            }

            return;
        }

        var ss = "";
        long sn = 0;
        for (var i = numPosition; i < num.Length; i++)
        {
            ss += num[i];
            sn = sn * 10 + num[i] - '0';

            if (ss.Length > 1 && ss[0] == '0')
            {
                break;
            }

            if (numPosition == 0)
            {
                AddOperatorsInternal_000(acc, num, i + 1, target, ss, sn, sn);
            }
            else
            {
                AddOperatorsInternal_000(acc, num, i + 1, target, path + "+" + ss, result + sn, sn);
                AddOperatorsInternal_000(acc, num, i + 1, target, path + "-" + ss, result - sn, -sn);
                AddOperatorsInternal_000(acc, num, i + 1, target, path + "*" + ss,
                    (result - previous) + (previous * sn),
                    previous * sn);
            }
        }
    }

    public IList<string> AddOperators_001(string num, int target)
    {
        var results = new List<string>();

        var ss = "";
        long sn = 0;
        for (var i = 0; i < num.Length; i++)
        {
            ss += num[i];
            sn = sn * 10 + (num[i] - '0');

            if (ss.Length > 1 && ss[0] == '0')
            {
                break;
            }

            AddOperatorsInternal_001(results, num, i + 1, target, ss, sn, sn);
        }

        return results;
    }

    private static void AddOperatorsInternal_001(List<string> acc, string num, int position, int target, string path,
        long result, long prev)
    {
        if (position == num.Length)
        {
            if (result == target)
            {
                acc.Add(path);
            }

            return;
        }

        var ss = "";
        long sn = 0;
        for (var i = position; i < num.Length; i++)
        {
            ss += num[i];
            sn = sn * 10 + (num[i] - '0');

            if (ss.Length > 1 && ss[0] == '0')
            {
                break;
            }

            AddOperatorsInternal_001(acc, num, i + 1, target, path + "+" + ss, result + sn, sn);
            AddOperatorsInternal_001(acc, num, i + 1, target, path + "-" + ss, result - sn, -sn);
            AddOperatorsInternal_001(acc, num, i + 1, target, path + "*" + ss, (result - prev) + (prev * sn),
                prev * sn);
        }
    }

    public IList<string> AddOperators_002(string num, int target)
    {
        var results = new List<string>();

        AddOperatorsInternal_002(results, num, 0, target, string.Empty, 0, 0);

        return results;
    }

    private void AddOperatorsInternal_002(List<string> acc, string num, int position, int target, string path, long sum,
        long prev)
    {
        if (position == num.Length)
        {
            if (sum == target)
            {
                acc.Add(path);
            }

            return;
        }

        var ss = "";
        long sn = 0;
        for (var i = position; i < num.Length; i++)
        {
            ss += num[i];
            sn = sn * 10 + (num[i] - '0');

            if (ss.Length > 1 && ss[0] == '0')
            {
                break;
            }

            if (position == 0)
            {
                AddOperatorsInternal_002(acc, num, i + 1, target, ss, sn, sn);
            }
            else
            {
                AddOperatorsInternal_002(acc, num, i + 1, target, path + "+" + ss, sum + sn, sn);
                AddOperatorsInternal_002(acc, num, i + 1, target, path + "-" + ss, sum - sn, -sn);
                AddOperatorsInternal_002(acc, num, i + 1, target, path + "*" + ss, (sum - prev) + (prev * sn),
                    prev * sn);
            }
        }
    }

    public IList<string> AddOperators_003(string num, int target)
    {
        var results = new List<string>();
        AddOperatorsInternal_003(results, num, 0, target, "", 0, 0);
        return results;
    }

    public static void AddOperatorsInternal_003(
        List<string> acc,
        string num,
        int pos,
        int target,
        string path,
        long sum,
        long prev)
    {
        if (pos == num.Length)
        {
            if (sum == target)
            {
                acc.Add(path);
            }

            return;
        }

        var ss = string.Empty;
        long sn = 0;
        for (var i = pos; i < num.Length; i++)
        {
            ss += num[i];
            sn = sn * 10 + (num[i] - '0');

            if (ss.Length > 1 && ss[0] == '0')
            {
                break;
            }

            if (pos == 0)
            {
                AddOperatorsInternal_003(acc, num, i + 1, target, ss, sn, sn);
            }
            else
            {
                AddOperatorsInternal_003(acc, num, i + 1, target, path + "+" + sn, sum + sn, sn);
                AddOperatorsInternal_003(acc, num, i + 1, target, path + "-" + sn, sum - sn, -sn);
                AddOperatorsInternal_003(acc, num, i + 1, target, path + "*" + sn, sum - prev + prev * sn, prev * sn);
            }
        }
    }
}