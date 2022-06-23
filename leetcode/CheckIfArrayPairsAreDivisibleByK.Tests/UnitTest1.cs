namespace CheckIfArrayPairsAreDivisibleByK.Tests;

public class Tests
{
    [TestCase(new[] { 1, 2, 3, 4, 5, 10, 6, 7, 8, 9 }, 5, true)]
    [TestCase(new[] { 1, 2, 3, 4, 5, 6 }, 7, true)]
    [TestCase(new[] { 1, 2, 3, 4, 5, 6 }, 10, false)]
    public void Test_000(int[] input, int k, bool expected)
    {
        var actual = new Solution().CanArrange(input, k);
        Assert.That(actual, Is.EqualTo(expected));
    }
}