using NUnit.Framework;

namespace P_01_01.Tests;

public class Tests
{
    [TestCase("a", true)]
    [TestCase("abc", true)]
    [TestCase("!3125abc", true)]
    [TestCase("!3125abcc", false)]
    public void Test_000(string s, bool expected)
    {
        var actual = new Class1().IsUniqueChars_000(s);
        Assert.AreEqual(expected, actual);
    }

    [TestCase("a", true)]
    [TestCase("abc", true)]
    [TestCase("!3125abc", true)]
    [TestCase("!3125abcc", false)]
    public void Test_001(string s, bool expected)
    {
        var actual = new Class1().IsUniqueChars_001(s);
        Assert.AreEqual(expected, actual);
    }
}