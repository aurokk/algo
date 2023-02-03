using NUnit.Framework;

namespace LongestPalindromicSubstring.Tests;

public class Tests
{
    [TestCase("", "")]
    [TestCase("a", "a")]
    [TestCase("ab", "a")]
    [TestCase("aa", "aa")]
    [TestCase("aaa", "aaa")]
    [TestCase("aaaa", "aaaa")]
    [TestCase("aaca", "aca")]
    [TestCase("kacaa", "aca")]
    [TestCase("aba", "aba")]
    [TestCase("abb", "bb")]
    [TestCase("abbc", "bb")]
    [TestCase("abbbc", "bbb")]
    [TestCase("abc", "a")]
    [TestCase("babad", "bab")]
    [TestCase("babadd", "bab")]
    [TestCase("bababdd", "babab")]
    [TestCase("babababdd", "bababab")]
    [TestCase("aacabdkacaa", "aca")]
    public void Test_000(string input, string expected)
    {
        var actual = new Solution().LongestPalindrome_000(input);
        Assert.AreEqual(expected, actual);
    }

    [TestCase("", "")]
    [TestCase("a", "a")]
    [TestCase("ab", "a")]
    [TestCase("aa", "aa")]
    [TestCase("aaa", "aaa")]
    [TestCase("aaaa", "aaaa")]
    [TestCase("aaca", "aca")]
    [TestCase("kacaa", "aca")]
    [TestCase("aba", "aba")]
    [TestCase("abb", "bb")]
    [TestCase("abbc", "bb")]
    [TestCase("abbbc", "bbb")]
    [TestCase("abc", "a")]
    [TestCase("babad", "bab")]
    [TestCase("babadd", "bab")]
    [TestCase("bababdd", "babab")]
    [TestCase("babababdd", "bababab")]
    [TestCase("aacabdkacaa", "aca")]
    public void Test_001(string input, string expected)
    {
        var actual = new Solution().LongestPalindrome_001(input);
        Assert.AreEqual(expected, actual);
    }
}