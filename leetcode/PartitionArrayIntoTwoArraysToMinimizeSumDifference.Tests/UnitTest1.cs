namespace PartitionArrayIntoTwoArraysToMinimizeSumDifference.Tests;

public class Tests
{
    [TestCase(new[] { 3, 9, 7, 3 }, 2)]
    [TestCase(new[] { -36, 36 }, 72)]
    [TestCase(new[] { 2, -1, 0, 4, -2, -9 }, 0)]
    public void Test_000(int[] input, int expected)
    {
        var actual = new Solution().MinimumDifference(input);
        Assert.That(actual, Is.EqualTo(expected));
    }
}