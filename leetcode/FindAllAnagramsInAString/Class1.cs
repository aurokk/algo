namespace FindAllAnagramsInAString;

public class Solution
{
    public IList<int> FindAnagrams(string s, string p) // abab ab
    {
        // init
        var counts = new Dictionary<char, int>();
        for (var i = 'a'; i <= 'z'; i++)
        {
            counts[i] = 0;
        }

        // set counts
        foreach (var ch in p)
        {
            counts[ch]++;
        }

        var result = new List<int>();
        for (var i = 0; i < s.Length; i++)
        {
            var currCh = s[i];
            var currLength = i + 1;

            // subtract current
            counts[currCh]--;

            // add previous
            if (currLength > p.Length)
            {
                var prevCh = s[i - p.Length];
                counts[prevCh]++;
            }

            // check condition
            var isAnagram = counts.Values.All(x => x == 0);
            if (currLength >= p.Length && isAnagram)
            {
                result.Add(currLength - p.Length);
            }
        }

        return result;
    }
}