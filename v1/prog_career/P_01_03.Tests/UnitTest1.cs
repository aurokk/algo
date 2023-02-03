using NUnit.Framework;

namespace P_01_03.Tests;

public class Tests
{
    [TestCase(" ", "%20")]
    [TestCase("Mr John Smith", "Mr%20John%20Smith")]
    public void Test_000(string a, string expected)
    {
        var actual = new Class1().ReplaceSpaces(a);
        Assert.AreEqual(expected, actual);
    }
}