namespace P_01_04;

public class Class1
{
    public bool IsPalindromePermutation_000(string s)
    {
        var odds = 0;
        var res = new int['z' - 'a' + 1];
        foreach (var ch in s)
        {
            var pos = GetCharPos(ch);
            if (pos == -1) continue;

            res[pos]++;

            if (res[pos] % 2 == 1)
            {
                odds++;
            }
            else
            {
                odds--;
            }
        }

        return odds <= 1;
    }

    private int GetCharPos(char c) =>
        c switch
        {
            >= 'a' and <= 'z' => c - 'a',
            >= 'A' and <= 'Z' => c - 'A',
            _ => -1
        };
}