using NUnit.Framework;

namespace LongestSubstringWithoutRepeatingCharacters.Tests;

public class Tests
{
    [TestCase("abcabcbb", 3)]
    [TestCase("bbbbb", 1)]
    [TestCase("pwwkew", 3)]
    [TestCase("abba", 2)]
    public void Test_0(string s, int expected)
    {
        var actual = new Solution().LengthOfLongestSubstring(s);
        Assert.AreEqual(expected, actual);
    }
}