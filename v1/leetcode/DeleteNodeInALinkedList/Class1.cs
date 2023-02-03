namespace DeleteNodeInALinkedList;

public class Solution
{
    public void ReverseString_000(char[] s)
    {
        var h = 0;
        var t = s.Length - 1;

        while (h <= t)
        {
            (s[h], s[t]) = (s[t], s[h]);
            h++;
            t--;
        }
    }
}