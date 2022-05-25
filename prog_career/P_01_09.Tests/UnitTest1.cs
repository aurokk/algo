using NUnit.Framework;

namespace P_01_09.Tests;

public class Tests
{
    [TestCase("a", "a", true)]
    [TestCase("ab", "a", false)]
    [TestCase("ab", "ba", true)]
    [TestCase("abc", "cba", false)]
    [TestCase("abc", "bca", true)]
    [TestCase("abc", "bcaa", false)]
    public void Test1(string s1, string s2, bool expected)
    {
        var actual = new Class1().IsSubstring(s1, s2);
        Assert.AreEqual(expected, actual);
    }
}