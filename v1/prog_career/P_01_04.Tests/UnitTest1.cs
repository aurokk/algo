using NUnit.Framework;

namespace P_01_04.Tests;

public class Tests
{
    [TestCase("Tact Coa", true)]
    [TestCase("Tact Coaa", false)]
    public void Test_000(string input, bool expected)
    {
        var actual = new Class1().IsPalindromePermutation_000(input);
        Assert.AreEqual(expected, actual);
    }
}