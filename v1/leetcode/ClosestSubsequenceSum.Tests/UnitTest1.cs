namespace ClosestSubsequenceSum.Tests;

public class Tests
{
    [TestCase(new[] { 5, -7, 3, 5 }, 6, 0)]
    [TestCase(new[] { 5, 3, -7, 5 }, 6, 0)]
    [TestCase(new[] { 5, 3, 5, -7 }, 6, 0)]
    [TestCase(new[] { 5, 5, 3, -7 }, 6, 0)]
    [TestCase(new[] { 7, -9, 15, -2 }, -5, 1)]
    [TestCase(new[] { 1, 2, 3 }, -7, 7)]
    public void Test1(int[] input, int goal, int expected)
    {
        var actual = new Solution().MinAbsDifference_000(input, goal);
        Assert.That(actual, Is.EqualTo(expected));
    }
}