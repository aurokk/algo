using NUnit.Framework;

namespace P_01_05.Tests;

public class Tests
{
    [TestCase("pale", "ple", true)]
    [TestCase("pales", "pale", true)]
    [TestCase("pale", "bale", true)]
    [TestCase("pale", "bake", false)]
    [TestCase("pale", "bakea", false)]
    [TestCase("pale", "palea", true)]
    [TestCase("pale", "paleaa", false)]
    public void Test_000(string a, string b, bool expected)
    {
        var actual = new Class1().DistanceOne_000(a, b);
        Assert.AreEqual(expected, actual);
    }
}