namespace CountArrayPairsDivisibleByK.Tests;

public class Tests
{
    [TestCase(new[] { 1, 2 }, 2, 1)]
    [TestCase(new[] { 1, 2, 3 }, 2, 2)]
    [TestCase(new[] { 1, 2, 3, 4, 5 }, 2, 7)]
    public void Test_000(int[] input, int k, int expected)
    {
        var actual = new Solution().CountPairs_000(input, k);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase(new[] { 1, 2, 3, 4, 5 }, 2, 7)]
    public void Test_001(int[] input, int k, int expected)
    {
        var actual = new Solution().CountPairs_001(input, k);
        Assert.That(actual, Is.EqualTo(expected));
    }
}