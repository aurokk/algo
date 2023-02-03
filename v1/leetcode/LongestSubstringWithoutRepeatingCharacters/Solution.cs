namespace LongestSubstringWithoutRepeatingCharacters;

public class Solution
{
    // time O(N)
    // memory O(N)
    public int LengthOfLongestSubstring(string s)
    {
        var left = 0;
        var max = 0;

        // abba
        // 0022
        // 1234
        // 1212

        var charToIndex = new Dictionary<char, int>();

        for (var i = 0; i < s.Length; i++)
        {
            var c = s[i];

            if (charToIndex.ContainsKey(c))
            {
                left = charToIndex[c] + 1 > left ? charToIndex[c] + 1 : left;
            }

            var curr = (i + 1) - left;
            max = curr > max ? curr : max;

            charToIndex[c] = i;
        }

        return max;
    }
}