namespace LargestVariance.Tests;

public class Tests
{
    [TestCase("a", 0)]
    [TestCase("ab", 0)]
    [TestCase("abab", 1)]
    [TestCase("ababb", 2)]
    [TestCase("ababbb", 3)]
    [TestCase("aababbb", 3)]
    [TestCase("abbaaa", 2)]
    public void Test_000(string s, int expected)
    {
        var actual = new Solution().LargestVariance_000(s);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase("a", 0)]
    [TestCase("ab", 0)]
    [TestCase("abab", 1)]
    [TestCase("ababb", 2)]
    [TestCase("ababbb", 3)]
    [TestCase("aababbb", 3)]
    [TestCase("abbaaa", 2)]
    public void Test_001(string s, int expected)
    {
        var actual = new Solution().LargestVariance_001(s);
        Assert.That(actual, Is.EqualTo(expected));
    }
}