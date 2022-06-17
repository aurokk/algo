namespace MinimumNumberOfIncrementsOnSubarraysToFormATargetArray.Tests;

public class Tests
{
    [TestCase(new[] { 1, 2, 3 }, 3)]
    [TestCase(new[] { 1, 2, 3, 2, 1 }, 3)]
    [TestCase(new[] { 1, 2, 3, 2, 1, 2 }, 4)]
    public void Test_000(int[] target, int expected)
    {
        var actual = new Solution().MinNumberOperations_000(target);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase(new[] { 1, 2, 3 }, 3)]
    [TestCase(new[] { 1, 2, 3, 2, 1 }, 3)]
    [TestCase(new[] { 1, 2, 3, 2, 1, 2 }, 4)]
    [TestCase(new[] { 1, 2, 3, 2, 1, 2, 3, 4, 8}, 10)]
    public void Test_001(int[] target, int expected)
    {
        var actual = new Solution().MinNumberOperations_001(target);
        Assert.That(actual, Is.EqualTo(expected));
    }
}