namespace CountEqualAndDivisiblePairsInAnArray.Tests;

public class Tests
{
    [TestCase(new[] { 3, 1, 2, 2, 2, 1, 3 }, 2, 4)]
    public void Test_000(int[] input, int k, int expected)
    {
        var actual = new Solution().CountPairs_000(input, k);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase(new[] { 3, 1, 2, 2, 2, 1, 3 }, 2, 4)]
    public void Test_001(int[] input, int k, int expected)
    {
        var actual = new Solution().CountPairs_001(input, k);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase(0, 1, 1)] // 000 001 => 001
    [TestCase(0, 2, 2)] // 000 010 => 010
    [TestCase(1, 2, 3)] // 001 010 => 011
    [TestCase(1, 3, 3)] // 001 011 => 011
    [TestCase(1, 4, 5)] // 001 100 => 101
    [TestCase(1, 5, 5)] // 001 101 => 101
    [TestCase(1, 6, 7)] // 001 110 => 111
    [TestCase(1, 7, 7)] // 001 110 => 111
    public void Test_002(int a, int b, int expected)
    {
        Assert.That(a | b, Is.EqualTo(expected));
    }

    [TestCase(0, 1, 1)]
    [TestCase(0, 2, 2)]
    [TestCase(0, 3, 3)]
    [TestCase(1, 3, 1)]
    [TestCase(2, 3, 1)]
    [TestCase(3, 3, 3)]
    [TestCase(3, 5, 1)]
    [TestCase(3, 6, 3)]
    public void Test_003(int a, int b, int expected)
    {
        var actual = Solution.GCD(a, b);
        Assert.That(actual, Is.EqualTo(expected));
    }
}