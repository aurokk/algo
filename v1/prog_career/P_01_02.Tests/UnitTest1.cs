using NUnit.Framework;

namespace P_01_02.Tests;

public class Tests
{
    [TestCase("abc", "bca", true)]
    [TestCase("abc", "bcac", false)]
    public void Test_000(string a, string b, bool expected)
    {
        var actual = new Class1().Permutation_000(a, b);
        Assert.AreEqual(expected, actual);
    }

    [TestCase("abc", "bca", true)]
    [TestCase("abc", "bcac", false)]
    public void Test_001(string a, string b, bool expected)
    {
        var actual = new Class1().Permutation_001(a, b);
        Assert.AreEqual(expected, actual);
    }
}