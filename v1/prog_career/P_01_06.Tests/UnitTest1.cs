using NUnit.Framework;

namespace P_01_06.Tests;

public class Tests
{
    [TestCase("ааbсссссааа", "а2b1с5а3")]
    [TestCase("abc", "abc")]
    [TestCase("aabc", "aabc")]
    [TestCase("aabbcc", "aabbcc")]
    [TestCase("aabbbcc", "a2b3c2")]
    [TestCase("", "")]
    public void Test_000(string input, string expected)
    {
        var actual = new Class1().Compress_000(input);
        Assert.AreEqual(expected, actual);
    }
}