namespace ImplementStrStr.Tests;

public class Tests
{
    [TestCase("hello", "ll", 2)]
    public void Test_000(string haystack, string needle, int expected)
    {
        var actual = new Solution().StrStr_000(haystack, needle);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase("hello", "ll", 2)]
    public void Test_001(string haystack, string needle, int expected)
    {
        var actual = new Solution().StrStr_001(haystack, needle);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase("hello", new[] { 0, 0, 0, 0, 0 })]
    [TestCase("aaaaa", new[] { 0, 1, 2, 3, 4 })]
    [TestCase("aabaa", new[] { 0, 1, 0, 1, 2 })]
    [TestCase("aaabaa", new[] { 0, 1, 2, 0, 1, 2 })]
    [TestCase("issipi#mississippi", new[] { 0, 0, 0, 1, 0, 1, 0, 0, 1, 2, 3, 4, 2, 3, 4, 5, 0, 1 })]
    public void Test_Prefixes_000(string needle, int[] expected)
    {
        var actual = Solution.Prefixes_000(needle);
        CollectionAssert.AreEquivalent(expected, actual);
    }

    [TestCase("hello", new[] { 0, 0, 0, 0, 0 })]
    [TestCase("aaaaa", new[] { 0, 1, 2, 3, 4 })]
    [TestCase("aabaa", new[] { 0, 1, 0, 1, 2 })]
    [TestCase("aaabaa", new[] { 0, 1, 2, 0, 1, 2 })]
    [TestCase("issipi#mississippi", new[] { 0, 0, 0, 1, 0, 1, 0, 0, 1, 2, 3, 4, 2, 3, 4, 5, 0, 1 })]
    public void Test_Prefixes_001(string needle, int[] expected)
    {
        var actual = Solution.Prefixes_001(needle);
        CollectionAssert.AreEquivalent(expected, actual);
    }

    [TestCase("hello", new[] { 0, 0, 0, 0, 0 })]
    [TestCase("aaaaa", new[] { 0, 1, 2, 3, 4 })]
    [TestCase("aabaa", new[] { 0, 1, 0, 1, 2 })]
    [TestCase("aaabaa", new[] { 0, 1, 2, 0, 1, 2 })]
    [TestCase("issipi#mississippi", new[] { 0, 0, 0, 1, 0, 1, 0, 0, 1, 2, 3, 4, 2, 3, 4, 5, 0, 1 })]
    public void Test_Prefixes_002(string needle, int[] expected)
    {
        var actual = Solution.Prefixes_002(needle);
        CollectionAssert.AreEquivalent(expected, actual);
    }
}